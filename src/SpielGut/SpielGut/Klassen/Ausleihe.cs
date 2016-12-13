using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpielGut.Klassen
{
    public class Ausleihe
    {
        public Benutzer Benutzer { get; set; }
        public Spiel Spiel { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EndDatum { get; set; }
        public void Verlaengern(int anzWochen)
        {

        }
    }
}