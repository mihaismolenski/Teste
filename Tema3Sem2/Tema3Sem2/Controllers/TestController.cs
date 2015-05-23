using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema3Sem2.Repositories;
using Tema3Sem2.Models.DB;


namespace Tema3Sem2.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            //var list = new Models.CustomTest();
            //list = Repositories.TestHelper.GenerareTest(1, 2);
            /*int id = DomeniuHelper.AdaugaDomeniu("test", "testd");
            DomeniuHelper.ModificaDomeniu(id, "testt", "testdd");
            DomeniuHelper.StergeDomeniu(id);

            id = SubdomeniuHelper.AdaugaSubomeniu(2,"subd:", "submd");
            SubdomeniuHelper.ModificaSubdomeniu(id, "stestt", "stestdd");
            SubdomeniuHelper.StergeSubdomeniu(id);

            id = CursantHelper.AdaugaCursant("popa", "popa", "popa");
            CursantHelper.UpdateCursant(id, "as", "as", "as");
            CursantHelper.StergeCursant(id);*/
            /*List<int> l= new List<int>();
            l.Add(1);
            l.Add(2);
            RaspunsCursantHelper.TrimiteRaspuns(1, 6, 1, l);*/
            var list = new List<VariantaRaspun>();
            var a = new VariantaRaspun();
            a.Text = "test";
            a.Motivatie = "asa";
            a.Corect = true;
            list.Add(a);
            IntrebariHelper.AdaugaIntrebare(2, 1, "testIntrebare", 1, list);

            return View();
        }

    }
}
