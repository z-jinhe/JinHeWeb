using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
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
        /// 微信小程序登录
        /// </summary>
        /// <returns></returns>
        public async  Task<ActionResult> WxLogin()
        {

            var unionid = Request["unionid"]; //微信唯一标示
            var username = Request["username"]; //用户昵称即用户名(可重复)
            if (CommonHelper.Check.CheckParamsByDir(new Dictionary<string, string>() { { "id", unionid }, { "username", username } }) || (unionid.Substring(0, 4) != "UID_"))//用户昵称和id有空或者null值
            {
                return  this.JsonNet(new ResponseData() { Status = -2, ErrorMsg = "请使用微信登录", Data = null });
            }
            //检查用户是否已经存在
            var userInfos = await new BLL.UserInfoSevice().GetUserInfoAsync(new UserInfo() { UnionId = unionid }) as UserInfo[];
            if (userInfos != null)
            {
                var loginUser = userInfos[0];
                if (loginUser == null)//用户不存在,创建用户
                {
                    if (! await new BLL.UserInfoSevice().AddUserInfosAsync(new List<UserInfo> { new UserInfo() { UnionId = unionid, UserName = username } }))//添加用户失败
                    {
                        CommonHelper.Log.WriteLog(HttpContext.Server.MapPath("log.txt"), $"新增用户失败,用户unionID为:{unionid},用户昵称为{username}");
                        return Json(new ResponseData() { Status = 1, ErrorMsg = "新增用户失败!请联系管理员!", Data = null });
                    }
                    //添加用户成功
                    var infos = await new BLL.UserInfoSevice().GetUserInfoAsync(new UserInfo() { UnionId = unionid })as UserInfo[];
                    if (infos !=
                        null)
                        loginUser =infos[0];
                }
                //用户已经存在,则返回用户昵称和id
                if (loginUser != null)
                    return this.JsonNet(new ResponseData() { Status = 0, ErrorMsg = "", Data = new { userName = loginUser.UserName, id = loginUser.Id } });
            }
            else
            {
                return this.JsonNet(new ResponseData() { Status = -1, ErrorMsg = "用户不存在", Data = null });
            }
              return this.JsonNet(new ResponseData() { Status = -2, ErrorMsg = "未知错误", Data = null });
        }
        /// <summary>
        /// 退出登录,清除session
        /// </summary>
        /// <returns></returns>
        public ActionResult ExitLogin(UserInfo userInfo)
        {
            HttpContext.Session?.Clear();
            return this.JsonNet(new ResponseData() {Status = 0,ErrorMsg = "",Data = null});
        }
        /// <summary>
        /// 后台用户注册
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Register()
        {
            var username = Request["username"];
            var passwrod = Request["password"];
            var phoneNumber = Request["phoneNumber"];
            //检测空值
            if (CommonHelper.Check.CheckParamsByDir(new Dictionary<string, string> { { "username", username }, { "password", passwrod }, {"phoneNumber",phoneNumber} }))
            {
                return this.JsonNet(new ResponseData() { Status = 1, ErrorMsg = "用户名或密码或手机号不为能空" });
            }
            if (username.Length > 16 || username.Length < 8 || passwrod.Length > 16 || passwrod.Length < 8/*||phoneNumber.Length!=11||Regex.IsMatch(phoneNumber,"[^0-9]{1}")*/)
            {
                //长度不符合规则
                return Json(new ResponseData() { Status = 1, ErrorMsg = "用户名或密码长度不能小于8位或者大于16位!", Data = null });
            }
            var bll = new UserInfoSevice();
            var bl =await bll.AddUserInfosAsync(new List<UserInfo>() { new UserInfo() { UserName = username, Password = passwrod } });
            return bl ? this.JsonNet(new ResponseData { Status = 0, ErrorMsg = "", Data = null }) : this.JsonNet(new ResponseData(){ Status = 1, ErrorMsg = "注册失败,尝试重新注册!",Data = null});
        }


    }
}