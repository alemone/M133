﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers.BaseTypes;

namespace SpielGut.Klassen
{
    public class Ausleihe : DataObject
    {
        public Benutzer Benutzer { get; set; }
        public Spiel Spiel { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EndDatum { get; set; }
        public double Kosten { get; set; }
        public Ausleihe(Benutzer benutzer, Spiel spiel)
        {
            this.Benutzer = benutzer;
            this.Spiel = spiel;
        }
        public Ausleihe()
        {

        }
        public void Verlaengern(int anzWochen)
        {

        }
    }
}