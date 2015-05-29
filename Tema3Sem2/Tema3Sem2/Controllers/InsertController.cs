using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tema3Sem2.Repositories;
using Tema3Sem2.Models;
using Tema3Sem2.Models.DB;

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

        [System.Web.Services.WebMethod]
        public int AddDomain(string domain)
        {
            //int id = DomeniuHelper.AdaugaDomeniu(domain, "");
            int id = 1;
            return id;
        }

        [System.Web.Services.WebMethod]
        public int AddSubDomain(string id, string subdomain)
        {
            //int idSub = SubdomeniuHelper.AdaugaSubomeniu(id, subdomain, "");
            int idSub = 1;
            return idSub;
        }

        [HttpPost]
        public ActionResult Submit()
        {

            //IntrebariHelper.AdaugaIntrebare();
            Console.WriteLine(Request.Form);
           
            var ceva = Request.Form.GetValues(0);
            int idDomeniu = Convert.ToInt32(ceva[0]);
            
            ceva = Request.Form.GetValues(2);
            int idSubdomeniu = Convert.ToInt32(ceva[0]);

            var titlu = Request.Form.GetValues(4)[0];

            List<VariantaRaspun> variante = new List<VariantaRaspun>();

            int nrRaspunsuri = 0;
            for (int i = 5; i < Request.Form.AllKeys.Length - 1; i++)
            {
                VariantaRaspun varianta = new VariantaRaspun();
                if (Request.Form.Keys[i].Contains("question") == true)
                {
                    //int id = Convert.ToInt32(Request.Form.Keys[i].Substring(8, Request.Form.GetValues(i)[0].Length));
                    varianta.Text = Request.Form.GetValues(i)[0];
                    if (Request.Form.Keys[i + 1].Contains("answer") == true)
                    {
                        varianta.Corect = true;
                        nrRaspunsuri++;
                        i++;
                    }
                    else
                    {
                        varianta.Corect = false;
                    }

                }
                variante.Add(varianta);
            }
            int tip = 1;
            if (nrRaspunsuri > 1)
            {
                tip = 2;
            }

            
            //IntrebariHelper.AdaugaIntrebare(idDomeniu, idSubdomeniu, titlu, tip, variante);
            
            return View("~/Views/Insert/Index.cshtml"); 
        }

    }
}
