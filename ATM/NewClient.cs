using Functii;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class NewClient
    {
        
        OptiuniClient optiuni = new OptiuniClient();
        public void autentification()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MenuNewClient();
            }
        }
        private  bool MenuNewClient()
        {
            
            Console.WriteLine("Choose an option: Introdu Nume,Prenume,CNP,Adresa");
            Console.WriteLine("1) Introdu Date");
            Console.WriteLine("2) Oferta Cont");
            Console.WriteLine("3) Afisare");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    optiuni.Read();
                    
                    return true;
                case "2":
               //     optiuni.
                    return true;
                case "3":
                    optiuni.Afisare();
                    
                    return true;
                  

                case "4":
                    return false;
                                                     
                default:
                    return true;
            }
        }
    }
}
