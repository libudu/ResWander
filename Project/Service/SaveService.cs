using ResWander.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            string filePath, localFilePath;
            // 利用C#封装好的类进行图片等资源的保存
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // 设置保存的格式等相关信息
            saveFileDialog.Filter = "Jpg 图片|*.jpg|Bmp 图片|*.bmp|Gif 图片|*.gif|Png 图片|*.png|Wmf  图片|*.wmf";
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
                    imageSources[i].Img.Save(fileName[0] + " " + i + "." + fileName[1]);

                }

                // 提示用户保存成功
                MessageBox.Show("已成功保存图片", "保存成功");
                return filePath;
            }
            return null;
        }
    }
}
