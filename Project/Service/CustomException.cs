using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWander.Service
{
    public class CustomException : ApplicationException
    {
        /// <summary>
        /// 功能：根据传入异常信息构建自定义业务异常
        /// </summary>
        /// <param name="message">异常信息</param>
        public CustomException(string message) : base(message)
        {          
        }

        /// <summary>
        /// 功能：根据传入事先封装好的异常枚举类型构建自定义业务异常
        /// </summary>
        /// <param name="exception">事先封装好的异常枚举类型，例如CustomExceptionValues.ExceptionEnum.CONFLICT</param>
        public CustomException(CustomExceptionValues.ExceptionEnum exception) : base(exception.GetDestription())
        {
        }

    }

}
