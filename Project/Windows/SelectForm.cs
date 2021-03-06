﻿using ResWander.Data;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResWander.Service;

namespace ResWander.Windows
{
    public partial class SelectForm : Form
    {
        public ResWanderForm resForm;

        public Project  Project { get; set; }
        public SelectForm(Project project)
        {
            InitializeComponent();
            Project = project;
            SelctInit();

        }

        public void SelctInit()
        {
            //为筛选条件显示为上一次的筛选条件以供参考
            this.maxWidthTextBox.Text = Project.ImgInputData.MaxX.ToString();
            this.minWidthTextBox.Text = Project.ImgInputData.MinX.ToString();
            this.maxHeightTextBox.Text = Project.ImgInputData.MaxY.ToString();
            this.minHeightTextBox.Text = Project.ImgInputData.MinY.ToString();
            this.maxSizeTextBox.Text = Project.ImgInputData.MaxSize.ToString();
            this.minSizeTextBox.Text = Project.ImgInputData.MinSize.ToString();
            foreach (ImageFormat format in Project.ImgInputData.TargetImgFormat)
            {
                if(format==ImageFormat.Jpeg)
                    this.formatCheckedListBox.SetItemChecked(0, true);
                else if (format == ImageFormat.Png)
                    this.formatCheckedListBox.SetItemChecked(1, true);
                else if (format == ImageFormat.Tiff)
                    this.formatCheckedListBox.SetItemChecked(2, true);
                else if (format == ImageFormat.Gif)
                    this.formatCheckedListBox.SetItemChecked(3, true);
                else
                {
                    this.formatCheckedListBox.SetItemChecked(0, true);
                    this.formatCheckedListBox.SetItemChecked(1, true); 
                    this.formatCheckedListBox.SetItemChecked(2, true);
                    this.formatCheckedListBox.SetItemChecked(3, true); 

                }

            }
            
        }

        private void AffirmButton_Click(object sender, EventArgs e)
        { 
            //变量用来指示复选框中有无被选中的选项
            bool check = false;                     
            for (int i = 0; i < formatCheckedListBox.Items.Count; i++)
            {
                if (formatCheckedListBox.GetItemChecked(i))
                {
                    check = true;
                }
            }
            if (!string.IsNullOrWhiteSpace(minWidthTextBox.Text) && !string.IsNullOrWhiteSpace(maxWidthTextBox.Text) &&
               !string.IsNullOrWhiteSpace(minHeightTextBox.Text) && !string.IsNullOrWhiteSpace(maxHeightTextBox.Text) &&
               !string.IsNullOrWhiteSpace(minSizeTextBox.Text) && !string.IsNullOrWhiteSpace(maxSizeTextBox.Text) && check )
            {
                resForm.widthLabel.Text = minWidthTextBox.Text + "~" + maxWidthTextBox.Text;
                resForm.heightLabel.Text = minHeightTextBox.Text + "~" + maxHeightTextBox.Text;
                resForm.sizeLabel.Text = minSizeTextBox.Text + "~" + maxSizeTextBox.Text;
                for(int j = 0; j < formatCheckedListBox.Items.Count; j++)
                {
                    if (formatCheckedListBox.GetItemChecked(j))
                    {
                        resForm.formatLabel.Text = resForm.formatLabel.Text + formatCheckedListBox.GetItemText(formatCheckedListBox.Items[j])+" ";
                        if (formatCheckedListBox.GetItemText(formatCheckedListBox.Items[j]).Equals("*..*")){
                            resForm.formatLabel.Text = "JPG PNG TIF GIF";
                            break;
                        }
                    }
                }
                
                //存储相应的筛选条件
                Project.ImgInputData.MaxX = int.Parse(maxWidthTextBox.Text);
                Project.ImgInputData.MinX = int.Parse(minWidthTextBox.Text);
                Project.ImgInputData.MaxY = int.Parse(maxHeightTextBox.Text);
                Project.ImgInputData.MinY = int.Parse(minHeightTextBox.Text);
                Project.ImgInputData.MaxSize = int.Parse(maxSizeTextBox.Text);
                Project.ImgInputData.MinSize = int.Parse(minSizeTextBox.Text);
                //将用户选中的图片格式加入图片格式列表前，先清空原有的图片格式列表
                Project.ImgInputData.TargetImgFormat.Clear();
                //遍历选项，得到用户选中的选项，加入图片格式列表中
                for (int k = 0; k < formatCheckedListBox.Items.Count; k++)
                {
                    if (formatCheckedListBox.GetItemChecked(k))
                    {
                       string format = formatCheckedListBox.GetItemText(formatCheckedListBox.Items[k]);
                        switch (format)
                        {
                            case "JPG":
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Jpeg);
                                break;
                            case "PNG":
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Png);
                                break;
                            case "TIF":
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Tiff);
                                break;
                            case "GIF":
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Gif);
                                break;
                            case "*..*":
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Jpeg);
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Png);
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Tiff);
                                Project.ImgInputData.TargetImgFormat.Add(ImageFormat.Gif);
                                break;
                            default:
                                break;
                        }
                    }
                }
                //调用筛选方法，给这个方法传入用户输入的筛选条件，宽度，高度等
                Project.ImgResourcesContainer.ProcessedImages = ImageFilterService.FilterImages(Project);
                int count = Project.ImgResourcesContainer.ProcessedImages.Count;
                //对预览中动态生成的图片控件重新赋值，赋值为筛选的图片
                for(int i = 0; i < count; i++)
                {
                    resForm.pictureBox[i].Image = Project.ImgResourcesContainer.ProcessedImages[i].Img;
                    if (resForm.pictureBox[i].Visible)
                    {
                        resForm.checkBoxes[i].Visible = true;
                    }
                }
                //对预览中多余的图片控件置为null同时让相应的复选框隐藏并且设置复选框为未选中状态
                int c = count;
                while (c < resForm.pictureBox.Count)
                {
                    resForm.pictureBox[c].Image = null;
                    resForm.checkBoxes[c].Visible = false;
                    resForm.checkBoxes[c].Checked = false;
                    c++;
                }

                resForm.resourceBindingSource.Clear();
                //对资源重复筛选前，先将资源爬取情况恢复到最初爬取的全部资源
                for (int re = 0; re < resForm.saveResourceBindingSource.Count; re++)
                {                                     
                    resForm.resourceBindingSource.Add(resForm.saveResourceBindingSource[re]);
                }
                //实现资源爬取情况在筛选之后的同步
                BindingSource processedImageSource = new BindingSource();
                //用一个int类型的List列表来记录筛选得到的图片的Index
                //根据图片序号是否相同，来判断是否移除资源爬取情况中的某一行记录
                List<int> index = new List<int>();
                for (int q = 0; q < Project.ImgResourcesContainer.ProcessedImages.Count; q++)
                {
                    var pageInfo = new { Index = Project.ImgResourcesContainer.ProcessedImages[q].ResourceNumber,
                                         URL = Project.ImgResourcesContainer.ProcessedImages[q].Url,
                                         PhotoFormat = Project.ImgResourcesContainer.ProcessedImages[q].PhotoFormat,
                                         ResourceName = Project.ImgResourcesContainer.ProcessedImages[q].ResourceSize,
                                         DownloadTime = Project.ImgResourcesContainer.ProcessedImages[q].DownloadTime,
                                         Status = Project.ImgResourcesContainer.ProcessedImages[q].State };
                    processedImageSource.Add(pageInfo);
                    index.Add(pageInfo.Index);
                }
                //用来记录应该被移除的图片序号
                List<int> removePictureIndex = new List<int>();
                //用来标记这一行资源记录应不应该被移除
                bool remove;
                for (int l = 0; l < resForm.resourceBindingSource.Count; l++)
                {
                    remove = true;
                   for(int x = 0; x < processedImageSource.Count; x++)
                    {
                        if (resForm.pictureIndex[l]==index[x])
                        {
                            remove = false;
                            break;
                        }
                    }
                    if (remove)
                        removePictureIndex.Add(l);
                }
                //记录删除次数
                int removeNumber = 0;
                //遍历删除记录在removePictureIndex列表里的图片【根据序号】
                for(int j = 0; j < removePictureIndex.Count; j++)
                {
                    resForm.resourceBindingSource.Remove(resForm.resourceBindingSource[removePictureIndex[j]-removeNumber]);
                    removeNumber++;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("筛选条件不完整，请用户补全筛选条件！");
            }
            
        }
    }
}
