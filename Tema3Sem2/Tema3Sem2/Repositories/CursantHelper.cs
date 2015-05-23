using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;

namespace Tema3Sem2.Repositories
{
    public static class CursantHelper
    {
        /// <summary>
        /// adaugare nou cursant in baza de date
        /// </summary>
        /// <param name="nume"></param>
        /// <param name="parola"></param>
        /// <param name="hint"></param>
        /// <returns></returns>
        public static int AdaugaCursant(string nume, string parola, string hint)
        {
            using (var dc = new TesteEntities())
            {
                var user = new Cursant();
                user.UserName = nume;
                user.Password = parola;
                user.Hint = hint;
                dc.Cursants.Add(user);
                dc.SaveChanges();
                return user.IdCursant;
            }
        }

        /// <summary>
        /// Update Cursant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nume"></param>
        /// <param name="parola"></param>
        /// <param name="hint"></param>
        public static void UpdateCursant(int id, string nume, string parola, string hint)
        {
            using (var dc = new TesteEntities())
            {
                var user = dc.Cursants.Find(id);
                user.UserName = nume;
                user.Password = parola;
                user.Hint = hint;
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// Stergere cursant
        /// </summary>
        /// <param name="id"></param>
        public static void StergeCursant(int id)
        {
            using (var dc = new TesteEntities())
            {
                var user = dc.Cursants.Find(id);
                dc.Cursants.Remove(user);
                dc.SaveChanges();
            }
        }

    }
}