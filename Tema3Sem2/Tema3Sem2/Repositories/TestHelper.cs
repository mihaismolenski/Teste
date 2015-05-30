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

                List<int> shuffleList = new List<int>();
                for (int i = 0; i < intrebari.Count; i++ )
                {
                    shuffleList.Add(i);
                }
                Shuffle(shuffleList);
                while (count < 10)
                {
                    int r = shuffleList[count];
                    var q = new Intrebare();
                    q.IdDomeniu = intrebari[r].IdDomeniu;
                    q.IdIntrebare = intrebari[r].IdIntrebare;
                    q.IdSubdomeniu = intrebari[r].IdSubdomeniu;
                    q.Text = intrebari[r].Text;
                    q.Tip = intrebari[r].Tip;

                    //daca e simpla
                    if ( q.Tip == 1)
                    {
                        if (!ct.Intrebari.Contains(q))
                        {
                            var list = new List<VariantaRaspun>();
                            list = dc.VariantaRaspuns.Where(a => a.IdIntrebare == q.IdIntrebare).ToList();
                            foreach (var l in list)
                            {
                                q.VariantaRaspuns.Add(l);
                            }
                            ct.Intrebari.Add(q);
                            count++;
                            simple++;
                        }
                    }
                    //daca e multipla
                    else if ( q.Tip == 2)
                    {
                        if (!ct.Intrebari.Contains(q))
                        {
                            var list = new List<VariantaRaspun>();
                            list = dc.VariantaRaspuns.Where(a => a.IdIntrebare == q.IdIntrebare).ToList();
                            foreach (var l in list)
                            {
                                q.VariantaRaspuns.Add(l);
                            }
                            ct.Intrebari.Add(q);
                            count++;
                            multiple++;
                        }
                    }
                }
                dc.SaveChanges();
                return ct;
            }
        }

        public static void Shuffle (List<int> listToShuffle, int numberOfTimesToShuffle = 2)
        {
            //make a new list of the wanted type
            List<int> newList = new List<int>();
            Random _rnd = new Random();

            //for each time we want to shuffle
            for (int i = 0; i < numberOfTimesToShuffle; i++)
            {
                //while there are still items in our list
                while (listToShuffle.Count > 0)
                {
                    //get a random number within the list
                    int index = _rnd.Next(listToShuffle.Count);

                    //add the item at that position to the new list
                    newList.Add(listToShuffle[index]);

                    //and remove it from the old list
                    listToShuffle.RemoveAt(index);
                }

                //then copy all the items back in the old list again
                listToShuffle.AddRange(newList);

                //and clear the new list
                //to make ready for next shuffling
                newList.Clear();
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