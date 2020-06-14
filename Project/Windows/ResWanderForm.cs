﻿using ResWander.Data;
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
        public BindingSource resourceBindingSource = new BindingSource();
        public CrawlerService crawlerService = new CrawlerService();
        //声明一个int型list，记录爬取到的图片的Index
        public List<int> pictureIndex = new List<int>();

        //声明一个图片控件列表
        List<PictureBox> pictureBox = new List<PictureBox>();

        public ResWanderForm()
        {
            InitializeComponent();
            resourceDataGridView.DataSource = resourceBindingSource;
            CrawlerProject = new Project();
            CrawlerService.DownloadedImag += Crawler_PageDownloaded;
        }

 

        public string stoPath;             //用来保存用户指定的存储路径

        /// <summary>
        /// 当用户点击爬取按钮后就会调用该方法，对相应网址进行资源爬取
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void CrawButton_Click(object sender, EventArgs e)
        {
            //每一次新爬取时都要把以前爬取得到的图片列表给清空
            CrawlerProject.ImgResourcesContainer.RowImages.Clear();
            CrawlerProject.ImgInputData.Url = this.urlTextBox.Text;
            //此处填入其他的输入
            bool crawlResult = CrawlerService.StartCrawl(CrawlerProject/*,crawlerService*/);
 
            
            if (!crawlResult)            //爬取失败
            {
                //中间还应加上爬取失败的网址，这个网址要得到
                messageLabel.Text = this.urlTextBox.Text + "网页爬取失败";
            }
            else                //爬取成功               
            {                   
                //中间还应加上成功爬取的网址，这个网址要得到
                messageLabel.Text = this.urlTextBox.Text + "网页爬取成功";
                //注意这里的List[i]的索引不能超出范围，即i<count，可以用一个
                //while循环加switch【switch用来判断图片和那个picturebox绑定】
                //来实现遍历，同时加条件来避免超出索引范围。

                //count用于统计爬取到的图片数量
                int count = CrawlerProject.ImgResourcesContainer.RowImages.Count;
                //将图片加入列表，同时初始化
                for(int j = 0 ; j < count; j++)
                {
                    PictureBox pBox = new PictureBox();
                    pictureBox.Add(pBox);
                    pictureBox[j].Parent = previewTabPage;
                    pictureBox[j].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox[j].Size = new Size(160, 100);
                    pictureBox[j].Image = CrawlerProject.ImgResourcesContainer.RowImages[j].Img;
                    pictureBox[j].Visible = false;
                    pictureBox[j].DoubleClick += new EventHandler(PictureBox_DoubleClick);
                }
                //为每个图片设置位置
                for(int k = 0; k < count; k = k + 3)
                {
                    pictureBox[k].Location = new Point(95, 60);
                    if (k + 1 < count)
                        pictureBox[k + 1].Location = new Point(295, 60);
                    if (k + 2 < count)
                        pictureBox[k + 2].Location = new Point(495, 60);
                }
                //一次最多展示3张图片
                if (0 < count)
                    pictureBox[0].Visible = true;
                if (1 < count)
                    pictureBox[1].Visible = true;
                if (2 < count)
                    pictureBox[2].Visible = true;
            /*   int i = 0;
                 while (i < count && i < 8)
                  {
                      switch (i)
                      {
                          case 0:            
                              pictureBox1.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 1:                       
                              pictureBox2.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 2:                        
                              pictureBox3.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 3:                      
                              pictureBox4.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 4:                       
                              pictureBox5.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 5:                      
                              pictureBox6.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 6:
                              pictureBox7.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                          case 7:                        
                              pictureBox8.Image = CrawlerProject.ImgResourcesContainer.RowImages[i].Img;
                              i++;
                              break;
                      }
                  }*/

            }        
        }
        /// <summary>
        /// 当用户点击筛选按钮后，会调用该方法，对相应资源按标准进行筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoseButton_Click(object sender, EventArgs e)
        {
            //每一次点击筛选按钮都要重置值
            formatLabel.Text = null;
            SelectForm SelectForm = new SelectForm(CrawlerProject);
            ////为筛选条件赋默认值
            //SelectForm.maxWidthTextBox.Text = "2000";
            //SelectForm.minWidthTextBox.Text = "0";
            //SelectForm.maxHeightTextBox.Text = "2000";
            //SelectForm.minHeightTextBox.Text = "0";
            //SelectForm.maxSizeTextBox.Text = "10240";
            //SelectForm.minSizeTextBox.Text = "0";
            //SelectForm.formatCheckedListBox.SetItemChecked(0, true);
            SelectForm.resForm = this;
            SelectForm.Show();                      //展示筛选条件的窗口
            //pictureBox.Clear();
            //int count = CrawlerProject.ImgResourcesContainer.ProcessedImages.Count;
            //for (int j = 0; j < count; j++)
            //{
            //    PictureBox pBox = new PictureBox();
            //    pictureBox.Add(pBox);
            //    pictureBox[j].Parent = previewTabPage;
            //    pictureBox[j].SizeMode = PictureBoxSizeMode.Zoom;
            //    pictureBox[j].Size = new Size(160, 100);
            //    pictureBox[j].Image = CrawlerProject.ImgResourcesContainer.ProcessedImages[j].Img;
            //    pictureBox[j].Visible = false;
            //    pictureBox[j].DoubleClick += new EventHandler(PictureBox_DoubleClick);
            //}
            ////为每个图片设置位置
            //for (int k = 0; k < count; k = k + 3)
            //{
            //    pictureBox[k].Location = new Point(95, 60);
            //    if (k + 1 < count)
            //        pictureBox[k + 1].Location = new Point(295, 60);
            //    if (k + 2 < count)
            //        pictureBox[k + 2].Location = new Point(495, 60);
            //}
            ////一次最多展示3张图片
            //if (0 < count)
            //    pictureBox[0].Visible = true;
            //if (1 < count)
            //    pictureBox[1].Visible = true;
            //if (2 < count)
            //    pictureBox[2].Visible = true;
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
           SaveService.SaveImages(CrawlerProject.ImgResourcesContainer.ProcessedImages);
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
        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pBox = (PictureBox)sender;
            Picture picture = new Picture();
            picture.Show();
            picture.pictureBox1.Image = pBox.Image;
        }
       
       

        private void Crawler_PageDownloaded(int number, string url, string format, string name, long time, string state)
        {
            var pageInfo = new { Index = number, URL = url, PhotoFormat = format, ResourceName = name, DownloadTime = time, Status = state };
            Action action = () => { resourceBindingSource.Add(pageInfo); };
            pictureIndex.Add(pageInfo.Index);
            //将第二列URL的宽度设置为自动填充
            if(this.resourceDataGridView.Columns.Count>1)
                this.resourceDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void NextPictureBox_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < pictureBox.Count; i++)
            {
                if (pictureBox[i].Visible)
                {
                    if (i + 3 < pictureBox.Count)
                    {
                        pictureBox[i].Visible = false;
                        pictureBox[i + 1].Visible = false;
                        pictureBox[i + 2].Visible = false;
                        pictureBox[i + 3].Visible = true;
                        if (i + 4 < pictureBox.Count)
                            pictureBox[i + 4].Visible = true;
                        if (i + 5 < pictureBox.Count)
                            pictureBox[i + 5].Visible = true;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void LastPictureBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBox.Count; i++)
            {
                if (pictureBox[i].Visible)
                {
                    if (i - 3 >= 0)
                    {
                        pictureBox[i].Visible = false;
                        if (i + 1 < pictureBox.Count)
                            pictureBox[i + 1].Visible = false;
                        if (i + 2 < pictureBox.Count)
                            pictureBox[i + 2].Visible = false;
                        pictureBox[i - 1].Visible = true;
                        pictureBox[i - 2].Visible = true;
                        pictureBox[i - 3].Visible = true;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }


    }
}
