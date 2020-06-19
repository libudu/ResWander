using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ResWander.Service
{
    ///// <summary>
    ///// 对下载完毕的html代码进行解析资源的父类
    ///// </summary>
    //public abstract class ParseService
    //{
    //    /// <summary>
    //    /// 对一个html代码进行解析：根据条件筛选一些资源url
    //    /// </summary>
    //    /// <param name="htmlCode">html源代码</param>
    //    /// <returns>返回一组url</returns>
    //    public abstract List<string> Parse(string htmlCode);
    //}

    /// <summary>
    /// 找出一个html代码中的图片url
    /// </summary>
    public class ImgParseService /*: ParseService*/
    {
        public static /*override*/ List<string> Parse(string htmlCode)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlCode);
            //获取网页链接：寻找img标签
            HtmlNodeCollection imgList = htmlDocument.DocumentNode.SelectNodes(".//img[@src]");
            List<string> imgUrlList = new List<string>();
            if (imgUrlList != null)
            {
                foreach (HtmlNode img in imgList)
                {
                    //获得网页url
                    string url;
                    //懒加载情况下，真正的url存储在data-src里
                    if (img.Attributes["data-src"] != null)
                    {
                        url = img.Attributes["data-src"].Value;
                    }
                    else
                    {
                        url = img.Attributes["src"].Value;
                    }
                    //svg格式的图标暂不支持下载
                    if (!url.Contains("/") || url.Contains("svg"))
                    {
                        continue;
                    }
                    //将相对地址转换成绝对地址
                    url = HTMLService.TransferUrl(url);
                    //字符转义
                    url = HTMLService.ReplaceChar(url);
                    if(!imgUrlList.Contains(url))
                    {
                        imgUrlList.Add(url);
                    }
                }
            }
            return imgUrlList;
        }
    }

    /// <summary>
    /// 找出百度贴吧中源代码中的图片url
    /// </summary>
    public class TiebaImgParse
    {
        public static List<string> GetImgUrls(string htmlCode)
        {
            List<string> imgUrls = new List<string>();
            //使用HtmlAgility类实现html代码的解析
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlCode);
            //百度贴吧源代码将正文放在cc标签下
            HtmlNodeCollection contentLists = htmlDocument.DocumentNode.SelectNodes(".//cc");
            //没找到正文标签
            if (contentLists == null)
            {
                return null;
            }
            foreach (HtmlNode content in contentLists)
            {
                //从正文中找到img标签集合
                HtmlNodeCollection imgList = content.SelectNodes(".//img[@src]");
                //该正文中没有图片
                if (imgList == null)
                {
                    continue;
                }
                foreach (HtmlNode img in imgList)
                {
                    string imgUrl = img.Attributes["src"].Value;
                    //若已经爬取了该图片，则不必重复爬取
                    if (imgUrls.Contains(imgUrl))
                    {
                        continue;
                    }

                    //过滤掉一些表情图片
                    if(imgUrl.Contains("https://gsp0.baidu.com"))
                    {
                        continue;
                    }

                    //Console.WriteLine(imgUrl);
                    imgUrls.Add(imgUrl);
                }
            }
            return imgUrls;
        }
    }

    /// <summary>
    /// 找出微博源代码中的图片url
    /// </summary>
    public class WeiboImgParse
    {
        /// <summary>
        /// 找到微博html源代码中的图片url，并以绝对地址的形式返回
        /// </summary>
        /// <param name="htmlCode">微博html源代码</param>
        /// <returns>所有的图片url</returns>
        public static List<string> GetImgUrls(string htmlCode)
        {
            // 用于识别图片url的正则表达式
            string imgPattern = @"(?<imgNode><[\s\t\r\n]*img[^>]*src[\s\t\r\n]*=[\s\t\r\n]*[\\]*""(?<imgSrc>[^""?]+)[^>]*)";
            var matches = Regex.Matches(htmlCode, imgPattern);

            // 获取绝对地址网址
            List<string> imgUrls = new List<string>();
            string imgUrl;
            foreach(Match matchUrl in matches)
            {
                // 将表情符号过滤
                if(Regex.IsMatch(matchUrl.Value, @"W_img_face") ||
                    Regex.IsMatch(matchUrl.Value, @"feed_icon"))
                {
                    continue;
                }

                // 将多余的头像过滤
                if (Regex.IsMatch(matchUrl.Value, @"W_face_radius"))
                {
                    continue;
                }

                // svg图片无法下载
                if (Regex.IsMatch(matchUrl.Value, @".svg"))
                {
                    continue;
                }

                // 过滤其他用户的头像（关注、粉丝），留下博主的头像
                if ((matchUrl.Value.Contains("crop.") && !Regex.IsMatch(matchUrl.Value,@"class[\s\t\r\n]*=[\s\t\r\n]*""photo"""))
                    || matchUrl.Value.Contains("default_avatar"))
                {
                    continue;
                }

                // 过滤默认音乐图片
                if (matchUrl.Value.Contains("square.180"))
                {
                    continue;
                }

                // 过滤无法下载的错误图片
                if (matchUrl.Value.Contains("beacon.sina"))
                {
                    continue;
                }

                imgUrl = matchUrl.Groups["imgSrc"].Value.Replace("orj360","mw690"); // 将缩略图换成高清大图
                string absoluteUrl;
                if (WeiboImgParse.RelativeToAbsolute(imgUrl, out absoluteUrl))
                {
                    imgUrls.Add(absoluteUrl);
                }
            }

            return imgUrls;
        }

        /// <summary>
        /// 用于将微博爬取的url相对地址转为绝对地址
        /// </summary>
        /// <param name="relativeUrl">直接爬取的weibourl</param>
        /// <param name="absoluteUrl">转换为绝对地址的结果</param>
        /// <returns>是否转换成功</returns>
        private static bool RelativeToAbsolute(string relativeUrl, out string absoluteUrl)
        {
            relativeUrl = relativeUrl.Replace(@"\/", "/");

            if (relativeUrl.EndsWith("\\"))
            {
                relativeUrl = relativeUrl.Substring(0, relativeUrl.Length - 1);
            }

            if(Regex.IsMatch(relativeUrl, @"http[s]*://"))
            {
                absoluteUrl = relativeUrl;
                return true;
            }
            else if(Regex.IsMatch(relativeUrl, @"//"))
            {
                absoluteUrl = "https:" + relativeUrl;
                return true;
            }
            else
            {
                absoluteUrl = null;
                return false;
            }
        }
    }
}