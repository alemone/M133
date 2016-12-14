using System;
using System.IO;
using SpielGut.Klassen;
using SpielGut.Validierer;
using Helpers.Password;
using Helpers.Serializers.Json;

namespace WebAppWebpage
{
    public partial class Registrieren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.HandlePostRequests();
            }
            else if (IsLoggedIn())
            {
                Response.Redirect("MeinProfil.aspx");
            }
        }

        private void HandlePostRequests()
        {
            var adresse = new Address(
                   this.postleitzahl.Value,
                   this.strasse.Value,
                   this.ort.Value
                  );

            var benutzer = new Benutzer(
                this.vorname.Value,
                this.nachname.Value,
                this.email.Value,
                this.passwort.Value,
                this.passwortwiderholen.Value,
                adresse,
                this.telefonnummer.Value
                );

            if (new UserValidator().IsValid(benutzer))
            {
                benutzer.Passwort = PasswordHelper.HashPassword(benutzer.Passwort);
                benutzer.PasswortWiderholen = "";
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                jsonSerializer.SaveObject(benutzer);
            }
        }

        private bool IsLoggedIn()
        {
            return !(this.Session["Benutzer"] == null && this.Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
    }
}