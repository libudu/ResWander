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

namespace ResWander.Service
{
    public class CrawlerService
    {
        public event Action<int, string, string, string, long, string> DownloadedImag;
        //单线程，单个网页爬取
        public static bool StartCrawl(Project project, CrawlerService crawler)
        {
            //输入处理
            InputService.AdjustUrl(project.ImgInputData);
            //if (InputService.GetWebStatusCode(project.ImgInputData) != "200")
            //{
            //    return false;//无效起始网页
            //}

            //存储网页url
            List<string> urls;

            //存储图片ul
            List<string> imgUrls = new List<string>();
            //如果是贴吧网址则使用爬取贴吧图片的策略
            if (TiebaHTMLService.isTiebaSite(project.ImgInputData.Url))
            {
                //解析网页url
                urls = TiebaHTMLService.TiebaParse(project.ImgInputData.Url);
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
            else
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

            foreach (string item in imgUrls)
            {
                if (true/*一些筛选条件*/)
                {
                    project.URLData.ImgUrls.Enqueue(item);
                }
            }
            //开始下载图片资源
            string imgUrl = project.URLData.ImgUrls.Dequeue();
            while (imgUrl != null)
            {
                ImgResource img = new ImgResource(DownloadService.DownloadImg(imgUrl), imgUrl);
                if(img != null)
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
                    img.ResourceNumber = project.ImgResourcesContainer.RowImages.IndexOf(img) + 1;
                    string format;
                    ImageService.GetImageFormat(img.Img,out format);
                    img.PhotoFormat = format;
                    img.ResourceName = "待定，测试";
                }
                imgUrl = project.URLData.ImgUrls.Count > 0 ?  project.URLData.ImgUrls.Dequeue() : null;
                //此处可添加事件，与前端互动
                crawler.DownloadedImag(img.ResourceNumber, img.Url, img.PhotoFormat, img.ResourceName, img.DownloadTime, img.State);
            }
            return true;
        }

        public static List<string> CrawlBaiduImg(string BaiduImgUrl)
        {
            var HtmlCode = HTMLService.DownloadUrl(BaiduImgUrl);
            string pattern = @"{""thumbURL"":""(?<url>.*?)""";
            List<string> UrlList = new List<string>();
            foreach (Match match in Regex.Matches(HtmlCode, pattern))
            {
                UrlList.Add(match.Groups["url"].Value);
            }
            return UrlList;
        }
    }
}
