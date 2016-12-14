using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KDG.DataObjectHandler.Serializers.Json;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class MeineAusleihen : System.Web.UI.Page
    {
        public List<Ausleihe> Ausleihen { get; set; }
        public List<Spiel> Spiele { get; set; }
        public Benutzer Benutzer { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsLoggedIn())
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                this.Benutzer = (Benutzer)this.Session["Benutzer"]; ;
                var ausleiheList = jsonSerializer.LoadAllObjects<Ausleihe>();
                this.Ausleihen = ausleiheList.Where(o => o.Benutzer.Id == this.Benutzer.Id).ToList();
                this.Spiele = jsonSerializer.LoadAllObjects<Spiel>();
                var spiel1 = new Spiel("hersteller", "name", KategorieEnum.Oberstufe, PreisklasseEnum.Preisklasse2);
                var spiel2 = new Spiel("Kek", "rain", KategorieEnum.Unterstufe, PreisklasseEnum.Preisklasse3);
                var spiel3 = new Spiel("snow", "powe", KategorieEnum.Kindergarten, PreisklasseEnum.Preisklasse1);
                this.Spiele = new List<Spiel>()
                {
                    spiel1,spiel2,spiel3
                };
            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(this.Session["Benutzer"] == null && this.Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
        protected void AusleiheZurueckgeben(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        protected void SpielAuslehnen(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}