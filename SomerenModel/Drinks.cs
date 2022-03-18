using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    { 
        public string Name { get; set; }
        public int DrinkID { get; set; } // StudentNumber, e.g. 474791
        public bool IsAlcoholic { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public int Stock { get; set; }

        //public int Room { get; set; }
    }
}
