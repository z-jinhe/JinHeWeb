using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace JinHeMilk.Controllers
{
    public class HomeController : Controller
    {
        public  ActionResult Index()
        {
            var Bll= new UserInfoSevice();
            ViewBag.Title = "Home Page";
            var list = Bll.GetList().Result;
            ViewBag.UserList = list;
            
            return View();
        }
    }
}
