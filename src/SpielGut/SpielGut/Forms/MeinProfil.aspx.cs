using System;
using System.IO;
using Newtonsoft.Json;
using SpielGut.Klassen;
using SpielGut.Validierer;
using JsonSerializer = KDG.DataObjectHandler.Serializers.Json.JsonSerializer;

namespace SpielGut.Forms
{
    public partial class MeinProfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.IsLoggedIn())
            {
                var uid = Guid.Parse(this.Session["Benutzer"].ToString());
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                var benutzer = jsonSerializer.LoadObject<Benutzer>(uid);
                if (this.IsPostBack)
                {
                    benutzer.Vorname = this.vorname.Value;
                    benutzer.Nachname = this.nachname.Value;
                    benutzer.Email = this.email.Value;
                    benutzer.Address.Postleitzahl = this.postleitzahl.Value;
                    benutzer.Address.Ort = this.ort.Value;
                    benutzer.Address.Strasse = this.strasse.Value;
                    benutzer.Telefonnummer = this.telefonnummer.Value;
                    if (new UserValidator().IsValid(benutzer))
                    {
                        jsonSerializer.SaveObject(benutzer);
                    }
                }
                this.vorname.Value = benutzer.Vorname;
                this.nachname.Value = benutzer.Nachname;
                this.email.Value = benutzer.Email;
                this.postleitzahl.Value = benutzer.Address.Postleitzahl;
                this.ort.Value = benutzer.Address.Ort;
                this.strasse.Value = benutzer.Address.Strasse;
                this.telefonnummer.Value = benutzer.Telefonnummer;

            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return this.Session["Benutzer"] != null;
        }

        protected void Zuruecksetzen_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect("PasswortZuruecksetzen.aspx?u=" + ((Benutzer)this.Session["benutzer"]).Id);
        }
    }
}