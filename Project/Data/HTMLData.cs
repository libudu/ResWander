using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    /// <summary>
    /// 负责存储初步爬取的html代码数据
    /// </summary>
    public class HTMLData
    {
        /// <summary>
        /// 存储下载得到的HTML代码
        /// </summary>
        public Queue<string> HTMLCodes { get; set; }

        public HTMLData()
        {
            HTMLCodes = new Queue<string>();
        }
    }
}
