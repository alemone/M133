using System;
using SpielGut.Klassen;

namespace WebAppWebpage
{
    public partial class MeinProfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsLoggedIn())
            {
                var benutzer = (Benutzer) Session["benutzer"];
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
                Response.Redirect("Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(Session["Benutzer"] == null && Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
    }
}