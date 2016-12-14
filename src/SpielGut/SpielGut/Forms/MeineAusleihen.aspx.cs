using System;
using System.IO;
using SpielGut.Klassen;
using System.Collections.Generic;
using System.Linq;
using Helpers.Serializers.Json;

namespace WebAppWebpage
{
    public partial class MeineAusleihen : System.Web.UI.Page
    {
        public List<Ausleihe> Ausleihen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsLoggedIn())
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                var benutzer = (Benutzer)Session["Benutzer"]; ;
                var ausleiheList = jsonSerializer.LoadAllObjects<Ausleihe>();
                this.Ausleihen = ausleiheList.Where(o => o.Benutzer.Id == benutzer.Id).ToList();
                var spiel1 = new Spiel("Toyland", "Monopoly", Kategorie.Oberstufe, new Preisklasse(1, 4, 6));
                var ausleihe1 = new Ausleihe(benutzer, spiel1);
                var ausleihe2 = new Ausleihe(benutzer, spiel1);
                ausleihe2.Terminate();
                this.Ausleihen = new List<Ausleihe> { ausleihe1, ausleihe1, ausleihe1, ausleihe2, ausleihe2 };
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(Session["Benutzer"] == null && Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
        protected void AusleiheZurueckgeben(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}