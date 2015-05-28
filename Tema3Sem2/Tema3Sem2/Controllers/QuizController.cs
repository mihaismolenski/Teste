using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tema3Sem2.Controllers
{
    public class QuizController : Controller
    {
        //
        // GET: /Quiz/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit()
        {
            string[] keys = Request.Form.AllKeys;
           
                Response.Write("Form: " + Request["group"] + "<br>");
            
            return Content("Thanks", "text/html");
        }

    }
}
