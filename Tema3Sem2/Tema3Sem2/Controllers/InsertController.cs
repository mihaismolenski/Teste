using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tema3Sem2.Controllers
{
    public class InsertController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            Console.WriteLine(Request);
            return View();
        }

        [HttpPost]
        public ActionResult Submit()
        {
            Console.WriteLine(Request);
            return View("~/Views/Insert/Index.cshtml"); 
        }
    }
}
