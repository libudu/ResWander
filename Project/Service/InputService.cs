using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResWander.Data;

namespace ResWander.Service
{
    /// <summary>
    /// 负责对用户输入的网址、筛选条件进行处理（正确性校验、预处理）
    /// </summary>
    abstract public class InputService
    {
        /// <summary>
        /// 调整Url，输入一个url，判断是否以www或http(s)开头，没有则加上
        /// </summary>
        /// <param name="OriginUrl">原Url</param>
        /// <returns>调整后的Url</returns>
        protected string AdjustUrl(string OriginUrl)
        {
            if (OriginUrl.StartsWith("http://") || OriginUrl.StartsWith("https://"))
            {
                return OriginUrl;
            }

            string AdjustedUrl;
            if (OriginUrl.StartsWith("www."))
            {
                AdjustedUrl = "https://" + OriginUrl;
            }
            else
            {
                AdjustedUrl = "https://www." + OriginUrl;
            }
            return AdjustedUrl;
        }

        /// <summary>
        /// 向目标网址发送请求，根据返回的请求头判断网址是否有效
        /// 仅检测链接头，不会获取链接的结果。所以速度很快，超时的时间单位为毫秒
        /// </summary>
        /// <param name="url">目标网址</param>
        /// <returns>返回状态码或错误信息</returns>
        public static string GetWebStatusCode(string url)
        {
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                req.Method = "HEAD";  //这是关键        
                req.Timeout = 100;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                return Convert.ToInt32(res.StatusCode).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (req != null)
                {
                    req.Abort();
                    req = null;
                }
            }
        }
    }

        /// <summary>
        /// 处理图片输入，对接前端组
        /// </summary>
    public class ImgInputService:InputService
    {
        public ImgInputData inputData { get; }

        /// <summary>
        ///  设置图片尺寸范围
        /// </summary>
        /// <param name="MinX">最小宽度</param>
        /// <param name="MaxX">最大宽度</param>
        /// <param name="MinY">最小高度</param>
        /// <param name="MaxY">最大高度</param>
        /// <returns></returns>
        public bool setXYRange(int MinX = 0, int MaxX = int.MaxValue, int MinY = 0, int MaxY = int.MaxValue)
        {
            if(MinX > 0 && MinX <= MaxX && MinY > 0 && MinY <= MaxY)
            {
                inputData.MinX = MinX;
                inputData.MinY = MinY;
                inputData.MaxX = MaxX;
                inputData.MaxY = MaxY;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置图片尺寸范围
        /// </summary>
        /// <param name="MinSize">最小尺寸</param>
        /// <param name="MaxSize">最大尺寸</param>
        /// <returns></returns>
        public bool setSizeRange(int MinSize, int MaxSize)
        {
            if (MinSize > 0 && MaxSize >= MinSize)
            {
                inputData.MinSize = MinSize;
                inputData.MaxSize = MaxSize;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加一个图片格式
        /// </summary>
        /// <param name="Format">图片格式的字符串</param>
        public void addImgFormat(string Format)
        {
            inputData.ImgFormat.Add(Format);
        }

        /// <summary>
        /// 添加一组图片格式
        /// </summary>
        /// <param name="Format">图片格式字符串的数组</param>
        public void addImgFormat(string[] Format)
        {
            inputData.ImgFormat.AddRange(Format);
        }

        public void setUrl(string Url)
        {
            inputData.Url = Url;
        }
    }

    public class TextInputService:InputService
    {
        public TextInputData inputData { get; }

        public void setUrl(string Url)
        {
            inputData.Url = Url;
        }
    }
}
