using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public abstract string[] Parse(string htmlCode);
    }

    /// <summary>
    /// 找出一个html代码中的链接到另一个网页的url
    /// </summary>
    public class HTMLParseService : ParseService
    {
        //TODO:正则表达式
        public string HTMLRegex { get; set; }
        public override string[] Parse(string htmlCode)
        {
            return null;
        }
    }

    /// <summary>
    /// 找出一个html代码中的图片url
    /// </summary>
    public class ImgParseService : ParseService
    {
        public string ImgRegex { get; set; }
        public override string[] Parse(string htmlCode)
        {
            return null;
        }
    }
}
