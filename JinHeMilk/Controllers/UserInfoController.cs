using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using System.Threading.Tasks;

namespace JinHeMilk.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly BLL.UserInfoSevice _bll = new UserInfoSevice();
        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> UpdateUser(UserInfo use)
        {
            if (CommonHelper.Check.CheckParamsByObj(use))
            {
                return this.JsonNet(new {status=1,msg="请检查输入的参数是否合法!"});
            }
           if(await _bll.UpdateAsync(use)==1)
            return this.JsonNet(new {status=0,msg="修改成功!"});
            return this.JsonNet(new {status = 1, msg = "修改失败,请重新尝试!"});
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> DelUser(UserInfo use)
        {

            return this.JsonNet("");
        }
    }
}