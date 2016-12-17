using System;
using System.IO;
using KDG.DataObjectHandler.Serializers.Json;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class AccountBestaetigen : System.Web.UI.Page
    {
        public Benutzer Benutzer { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsLoggedIn())
            {
                this.Response.Redirect("MeineAusleihen.aspx");
            }
            else
            {
                var uid = this.Request.QueryString["u"];
                var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                if (uid == null)
                {
                    this.Response.Redirect("MeineAusleihen.aspx");
                }
                else
                {
                    this.Benutzer = jsonSerializer.LoadObject<Benutzer>(Guid.Parse(uid));
                    if (this.Benutzer == null || this.Benutzer.IstBestaetigt)
                    {
                        this.Response.Redirect("MeineAusleihen.aspx");
                    }
                    else
                    {
                        this.Benutzer.IstBestaetigt = true;
                        jsonSerializer.SaveObject(this.Benutzer);
                    }
                }

            }
        }

        private bool IsLoggedIn()
        {
            return this.Session["Benutzer"] != null;
        }
    }
}