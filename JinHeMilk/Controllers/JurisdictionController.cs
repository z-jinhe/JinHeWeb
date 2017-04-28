using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JinHeMilk.Controllers
{
    /// <summary>
    /// 权限增删改
    /// </summary>
    public class JurisdictionController : Controller
    {
        /// <summary>
        /// 增加权限
        /// </summary>
        /// <returns></returns>
        public ActionResult AddJurisdiction()
        {
            return View();
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <returns></returns>
        public ActionResult DelJurisdiction()
        {
            return null;

        }
    }
}