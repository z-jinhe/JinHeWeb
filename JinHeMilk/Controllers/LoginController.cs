using ClaySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CommonHelper;
using Models;

namespace JinHeMilk.Controllers
{
    /// <summary>
    /// 登录,退出登录,注册
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            var unionid = Request["unionid"] ; //微信唯一标示
            var username = Request["username"]; //用户昵称即用户名(可重复)
            if (CommonHelper.Check.ParamsHasNullOrWhiteSpaceValue(new Dictionary<string, string>(){{"id", unionid },{"username",username}})|| (unionid.Substring(0,4)!="UID_"))//用户昵称和id有空或者null值
            {
               return  Json(new ResponseData() { Status = -2, ErrorMsg = "请使用微信登录", Data = null });
            }
            //检查用户是否已经存在
            var loginUser=new BLL.UserInfoSevice().GetUserInfo(new UserInfo() { UnionId= unionid}).Result?.ToList()[0];
            if (loginUser == null)//用户不存在,创建用户
            {

              
                if (!new BLL.UserInfoSevice().AddUserInfos(new List<UserInfo> { new UserInfo() { UnionId = unionid, UserName = username } }))//添加用户失败
                {
                    CommonHelper.Log.WriteLog(HttpContext.Server.MapPath("log.txt"),$"新增用户失败,用户unionID为:{unionid},用户昵称为{username}");
                    return Json(new ResponseData() { Status = 1, ErrorMsg = "新增用户失败!请联系管理员!", Data =null });
                }
                //添加用户成功
                loginUser = new BLL.UserInfoSevice().GetUserInfo(new UserInfo() { UnionId = unionid }).Result?.ToList()[0];
            }
            //用户已经存在,则返回用户昵称和id
            return Json(new ResponseData() { Status = 0, ErrorMsg = "", Data = new { userName = loginUser.UserName, id = loginUser.Id } });
        }
        ///// <summary>
        ///// 退出登录,APP直接清除数据即可
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult ExitLogin()
        //{
        //    return null;
        //}
        ///// <summary>
        ///// 注册  登录时候发现未注册,直接使用微信唯一标示注册了
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult Register()
        //{
        //    var username = Request["username"];
        //    var passwrod = Request["password"];
        //    if (username.Length <= 8 || passwrod.Length <= 8)
        //        //长度不符合规则
        //        return Json(new ResponseData() { Status = 1, ErrorMsg = Newtonsoft.Json.JsonConvert.SerializeObject(null), Data = null });
        //    CommonHelper.Check.ParamsHasNullOrWhiteSpaceValue(new Dictionary<string, string> { { "username", username }, { "password", passwrod } });
        //    dynamic createClass = new ClayFactory();
        //    var user = createClass.Person();
        //    user.UserName = username;
        //    user.PassWord = passwrod;

        //    return null;
        //}


    }
}