using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    /// <summary>
    /// 负责将用户的输入（网址、筛选条件）封装成类
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// 用户输入的网址，已经预处理
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// 负责将用户的爬取图片的输入封装成类
    /// </summary>
    public class ImgInputData:InputData
    {        
        /// <summary>
        /// 尺寸范围；最小宽度
        /// </summary>
        public int MinX { get; set; }

        /// <summary>
        /// 尺寸范围；最大宽度
        /// </summary>
        public int MaxX { get; set; }

        /// <summary>
        /// 尺寸范围；最小高度
        /// </summary>
        public int MinY { get; set; }

        /// <summary>
        /// 尺寸范围；最大高度
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// 下载图片的最小尺寸,单位：字节
        /// </summary>
        public int MinSize { get; set; }

        /// <summary>
        /// 下载图片的最大尺寸,单位：字节
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// 支持的的图片类型
        /// </summary>
        public List<ImageFormat> TargetImgFormat;

        /// <summary>
        /// 构造函数，主要对参数初始化
        /// </summary>
        ImgInputData()
        {
            MinX = 0;
            MaxX = int.MaxValue;
            MinY = 0;
            MaxX = int.MaxValue;
            MinSize = 0;
            MaxSize = int.MaxValue;
            TargetImgFormat = new List<ImageFormat>();
            TargetImgFormat.Add(ImageFormat.Png);
            TargetImgFormat.Add(ImageFormat.Jpeg);
            TargetImgFormat.Add(ImageFormat.Bmp);
            TargetImgFormat.Add(ImageFormat.Gif);
            TargetImgFormat.Add(ImageFormat.Tiff);
            TargetImgFormat.Add(ImageFormat.Emf);
            TargetImgFormat.Add(ImageFormat.Icon);
            TargetImgFormat.Add(ImageFormat.Wmf);
            TargetImgFormat.Add(ImageFormat.MemoryBmp);
        }
    }

    /// <summary>
    /// 负责将用户的爬取文本的输入封装成类
    /// （初期版本中不考虑爬取文本的功能实现）
    /// </summary>
    public class TextInputData : InputData
    {
        /// <summary>
        /// 一段文本的最小数量
        /// </summary>
        public int MinCharNum = 0;

        /// <summary>
        /// 一段文本的最大数量
        /// </summary>
        public int MaxCharNum = int.MaxValue;

        /// <summary>
        /// 文本中必须包含的关键词
        /// </summary>
        public List<String> KeyWord;
    }
}
