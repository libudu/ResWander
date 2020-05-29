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
        /// <summary>
        /// 资源url
        /// </summary>
        public string Url { get; set; }
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
    }
}
