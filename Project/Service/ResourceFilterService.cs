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
        public static List<ImgResource> FilterImages(Project project)
        {
            List<ImgResource> imgResourcesRow = project.ImgResourcesContainer.RowImages;
            List<ImgResource> imgResourcesProcessed = project.ImgResourcesContainer.ProcessedImages;
            ImgInputData imgInputData = project.ImgInputData;
            imgResourcesProcessed.Clear();
            // 按照宽度、高度、大小、格式对图片进行筛选
            foreach (ImgResource img in imgResourcesRow)
            {
                if(img == null)
                {
                    continue;
                }
                if(img.Img == null)
                {
                    continue;
                }
                if(imgInputData == null)
                {
                    continue;
                }
                // 宽、高度筛选
                if (img.Img.Width < imgInputData.MinY ||
                img.Img.Width > imgInputData.MaxY ||
                img.Img.Height < imgInputData.MinX ||
                img.Img.Height > imgInputData.MaxX)
                {
                    continue;
                }

                // 图片文件大小筛选
                if (img.Img.PropertyItems.FirstOrDefault().Len < imgInputData.MinSize ||
                img.Img.PropertyItems.FirstOrDefault().Len > imgInputData.MaxSize)
                {
                    continue;
                }

                // 图片格式筛选
                if (!imgInputData.TargetImgFormat.Contains(img.Img.RawFormat))
                {
                    continue;
                }

                // 如果三者均满足条件，加入到筛选列表
                imgResourcesProcessed.Add(img);
            }

            return imgResourcesProcessed;
        }
    }
}
