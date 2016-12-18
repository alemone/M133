using System;
using System.Collections.Generic;
using System.IO;
using KDG.DataObjectHandler.Serializers.Json;
using SpielGut.Klassen;

namespace WebAppWebpage
{
    public partial class Initialisierer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
            File.Delete(Path.GetTempPath() + "\\SpielGutSicherungen\\Spiel.json"); 

            var spiele = new List<Spiel>
            {
                new Spiel("Hasbro", "Monopoly", KategorieEnum.Oberstufe, PreisklasseEnum.Preisklasse3),
                new Spiel("Hasbro", "Dungeons & Dragons", KategorieEnum.Oberstufe, PreisklasseEnum.Preisklasse2),
                new Spiel("Hasbro", "Ouija", KategorieEnum.Unterstufe, PreisklasseEnum.Preisklasse3),
                new Spiel("Hasbro", "Magic: The Gathering", KategorieEnum.Oberstufe, PreisklasseEnum.Preisklasse1),
                new Spiel("Ravensburger", "Fang den Hut", KategorieEnum.Kindergarten, PreisklasseEnum.Preisklasse3),
                new Spiel("Ravensburger", "Lotti Karotti", KategorieEnum.Oberstufe, PreisklasseEnum.Preisklasse1),
                new Spiel("Ravensburger", "Plitsch Platsch Pinguin", KategorieEnum.Kindergarten, PreisklasseEnum.Preisklasse2)
            };

            spiele.ForEach(s => serializer.SaveObject(s));
            this.Response.Redirect("../Forms/Login.aspx");
        }
    }
}