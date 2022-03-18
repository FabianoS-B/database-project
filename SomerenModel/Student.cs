using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    { 
        public string Name { get; set; }
        public int StudentID { get; set; } // StudentNumber, e.g. 474791
        public DateTime BirthDate { get; set; }

        public int RoomID { get; set; }

        //public int Room { get; set; }
    }
}
