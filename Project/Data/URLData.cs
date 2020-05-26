using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    /// <summary>
    /// 负责存储一个网页中的url
    /// </summary>
    class URLData
    {
        /// <summary>
        /// html代码里的网页url
        /// </summary>
        public Queue<string> HTMLUrls { get; set; }

        /// <summary>
        /// html代码里的图片url
        /// </summary>
        public Queue<string> ImageUrls { get; set;  }
    }
}
