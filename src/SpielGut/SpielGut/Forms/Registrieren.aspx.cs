using System;
namespace WebAppWebpage
{
    public partial class Registrieren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Session.Add("Benutzer", "Joan Künzler");

                Response.Cookies["SpielGut"]["Benutzer"] = "Joan Künzler";
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
    }
}