using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    /// <summary>
    /// 从指定网址下载html代码
    /// </summary>
    public class DownloadService
    {
        /// <summary>
        /// 从指定网址下载html代码
        /// </summary>
        /// <param name="url">所指定的网址</param>
        /// <returns>下载完毕的html源代码</returns>
        public string DownloadUrl(string url)
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
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Image DownloadImg(string url)
        {
            //下载图片
            return null;
        }
    }
}
