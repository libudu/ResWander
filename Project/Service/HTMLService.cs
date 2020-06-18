using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        /// <summary>
        /// 传入原始网址，下载网页的源码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
        private static int maxPage = int.MaxValue;
        /// <summary>
        /// 设置最大爬取深度
        /// </summary>
        private static int MaxPage { get; set; }
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

        /// <summary>
        /// 百度贴吧获取一个帖子的所有网址（页数不超过最大页数）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
            pagesCount = pagesCount > MaxPage ? MaxPage : pagesCount;
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

    /// <summary>
    /// 获取微博的html源代码的相关服务
    /// </summary>
    public class WeiboHTMLService
    {
        // 动态获取cookie时想服务器端发送的字符串
        private static string cbString;
        private static string fpString;
        private static string a;
        private static string cb;
        private static string from;
        private static string url;
        private static string cookieSavePath; // 用于保存序列化的cookie使用的路径
        private static WeiboCookie userCookie; // 用户访问微博的cookie

        [Serializable]
        private class WeiboCookie
        {
            public string Sub { get; set; }

            public string Subp { get; set; }

            /// <summary>
            /// 初始化微博cookie的构造函数
            /// </summary>
            /// <param name="sub">sub参数</param>
            /// <param name="subp">subp参数</param>
            public WeiboCookie(string sub, string subp)
            {
                this.Sub = sub;
                this.Subp = subp;
            }

            /// <summary>
            /// 无参构造函数，用于序列化
            /// </summary>
            public WeiboCookie()
            {

            }
        }

        /// <summary>
        /// 静态构造器，初始化发送请求时的字符串
        /// </summary>
        static WeiboHTMLService()
        {
            WeiboHTMLService.cbString = "gen_callback";
            WeiboHTMLService.fpString = "{\"os\":\"1\",\"browser\":\"Chrome70,0,3538,25\"," +
                "\"fonts\":\"undefined\",\"screenInfo\":\"1920 * 1080 * 24\",\"plugins\":\"Portable Document" +
                " Format::internal-pdf-viewer::Chromium PDF " +
                "Plugin|::mhjfbmdgcfjbbpaeojofohoefgiehjai::Chromium PDF" +
                " Viewer|::gbkeegbaiigmenfmjfclcdgdpimamgkj::Google文档、" +
                "表格及幻灯片的Office编辑扩展程序|::internal-nacl-plugin::Native Client\"}";
            WeiboHTMLService.a = "incarnate";
            WeiboHTMLService.cb = "cross_domain";
            WeiboHTMLService.from = "weibo";
            WeiboHTMLService.cookieSavePath = "weibo.ck";
        }

        /// <summary>
        /// 是否是微博的网址
        /// </summary>
        /// <param name="url">待判断的url</param>
        /// <returns>返回是否是微博url</returns>
        public static bool IsWeiboUrl(string url)
        {
            return Regex.IsMatch(url, @"(weibo.com|weibo.cn)");
        }

        /// <summary>
        /// 输入微博的网址，下载微博的网页源代码
        /// </summary>
        /// <param name="url">待爬取的微博网页</param>
        /// <returns>网页源码</returns>
        public static string DownloadUrl(string url)
        {
            // 将weibo.cn替换为weibo.com
            url = url.Replace(".cn", ".com");
            WeiboHTMLService.url = url;
            CookieContainer container = new CookieContainer();
            string htmlCode; // 爬取到的html网页

            // 判断是否已经获取过cookie
            if (File.Exists(WeiboHTMLService.cookieSavePath))
            {
                // 如果之前已经获取过cookie，则尝试使用以前的cookie
                using(FileStream reader = new FileStream(WeiboHTMLService.cookieSavePath, FileMode.Open))
                {
                    BinaryFormatter deSerializer = new BinaryFormatter();
                    WeiboHTMLService.userCookie = deSerializer.Deserialize(reader) 
                        as WeiboHTMLService.WeiboCookie;
                }

                container.Add(new Cookie("sub", WeiboHTMLService.userCookie.Sub, "/", ".weibo.com"));
                container.Add(new Cookie("subp", WeiboHTMLService.userCookie.Subp, "/", ".weibo.com"));

                if(WeiboHTMLService.TryDownloadHtml(container, out htmlCode))
                {
                    // 如果原有cookie使用成功，则直接返回htmlcode否则还需要重新动态获取cookie
                    return htmlCode;
                }
            }

            // 如果不存在已有cookie，则动态获取cookie
            string[] dynamicParams = WeiboHTMLService.GetParams(); // 获取三个动态参数
            container = WeiboHTMLService.GetCookie(dynamicParams); // 获取cookie

            if(WeiboHTMLService.TryDownloadHtml(container, out htmlCode))
            {
                return htmlCode;
            }
            else
            {
                throw new CustomException(CustomExceptionValues.ExceptionEnum.WEIBO_HTML_FAILED);
            }
        }

        /// <summary>
        /// 动态获取三个字符换参数，用于cookie动态获取
        /// </summary>
        /// <returns>三个动态参数，分别是：tid，w，c</returns>
        private static string[] GetParams()
        {
            int attempCount = 0;
            while (attempCount < 10)
            {
                // 将需要传递的参数与目标url拼接，以查询参数的形式传递给服务器
                string visitorUrl = "https://passport.weibo.com/visitor/genvisitor";
                string targetUrl = visitorUrl + "?" + "cb=" + WeiboHTMLService.cbString +
                    "&" + "fp =" + WeiboHTMLService.fpString;

                // 获取参数信息
                HttpWebRequest request = WebRequest.CreateHttp(targetUrl);
                request.Method = "POST";

                string tid;
                string w;
                string c;
                using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    string resultString = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(resultString))
                    {
                        // 资源获取失败
                        throw new CustomException(CustomExceptionValues.ExceptionEnum.WEIBO_HTML_FAILED);
                    }

                    // 获取tid,c,w
                    string patternTid = @"(?<targetInfo>""tid"":""(?<tidMatch>[^""]+)\S*""new_tid"":(?<new_tidMatch>[^},]+))"; // 用于给tid和c赋值
                    string patternConfidence = @"""confidence"":(?<confidenceMatch>[^},]+)"; // 用于给w赋值
                    string flag; // 用于接收new_tid
                    Match match = Regex.Match(resultString, patternTid);

                    // tid
                    tid = match.Groups["tidMatch"].Value;

                    // c
                    flag = match.Groups["new_tidMatch"].Value;
                    if (Convert.ToBoolean(flag))
                    {
                        w = "3";
                    }
                    else
                    {
                        w = "2";
                    }

                    // w
                    if (Regex.IsMatch(resultString, patternConfidence))
                    {
                        c = Regex.Match(resultString, patternConfidence).Groups["confidenceMatch"].Value;
                    }
                    else
                    {
                        c = "100";
                    }
                }

                // 返回信息
                string[] dynamicParams = new string[3];
                dynamicParams[0] = tid;
                dynamicParams[1] = w;
                dynamicParams[2] = c;

                if (!Regex.IsMatch(tid, @"[+\\/]"))
                {
                    // 如果没有+，/,\则该tid有效，否则需要重新获取
                    return dynamicParams;
                }
                else
                {
                    // 否则等待0.2s，继续获取tid
                    Thread.Sleep(200);
                    continue;
                }
            }

            //TODO 以事件的方式提示用户爬取的进度
            throw new CustomException(CustomExceptionValues.ExceptionEnum.WEIBO_HTML_FAILED);
        }

        /// <summary>
        /// 传入动态获取的三个参数，以动态获取cookie
        /// </summary>
        /// <param name="dynamicParams">包含三个string，分别为t，w，c</param>
        /// <returns>返回cookie中的name和value的键值对</returns>
        private static CookieContainer GetCookie(string[] dynamicParams)
        {
            // 之前动态获取的参数
            string t = dynamicParams[0];
            string w = dynamicParams[1];
            string c = dynamicParams[2];

            // 在目标网址添加查询参数
            string destUrl = "https://passport.weibo.com/visitor/visitor";
            string targetUrl = destUrl + $"?a={a}&t={t}&w={w}&c={c}&cb={cb}&from={from}";

            // 新建http请求
            HttpWebRequest request = WebRequest.CreateHttp(targetUrl);
            request.Method = "GET";

            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string resultString = reader.ReadToEnd();
                if (string.IsNullOrEmpty(resultString))
                {
                    throw new CustomException(CustomExceptionValues.ExceptionEnum.WEIBO_HTML_FAILED);
                }

                // 利用正则表达式，获取sub，subp的值
                string pattern = @"(?<targetInfo>""sub"":""(?<sub>[^""]+)\S+""subp"":""(?<subp>[^""]+))";
                Match match = Regex.Match(resultString, pattern);

                // sub,subp获取
                WeiboHTMLService.userCookie = new WeiboCookie(match.Groups["sub"].Value,
                    match.Groups["subp"].Value);

                // 通过序列化写入文件
                WeiboHTMLService.RecordCookie();
            }

            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("SUB", WeiboHTMLService.userCookie.Sub, "/", ".weibo.com"));
            cookieContainer.Add(new Cookie("SUBP", WeiboHTMLService.userCookie.Subp, "/", ".weibo.com"));

            return cookieContainer;
        }

        /// <summary>
        /// 将cookie以序列化的方式写入文件
        /// </summary>
        private static void RecordCookie()
        {
            using (FileStream writeStream = new FileStream(WeiboHTMLService.cookieSavePath, FileMode.Create))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                if (WeiboHTMLService.userCookie == null)
                {
                    return;
                }
                else
                {
                    serializer.Serialize(writeStream, WeiboHTMLService.userCookie);
                }
            }
        }

        private static bool TryDownloadHtml(CookieContainer container, out string htmlCode)
        {
            HttpWebRequest request = WebRequest.CreateHttp(WeiboHTMLService.url);
            request.Method = "GET";
            request.CookieContainer = container;
            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                htmlCode = reader.ReadToEnd();
            }
            
            // 判断是否识别成功，并返回判断值
            if(Regex.IsMatch(htmlCode, "Sina Visitor System"))
            {
                // 如果爬取失败，则会返回新浪访客系统
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
