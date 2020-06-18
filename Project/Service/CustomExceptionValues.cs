using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    public static class CustomExceptionValues
    {
        public enum ExceptionEnum
        {

            /*——————————————网页爬取异常:10000-10010———————————————*/
            // 默认网络爬取异常
            [Display(Name = "默认网页爬取异常")]
            DEFAULT_CRAWL_EXCEPTION = 10000,

            // 网络连接超时
            [Display(Name = "网络连接超时")]
            CONNECT_TIMEOUT_EXCEPTION = 10001,

            // 网址无效
            [Display(Name = "网址无效")]
            NOT_FOUND = 10002,

            /*——————————————微博爬取相关异常异常:10011-10020———————————————*/
            // tid参数尝试多次获取仍然失败
            [Display(Name = "微博网页爬取失败")]
            WEIBO_HTML_FAILED = 10011
        }
        /// <summary>
        /// 作者：邢雄
        /// 功能：获取对应自定义枚举异常的描述，供自定义异常的创建
        /// </summary>
        /// <param name="customException">自定义枚举异常的对象，例如 CustomExceptionValuesEnum.NOT_FOUND</param>
        /// <returns>返回对应自定义枚举异常的描述</returns>
        public static string GetDestription(this Enum customException)
        {
            var type = customException.GetType();//获取传入枚举对象的类型 
            var fieldName = Enum.GetName(type, customException);//获取该传入枚举对象的名称
            //根据System.ComponentModel.DataAnnotations下的DisplayAttribute特性获取显示文本
            var objs = type.GetField(fieldName).GetCustomAttributes(typeof(DisplayAttribute), false);

            //如果没有定义描述，就把当前枚举值的对应名称返回
            return objs.Length > 0 ? ((DisplayAttribute)objs[0]).Name : customException.ToString();
        }

        //使用方式:
        //      if (参数无效) {
        //	 抛出对应自定义业务异常
        //		throw new CustomException(CustomExceptionValuesEnum.PARAMETER_INVALID);
        //  }
    }
}
