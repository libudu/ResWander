using ResWander.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.IO;
using System.Drawing;

namespace ResWander.Service
{
    public class CrawlerService
    {
        public static event Action<int, string, string, string, long, string> DownloadedImag;
        public static event Action ImgPreview;
        public static bool flag { get; set; }
        public static ResWanderForm form { get; set; }
        //单线程，单个网页爬取
        public static bool StartCrawl(Project project/*, CrawlerService crawler*/)
        {
            //存储网页url
            List<string> urls=new List<string>();
            //存储图片ul
            List<string> imgUrls=new List<string>();
            ///初始化爬虫
            InitCrawl(project);
            //如果是贴吧网址则使用爬取贴吧图片的策略
            if (TiebaHTMLService.isTiebaSite(project.ImgInputData.Url))
            {
                TibaCrawl(project,out urls,out imgUrls);
            }
            //如果是百度图片网址则使用爬取贴吧图片的策略
            else if (BaiduHTMLService.IsBaiduImgUrl(project.ImgInputData.Url))
            {
                CrawlBaiduImg(project.ImgInputData.Url, out imgUrls);
            }
            // 如果是微博网址则使用爬取微博图片的策略
            else if (WeiboHTMLService.IsWeiboUrl(project.ImgInputData.Url))
            {
                //微博
                CrawlWeiboImg(project.ImgInputData.Url, out imgUrls);
            }
            //如果是其他网址则使用爬取贴吧图片的策略
            else
            {
                DefaultCrawl(project,out urls,out imgUrls);
            }

            foreach (string item in imgUrls)
            {
                if (true/*一些筛选条件*/)
                {
                    project.URLData.ImgUrls.Enqueue(item);
                }
            }
            ThreadCrawlDownload(project/*, urls, imgUrls)*/);
            return true;
        }

        /// <summary>
        /// 对爬虫的进行初始化，主要处理爬虫的输入
        /// </summary>
        public static void InitCrawl(Project project)
        {
            //输入处理
            InputService.AdjustUrl(project.ImgInputData);
            //if (InputService.GetWebStatusCode(project.ImgInputData) != "200")
            //{
            //    return false;//无效起始网页
            //}
        }

        public static void TibaCrawl(Project project,out List<string> urls,out List<string> imgUrls)
        {
            //解析网页url
            urls = TiebaHTMLService.TiebaParse(project.ImgInputData.Url);
            //存储图片url
            imgUrls = new List<string>();
            foreach (string item in urls)
            {
                //生成一个0-1000内的随机数
                int waitTime = new Random().Next(0, 1000);
                //为防止网站的反爬机制，等待一个随机时间
                Thread.Sleep(waitTime);
                List<string> onePageImgUrl;
                project.URLData.HTMLUrls.Enqueue(item);
                //解析出该网页上的图片资源
                string htmlcode = TiebaHTMLService.DownloadUrl(item);
                onePageImgUrl = TiebaImgParse.GetImgUrls(htmlcode);
                foreach (string imgurl in onePageImgUrl)
                {
                    if (true/*一些筛选条件*/)
                    {
                        imgUrls.Add(imgurl);
                    }
                }
            }
            ////使用并行方式提高爬取速度
            //ArrayList imgUrls = ArrayList.Synchronized(new ArrayList());
            //Parallel.ForEach(urls, url => {
            //    string htmlCode = TiebaHTMLService.DownloadUrl(url);
            //    List<string> onePageImgUrls = TiebaHTMLService.Parse(htmlCode);
            //    foreach(string imgurl in onePageImgUrls)
            //    {
            //        imgUrls.Add(imgUrls);
            //    }
            //});
        }
        public static void CrawlBaiduImg(string BaiduImgUrl, out List<string> imgUrls)
        {
            var HtmlCode = HTMLService.DownloadUrl(BaiduImgUrl);
            string pattern = @"""objURL"":""(?<url>.*?)""";
            imgUrls = new List<string>();
            foreach (Match match in Regex.Matches(HtmlCode, pattern))
            {
                imgUrls.Add(match.Groups["url"].Value);
            }

        }
        public static void DefaultCrawl(Project project, out List<string> urls, out List<string> imgUrls)
        {
            //下载当前url网页的html代码并保存
            project.HTMLData.HTMLCodes.Enqueue(HTMLService.DownloadUrl(project.ImgInputData.Url));
            string htmlcode = project.HTMLData.HTMLCodes.Dequeue();
            //解析出该网页链接到下一个网页的url
            urls = HTMLService.Parse(htmlcode);
            foreach (string item in urls)
            {
                if (true/*一些筛选条件*/)
                {
                    project.URLData.HTMLUrls.Enqueue(item);
                }
            }
            //解析出该网页上的图片资源
            imgUrls = ImgParseService.Parse(htmlcode);
        }
        public static void CrawlDownload(Project project, List<string> urls, List<string> imgUrls)
        {
            //开始下载图片资源
            string imgUrl = project.URLData.ImgUrls.Dequeue();
            while (imgUrl != null)
            {
                ImgResource img = new ImgResource(DownloadService.DownloadImg(imgUrl), imgUrl);
                if (img != null)
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    project.ImgResourcesContainer.RowImages.Add(img);
                    watch.Stop();
                    img.DownloadTime = watch.ElapsedMilliseconds;
                    if (img.Img != null)
                    {
                        img.State = "Successful";
                    }
                    else
                    {
                        img.State = "Fail";
                    }
                    img.ResourceNumber = project.ImgResourcesContainer.RowImages.IndexOf(img) + 1;
                    string format;
                    ImageService.GetImageFormat(img.Img, out format);
                    img.PhotoFormat = format;
                    img.ResourceName = "待定，测试";
                }
                imgUrl = project.URLData.ImgUrls.Count > 0 ? project.URLData.ImgUrls.Dequeue() : null;
                //此处可添加事件，与前端互动
                CrawlerService.DownloadedImag(img.ResourceNumber, img.Url, img.PhotoFormat, img.ResourceName, img.DownloadTime, img.State);

            }
        }
        public static void ThreadCrawlDownload(Project project)
        {
            flag= false;
            List<Thread> Threads = new List<Thread>();
            int count = project.URLData.ImgUrls.Count();
            //开始下载图片资源
            int finish = 0;
            string imgUrl = project.URLData.ImgUrls.Dequeue();
            while (finish<count)
            {
                if (flag)
                {
                    //foreach (Thread item in Threads)
                    //{
                    //    item.Abort();
                    //}
                    while (finish != Threads.Count) { }
                    break;
                }
                Thread thread = new Thread(() =>
                  {
                      ImgResource img = new ImgResource(DownloadService.DownloadImg(imgUrl), imgUrl);
                      if (img != null)
                      {
                          Stopwatch watch = new Stopwatch();
                          watch.Start();
                          project.ImgResourcesContainer.RowImages.Add(img);
                          watch.Stop();
                          img.DownloadTime = watch.ElapsedMilliseconds;
                          if (img.Img != null)
                          {
                              img.State = "Successful";
                          }
                          else
                          {
                              img.State = "Fail";
                          }
                          img.ResourceNumber = project.ImgResourcesContainer.RowImages.IndexOf(img) + 1;
                          string format;
                          ImageService.GetImageFormat(img.Img, out format);
                          img.PhotoFormat = format;
                          img.ResourceName = "待定，测试";
                          imgUrl = project.URLData.ImgUrls.Count > 0 ? project.URLData.ImgUrls.Dequeue() : null;
                          //此处可添加事件，与前端互动
                          CrawlerService.DownloadedImag(img.ResourceNumber, img.Url, img.PhotoFormat, img.ResourceName, img.DownloadTime, img.State);       
                          CrawlerService.ImgPreview();
                          finish++;
                          
                  }
                  });
                Threads.Add(thread);
                thread.Start();
                Thread.Sleep(200);
            }
        }
        /// <summary>
        /// 对微博上图片爬取的封装
        /// </summary>
        /// <param name="weiboImgUrl">待爬取的微博url</param>
        /// <param name="imgUrls">爬取出来的url列表，已全部转换为绝对地址</param>
        public static void CrawlWeiboImg(string weiboImgUrl, out List<string> imgUrls)
        {
            string htmlCode = WeiboHTMLService.DownloadUrl(weiboImgUrl);
            imgUrls = WeiboImgParse.GetImgUrls(htmlCode);
        }


        public static List<string> ImgSearchImg(string ImgPath)
        {
            var APP_ID = "20408952";
            var API_KEY = "oGP41zYCvdWBzFkyz1xBfUXT";
            var SECRET_KEY = "CwM4KCyzngkTCQAd2aIy08LYtPgPaDL8";

            var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
            client.Timeout = 6000;  // 修改超时时间

            var image = File.ReadAllBytes(ImgPath);
            // 调用通用物体识别，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.AdvancedGeneral(image)["result"];
            List<string> ImgKeywordList = new List<string>();
            foreach(var i in result)
            {
                ImgKeywordList.Add(i["keyword"].ToString());
            }
            return ImgKeywordList;
        }

        /// <summary>
        /// 根据关键字到百度搜索里查找图片
        /// 输入一个关键字，返回url
        /// </summary>
        public static string SearchKeyword(string keyword)
        {
            //若关键字中含有特殊字符，则将其转义
            keyword = TransferKeyword(keyword);

            //搜索关键字实际上就是生成一个搜索的网址
            string url = $"https://image.baidu.com/search/index?tn=baiduimage&word={keyword}";

            return url;
        }

        private static string TransferKeyword(string keyword)
        {
            //关键字中若有特定字符则需要转义
            keyword = keyword.Replace(" ", "%20");
            keyword = keyword.Replace("/", "%2F");
            keyword = keyword.Replace("?", "%3F");
            keyword = keyword.Replace("#", "%23");
            keyword = keyword.Replace("&", "%26");
            keyword = keyword.Replace("=", "%3D");
            //返回转义之后的关键字字符序列
            return keyword;
        }
    }
}
