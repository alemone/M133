using System;
using SpielGut.Klassen;

namespace WebAppWebpage
{
    public partial class MeineAusleihen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsLoggedIn()){
     
                Response.Redirect("Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(Session["Benutzer"] == null && Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
    }
}