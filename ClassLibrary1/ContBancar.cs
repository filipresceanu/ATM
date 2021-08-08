using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    public class ContBancar
    {
        public int ID { get; set; }
        public int PIN { get; set; }

        public string Moneda { get; set; }

        public TipCont tipContBancar = new TipCont();

        public float TotalSold { get; set; }

        public string IBAN { get; set; }

        public DateTime Data { get; set; }

        public int generarePIN()
        {
            Random rnd = new Random();
            PIN = rnd.Next(1000, 9999);
            return PIN;
             
        }
        public void DepunereNumerar(float sold)
        {
            TotalSold += sold;
            TotalSold -= (tipContBancar.ProcentDepunere / 100) * sold;

        }
        public void RetragereNumerar(float sold)
        {
            if(TotalSold>sold)
            {
                TotalSold -= sold;
                TotalSold -= (tipContBancar.ProcentRetragere / 100) * sold;
            }
        }
        public void Transfer(float sold)
        {
            if (TotalSold > sold)
            {
                TotalSold -= sold;
                
            }
        }
        public void SchimbPIN(int schimbarePIN)
        {
            PIN = schimbarePIN;
        }
        public string RandomIBAN()
        {
            String startWith = "RO";
            Random generator = new Random();
            String r = generator.Next(0, 999999).ToString("D6");
            String num = generator.Next(10, 99).ToString("D6");
            String aAccounNumber = startWith + num+CharacterIBAN()+num;
            IBAN = aAccounNumber;
            return IBAN;

        }
        private string CharacterIBAN()
        {
            int length = 3;

            
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

       
    }
}
