using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResWander.Service;
using ResWander.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResWanderUnitTest.ServiceTest
{
    [TestClass()]
    class ResourceFilterService
    {
        /// <summary>
        /// 存储着测试用的图片资源
        /// </summary>
        private List<Image>  imageSources;

        /// <summary>
        /// 初始化测试用的图片资源
        /// </summary>
        [TestInitialize]
        public void InitSourceFiles()
        {
            imageSources = new List<Image>();
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Pic.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Study.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Trade.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\100.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\BookShell.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\BookStudy.png"));
            imageSources.Add(new Bitmap(Environment.CurrentDirectory + @"\TestFiles\Theme.png"));
        }

        /// <summary>
        /// 用于测试文件过滤的方法
        /// </summary>
        [TestMethod]
        public void FilterImagesTest()
        {
            ImgInputData imgInputData = new ImgInputData();
            imgInputData.MinX = 0;
            imgInputData.MaxX = 1000;
            imgInputData.MinY = 0;
            imgInputData.MaxY = 1000;
            imgInputData.MinSize = 0;
            imgInputData.MaxSize = 1000;
            List<Image> filteredImages = ImageFilterService.FilterImages(this.imageSources,
                imgInputData);
        }
    }
}
