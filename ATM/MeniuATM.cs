using System;

namespace ATM
{
    class MeniuATM
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while(showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Client Nou");
            Console.WriteLine("2) Client Existent");
            Console.WriteLine("3) Meniu Operator Bancar");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    NewClient client=new NewClient();
                    client.autentification();
                    return true;
                case "2":
                    //RemoveWhitespace();
                    return true;
                case "3":
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

    }
}
