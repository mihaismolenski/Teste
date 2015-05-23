using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;

namespace Tema3Sem2.Repositories
{
    public static class SubdomeniuHelper
    {
        /// <summary>
        /// adauga domeniu
        /// </summary>
        /// <param name="nume"></param>
        /// <param name="descriere"></param>
        /// <returns></returns>
        public static int AdaugaSubomeniu(int idDomeniu, string nume, string descriere)
        {
            using (var dc = new TesteEntities())
            {
                var subdomeniu = new Subdomeniu();
                subdomeniu.Nume = nume;
                subdomeniu.Descriere = descriere;
                subdomeniu.IdDomeniu = idDomeniu;
                dc.Subdomenius.Add(subdomeniu);
                dc.SaveChanges();
                return subdomeniu.IdSubdomeniu;
            }
        }

        /// <summary>
        /// modificare domeniu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nume"></param>
        /// <param name="descriere"></param>
        public static void ModificaSubdomeniu(int id, string nume, string descriere)
        {
            using (var dc = new TesteEntities())
            {
                var subdomeniu = dc.Subdomenius.Find(id);
                subdomeniu.Nume = nume;
                subdomeniu.Descriere = descriere;
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// stergere domeniu
        /// </summary>
        /// <param name="id"></param>
        public static void StergeSubdomeniu(int id)
        {
            using (var dc = new TesteEntities())
            {
                var subdomeniu = dc.Subdomenius.Find(id);
                dc.Subdomenius.Remove(subdomeniu);
                dc.SaveChanges();
            }
        }
    }
}