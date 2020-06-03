using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
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

        //相对地址转绝对地址
        public static string TransferUrl(string url)
        {
            string OriginUrl = url;
            if (OriginUrl.StartsWith("http://") || OriginUrl.StartsWith("https://"))
            {
                return OriginUrl;
            }
            else
            {
                return "https:" + OriginUrl;
            }
        }

        //将相对地址转化为绝对地址
        public static string DownloadUrl(string url)
        {
            try
            {
                //将该网址的源html代码下载返回
                HttpWebRequest request = WebRequest.CreateHttp(url);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36";
                string html = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        //使用HtmlAgility类实现html代码的解析
        public static List<string> Parse(string htmlCode)
        {
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
                    //将相对地址转换成绝对地址
                    url = TransferUrl(url);
                    //......
                    hrefUrlList.Add(url);
                }
            }
            return hrefUrlList;
        }
    }
}
