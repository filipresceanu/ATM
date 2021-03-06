using ATM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Functii
{
    public class Client
    {
        public int ID { get; set; }
        public Client()
        {
            Conturi = new List<ContBancar>();
        }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }

        public string CNP { get; set; }

        public float SoldTotal { get; set; }
        public List<ContBancar> Conturi { get; set; }

        public override string ToString()
        {
            return "Nume: " + Nume + "Prenume: " + Prenume + "Adresa: " + Adresa + "CNP: " + CNP;
        }
        public void SoldTotalConturi()
        {
            
            
           foreach(var cont in Conturi)
            {
                SoldTotal += cont.TotalSold;
            }
            
        }
        

    }
}
