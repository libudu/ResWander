using ResWander.Data;
using ResWander.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResWander.Windows;

namespace ResWander
{
    public partial class ResWanderForm : Form
    {
        public Project  CrawlerProject { get; set; }

        public ResWanderForm()
        {
            InitializeComponent();
            CrawlerProject = new Project();
        }

        public string stoPath;             //用来保存用户指定的存储路径

        /// <summary>
        /// 当用户点击爬取按钮后就会调用该方法，对相应网址进行资源爬取
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void CrawButton_Click(object sender, EventArgs e)
        {
            CrawlerProject.ImgInputData.Url = this.urlTextBox.Text;
            //此处填入其他的输入
            bool crawlResult = CrawlerService.StartCrawl(CrawlerProject);
            if (!crawlResult)            //爬取成功
            {
                //中间还应加上爬取失败的网址，这个网址要得到
                messageLabel.Text = "爬取网址" +this.urlTextBox.Text+ "失败";
            }
            else                //爬取失败               
            {                   
                //中间还应加上成功爬取的网址，这个网址要得到
                messageLabel.Text = "网址" + this.urlTextBox.Text+"爬取成功";
                int i = 0;
                pictureBox1.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox2.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox3.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox4.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox5.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox6.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox7.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
                i++;
                pictureBox8.DataBindings.Add("Image", CrawlerProject.ImgResourcesContainer.RowImages, "RowImages[i]");
            }

            //messageLabel.Text = ,这块给messageLabel赋值相应的信息去显示
        }
        /// <summary>
        /// 当用户点击筛选按钮后，会调用该方法，对相应资源按标准进行筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoseButton_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm(CrawlerProject);           
            select.Show();                      //展示筛选条件的窗口
            select.resForm = this;
        }
        /// <summary>
        /// 当用户点击重新筛选按钮后，会调用该方法，对资源按新的标准重新筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReChoseButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 当用户点击全选按钮后，会调用该方法，选中所有的资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 当用户点击下载选中按钮后，会调用该方法，把选中的资源下载到用户指定的目录中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDateButton_Click(object sender, EventArgs e)
        {
           // SaveService.SaveImages(CrawlerProject.ImgResourcesContainer.ProcessedImages);
        }
        /// <summary>
        /// 当用户点击打开下载目录按钮后，会调用该方法，打开用户之前指定的资源下载目录，方便查看下载的资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenListButton_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 当用户点击设置按钮后，会调用该方法，弹出一个窗口，让用户输入下载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetButton_Click(object sender, EventArgs e)
        {
            Form2 formtwo = new Form2();                    //新建一个窗口
            formtwo.Show();                                 //让新窗口显示
            formtwo.formone = this;
        }
        /// <summary>
        /// 当用户双击图片，即可看到相应的放大的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox1.Image;
        }
        private void PictureBox2_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox2.Image;
        }
        private void PictureBox3_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox3.Image;
        }
        private void PictureBox4_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox4.Image;
        }
        private void PictureBox5_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox5.Image;
        }
        private void PictureBox6_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox6.Image;
        }
        private void PictureBox7_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox7.Image;
        }
        private void PictureBox8_DoubleClick(object sender, EventArgs e)
        {
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = this.pictureBox8.Image;
        }
    }
}
