using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    /// <summary>
    /// 对HTML进行下载、解析操作
    /// </summary>
    public class HTMLService
    {
        /// <summary>
        /// 从指定网址下载html代码
        /// </summary>
        /// <param name="url">所指定的网址</param>
        /// <returns>下载完毕的html源代码</returns>
        public static string DownloadUrl(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                //将该网址的源html代码下载返回
                string html = webClient.DownloadString(url);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 找出一个html代码中的链接到另一个网页的url
        /// </summary>
        public static List<string> HTMLParse(string htmlCode)
        {
            //使用HtmlAgility类实现html代码的解析
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlCode);
            //获取网页链接：寻找a标签下的href属性
            HtmlNodeCollection hrefList = htmlDocument.DocumentNode.SelectNodes(".//a[@href]");
            List<string> hrefUrlList = new List<string>();
            if (hrefList != null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    //获得网页url
                    string url = href.Attributes["href"].Value;

                    //根据初始条件筛选url
                    if (!url.Contains("/"))
                    {
                        continue;
                    }
                    //......
                    hrefUrlList.Add(url);
                }
            }

            return hrefUrlList;
        }
    }
}
