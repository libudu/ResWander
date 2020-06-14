using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

        //html文本与url的一些字符需要转义
        public static string ReplaceChar(string url)
        {
            //&符号
            url = url.Replace("&amp;", "&");
            //'
            url = url.Replace("&apos;", "'");
            //"
            url = url.Replace("&quot;", "\"");
            //>
            url = url.Replace("&gt;", ">");
            //<
            url = url.Replace("&lt;", "<");
            return url;
        }

        //将相对地址转化为绝对地址
        public static string DownloadUrl(string url)
        {
            try
            {
                HttpWebRequest webRequest = WebRequest.CreateHttp(url);
                //持续连接
                webRequest.KeepAlive = false;
                //超时时间为30秒
                webRequest.Timeout = 30 * 1000;
                webRequest.Method = "GET";
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                webRequest.UserAgent = GetUA();
                //webRequest.Proxy = new WebProxy
                //接受返回
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                //WebHeaderCollection headers = response.Headers;
                //string type = headers.Get("Content-Type");
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return null; 
                }
                string html;
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    html = sr.ReadToEnd();
                }
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        //随机获取一个UA
        private static string GetUA()//随机获取userAgent
        {
            string[] userAgents =
            {
              // Opera
             "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.95 Safari/537.36 OPR/26.0.1656.60",
             "Opera/8.0 (Windows NT 5.1; U; en)",
            "Mozilla/5.0 (Windows NT 5.1; U; en; rv:1.8.1) Gecko/20061208 Firefox/2.0.0 Opera 9.50",
            "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.50",
            // Firefox
           "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:34.0) Gecko/20100101 Firefox/34.0",
           "Mozilla/5.0 (X11; U; Linux x86_64; zh-CN; rv:1.9.2.10) Gecko/20100922 Ubuntu/10.10 (maverick) Firefox/3.6.10",
           //Safari
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.57.2 (KHTML, like Gecko) Version/5.1.7 Safari/534.57.2",
           //chrome
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/39.0.2171.71 Safari/537.36",
           "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.64 Safari/537.11",
           "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.16 (KHTML, like Gecko) Chrome/10.0.648.133 Safari/534.16",
           // 360
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36",
           "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko",
           // 淘宝浏览器
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.11 TaoBrowser/2.0 Safari/536.11",
           // 猎豹浏览器
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.71 Safari/537.1 LBBROWSER",
           "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; LBBROWSER)",
           "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 732; .NET4.0C; .NET4.0E; LBBROWSER)",
           // QQ浏览器
           "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; QQBrowser/7.0.3698.400)",
           "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; QQDownload 732; .NET4.0C; .NET4.0E)",
           // sogou浏览器
           "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.84 Safari/535.11 SE 2.X MetaSr 1.0",
           "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; SV1; QQDownload 732; .NET4.0C; .NET4.0E; SE 2.X MetaSr 1.0)",
           // maxthon浏览器
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Maxthon/4.4.3.4000 Chrome/30.0.1599.101 Safari/537.36",
           //UC浏览器
           "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.122 UBrowser/4.0.3214.0 Safari/537.36"
          };
            return userAgents[new Random().Next(0, userAgents.Length)];//随机给予一个代理
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
                    //字符转义
                    url = ReplaceChar(url);
                    //......
                    hrefUrlList.Add(url);
                }
            }
            return hrefUrlList;
        }
    }

    /// <summary>
    /// 百度贴吧使用的HTML解析类
    /// </summary>
    public class TiebaHTMLService:HTMLService
    {
        /// <summary>
        /// 判断一个网页是否是贴吧网页
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool isTiebaSite(string url)
        {
            return url.StartsWith("https://tieba.baidu.com/p");
        }


        //获取该帖的总页数
        private static int GetPagesCount(string url)
        {
            string html = DownloadUrl(url);
            //使用HtmlAgility类实现html代码的解析
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            //要获得该帖子的总页数，可以在一个input标签下获得
            HtmlNodeCollection inputNodes = htmlDocument.DocumentNode.SelectNodes(".//input[@max-page]");
            if (inputNodes == null)
            {
                return 0;
            }
            foreach (HtmlNode inputNode in inputNodes)
            {
                if (inputNode.Attributes["id"].Value == "jumpPage4")
                {
                    return int.Parse(inputNode.Attributes["max-page"].Value);
                }
            }
            return 0;
        }

        public static List<string> TiebaParse(string url)
        {
            //若给出的url中包含?，首先根据url获取原网址
            if (url.Contains("?"))
            {
                Regex orginalUrlRegex = new Regex(@"(?<ORGINALSITE>[^?]+)\?(pn=\d)");
                Match match = orginalUrlRegex.Match(url);
                url = match.Groups["ORGINALSITE"].Value;
            }
            List<string> urlList = new List<string>();
            //获得该帖的页面总数
            int pagesCount = GetPagesCount(url);
            pagesCount = pagesCount > 3 ? 3 : pagesCount;
            for (int i = 1; i <= pagesCount; i++)
            {
                //原网址与?pn=i拼接就形成了该页面的url
                urlList.Add(url + $"?pn={i}");
            }
            return urlList;
        }
    }
    /// <summary>
    /// 百度图片使用的HTML解析类
    /// </summary>
    public class BaiduHTMLService:HTMLService
    {
        /// <summary>
        /// 判断是否为百度图片的网页
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsBaiduImgUrl(string url)
        {
            return url.Contains("//image.baidu.com/search");
        }
    }
}
