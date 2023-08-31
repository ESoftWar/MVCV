using MVCV.Models.Entity;
using MVCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCV.Controllers
{
    public class SocialController : Controller
    {
        // GET: Social
        SocialRepository repo = new SocialRepository();
        public ActionResult Index()
        {
            var result = repo.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TBL_SOCIAL p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var result = repo.Find(x => x.ID == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Update(TBL_SOCIAL p)
        {
            var result = repo.Find(x => x.ID == p.ID);
            result.NAME = p.NAME;
            result.LINK = p.LINK;
            result.ICON = p.ICON;
            repo.Update(result);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = repo.Find(x => x.ID == id);
            repo.Delete(result);
            return RedirectToAction("Index");
        }
    }
}