﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    public  class ImageService
    {
        /// <summary>
        /// 获取Image图片格式
        /// </summary>
        /// <param name="file">图片以二进制数据流形式保存</param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static  System.Drawing.Imaging.ImageFormat GetImageFormat(FileStream file, out string format)
        {
            byte[] sb = new byte[2];  //这次读取的就是直接0-1的位置长度了.
            file.Read(sb, 0, sb.Length);
            //根据文件头判断
            string strFlag = sb[0].ToString() + sb[1].ToString();
            //察看格式类型
            switch (strFlag)
            {
                //JPG格式
                case "255216":
                    format = ".jpg";
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                //GIF格式
                case "7173":
                    format = ".gif";
                    return System.Drawing.Imaging.ImageFormat.Gif;
                //BMP格式
                case "6677":
                    format = ".bmp";
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                //PNG格式
                case "13780":
                    format = ".png";
                    return System.Drawing.Imaging.ImageFormat.Png;
                //其他格式
                default:
                    format = string.Empty;
                    return null;
            }
        }

        /// <summary>
        /// 获取Image图片格式
        /// </summary>
        /// <param name="_img">图片以image类对象形式</param>
        /// <param name="format">图片的格式，后缀</param>
        /// <returns>以System.Drawing.Imaging.ImageFormat形式返回图片格式</returns>
        public static System.Drawing.Imaging.ImageFormat GetImageFormat(Image _img, out string format)
        {
            if (_img == null)
            {
                format = "";
                return null;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                format = "jpg";
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
            {
                format = "gif";
                return System.Drawing.Imaging.ImageFormat.Gif;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
                format = "png";
                return System.Drawing.Imaging.ImageFormat.Png;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
            {
                format = "bmp";
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            format = string.Empty;
            return null;
        }
    }
}
