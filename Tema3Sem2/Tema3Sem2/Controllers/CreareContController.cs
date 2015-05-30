using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tema3Sem2.Repositories;

namespace Tema3Sem2.Controllers
{
    public class CreareContController : Controller
    {
        //
        // GET: /CreareCont/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(string UserName, string Password,string Hint)
        {
         //   CursantHelper.AdaugaCursant(UserName , Password, Hint);
            return RedirectToAction("Index", "Home");

           // return View() ;
        }
    }
}
