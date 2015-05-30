using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema3Sem2.Models;
using Tema3Sem2.Repositories;
using Tema3Sem2.Models.DB;

namespace Tema3Sem2.Controllers
{
    public class QuizController : Controller
    {
        private static CustomTest test;
        private static int count = 0;
        //
        // GET: /Quiz/
        public ActionResult Index()
        {
            List<Domeniu> domenii = DomeniuHelper.GetDomenii();
            CustomDomain customDomain = new CustomDomain();
            customDomain.Domenii = DomeniuHelper.GetDomenii();
            return View(customDomain);
        }

        public ActionResult Test()
        {
            test = GetQuiz(1, 1);
            count = 0;
            return View(test);
        }

        [HttpPost]
        public int Submit()
        {
            string[] keys = Request.Form.AllKeys;
            int questonId = Convert.ToInt32(Request.Form.GetValues(0)[0]);

            List<int> raspunsuri = new List<int>();
            foreach (string option in Request.Form.GetValues(1))
            {
                int id = Convert.ToInt32(option);
                raspunsuri.Add(id);
            }
            
            RaspunsCursantHelper.TrimiteRaspuns(test.IdCursant, test.IdTest, questonId, raspunsuri);
            count++;
            return count;
        }

        public ActionResult Results()
        {
            //"~/Views/Quiz/Results.cshtml"
            ResultModel resultModel = new ResultModel();
            foreach (var question in test.Intrebari)
            {
                IntrebareResult raspunsuri = RaspunsCursantHelper.ObtineRaspuns(test.IdCursant, test.IdTest, question.IdIntrebare);
                resultModel.raspunsuri.Add(raspunsuri);
            }
            return View(resultModel); 
        }


        public CustomTest GetQuiz(int userId, int idDomeniu)
        {
            return TestHelper.GenerareTest(userId, idDomeniu);
        }
    }
}
