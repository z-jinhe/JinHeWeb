using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
  public  static class Md5
    {
        public static string GetMd5(string input)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var  bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            md5.Dispose();
            return BitConverter.ToString(bytes).ToUpper().Replace("-", "");
        }
    }
}
