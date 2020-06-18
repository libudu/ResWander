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
    public class SaveServiceTests
    {
        private List<ImgResource> imageSources;

        /// <summary>
        /// 在方法调用之前初始化资源文件
        /// </summary>
        [TestInitialize]
        public void InitSourceFiles()
        {
            imageSources = new List<ImgResource>();
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Pic.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Study.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Trade.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\100.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\BookShell.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\BookStudy.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Theme.png"), ""));
            imageSources.Add(new ImgResource(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\StarBerry.jpg"), ""));
        }

        /// <summary>
        /// 存储照片方法初始化功能测试
        /// </summary>
        [TestMethod]
        public void ImageSaveTest()
        {
            SaveService.SaveImages(this.imageSources);
        }

        /// <summary>
        /// 存储关键字照片到默认路径功能测试
        /// </summary>
        [TestMethod]
        public void KeywordImageSaveTest1()
        {
            //默认路径
            string defaultPath = Environment.CurrentDirectory + @"\KeywordImageTest";
            SaveService.SaveKeywordImages(defaultPath, "关键字2", this.imageSources);
        }

        /// <summary>
        /// 自选路径存储关键字图片功能测试
        /// </summary>
        [TestMethod]
        public void KeywordImageSaveTest2()
        {
            SaveService.SaveKeywordImages("关键字", this.imageSources);
        }
    }
}
