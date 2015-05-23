using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tema3Sem2.Models.DB;

namespace Tema3Sem2.Models
{
    public class CustomTest
    {
        public int IdTest { get; set; }
        public int IdCursant { get; set; }
    
        public List<Intrebare> Intrebari { get; set; }
    }
}