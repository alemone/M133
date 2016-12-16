using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
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
                var spiel3 = new Spiel("snow", "powe", KategorieEnum.Kindergarten, PreisklasseEnum.Preisklasse1)
                {
                    IstAusgeliehen = true
                };
                this.Spiele = new List<Spiel>()
                {
                    spiel1,spiel2,spiel3
                };

                myRepeater.DataSource = this.Spiele.Where(s => s.IsValid);
                this.myRepeater.DataBind();

                /*var tableRows = "";
                foreach (var spiel in this.Spiele)
                {

                    var tarif = this.Benutzer.IstMitglied ? spiel.Preisklasse.TarifMitglied : spiel.Preisklasse.TarifNichtMitglied;

                    var button = spiel.IstAusgeliehen ? "<asp:Button runat=\"server\" class=\"btn\" OnCommand=\"SpielAuslehnen\" CommandArgument=\"" + spiel.Id + "\" Text=\"+\" />" :
                                                        "<input type=\"submit\" disabled=\"disabled\" value=\" + \" class=\"btn\" />";

                    var tdSpielName = "<td>" + spiel.Name + "</td>";
                    var tdSpielHersteller = "<td>" + spiel.Hersteller + "</td>";
                    var tdSpielKategorie = "<td>" + spiel.Kategorie + "</td>";
                    var tdSpielTarif = "<td>" + tarif + "</td>";
                    var tdSpielButton = "<td>" + button + "</td>";


                    tableRows += "<tr>" + tdSpielName + tdSpielHersteller + tdSpielKategorie + tdSpielTarif + tdSpielButton + "</tr>";
                }

                var table = tableRows;
                this.spieleBody.InnerHtml = table;*/
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
        protected void SpielAuslehnen(object sender, CommandEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}