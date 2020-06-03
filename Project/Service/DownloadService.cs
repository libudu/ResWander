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
    /// 从指定网址下载资源文件
    /// </summary>
    public class DownloadService
    {
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Image DownloadImg(string url)
        {
            //下载图片
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            return Image.FromStream(response.GetResponseStream());
        }
    }
}
