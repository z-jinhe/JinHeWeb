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
        public static bool ParamsHasNullOrWhiteSpaceValue(Dictionary<string,string> dicParams  )
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

    }
}
