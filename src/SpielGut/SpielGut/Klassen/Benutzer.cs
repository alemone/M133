﻿using System;
using KDG.DataObjectHandler.BaseTypes;

namespace SpielGut.Klassen
{
    public class Benutzer : DataObject
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Passwort { get; set; }
        public Address Address { get; set; }
        public string Telefonnummer { get; set; }
        public bool IstMitglied { get; set; }
        public bool IstBestaetigt { get; set; }

        public Benutzer(string vorname, string nachname, string email, string passwort, string passwortWiderholen, Address address, string telefonnummer, bool istMitglied = false)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Email = email;
            this.Passwort = passwort;
            this.Address = address;
            this.Telefonnummer = telefonnummer;
            this.IstMitglied = istMitglied;
        }

        public Benutzer()
        {

        }
    }
}
