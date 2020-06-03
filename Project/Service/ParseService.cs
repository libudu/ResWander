using System;
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
                    string url = img.Attributes["src"].Value;
                    if (!url.Contains("/"))
                    {
                        continue;
                    }
                    //将相对地址转换成绝对地址
                    url = HTMLService.TransferUrl(url);
                    imgUrlList.Add(url);
                }
            }
            return imgUrlList;
        }
    }
}