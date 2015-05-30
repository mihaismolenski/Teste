using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;
using Tema3Sem2.Models;

namespace Tema3Sem2.Repositories
{
    public static class RaspunsCursantHelper
    {
        /// <summary>
        /// salvam raspunsurile
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idTest"></param>
        /// <param name="idIntrebare"></param>
        /// <param name="idRaspuns"></param>
        public static void TrimiteRaspuns(int idUser, int idTest, int idIntrebare, List<int> idRaspuns)
        {
            using (var dc = new TesteEntities())
            {
                //stergem raspunsurile anterioare
                var raspunsuri = dc.RaspunsCursants.Where(a => a.IdTest == idTest && a.IdIntrebare == idIntrebare);
                foreach (var r in raspunsuri)
                {
                    dc.RaspunsCursants.Remove(r);
                }

                foreach (var r in idRaspuns)
                {
                    var raspuns = new RaspunsCursant();
                    raspuns.IdIntrebare = idIntrebare;
                    raspuns.IdTest = idTest;
                    raspuns.IdRaspuns = r;
                    dc.RaspunsCursants.Add(raspuns);
                }
                dc.SaveChanges();
            }
        }

        public static IntrebareResult ObtineRaspuns(int idUser, int idTest, int idIntrebare)
        {
            using (var dc = new TesteEntities())
            {
                var raspunsuri = dc.RaspunsCursants.Where(a => a.IdTest == idTest && a.IdIntrebare == idIntrebare);
                IntrebareResult intrebare = new IntrebareResult();

                bool ok = true;
                foreach (var r in raspunsuri)
                {
                    if (r.Intrebare.VariantaRaspuns.ToList().FindIndex( x => x.IdRaspuns == r.IdRaspuns && x.Corect == true) < 0)
                    {
                        ok = false;
                        
                    }
                    intrebare.raspunsuriCursant.Add(r.VariantaRaspun.Text);
                }

                intrebare.valid = ok;
                intrebare.text = dc.Intrebares.Where(a => a.IdIntrebare == idIntrebare).FirstOrDefault().Text;
                intrebare.Motivatie = raspunsuri.ToList()[0].Intrebare.VariantaRaspuns.ToList()[0].Motivatie;
                
                return intrebare;
            }
        }


    }


}