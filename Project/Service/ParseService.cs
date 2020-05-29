using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ResWander.Service
{
    /// <summary>
    /// 对下载完毕的html代码进行解析的父类
    /// </summary>
    public abstract class ParseService
    {
        /// <summary>
        /// 对一个html代码进行解析：根据条件筛选一些超链接
        /// </summary>
        /// <param name="htmlCode">html源代码</param>
        /// <returns>返回一组url</returns>
        public abstract List<string> Parse(string htmlCode);
    }

    /// <summary>
    /// 找出一个html代码中的链接到另一个网页的url
    /// </summary>
    public class HTMLParseService : ParseService
    {
        //使用HtmlAgility类实现html代码的解析
        public override List<string> Parse(string htmlCode)
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

    /// <summary>
    /// 找出一个html代码中的图片url
    /// </summary>
    public class ImgParseService : ParseService
    {
        public override List<string> Parse(string htmlCode)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlCode);
            //获取网页链接：寻找a标签下的href属性
            HtmlNodeCollection imgList = htmlDocument.DocumentNode.SelectNodes(".//img[@src]");
            List<string> imgUrlList = new List<string>();
            if (imgUrlList != null)
            {
                foreach (HtmlNode img in imgList)
                {
                    //获得网页url
                    string url = img.Attributes["src"].Value;

                    //根据初始条件筛选url
                    //......
                    imgUrlList.Add(url);
                }
            }
            return imgUrlList;
        }
    }
}