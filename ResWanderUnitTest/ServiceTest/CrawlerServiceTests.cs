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
            List<String> UrlList;
            CrawlerService.CrawlBaiduImg("http://image.baidu.com/search/index?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8&word=C%23", out UrlList);
            foreach (var Url in UrlList)
            {
                Console.WriteLine(Url);
            }
        }

        [TestMethod()]
        public void IsBaiduImgUrlTest()
        {
            /*
            var result = CrawlerService.IsBaiduImgUrl("http://image.baidu.com/search/index?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8&word=C%23");
            Assert.IsTrue(result);
            result = CrawlerService.IsBaiduImgUrl("https://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&tn=baidu&wd=C%23&oq=%2526lt%253B%2523%2520assert&rsv_pq=ccf5dec400044297&rsv_t=ee50J0%2Bm9UitMDU%2BClewCEThs9AjtfKMjWqsrr%2BP98hoTFNmaZjGRgcx478&rqlang=cn&rsv_enter=1&rsv_dl=tb&rsv_btype=t&inputT=1104&rsv_sug3=10&rsv_sug1=10&rsv_sug7=100&rsv_sug2=0&rsv_sug4=1433");
            Assert.IsFalse(result);
            */
        }

        [TestMethod()]
        public void ImgSearchImgUrlTest()
        {
            var result = CrawlerService.ImgSearchImg("test.png");
            foreach(var keyword in result)
            {
                Console.WriteLine(keyword);
            }
        }
    }
}