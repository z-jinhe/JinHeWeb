using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
   public static class Check
    {
        /// <summary>
        /// 检查字段里面的参数值是否有空值和null,如果有返回true,没有返回false
        /// </summary>
        /// <param name="dicParams"></param>
        /// <returns>有空或者null值返回true,没有返回false</returns>
        public static bool CheckParamsByDir(Dictionary<string,string> dicParams  )
        {
            foreach (var item in dicParams)
            {
                if (string.IsNullOrWhiteSpace(item.Value))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断该对象的属性是否有空值或者null值,如果有返回true,没有返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>true有,false没有</returns>
        public static bool CheckParamsByObj<T>(T obj)
        {
            var type = obj.GetType();
            var pro = type.GetProperties();
            foreach (var item in pro)
            {
                if (string.IsNullOrWhiteSpace(item.GetValue(0).ToString()))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
