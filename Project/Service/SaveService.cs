using ResWander.Data;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResWander.Service
{
    /// <summary>
    /// 负责对不同类型资源进行本地保存的父类
    /// 对前端封装图片保存的方法
    /// </summary>
    public class SaveService
    {
        /// <summary>
        /// 前端调用接口：图片文件存储
        /// </summary>
        /// <param name="imageSources">待保存的图片文件</param>
        public static string SaveImages(List<ImgResource> imageSources)
        { 
            return ImageSaver.SaveImage(imageSources);
        }

        /// <summary>
        /// 前端调用接口：保存关键字搜索图片
        /// </summary>
        public static string SaveKeywordImages(string keyword, List<ImgResource> imageSources)
        {
            return KeywordImgSaver.SaveKeywordImg(keyword, imageSources);
        }
    }

    /// <summary>
    ///  用于提供和保存图片相关函数的类
    /// </summary>
    internal class ImageSaver
    {
        /// <summary>
        /// 用于保存指定的图片资源
        /// </summary>
        /// <param name="imageSources">待保存的图片资源</param>
        internal static string SaveImage(List<ImgResource> imageSources)
        {
            string localFilePath;
            string filePath;
            // 利用C#封装好的类进行图片等资源的保存
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 设置保存的格式等相关信息
            saveFileDialog.Filter = "自适应|*.*|Jpg 图片|*.jpg|Bmp 图片|*.bmp|Gif 图片|*.gif|Png 图片|*.png|Wmf  图片|*.wmf";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true; //保存对话框记忆上次打开的目录

            // 打开对话框并保存
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径 
                localFilePath = saveFileDialog.FileName.ToString();
                //获取文件路径，不带文件名 
                filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

                // 依次保存每个文件
                for (int i = 0; i < imageSources.Count; i++)
                {
                    string[] fileName = saveFileDialog.FileName.Split('.');
                    //若选择自适应，按照图片格式保存图片
                    if (saveFileDialog.FilterIndex == 1)
                    {
                        string format = string.Empty;
                        ImageService.GetImageFormat(imageSources[i].Img, out format);

                        if (format == string.Empty)
                        {
                            format = "jpg";
                        }
                        imageSources[i].Img.Save(fileName[0] + " " + i + "." + format);
                    }
                    else
                    {
                        imageSources[i].Img.Save(fileName[0] + " " + i + "." + fileName[1]);
                    }
                }
                // 提示用户保存成功
                MessageBox.Show("已成功保存图片", "保存成功");
                return filePath;
            }
            return null;
        }
    }

    internal class KeywordImgSaver
    {
        /// <summary>
        /// 关键字摘取图片自动保存到目录中
        /// </summary>
        internal static string SaveKeywordImg(string keyword, List<ImgResource> imageSources)
        {
            string path = SelectPath();
            //path是默认路径，文件夹名字是keyword，将它们合并成一个路径
            string savePath = Path.Combine(path, keyword);

            //如果文件夹不存在，创建之
            if (Directory.Exists(savePath) == false)
            {
                Directory.CreateDirectory(savePath);
            }
            //将图片保存在路径中
            Save(savePath, keyword, imageSources);
            return savePath;
        }

        private static string SelectPath()
        {
            string path = string.Empty;

            //打开文件选择窗口选择路径
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            return path;
        }

        private static void Save(string path, string keyword, List<ImgResource> imgResources)
        {
            for(int i = 0;i < imgResources.Count;i++)
            {
                //获取图片的格式
                string format = "";
                ImageService.GetImageFormat(imgResources[i].Img, out format);
                
                //默认格式为jpg
                if(format == string.Empty)
                {
                    format = "jpg";
                }

                //保存图片
                imgResources[i].Img.Save(path + "/" + keyword + " " + i + "." + format);
            }
        }
    }
}
