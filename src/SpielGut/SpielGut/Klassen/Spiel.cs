using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDG.DataObjectHandler.BaseTypes;

namespace SpielGut.Klassen
{
    public class Spiel : DataObject
    {
        public string Hersteller { get; set; }
        public string Name { get; set; }
        public KategorieEnum Kategorie { get; set; }
        public Preisklasse Preisklasse { get; set; }
        public bool IstAusgeliehen { get; set; } = false;
        public Spiel(string hersteler, string name, KategorieEnum kategorie, Preisklasse preisklasse)
        {
            this.Hersteller = hersteler;
            this.Name = name;
            this.Kategorie = kategorie;
            this.Preisklasse = preisklasse;
        }
        public Spiel()
        {
        }

    }
}