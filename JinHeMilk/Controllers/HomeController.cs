using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace JinHeMilk.Controllers
{
    public class HomeController: Controller
    {
        
        readonly UserInfoSevice _bll = new UserInfoSevice();
        public async Task< ActionResult>  Index()
        {

            ViewBag.Title = "Home Page";
            var task = await _bll.GetListAsync();
            var list = task;
            ViewBag.UserList = list;
            return  View();
        }

        public async Task<ActionResult> Update()
        {
            string password = Request["password"];
            var r = await _bll.UpdateAsync(new UserInfo { Password = password, UserName = "tianmeng" });
            
            return this.JsonNet(r);
           
        }
    }
}