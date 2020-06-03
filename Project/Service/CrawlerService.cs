using ResWander.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ResWander.Service
{
    public class CrawlerService
    {
        //单线程，单个网页爬取
        public static bool StartCrawl(Project project)
        {
            //输入处理
            InputService.AdjustUrl(project.ImgInputData);
            if (InputService.GetWebStatusCode(project.ImgInputData) != "200")
            {
                return false;//无效起始网页
            }
            //下载当前url网页的html代码并保存
            project.HTMLData.HTMLCodes.Enqueue(HTMLService.DownloadUrl(project.ImgInputData.Url));
            string htmlcode = project.HTMLData.HTMLCodes.Dequeue();
            //解析出该网页链接到下一个网页的url
            List<string> urls = HTMLService.Parse(htmlcode);
            foreach (string item in urls)
            {
                if (true/*一些筛选条件*/)
                {
                    project.URLData.HTMLUrls.Enqueue(item);
                }
            }
            //解析出该网页上的图片资源
            List<string> imgUrls = ImgParseService.Parse(htmlcode);
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
                project.ImgResourcesContainer.RowImages.Add(img);
                imgUrl = project.URLData.ImgUrls.Dequeue();
                //此处可添加事件，与前端互动
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
