using System;
namespace WebAppWebpage
{
    public partial class Abmelden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Cookies.Clear();
            Response.Redirect("../Forms/Login.aspx");       
        }
    }
}