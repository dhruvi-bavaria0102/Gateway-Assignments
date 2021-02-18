namespace CustomerWebapp1.Models
{
    using System;
    using System.Collections.Generic;
    using SBS.Data;

    public partial class ServiceProvider
    {
        public int id { get; set; }
        public Nullable<int> AppoinmentId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual appoinment appoinment { get; set; }
        public virtual Service Service1 { get; set; }
    }
}
