using MVCV.Models.Entity;
using MVCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult EducationAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult EducationAdd(TBL_EDUCATION p)
        {
            //If it's empty, go back here
            if (!ModelState.IsValid)
            {
                return View("EducationAdd");
            }
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult EducationDelete(int id)
        {
            var result = repo.Find(x=>x.ID == id);
            repo.Delete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EducationGet(int id)
        {
            var result = repo.Find(x => x.ID == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EducationGet(TBL_EDUCATION p)
        {
            //If it's empty, go back here
            if (!ModelState.IsValid)
            {
                return View("EducationGet");
            }
            var result = repo.Find(x => x.ID == p.ID);
            result.Title = p.Title;
            result.Subheading1 = p.Subheading1;
            result.Subheading2 = p.Subheading2;
            result.GPA = p.GPA;
            result.Date = p.Date;
            repo.Update(result);
            return RedirectToAction("Index");
        }
    }
}