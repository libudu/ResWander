﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Data
{
    ///// <summary>
    ///// 所有解析完毕的资源类型的父类
    ///// </summary>
    //public class ProcessedResource
    //{
    //    /// <summary>
    //    /// 存储资源
    //    /// </summary>
    //    public List<Object> Resources { get; set; }
    //}

    /// <summary>
    /// 图片集合类
    /// </summary>
    public class ImgResourcesContainer
    {
        /// <summary>
        /// 下载下来的未经筛选的图片集合
        /// </summary>
        public List<ImgResource> RowImages { get; set; }

        /// <summary>
        /// 经过筛选条件筛选之后的图片集合
        /// </summary>
        public List<ImgResource> ProcessedImages { get; set; }

        /// <summary>
        /// 百度搜寻关键字得到的图片
        /// </summary>
        public List<ImgResource> SearchedImages { get; set; }

        public ImgResourcesContainer()
        {
            RowImages = new List<ImgResource>();
            ProcessedImages = new List<ImgResource>();
        }
    }
}
