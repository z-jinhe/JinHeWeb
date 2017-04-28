using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace JinHeMilk.Controllers
{
    public class HomeController : BaseController
    {
        UserInfoSevice Bll = new UserInfoSevice();
        public  ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";
            ViewBag.Name = "zhangsan";
            ViewBag.Age = 14;
            ViewBag.Height = 131;
            var list = Bll.GetList().Result;
            ViewBag.UserList = list;

            return View();
        }

        public ActionResult Update()
        {
           string password = Request["password"];
           var r =  Bll.Update(new UserInfo{Password = password,UserName = "tianmeng"});
           return Json(r.Result);
        }
    }
}
