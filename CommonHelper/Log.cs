using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
  public  static class Log
    {
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="path"></param>
        /// <param name="errorMsg"></param>
        public static void WriteLog(string path,string errorMsg)
        {
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.Create(path);
            }
            System.IO.File.AppendAllText(path,errorMsg+"当前系统时间为:"+DateTime.Now.ToString("yyyy-M-d hh-mm-ss" ));
        }
    }
}
