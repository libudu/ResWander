using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResWander.Service;
using ResWander.Data;

namespace ResWanderUnitTest.ServiceTest
{
    /// <summary>
    /// 保存服务测试类(SaveService 测试类)
    /// </summary>
    [TestClass()]
    public class SaveServiceTest
    {
        private List<ImgResource> imageSources;

        /// <summary>
        /// 在方法调用之前初始化资源文件
        /// </summary>
        [TestInitialize]
        public void InitSourceFiles()
        {
            imageSources = new List<ImgResource>();
            imageSources.Add(new Bitmap(Environment.CurrentDirectory +@"\TestFiles\Pic.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Study.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Trade.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\100.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\BookShell.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\BookStudy.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Theme.png"));
        }

        /// <summary>
        /// 存储照片方法初始化功能测试
        /// </summary>
        [TestMethod]
        public void ImageSaveTest()
        {
            SaveService.SaveImages(this.imageSources);
        }
    }
}
