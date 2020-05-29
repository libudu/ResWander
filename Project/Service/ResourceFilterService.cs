using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWander.Data;

namespace ResWander.Service
{
    ///// <summary>
    ///// 按照用户选定的筛选条件对下载完的资源进行二次筛选的父类
    ///// </summary>
    //public abstract class ResourceFilterService
    //{
    //    /// <summary>
    //    /// 对资源进行二次筛选
    //    /// </summary>
    //    /// <param name="resources"></param>
    //    /// <returns></returns>
    //    public abstract bool ResourceFilter(Object[] resources);
    //}

    /// <summary>
    /// 按照用户选定的筛选条件对下载完的图片进行二次筛选
    /// </summary>
    public class ImageFilterService 
    {
        /// <summary>
        /// 将下载好的图片进行二次筛选
        /// </summary>
        /// <param name="imageSources">将待筛选的目标图片传入</param>
        /// <param name="imgInputData">筛选条件</param>
        /// <returns>将筛选结果返回</returns>
        public static List<Image> FilterImages(List<Image> imageSources, ImgInputData imgInputData)
        {
            // 按照宽度、高度、大小、格式对图片进行筛选
            imageSources.RemoveAll(img =>
            {
                // 宽、高度晒窜
                if (img.Width < imgInputData.MinY ||
                img.Width > imgInputData.MaxY ||
                img.Height < imgInputData.MinX ||
                img.Height > imgInputData.MaxX)
                {
                    return true;
                }

                // 图片文件大小筛选
                if (img.PropertyItems.FirstOrDefault().Len < imgInputData.MinSize ||
                img.PropertyItems.FirstOrDefault().Len > imgInputData.MaxSize)
                {
                    return true;
                }

                // 图片格式筛选
                if (!imgInputData.TargetImgFormat.Contains(img.RawFormat))
                {
                    return true;
                }

                // 如果三者均满足条件，则不删除
                return false;
            });

            return imageSources;
        }
    }
}
