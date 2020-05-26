using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    /// <summary>
    /// 负责筛选资源文件的类的基类
    /// </summary>
    public abstract class FilterService
    {
        /// <summary>
        /// 从一个html文本中筛选各种资源
        /// </summary>
        /// <param name="html">下载得到的html文本</param>
        /// <returns>符合条件的url</returns>
        public abstract string[] FilterAll(string html);
    }

    /// <summary>
    /// 筛选符合条件的网页url
    /// </summary>
    public class HTMLFilterService : FilterService
    {
        /// <summary>
        /// 传入一个url，判断其是否符合条件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool Filter(string url)
        {
            return false;
        }

        /// <summary>
        /// 筛选符合条件的网页url
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public override string[] FilterAll(string html)
        {
            return null;
        }
    }

    /// <summary>
    /// 负责筛选图片资源的url
    /// </summary>
    public class ImgFilterService : FilterService
    {
        /// <summary>
        /// 传入一个图片url，判断其是否符合条件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool Filter(string url)
        {
            return false;
        }

        /// <summary>
        /// 筛选符合条件的图片url
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public override string[] FilterAll(string html)
        {
            return null;
        }
    }
}
