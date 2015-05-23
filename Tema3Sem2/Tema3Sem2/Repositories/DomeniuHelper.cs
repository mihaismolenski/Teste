using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;

namespace Tema3Sem2.Repositories
{
    public static class DomeniuHelper
    {
        /// <summary>
        /// adauga domeniu
        /// </summary>
        /// <param name="nume"></param>
        /// <param name="descriere"></param>
        /// <returns></returns>
        public static int AdaugaDomeniu(string nume, string descriere)
        {
            using (var dc = new TesteEntities())
            {
                var domeniu = new Domeniu();
                domeniu.Nume = nume;
                domeniu.Descriere = descriere;
                dc.Domenius.Add(domeniu);
                dc.SaveChanges();
                return domeniu.IdDomeniu;
            }
        }

        /// <summary>
        /// modificare domeniu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nume"></param>
        /// <param name="descriere"></param>
        public static void ModificaDomeniu(int id, string nume, string descriere)
        {
            using (var dc = new TesteEntities())
            {
                var domeniu = dc.Domenius.Find(id);
                domeniu.Nume = nume;
                domeniu.Descriere = descriere;
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// stergere domeniu
        /// </summary>
        /// <param name="id"></param>
        public static void StergeDomeniu(int id)
        {
            using (var dc = new TesteEntities())
            {
                var domeniu = dc.Domenius.Find(id);
                dc.Domenius.Remove(domeniu);
                dc.SaveChanges();
            }
        }
    }
}