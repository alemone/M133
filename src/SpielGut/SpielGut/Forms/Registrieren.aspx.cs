using System;
using System.IO;
using System.Web;
using KDG.DataObjectHandler.Serializers.Json;
using Microsoft.AspNet.Identity;
using SendGrid.Helpers.Mail;
using SpielGut.Klassen;
using SpielGut.Validierer;

namespace SpielGut.Forms
{
    public partial class Registrieren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (this.IsPostBack)
            {
                this.HandlePostRequests();
            }
            else if (this.IsLoggedIn())
            {
                this.Response.Redirect("MeinProfil.aspx");
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
                new PasswordHasher().HashPassword(this.passwort.Value),
                this.passwortwiderholen.Value,
                adresse,
                this.telefonnummer.Value
                );

            if (BenutzerValidator.IsValid(benutzer) && PasswortValidator.IsValid(this.passwort.Value, this.passwortwiderholen.Value))
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                jsonSerializer.SaveObject(benutzer);

                var sendGrid = new SendGrid.SendGridAPIClient("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");
                var from = new Email("noreply@spielgut.ch");

                var subject = "Account registration SpielGut";
                var to = new Email(benutzer.Email);
                var content = new Content("text/html", "<h1>Danke, dass Sie sich bei SpielGut registriert haben.</h1>" +
                                                       "<h2>Um die Registration abzuschliessen, bestätigen Sie bitte Ihren Account " +
                                                       "unter folgendem <a href='http://" + HttpContext.Current.Request.Url.Authority + "/Forms/AccountBestaetigen.aspx?u=" + benutzer.Id +
                                                       "'>Link</a>.</h2>");
                var mail = new Mail(from, subject, to, content);

                sendGrid.client.mail.send.post(requestBody: mail.Get());

            }
        }

        private bool IsLoggedIn()
        {
            return this.Session["Benutzer"] != null;
        }
    }
}