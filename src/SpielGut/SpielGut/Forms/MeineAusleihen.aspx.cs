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

                myRepeater.DataSource = this.Spiele.Where(s => s.IsValid);
                this.myRepeater.DataBind();
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
            var id = Guid.Parse((string)e.CommandArgument);
            var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
            var spiel = jsonSerializer.LoadObject<Spiel>(id);
            var ausleihe = new Ausleihe(this.Benutzer, spiel);
            jsonSerializer.SaveObject(ausleihe);
        }
    }
}