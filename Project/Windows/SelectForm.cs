using ResWander.Data;
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
                    }
                }
                //在这还要调用相应的筛选方法，给这个方法传入用户输入的筛选条件，宽度，高度等

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
                ImageFilterService.FilterImages(Project);
                this.Close();
            }
            else
            {
                MessageBox.Show("筛选条件不完整，请用户补全筛选条件！");
            }
            
        }
    }
}
