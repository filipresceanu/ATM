using System;
using System.Collections.Generic;
using System.Text;

namespace Functii
{
    public class Client
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }

        public string CNP { get; set; }


        public override string ToString()
        {
            return "Nume: "+Nume+"Prenume: "+Prenume+"Adresa: "+Adresa+"CNP: "+CNP;
        }

    }
}
