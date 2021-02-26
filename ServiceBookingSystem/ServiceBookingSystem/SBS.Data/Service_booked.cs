namespace CustomerWebapp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service_Booked
{
    public int id { get; set; }
    public Nullable<int> appoinmentId { get; set; }
    public Nullable<int> ServiceId { get; set; }
    public Nullable<decimal> Price { get; set; }

    public virtual appoinment appoinment { get; set; }
    public virtual Service1 Service1 { get; set; }
}
}
