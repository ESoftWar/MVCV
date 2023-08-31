using MVCV.Models.Entity;
using MVCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult ExperienceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperienceAdd(TBL_EXPERIENCES p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult ExperienceDelete(int id)
        {
            TBL_EXPERIENCES t = repo.Find(x => x.ID == id);
            repo.Delete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ExperienceGet(int id)
        {
            TBL_EXPERIENCES t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult ExperienceGet(TBL_EXPERIENCES p)
        {
            TBL_EXPERIENCES t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subheading = p.Subheading;
            t.Description = p.Description;
            t.Date = p.Date;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}