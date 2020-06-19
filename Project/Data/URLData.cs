using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    /// <summary>
    /// 负责存储一个网页中的url
    /// </summary>
    public class URLData
    {
        /// <summary>
        /// html代码里的网页url
        /// </summary>
        public Queue<string> HTMLUrls { get; set; }

        public ConcurrentQueue<string> ImgUrls { get; set; }

        public URLData()
        {
            HTMLUrls = new Queue<string>();
            ImgUrls = new ConcurrentQueue<string>();
        }
    }
}
