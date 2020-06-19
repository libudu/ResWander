using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    /// <summary>
    /// 资源类：包括资源的url和资源
    /// </summary>
    
    public class Resource
    {
        //资源序号
        public int ResourceNumber { get; set; } 
        /// <summary>
        /// 资源url
        /// </summary>
        public string Url { get; set; }

        //图片格式【ImageFormat或者string】，先用string，后面看实现再说
        public string PhotoFormat { get; set; }
        //资源名称
        public string ResourceSize { get; set; }
        //下载时间
        public long DownloadTime { get; set; }
        //状态
        public string State { get; set; }

        public Resource(string url)
        {
            Url = url;
        }
    }

    /// <summary>
    /// 图片
    /// </summary>
    public class ImgResource : Resource
    {
        /// <summary>
        /// 图片
        /// </summary>
        public Image Img { get; set; }

        public ImgResource(Image img, string url) :base(url)
        {
            Img = img;
        }
    }
}
