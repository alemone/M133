using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KDG.DataObjectHandler.BaseTypes;


namespace SpielGut.Klassen
{
    public class Ausleihe : DataObject
    {
        public Benutzer Benutzer { get; set; }
        public Spiel Spiel { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EndDatum { get; set; }

        public double Kosten => this.Benutzer.IstMitglied
            ? this.Spiel.Preisklasse.TarifMitglied
            : this.Spiel.Preisklasse.TarifNichtMitglied;

        public Ausleihe(Benutzer benutzer, Spiel spiel)
        {
            this.Benutzer = benutzer;
            this.Spiel = spiel;
            this.StartDatum = DateTime.Today;
            this.EndDatum = DateTime.Today.AddDays(7);
        }
        public Ausleihe()
        {

        }
        public void Verlaengern(int anzWochen)
        {
                this.EndDatum = this.EndDatum.AddDays(anzWochen*7);
        }
    }
}