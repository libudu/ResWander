﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    imgUrlList.Add(url);
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
                    Console.WriteLine(imgUrl);
                    imgUrls.Add(imgUrl);
                }
            }
            return imgUrls;
        }
    }
}