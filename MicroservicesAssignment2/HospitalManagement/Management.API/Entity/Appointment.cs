using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.API.Entities
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingTime { get; set; }
        public long DoctorID { get; set; }
        public long PatientID { get; set; }
    }
}
