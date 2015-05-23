using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;
using Tema3Sem2.Models;

namespace Tema3Sem2.Repositories
{
    public static class TestHelper
    {
        /// <summary>
        /// Generare test
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static CustomTest GenerareTest(int userId, int domeniuId)
        {
            using (var dc = new TesteEntities())
            {
                var ct = new CustomTest();
                Random rnd = new Random();

                var test = new Test();
                test.IdCursant = userId;
                dc.Tests.Add(test);
                dc.SaveChanges();

                ct.IdTest = test.IdTest;
                ct.IdCursant = userId;
                ct.Intrebari = new List<Intrebare>();

                var intrebari = new List<Intrebare>();
                intrebari = dc.Intrebares.Where(a=>a.IdDomeniu == domeniuId).ToList();
                
                int count = 0;
                int simple = 0;
                int multiple = 0;
                while (count < 10)
                {
                    int r = rnd.Next(intrebari.Count);

                    //daca e simpla
                    if (simple < 3 && intrebari[r].Tip == 1)
                    {
                        if (ct.Intrebari.Contains(intrebari[r]))
                        {
                            var list = new List<VariantaRaspun>();
                            list = dc.VariantaRaspuns.Where(a => a.IdIntrebare == intrebari[r].IdIntrebare).ToList();
                            foreach (var l in list)
                            {

                            }
                            ct.Intrebari.Add(intrebari[r]);
                            count++;
                            simple++;
                        }
                    }
                    //daca e multipla
                    else if (multiple < 7 && intrebari[r].Tip == 2)
                    {
                        if (ct.Intrebari.Contains(intrebari[r]))
                        {
                            var list = new List<VariantaRaspun>();
                            list = dc.VariantaRaspuns.Where(a => a.IdIntrebare == intrebari[r].IdIntrebare).ToList();
                            foreach (var l in list)
                            {

                            }
                            ct.Intrebari.Add(intrebari[r]);
                            count++;
                            multiple++;
                        }
                    }
                }
                dc.SaveChanges();
                return ct;
            }
        }

        /// <summary>
        /// stergere test
        /// </summary>
        /// <param name="idTest"></param>
        public static void StergeTest(int idTest)
        {
            using (var dc = new TesteEntities())
            {
                var test = dc.Tests.Find(idTest);
                dc.Tests.Remove(test);
                var list = dc.RaspunsCursants.Where(a => a.IdTest == idTest);
                foreach (var r in list)
                {
                    dc.RaspunsCursants.Remove(r);
                }
                dc.SaveChanges();
            }
        }

    }
}