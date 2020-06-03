using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResWander.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service.Tests
{
    [TestClass()]
    public class CrawlerServiceTests
    {
        [TestMethod()]
        public void StartCrawlTest()
        {
        }

        [TestMethod()]
        public void CrawlBaiduImgTest()
        {
            var UrlList = CrawlerService.CrawlBaiduImg("http://image.baidu.com/search/index?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8&word=C%23");
            foreach (var Url in UrlList)
            {
                Console.WriteLine(Url);
            }
        }
    }
}