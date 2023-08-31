using MVCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_ADMIN p)
        {

            DbCVEntities db = new DbCVEntities();
            var userInfo=db.TBL_ADMIN.FirstOrDefault(x=>x.UserName==p.UserName && x.Password==p.Password);
            if (userInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                Session["UserName"]=userInfo.UserName.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}