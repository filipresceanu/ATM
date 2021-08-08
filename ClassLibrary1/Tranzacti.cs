using ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public  class Tranzacti
    {
        public int  ID { get; set; }

        public ContBancar cont = new ContBancar();

        public string  operatia { get; set; }

        public float  Sold { get; set; }
#nullable enable
        public int ? contDestinatie { get; set; }
#nullable disable
        public DateTime dateTime { get; set; }

    }
}
