using ClaySharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonHelper;
using JinHeMilk.Models;
using Models;

namespace JinHeMilk.Controllers
{
    public class BaseController : Controller
    {
     
        public BaseController()
        {
            //CheckLogin();//检测是否已经登录
            CheckSign();//检测签名是否正确



        }
        /// <summary>
        /// 检测签名是否正确
        /// </summary>
        private void CheckSign()
        {
            Dictionary<string ,string >dic=new Dictionary<string, string>();
            var form = System.Web.HttpContext.Current.Request.Form;//取出所有参数和值
            if(form.Count<=0) return;

            for (int i = 0; i < form.Count; i++)
            {
                dic.Add(form.AllKeys[i], form[i]);

            }
            //按照参数名排序
            dic=dic.OrderBy(i => i.Key) as Dictionary<string,string>;
            var content = "";
            foreach (var item in dic)
            {
                if (item.Key == "sign")
                {
                    continue;
                }
                content += item.Key + item.Value;
            }
            var secretKey = System.Configuration.ConfigurationManager.AppSettings["secretKey"];//拼接待签名的字符串和秘钥
            content = secretKey + content + secretKey;
            //计算Md5
            var md5 = Md5.GetMd5(content);
            //比对签名
            if (md5 != dic["sign"])
            {
                Response.Write(new ResponseData() {Status = -1,ErrorMsg = "签名验证失败!",Data =null});
            }

        }
        /// <summary>
        /// 检测是否已经登录
        /// </summary>
        private void CheckLogin()
        {
            int userId = Convert.ToInt32(Request["userid"]);

            //未登录

            //已登录
            if (userId > 0)
            {
                var userName = Request["userName"];
                var userList = new BLL.UserInfoSevice().GetUserInfo(new UserInfo() { Id = userId }).Result.ToList();
                if (userList.Count <= 0 || userName != userList[0].UserName)//用户id和用户名不匹配,返回错误原因,并重新登录
                {
                    Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(new CommonHelper.ResponseData() { Status = -2, ErrorMsg = "用户不存在,请重新登录!", Data = null }));
                    return;
                }
                LoginUser.LoginUserInfo = new UserInfo() { Id = userId, UserName = userName };
            }
        }
    }
}