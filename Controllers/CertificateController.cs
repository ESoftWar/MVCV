using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCV.Models.Entity;
using MVCV.Repositories;

namespace MVCV.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificationRepository repo = new CertificationRepository();
        public ActionResult Index()
        {
            var result = repo.List();
            return View(result);
        }
        [HttpGet]
        public ActionResult CertificationGet(int id)
        {
            var result = repo.Find(x=>x.ID == id);
            ViewBag.ID = id;
            return View(result);
        }
        [HttpPost]
        public ActionResult CertificationGet(TBL_CERTIFICATES p)
        {
            var result = repo.Find(x => x.ID == p.ID);
            result.Description = p.Description;
            result.Date = p.Date;
            repo.Update(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CertificationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CertificationAdd(TBL_CERTIFICATES p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult CertificationDelete(int id)
        {
            var result = repo.Find(x=>x.ID==id);
            repo.Delete(result);
            return RedirectToAction("Index");
        }
    }
}