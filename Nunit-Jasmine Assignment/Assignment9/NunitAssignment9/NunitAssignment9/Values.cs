using System;
using System.Collections.Generic;
using System.Text;

namespace NunitAssignment9
{
    public class Values
    {
        public int Id;
        public string Name;
        public string Address ;
        public virtual List<Values> GetValues()
        {
            List<Values> readers = new List<Values>()
            {
                new Values {
                    Id = 1001,
                    Name = "Ms. Dhruvi",
                    Address = "GIDC Ankleshwar"
                },
                new Values {
                    Id = 1002,
                    Name = "Mr. Atul",
                    Address = "GIDC Ankleshwar - 393002"
                }

            };
            return readers;

        }
    }
}
