using System;
using System.IO;
using SpielGut.Klassen;
using Helpers.Serializers;
using System.Collections.Generic;

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
                var ausleiheList = jsonSerializer.LoadAllObjectsFromFile<Ausleihe>();
                this.Ausleihen = ausleiheList.FindAll(o => o.Benutzer.Id == benutzer.Id);
                var spiel1 = new Spiel("Toyland", "Monopoly", Kategorie.Oberstufe, new Preisklasse(1, 4, 6));
                var ausleihe1 = new Ausleihe(benutzer, spiel1);
                var ausleihe2 = new Ausleihe(benutzer, spiel1);
                ausleihe2.IsActive = false;
                this.Ausleihen = new List<Ausleihe>()
                {
                    ausleihe1,ausleihe1,ausleihe1,ausleihe2,ausleihe2
                };
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
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}