//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tema3Sem2.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test
    {
        public Test()
        {
            this.RaspunsCursants = new HashSet<RaspunsCursant>();
        }
    
        public int IdTest { get; set; }
        public Nullable<int> IdCursant { get; set; }
    
        public virtual Cursant Cursant { get; set; }
        public virtual ICollection<RaspunsCursant> RaspunsCursants { get; set; }
    }
}
