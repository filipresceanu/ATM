using System;
using System.Collections.Generic;
using System.Text;

namespace Functii
{
    public class OptiuniClient
    {
        Client client = new Client();
        TipCont tipCont = new TipCont();
        public bool CnpVerify(string cnp)
        {

            if (client.CNP == cnp)
                return true;
            else
                return false;
        }
       public void Read()
        {
            Console.WriteLine("Introdu Nume");
            client.Nume = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Numele este:" + client.Nume);

            Console.WriteLine("Introdu Prenume");
            client.Prenume = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Prenumele este:" + client.Prenume);

            Console.WriteLine("Introdu CNP");
            client.CNP = Convert.ToString(Console.ReadLine());
            Console.WriteLine("CNP este:" + client.CNP);

            Console.WriteLine("Introdu Adresa");
            client.Adresa = Convert.ToString(Console.ReadLine());
            Console.WriteLine("CNP este:" + client.Adresa);
        }
        
        public void Afisare()
        {

            Console.WriteLine(client.ToString());

        }
        public void ContOffer()
        {
            bool showOferte = true;
            while (showOferte)
            {
                showOferte = ClientOffer();
            }
        }
        public bool ClientOffer()
        {
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1) Cont Gold");
            Console.WriteLine("2) Cont Silver");
            Console.WriteLine("3) Cont Basic");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                  //  optiuni.Read();

                    return true;
                case "2":
                   // optiuni.
                    return true;
                case "3":
                   // optiuni.Afisare();

                    return true;


                case "4":
                    return false;

                default:
                    return true;
            }
        }
    }
}
