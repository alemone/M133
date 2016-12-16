using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using KDG.DataObjectHandler.BaseTypes;
using Newtonsoft.Json;
using JsonSerializer = KDG.DataObjectHandler.Serializers.Json.JsonSerializer;

namespace SpielGut.Klassen
{
    public class Spiel : DataObject
    {
        public string Hersteller { get; set; }
        public string Name { get; set; }
        public KategorieEnum Kategorie { get; set; }
        public Preisklasse Preisklasse { get; set; }

        

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
        
        [JsonIgnore]
        public bool IstAusgeliehen
        {
            get
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                var ausleihen = jsonSerializer.LoadAllObjects<Ausleihe>().Where(a => a.IsValid).ToList();
                var spiel = ausleihen.FirstOrDefault(a => a.Spiel.Id == this.Id);
                return spiel != null;
            }
        }
    }
}