using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    public class ContBancar
    {
        public int PIN { get; set; }

        public TipCont tipContBancar = new TipCont();

        public float TotalSlod { get; set; }

        public string IBAN { get; set; }

        public int generarePIN()
        {
            Random rnd = new Random();
            int pin = rnd.Next(1000, 9999);
            return pin;
        }
        public void DepunereNumerar(float sold)
        {
            TotalSlod += sold;
            TotalSlod -= (tipContBancar.ProcentDepunere / 100) * sold;

        }
        public void RetragereNumerar(float sold)
        {
            if(TotalSlod>sold)
            {
                TotalSlod -= sold;
            }
        }


    }
}
