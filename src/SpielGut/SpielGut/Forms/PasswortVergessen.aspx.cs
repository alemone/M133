using System;
using System.IO;
using System.Linq;
using System.Web;
using KDG.DataObjectHandler.Serializers.Json;
using SendGrid.Helpers.Mail;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class PasswortVergessen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack && this.email.Value != null)
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                var benutzer = jsonSerializer.LoadAllObjects<Benutzer>().FirstOrDefault(u => u.Email == this.email.Value);
                if (benutzer == null)
                {
                    // Fehlermeldung: Kein User zur email vorhanden
                    return;
                }

                var sendGrid = new SendGrid.SendGridAPIClient("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");
                var from = new Email("noreply@spielgut.ch");

                var subject = "Passwort zurücksetzen SpielGut";
                var to = new Email(this.email.Value);
                var content = new Content("text/html", "<h1>Passwort Vergessen?</h1>" +
                                                       "<h2>Sie können Ihr Passwort unter folgendem <a href='http://" + HttpContext.Current.Request.Url.Authority + "/Forms/PasswortZuruecksetzen.aspx?u=" + benutzer.Id + "'>Link</a>.</h2>");
                var mail = new Mail(from, subject, to, content);

                sendGrid.client.mail.send.post(requestBody: mail.Get());
            }
            else if (this.IsLoggedIn())
            {
                this.Response.Redirect("MeineAusleihen.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return this.Session["Benutzer"] != null;
        }

        protected void OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}