using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpielGut.Klassen
{
    public class Address
    { 
        public string Postleitzahl { get; set; }
        public string Ort { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }

        public Address(string postleitzahl, string ort, string strasse, string hausnummer)
        {
            this.Postleitzahl = postleitzahl;
            this.Ort = ort;
            this.Strasse = strasse;
            this.Hausnummer = hausnummer;
        }

        public Address()
        {
            
        }
    }
}