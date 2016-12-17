using System;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class MeinProfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsLoggedIn())
            {
                var benutzer = (Benutzer) this.Session["benutzer"];
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
            return !(this.Session["Benutzer"] == null && this.Response.Cookies["SpielGut"]["Benutzer"] == null);
        }

        protected void Zuruecksetzen_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect("PasswortZuruecksetzen.aspx?u=" + ((Benutzer)this.Session["benutzer"]).Id);
        }
    }
}