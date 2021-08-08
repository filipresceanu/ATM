using ATM;
using Functii;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meniu_ConsoleATM
{
    class FunctiBanca
    {
        ContBancar contBancar;
        Client client;
        public int GenerarePIN()
        {
           
            Random rnd = new Random();
            int pin = rnd.Next(1, 5);
            return pin;
        }
        public bool CnpVerify(string cnp)
        {

            if (client.CNP == cnp)
                return true;
            else
                return false;
        }

        public bool PinVerify(int PIN)
        {
            if (GenerarePIN() == PIN)
                return true;
            else
                return false;
        }
    }
}
