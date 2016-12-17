using System;
using System.IO;
using KDG.DataObjectHandler.Serializers.Json;
using Microsoft.AspNet.Identity;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                var benutzerList = jsonSerializer.LoadAllObjects<Benutzer>();
                var benutzer = benutzerList.Find(o => o.Email == this.email.Value);
                if (benutzer != null && benutzer.IstBestaetigt && new PasswordHasher().VerifyHashedPassword(benutzer.Passwort, this.passwort.Value) == PasswordVerificationResult.Success)
                {
                    this.Session.Add("Benutzer", benutzer);

                    this.Response.Cookies["SpielGut"]["Benutzer"] = benutzer.ToString();
                    this.Response.Cookies["SpielGut"].Expires = DateTime.Now.AddDays(10.0);
                    this.Response.Redirect("MeineAusleihen.aspx");
                }
            }
            else if (this.IsLoggedIn())
            {
                this.Response.Redirect("MeineAusleihen.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(this.Session["Benutzer"] == null && this.Response.Cookies["SpielGut"]["Benutzer"] == null);
        }

        protected void OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}