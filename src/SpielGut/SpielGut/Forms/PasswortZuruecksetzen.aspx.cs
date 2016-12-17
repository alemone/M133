using System;
using System.IO;
using KDG.DataObjectHandler.Serializers.Json;
using Microsoft.AspNet.Identity;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class PasswortZuruecksetzen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (this.passwort.Value != this.passwortWiederholen.Value)
                    return;
                // TODO Password Validator
                var uid = this.Request.QueryString["u"];
                if (uid == null)
                {
                    this.Response.Redirect("MeineAusleihen.aspx");
                }
                else
                {
                    var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                    var benutzer = jsonSerializer.LoadObject<Benutzer>(Guid.Parse(uid));
                    if (benutzer == null)
                    {
                        this.Response.Redirect("MeineAusleihen.aspx");
                    }
                    else
                    {
                        benutzer.Passwort = new PasswordHasher().HashPassword(this.passwort.Value);
                        jsonSerializer.SaveObject(benutzer);
                        this.Response.Redirect("Login.aspx");
                    }
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