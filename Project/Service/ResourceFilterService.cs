using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    /// <summary>
    /// 按照用户选定的筛选条件对下载完的资源进行二次筛选的父类
    /// </summary>
    public abstract class ResourceFilterService
    {
        /// <summary>
        /// 对资源进行二次筛选
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public abstract bool ResourceFilter(Object[] resources);
    }

    /// <summary>
    /// 按照用户选定的筛选条件对下载完的图片进行二次筛选
    /// </summary>
    public class ImageFilterService : ResourceFilterService
    {
        /// <summary>
        /// 对图片进行二次筛选
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public override bool ResourceFilter(object[] resources)
        {
            return false;
        }
    }
}
