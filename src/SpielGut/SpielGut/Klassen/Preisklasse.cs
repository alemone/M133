using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpielGut.Klassen
{
    public class Preisklasse
    {
        public int Nummer { get; set; }
        public double TarifMitglied { get; set; }
        public double TarifNichtMitglied { get; set; }
        public Preisklasse(int nummer, double tarifMitglied, double tarifNichtMitglied)
        {
            this.Nummer = nummer;
            this.TarifMitglied = tarifMitglied;
            this.TarifNichtMitglied = tarifNichtMitglied;
        }
    }
}