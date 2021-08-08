using Functii;
using Meniu_ConsoleATM;
using System;
using System.Collections.Generic;

namespace ATM
{
    public class MeniuATM
    {
        static Banca _banca = new Banca();
        //static ContBancar cont = new ContBancar();
        public static void Main()
        {
            Client client = new Client();
            _banca.clients.Add(client);
            client.Adresa = "as";
            client.CNP = "1231";
            client.Nume = "asa";
            client.Prenume = "asda";


            ContBancar contBancar = new ContBancar();
            client.Conturi.Add(contBancar);
            contBancar.IBAN = "1231231";
            contBancar.PIN = 123;
            contBancar.TotalSold = 1231;
            TipCont tipCont = new TipCont();
            contBancar.tipContBancar.Nume = "Gold";
            contBancar.tipContBancar.ProcentDepunere = 1;
            contBancar.tipContBancar.SumaFixaDepunere = 1;
            contBancar.tipContBancar.SumaFixaRetragere = 444;
        
            ContBancar contBancar1 = new ContBancar();
            contBancar1.IBAN = "121ddd";
            contBancar1.PIN = 444;
            contBancar1.TotalSold = 23;
            client.Conturi.Add(contBancar1);
            MainMenuATM();
        }
        public static void MainMenuATM()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Client Nou");
            Console.WriteLine("2) Client Existent");
            Console.WriteLine("3) Meniu Operator Bancar");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    autentification();
                    return true;
                case "2":
                    AppExistingClients();
                    return true;
                case "3":

                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        public static void autentification()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MenuNewClient();
            }
        }
        private static bool MenuNewClient()
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
                    AdaugaClientNOU();
                    return true;
                case "2":
                    Console.WriteLine(_banca.clients.Count);
                    return true;
                case "3":

                    return true;
                case "4":
                    return false;

                default:
                    return true;
            }
        }
        public static void AdaugaClientNOU()
        {
            Client client = new Client();
            _banca.clients.Add(client);
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
            Console.WriteLine("Adresa este:" + client.Adresa);
        }

        public static void AppExistingClients()
        {

            var client = ExistingCNPClients();
            var clientPIN = client.Conturi.Find(x => x.PIN == ReadPIN());
            if (clientPIN != null)
            {

                ExistingClientsMenu();
            }

        }
        public static Client ExistingCNPClients()
        {
            var client = _banca.clients.Find(x => x.CNP == ReadCNP());
            if (client != null)
            {
                return client;

            }
            return null;
        }

        public static bool ExistingClientsMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Verificare Sold");
            Console.WriteLine("2) Retragere Numerar");
            Console.WriteLine("3) Depunere Numerar");
            Console.WriteLine("4) Schimb PIN");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");
            var client = ExistingCNPClients();
            
            switch (Console.ReadLine())
            {
                case "1":
                    //var client = ExistingCNPClients();
                   // Console.WriteLine(client.SoldTotalConturi());
                    return true;
                case "2":
                    //RemoveWhitespace();
                    return true;
                case "3":
                    client.Conturi[0].DepunereNumerar(7);
                    
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
        public static string ReadCNP()
        {
            string CNP;
            Console.WriteLine("Introdu CNP pentru verificare identitate");
            CNP = Convert.ToString(Console.ReadLine());
            return CNP;
        }
        public static int ReadPIN()
        {
            int PIN;
            Console.WriteLine("Introdu PIN pentru verificare identitate");
            PIN = Convert.ToInt32(Console.ReadLine());
            return PIN;
        }
        public static float AddSold()
        {
            float addSold;
            Console.WriteLine("Adauga Sold");
            addSold = (float)Convert.ToInt32(Console.ReadLine());
            return addSold;
        }

    }
}
