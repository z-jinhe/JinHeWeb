using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    public class ResponseData
    {

        /// <summary>
        /// 状态码,0为正常,-1签名验证失败,-2需要重新登录,其他异常错误
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 错误信息内容
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 返回的数据对象
        /// </summary>
        public object Data { get; set; }
    }
}
