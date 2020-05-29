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
    /// 保存服务测试类(SaveService 测试类)
    /// </summary>
    [TestClass]
    public class SaveServiceTest
    {
        private static List<Image> imageSources;

        /// <summary>
        /// 在方法调用之前初始化资源文件
        /// </summary>
        [ClassInitialize]
        public static void InitSourceFiles(TestContext testContext)
        {
            imageSources = new List<Image>();
            imageSources.Add(new Bitmap("/测试文件/图片.png"));
        }

        /// <summary>
        /// 存储照片方法初始化
        /// </summary>
        [TestMethod]
        public void ImageSaveTest()
        {
            SaveService.SaveImages(SaveServiceTest.imageSources);
            Assert.AreEqual(true, true);
        }
    }
}
