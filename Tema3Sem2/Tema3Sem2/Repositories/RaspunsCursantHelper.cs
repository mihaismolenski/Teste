using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;

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

    }
}