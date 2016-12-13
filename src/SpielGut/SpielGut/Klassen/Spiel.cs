using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers.BaseTypes;

namespace SpielGut.Klassen
{
    public class Spiel : DataObject
    {
        public string Hersteller { get; set; }
        public string Name { get; set; }
        public Kategorie Kategorie { get; set; }
        public Preisklasse Preisklasse { get; set; }
        public bool IstAusgeliehen { get; set; }

    }
}