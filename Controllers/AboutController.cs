using MVCV.Models.Entity;
using MVCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository repo = new AboutRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var result = repo.List();
            return View(result);
        }
        [HttpPost]
        public ActionResult Index(TBL_ABOUT p)
        {
            var result = repo.Find(x=>x.ID==1);
            result.FirstName = p.FirstName;
            result.LastName = p.LastName;
            result.Address = p.Address;
            result.Phone = p.Phone;
            result.Mail = p.Mail;
            result.Description = p.Description;
            repo.Update(result);
            return RedirectToAction("Index");
        }
    }
}