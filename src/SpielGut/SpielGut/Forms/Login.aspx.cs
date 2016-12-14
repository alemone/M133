using System;
using System.IO;
using KDG.DataObjectHandler.Password;
using KDG.DataObjectHandler.Serializers.Json;
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
                if (benutzer != null && PasswordHelper.CompareStringWithHash(this.passwort.Value, benutzer.Passwort))
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