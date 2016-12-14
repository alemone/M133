using System;
using SpielGut.Klassen;

namespace WebAppWebpage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var address = new Address(
                    "9300",
                    "Wittenbach",
                    "Neusteig 14");
                var benutzer = new Benutzer(
                    "Joan",
                    "Künzler",
                    "joan.kuenzler@gmail.com",
                    "0123456789abcdef",
                    "0123456789abcdef",
                    address,
                    "071 290 12 14"
                    );

                Session.Add("Benutzer", benutzer);

                Response.Cookies["SpielGut"]["Benutzer"] = benutzer.ToString();
                Response.Cookies["SpielGut"].Expires = DateTime.Now.AddDays(10.0);
                Response.Redirect("MeinProfil.aspx");
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