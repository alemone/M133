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

        public Address(string postleitzahl, string ort, string strasse)
        {
            this.Postleitzahl = postleitzahl;
            this.Ort = ort;
            this.Strasse = strasse;
        }

        public Address()
        {
            
        }
    }
}