using System;
namespace WebAppWebpage
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                Response.Redirect("Forms/MeinProfil.aspx");
            }
            else
            {
                Response.Redirect("Forms/Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(Session["Benutzer"] == null && Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
    }
}