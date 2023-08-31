using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCV.Models.Entity;

namespace MVCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        //We create our database object.
        DbCVEntities db = new DbCVEntities();
        public ActionResult Index()
        {
            //We pull the data from our table about.
            var values = db.TBL_ABOUT.ToList();
            //We return the extracted data.
            return View(values);
        }
        public PartialViewResult Social()
        {
            var experiences = db.TBL_SOCIAL.ToList();
            return PartialView(experiences);
        }
        //Since there is more than one piece, we cut it into pieces.
        public PartialViewResult Experience()
        {
            var experiences = db.TBL_EXPERIENCES.ToList();
            return PartialView(experiences);
        } 
        public PartialViewResult Education()
        {
            var education = db.TBL_EDUCATION.ToList();
            return PartialView(education);
        }
        public PartialViewResult Skills()
        {
            var skill = db.TBL_SKILLS.ToList();
            return PartialView(skill);
        }
        public PartialViewResult Hobby()
        {
            var hobby = db.TBL_HOBBY.ToList();
            return PartialView(hobby);
        }
        public PartialViewResult Certification()
        {
            var certification = db.TBL_CERTIFICATES.ToList();
            return PartialView(certification);
        }
        //Codes that will run when the page loads.
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        //Codes that will run when the button is clicked.
        [HttpPost]
        public PartialViewResult Contact(TBL_COMMUNICATION t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_COMMUNICATION.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}