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
using System.Threading;

namespace ResWander
{
    public partial class ResWanderForm : Form
    {
        public Project  CrawlerProject { get; set; }
        public BindingSource resourceBindingSource = new BindingSource();
        //保存resourceBindingSource中的资源，实现重新筛选
        public BindingSource saveResourceBindingSource = new BindingSource();
        public CrawlerService crawlerService = new CrawlerService();
        //声明一个int型list，记录爬取到的图片的Index
        public List<int> pictureIndex = new List<int>();

        //声明一个图片控件列表
        public List<PictureBox> pictureBox = new List<PictureBox>();

        //声明一个复选框控件列表，一个复选框在相应的一个图片下面
        public List<CheckBox> checkBoxes = new List<CheckBox>();

        public string filePath { get; set; }

        public ResWanderForm()
        {
            InitializeComponent();
            CrawlerService.form = this;
            resourceDataGridView.DataSource = resourceBindingSource;
            CrawlerProject = new Project();
            CrawlerService.DownloadedImag += Crawler_PageDownloaded;
            CrawlerService.ImgPreview += Crawl_Preview;
            this.Size = new Size(1200,800);          
        }

 

        public string stoPath;             //用来保存用户指定的存储路径

        /// <summary>
        /// 当用户点击爬取按钮后就会调用该方法，对相应网址进行资源爬取
        /// </summary>
        /// <param name="sender"></param> 
        /// <param name="e"></param>
        private void CrawButton_Click(object sender, EventArgs e)
        {
            //每一次新爬取时清空上一次爬取记录的所有图片的index，避免下一次爬取保存index时出现错误
            pictureIndex.Clear();
            resourceBindingSource.Clear();
            saveResourceBindingSource.Clear();
            if (pictureBox.Count > 0)
            {
                for(int j = 0; j < pictureBox.Count; j++)
                {
                    pictureBox[j].Dispose();
                }
            }
            pictureBox.Clear();
            if (checkBoxes.Count > 0)
            {
                for(int j = 0; j < checkBoxes.Count; j++)
                {
                    checkBoxes[j].Dispose();
                }
            }
            checkBoxes.Clear();
            //每一次新爬取时都要把以前爬取得到的图片列表给清空
            CrawlerProject.ImgResourcesContainer.RowImages.Clear();
            CrawlerProject.ImgInputData.Url = this.urlTextBox.Text;
            //此处填入其他的输入
            //bool crawlResult = CrawlerService.StartCrawl(CrawlerProject/*,crawlerService*/);
            //此处填入其他的输入
            Crawl crawl = new Crawl(CrawlerProject);
            Thread thread = new Thread(crawl.CrawlFun);
            thread.Start();
            //bool crawlResult = CrawlerService.StartCrawl(CrawlerProject/*,crawlerService*/);
            bool crawlResult = true;


            if (!crawlResult)            //爬取失败
            {
                //中间还应加上爬取失败的网址，这个网址要得到
                messageLabel.Text = this.urlTextBox.Text + "网页爬取失败";
            }
            else                //爬取成功               
            {                   
                //中间还应加上成功爬取的网址，这个网址要得到
                messageLabel.Text = this.urlTextBox.Text + "网页爬取成功";
              
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
           
        }
        /// <summary>
        /// 当用户点击全选按钮后，会调用该方法，选中所有的资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkBoxes.Count; i++)
            {
                if (pictureBox[i].Image != null)
                {
                    checkBoxes[i].Checked = true;
                }
            }
        }
        /// <summary>
        /// 当用户点击下载选中按钮后，会调用该方法，把选中的资源下载到用户指定的目录中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDateButton_Click(object sender, EventArgs e)
        {
            //声明一个下载队列，将要下载的图片加入队列里
            List<ImgResource> img = new List<ImgResource>();
            //当用户点击筛选按钮，筛选出图片后，下载选中是基于筛选图片的列表里来的【看count是否为0】
            if (CrawlerProject.ImgResourcesContainer.ProcessedImages.Count > 0)
            {
                for(int f = 0; f < CrawlerProject.ImgResourcesContainer.ProcessedImages.Count; f++)
                {
                    //如果相应图片对应的复选框被选中，则加入下载队列
                    if(checkBoxes[f].Checked)
                    {
                        img.Add(CrawlerProject.ImgResourcesContainer.ProcessedImages[f]);
                    }
                }
            }
            else
            {
                for(int f = 0; f < CrawlerProject.ImgResourcesContainer.RowImages.Count; f++)
                {
                    if(checkBoxes[f].Checked)
                    {
                        img.Add(CrawlerProject.ImgResourcesContainer.RowImages[f]);
                    }
                }
            }
           filePath = SaveService.SaveImages(img);
        }
        /// <summary>
        /// 当用户点击打开下载目录按钮后，会调用该方法，打开用户之前存储的资源的下载目录，方便查看下载的资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenListButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", filePath);
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
            Action action = () => { resourceBindingSource.Add(pageInfo); saveResourceBindingSource.Add(pageInfo); };
            Action action1 = () => {
                //将第二列URL的宽度设置为自动填充
                if (this.resourceDataGridView.Columns.Count > 1)
                    this.resourceDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                FlagLabel.Text = number.ToString();
            };
            pictureIndex.Add(pageInfo.Index);

            if (this.InvokeRequired)
            {
                this.Invoke(action1);
                this.Invoke(action);
            }
            else
            {
                action1();
                action();
            }
        }
        /// <summary>
        /// 将爬到的图片一个一个的展示出去，每爬到一个，展示一个
        /// </summary>
        private void Crawl_Preview()
        {
            Action action = () =>
            {
               /* if (pictureBox.Count > 0)
                {
                    for (int j = 0; j < pictureBox.Count; j++)
                    {
                        pictureBox[j].Dispose();
                    }
                }
                pictureBox.Clear();
                if (checkBoxes.Count > 0)
                {
                    for (int j = 0; j < checkBoxes.Count; j++)
                    {
                        checkBoxes[j].Dispose();
                    }
                }
                checkBoxes.Clear();*/
               //count用于统计爬取到的图片数量
               int count = CrawlerProject.ImgResourcesContainer.RowImages.Count;
               
                    //每得到一张图片就相应的建一个图片以及复选框控件并初始化
                    PictureBox pBox = new PictureBox();
                    CheckBox chekBox = new CheckBox();
                    pictureBox.Add(pBox);
                    checkBoxes.Add(chekBox);
                    pictureBox[pictureBox.Count - 1].Parent = previewTabPage;
                    pictureBox[pictureBox.Count - 1].SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox[pictureBox.Count - 1].Size = new Size(200, 160);
                    pictureBox[pictureBox.Count - 1].Image = CrawlerProject.ImgResourcesContainer.RowImages[pictureBox.Count-1].Img;
                    pictureBox[pictureBox.Count - 1].Visible = false;
                    pictureBox[pictureBox.Count - 1].DoubleClick += new EventHandler(PictureBox_DoubleClick);
                    checkBoxes[checkBoxes.Count - 1].Visible = false;
                    checkBoxes[checkBoxes.Count - 1].Checked = false;
                    checkBoxes[checkBoxes.Count - 1].Text = "选中";
                    checkBoxes[checkBoxes.Count - 1].Size = new Size(100, 20);
                    checkBoxes[checkBoxes.Count - 1].Parent = previewTabPage;

                //为相应的图片以及复选框设置位置
                int p = (count - 1) % 9;
                switch (p)
                {
                    case 0:
                        pictureBox[count - 1].Location = new Point(120, 0);
                        checkBoxes[count - 1].Location = new Point(170, 180);
                        break;
                    case 1:
                        pictureBox[count - 1].Location = new Point(470, 0);
                        checkBoxes[count - 1].Location = new Point(520, 180);
                        break;
                    case 2:
                        pictureBox[count - 1].Location = new Point(820, 0);
                        checkBoxes[count - 1].Location = new Point(870, 180);
                        break;
                    case 3:
                        pictureBox[count - 1].Location = new Point(120, 210);
                        checkBoxes[count - 1].Location = new Point(170, 380);
                        break;
                    case 4:
                        pictureBox[count - 1].Location = new Point(470, 210);
                        checkBoxes[count - 1].Location = new Point(520, 380);
                        break;
                    case 5:
                        pictureBox[count - 1].Location = new Point(820, 210);
                        checkBoxes[count - 1].Location = new Point(870, 380);
                        break;
                    case 6:
                        pictureBox[count - 1].Location = new Point(120, 400);
                        checkBoxes[count - 1].Location = new Point(170, 570);
                        break;
                    case 7:
                        pictureBox[count - 1].Location = new Point(470, 400);
                        checkBoxes[count - 1].Location = new Point(520, 570);
                        break;
                    case 8:
                        pictureBox[count - 1].Location = new Point(820, 400);
                        checkBoxes[count - 1].Location = new Point(870, 570);
                        break;
                    default:
                        break;
                }
                //为每个图片以及复选框设置位置
                /* for (int k = 0; k < count; k = k + 9)
                  {
                      pictureBox[k].Location = new Point(120, 0);
                      checkBoxes[k].Location = new Point(170, 180);
                      if (k + 1 < count)
                      {
                          pictureBox[k + 1].Location = new Point(470, 0);
                          checkBoxes[k + 1].Location = new Point(520, 180);
                      }
                      if (k + 2 < count)
                      {
                          pictureBox[k + 2].Location = new Point(820, 0);
                          checkBoxes[k + 2].Location = new Point(870, 180);
                      }
                      if (k + 3 < count)
                      {
                          pictureBox[k + 3].Location = new Point(120, 210);
                          checkBoxes[k + 3].Location = new Point(170, 380);
                      }
                      if (k + 4 < count)
                      {
                          pictureBox[k + 4].Location = new Point(470, 210);
                          checkBoxes[k + 4].Location = new Point(520, 380);
                      }
                      if (k + 5 < count)
                      {
                          pictureBox[k + 5].Location = new Point(820, 210);
                          checkBoxes[k + 5].Location = new Point(870, 380);
                      }
                      if (k + 6 < count)
                      {
                          pictureBox[k + 6].Location = new Point(120, 400);
                          checkBoxes[k + 6].Location = new Point(170, 570);
                      }
                      if (k + 7 < count)
                      {
                          pictureBox[k + 7].Location = new Point(470, 400);
                          checkBoxes[k + 7].Location = new Point(520, 570);
                      }
                      if (k + 8 < count)
                      {
                          pictureBox[k + 8].Location = new Point(820, 400);
                          checkBoxes[k + 8].Location = new Point(870, 570);
                      }

                  }*/
               
                //记录当前有多个显示的图片【用复选框来表示】
                int vi = 0;
                //当加入的图片不为空时
                if (pictureBox[count - 1] != null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (checkBoxes[i].Visible)
                        {
                            vi++;
                        }
                    }
                }
                //要翻页了
                if (vi == 9)
                {
                    for(int i = 0; i < count; i++)
                    {
                        if (checkBoxes[i].Visible)
                        {
                            pictureBox[i].Visible = false;
                            checkBoxes[i].Visible = false;
                        }
                    }
                }

                //对于picturebox的Img为空的控件进行调整，使得后面的不为空的图象往前移
                for (int j = 0; j < count; j++)
                {
                    if (pictureBox[j].Image == null)
                    {
                        for (int k = j + 1; k < count; k++)
                        {
                            if (pictureBox[k].Image != null)
                            {
                                pictureBox[j].Image = pictureBox[k].Image;
                                pictureBox[k].Image = null;
                                break;
                            }
                        }
                    }
                }

                pictureBox[count - 1].Visible = true;
                if (pictureBox[count - 1].Image != null)
                {                    
                    checkBoxes[count - 1].Visible = true;
                }
                for(int i = 0; i < count; i++)
                {
                    if (pictureBox[i].Visible && pictureBox[i].Image != null)
                    {
                        checkBoxes[i].Visible = true;
                    }
                }
               
                //一次最多展示9张图片以及9个对应的复选框
                /*for (int j = 0; j < 9; j++)
                {
                    if (j < count && pictureBox[j].Image != null)
                    {
                        pictureBox[j].Visible = true;
                        checkBoxes[j].Visible = true;
                    }
                }*/
            };
         
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        /// <summary>
        /// 当用户点了下一个的箭头图标的控件后，会显示后面的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPictureBox_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < pictureBox.Count; i++)
            {
                if (pictureBox[i].Visible)
                {
                    if (i + 9 < pictureBox.Count && pictureBox[i+9].Image != null)
                    {   
                        //隐藏前9个图片以及复选框
                        int k = i + 9;
                        int kr = i;
                        while (kr < k)
                        {
                            pictureBox[kr].Visible = false;
                            checkBoxes[kr].Visible = false;
                            kr++;
                        }
                        
                        pictureBox[i + 9].Visible = true;
                        checkBoxes[i + 9].Visible = true;
                        for(int j = i + 10; j < i + 18; j++)
                        {
                            if (j < pictureBox.Count && pictureBox[j].Image != null)
                            {
                                pictureBox[j].Visible = true;
                                checkBoxes[j].Visible = true;
                            }
                        }
                       
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 当用户点了上一个的箭头图标控件后，会显示上一块的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastPictureBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pictureBox.Count; i++)
            {
                if (pictureBox[i].Visible)
                {
                    if (i - 9 >= 0)
                    {
                        pictureBox[i].Visible = false;
                        checkBoxes[i].Visible = false;
                        for(int k = i + 1; k < i + 9; k++)
                        {
                            if (k < pictureBox.Count)
                            {
                                pictureBox[k].Visible = false;
                                checkBoxes[k].Visible = false;
                            }
                        }
                        
                        for(int j = i - 1; j > i - 10; j--)
                        {
                            if (pictureBox[j].Image != null)
                            {
                                pictureBox[j].Visible = true;
                                checkBoxes[j].Visible = true;
                            }
                        }
                       
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        /// <summary>
        /// 下面的两个函数实现了鼠标点击控件以及松开时控件的变化，不过是通过改变控件的背景颜色来变的，因为控件被图片充满，所有没变化
        /// 如果找不到简单的解决办法，可以考虑对图片p一下，点击后直接换图片的方式来完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
           nextPictureBox.ImageLocation = "right.png";
        }

        private void NextPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            nextPictureBox.ImageLocation = "primaryRight.png";
        }
        /// <summary>
        /// 实现以图搜图按钮的相关功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();  //显示选择文件对话框
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; //所有的文件格式
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            string path;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                //获取用户选择的文件路径
                path = openFileDialog1.FileName;
                List<string> imgKeyWord = CrawlerService.ImgSearchImg(path);
                //声明一个url列表，存储得到的url
                List<string> url = new List<string>();
                for(int i = 0; i < imgKeyWord.Count; i++)
                {
                   url.Add(CrawlerService.SearchKeyword(imgKeyWord[i]));
                }
                //只爬取第一个url，因为此url关联最大
                if (url.Count > 0)
                    CrawlerProject.ImgInputData.Url = url[0];
                else
                    return;

                //每一次新爬取时清空上一次爬取记录的所有图片的index，避免下一次爬取保存index时出现错误
                pictureIndex.Clear();
                resourceBindingSource.Clear();
                saveResourceBindingSource.Clear();
                if (pictureBox.Count > 0)
                {
                    for (int j = 0; j < pictureBox.Count; j++)
                    {
                        pictureBox[j].Dispose();
                    }
                }
                pictureBox.Clear();
                if (checkBoxes.Count > 0)
                {
                    for (int j = 0; j < checkBoxes.Count; j++)
                    {
                        checkBoxes[j].Dispose();
                    }
                }
                checkBoxes.Clear();
                //每一次新爬取时都要把以前爬取得到的图片列表给清空
                CrawlerProject.ImgResourcesContainer.RowImages.Clear();

                Crawl crawl = new Crawl(CrawlerProject);
                Thread thread = new Thread(crawl.CrawlFun);
                thread.Start();
                //bool crawlResult = CrawlerService.StartCrawl(CrawlerProject/*,crawlerService*/);
                bool crawlResult = true;


                if (!crawlResult)            //爬取失败
                {
                   
                }
                else                //爬取成功               
                {
                   
                  /*  //count用于统计爬取到的图片数量
                    int count = CrawlerProject.ImgResourcesContainer.RowImages.Count;
                    //将图片和相应的复选框分别加入相应的列表，同时初始化
                    for (int j = 0; j < count; j++)
                    {
                        PictureBox pBox = new PictureBox();
                        CheckBox chekBox = new CheckBox();
                        pictureBox.Add(pBox);
                        checkBoxes.Add(chekBox);
                        pictureBox[j].Parent = previewTabPage;
                        pictureBox[j].SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox[j].Size = new Size(200, 160);
                        pictureBox[j].Image = CrawlerProject.ImgResourcesContainer.RowImages[j].Img;
                        pictureBox[j].Visible = false;
                        pictureBox[j].DoubleClick += new EventHandler(PictureBox_DoubleClick);
                        checkBoxes[j].Visible = false;
                        checkBoxes[j].Checked = false;
                        checkBoxes[j].Text = "选中";
                        checkBoxes[j].Size = new Size(100, 20);
                        checkBoxes[j].Parent = previewTabPage;
                    }
                    //为每个图片以及复选框设置位置
                    for (int k = 0; k < count; k = k + 9)
                    {
                        pictureBox[k].Location = new Point(120, 0);
                        checkBoxes[k].Location = new Point(170, 180);
                        if (k + 1 < count)
                        {
                            pictureBox[k + 1].Location = new Point(470, 0);
                            checkBoxes[k + 1].Location = new Point(520, 180);
                        }
                        if (k + 2 < count)
                        {
                            pictureBox[k + 2].Location = new Point(820, 0);
                            checkBoxes[k + 2].Location = new Point(870, 180);
                        }
                        if (k + 3 < count)
                        {
                            pictureBox[k + 3].Location = new Point(120, 210);
                            checkBoxes[k + 3].Location = new Point(170, 380);
                        }
                        if (k + 4 < count)
                        {
                            pictureBox[k + 4].Location = new Point(470, 210);
                            checkBoxes[k + 4].Location = new Point(520, 380);
                        }
                        if (k + 5 < count)
                        {
                            pictureBox[k + 5].Location = new Point(820, 210);
                            checkBoxes[k + 5].Location = new Point(870, 380);
                        }
                        if (k + 6 < count)
                        {
                            pictureBox[k + 6].Location = new Point(120, 400);
                            checkBoxes[k + 6].Location = new Point(170, 570);
                        }
                        if (k + 7 < count)
                        {
                            pictureBox[k + 7].Location = new Point(470, 400);
                            checkBoxes[k + 7].Location = new Point(520, 570);
                        }
                        if (k + 8 < count)
                        {
                            pictureBox[k + 8].Location = new Point(820, 400);
                            checkBoxes[k + 8].Location = new Point(870, 570);
                        }
                    }
                    //对于picturebox的Img为空的控件进行调整，使得后面的不为空的图象往前移
                    for (int j = 0; j < count; j++)
                    {
                        if (pictureBox[j].Image == null)
                        {
                            for (int k = j + 1; k < count; k++)
                            {
                                if (pictureBox[k].Image != null)
                                {
                                    pictureBox[j].Image = pictureBox[k].Image;
                                    pictureBox[k].Image = null;
                                    break;
                                }
                            }
                        }
                    }
                    //一次最多展示9张图片以及9个对应的复选框
                    for (int j = 0; j < 9; j++)
                    {
                        if (j < count && pictureBox[j].Image != null)
                        {
                            pictureBox[j].Visible = true;
                            checkBoxes[j].Visible = true;
                        }
                    }*/

                }

            }


        }

        private void LastPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastPictureBox.ImageLocation = "primaryLeft.jpg";
        }

        private void LastPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            lastPictureBox.ImageLocation = "left.png";
        }
        public delegate void SetText(string text);
        //委托调用的方法
        private void UpdateLabel(string str)
        {
            FlagLabel.Text = str;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            CrawlerService.flag = true;
        }
    }

    public class Crawl
    {
        public Project project;
        public bool CrawlResult;

        public Crawl(Project project)
        {
            this.project = project;
        }

        public void CrawlFun()
        {
            CrawlResult = CrawlerService.StartCrawl(project);
        }
    }
}
