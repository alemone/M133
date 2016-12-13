using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpielGut.Klassen
{
    public class Benutzer
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Adresse Adresse { get; set; }
        public string Telefonnummer { get; set; }
        public bool IstMitglied { get; set; }

    }
}