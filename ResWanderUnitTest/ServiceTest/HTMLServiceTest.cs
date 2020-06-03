using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResWander.Service;

namespace ResWanderUnitTest.ServiceTest
{
    /// <summary>
    /// HTMLService测试类
    /// </summary>
    [TestClass]
    public class HTMLServiceTest
    {
        //传入不正确的url
        [TestMethod]
        public void DownloadUrlTest1()
        {
            Assert.AreEqual("", HTMLService.DownloadUrl("baidu"));
            Assert.AreEqual("", HTMLService.DownloadUrl(null));
        }

        //传入正确的url
        [TestMethod]
        public void DownloadUrlTest2()
        {
            Assert.AreNotEqual("", HTMLService.DownloadUrl("https://www.baidu.com/"));
        }

        //传入一个空值
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HTMLParseTest1()
        {
            HTMLService.Parse(null);
        }

        //传入非空值
        [TestMethod]
        public void HTMLParseTest2()
        {
            List<string> urlList;
            urlList = HTMLService.Parse("");
            Assert.AreEqual(0, urlList.Count);
            string htmlCode = HTMLService.DownloadUrl("https://www.baidu.com/");
            urlList = HTMLService.Parse(htmlCode);
            Assert.AreNotEqual(0, urlList.Count);
            foreach(string url in urlList)
            {
                Assert.IsTrue(url.Contains("/"));
            }
        }
    }
}
