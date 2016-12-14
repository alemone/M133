using System;
using System.IO;
using SpielGut.Klassen;
using Helpers.Password;
using Helpers.Serializers.Json;

namespace WebAppWebpage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                var benutzerList = jsonSerializer.LoadAllObjectsFromFile<Benutzer>();
                var benutzer = benutzerList.Find(o => o.Email == email.Value);
                if (benutzer != null && PasswordHelper.CompareStringWithHash(passwort.Value, benutzer.Passwort))
                {
                    Session.Add("Benutzer", benutzer);

                    Response.Cookies["SpielGut"]["Benutzer"] = benutzer.ToString();
                    Response.Cookies["SpielGut"].Expires = DateTime.Now.AddDays(10.0);
                    Response.Redirect("MeinProfil.aspx");
                }
            }
            else if (IsLoggedIn())
            {
                Response.Redirect("MeinProfil.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(Session["Benutzer"] == null && Response.Cookies["SpielGut"]["Benutzer"] == null);
        }

        protected void OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}