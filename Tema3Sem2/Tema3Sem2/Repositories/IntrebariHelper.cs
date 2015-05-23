using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;

namespace Tema3Sem2.Repositories
{
    public static class IntrebariHelper
    {
        /// <summary>
        /// adaugare intrebare
        /// </summary>
        /// <param name="idDomeniu"></param>
        /// <param name="idSubdomeniu"></param>
        /// <param name="text"></param>
        /// <param name="tip"></param>
        /// <param name="variante"></param>
        /// <returns></returns>
        public static int AdaugaIntrebare(int idDomeniu, int idSubdomeniu, string text, int tip, List<VariantaRaspun> variante)
        {
            using (var dc = new TesteEntities())
            {
                var intrebare = new Intrebare();
                intrebare.IdDomeniu = idDomeniu;
                intrebare.IdSubdomeniu = idSubdomeniu;
                intrebare.Text = text;
                intrebare.Tip = tip;
                dc.Intrebares.Add(intrebare);
                foreach (var v in variante)
                {
                    intrebare.VariantaRaspuns.Add(v);
                }
                dc.SaveChanges();
                return intrebare.IdIntrebare;
            }
        }

        /// <summary>
        /// stergere intrebare
        /// </summary>
        /// <param name="id"></param>
        public static void StergeIntrebare(int id)
        {
            using (var dc = new TesteEntities())
            {
                var intrebare = dc.Intrebares.Find(id);
                dc.Intrebares.Remove(intrebare);
                var variateRaspuns = dc.VariantaRaspuns.Where(a => a.IdIntrebare == id);
                foreach (var v in variateRaspuns)
                {
                    dc.VariantaRaspuns.Remove(v);
                }
                dc.SaveChanges();
            }
        }

    }
}