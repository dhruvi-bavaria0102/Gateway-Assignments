//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SBS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mechanic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MechanicNumber { get; set; }
        public string Contact { get; set; }
        public string EmailID { get; set; }
        public Nullable<int> ServiceID { get; set; }
    
        public virtual Service Service { get; set; }
    }
}
