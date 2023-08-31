using MVCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCV.Repositories;

namespace MVCV.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        
        //GenericRepository<TBL_SKILLS> repo = new GenericRepository<TBL_SKILLS>();
        SkillRepository repo = new SkillRepository();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillAdd(TBL_SKILLS p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult SkillDelete(int id)
        {
            var result = repo.Find(x=> x.ID == id);
            repo.Delete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SkillGet(int id)
        {
            var result = repo.Find(x => x.ID == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult SkillGet(TBL_SKILLS p)
        {
            var result = repo.Find(x => x.ID == p.ID);
            result.Skill = p.Skill;
            result.Progress = p.Progress;
            repo.Update(result);
            return RedirectToAction("Index");
        }
    }
}