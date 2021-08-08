using ATM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Functii
{
    public class Client
    {
        public Client()
        {
            Conturi = new List<ContBancar>();
        }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }

        public string CNP { get; set; }

        public List<ContBancar> Conturi { get; set; }

        public override string ToString()
        {
            return "Nume: " + Nume + "Prenume: " + Prenume + "Adresa: " + Adresa + "CNP: " + CNP;
        }
        public float SoldTotalConturi()
        {
            float totalSold=0;
            
           foreach(var cont in Conturi)
            {
                totalSold += cont.TotalSlod;
            }
            return totalSold;
        }
        

    }
}
