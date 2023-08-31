using MVCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCV.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        HobbyRepository repo = new HobbyRepository();
        public ActionResult Index()
        {
            var result = repo.List();
            return View(result);
        }
    }
}