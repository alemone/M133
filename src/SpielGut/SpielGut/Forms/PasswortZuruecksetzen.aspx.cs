using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using KDG.DataObjectHandler.Serializers.Json;
using Microsoft.AspNet.Identity;
using SpielGut.Klassen;
using SpielGut.Validierer;

namespace SpielGut.Forms
{
    public partial class PasswortZuruecksetzen : System.Web.UI.Page
    {
        public ObservableCollection<string> Fehlermeldungen { get; set; } = new ObservableCollection<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Fehlermeldungen.CollectionChanged += this.AktualisiereFehlermeldungen;
            this.FehlermeldungsWiederholer.DataSource = this.Fehlermeldungen;
            if (this.IsPostBack)
            {
                var errormsgs = PasswortValidator.Validate(this.passwort.Value, this.passwortWiederholen.Value);
                if (errormsgs.Count != 0)
                {
                    this.Fehlermeldungen.Add("Eingabe Fehlerhaft");
                    errormsgs.ForEach(f => this.Fehlermeldungen.Add(f));
                    return;
                }
                var uid = this.Request.QueryString["u"];
                if (uid == null)
                {
                    this.Response.Redirect("MeinProfil.aspx");
                }
                else
                {
                    var jsonSerializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
                    var benutzer = jsonSerializer.LoadObject<Benutzer>(Guid.Parse(uid));
                    if (benutzer == null)
                    {
                        this.Response.Redirect("MeinProfil.aspx");
                    }
                    else
                    {
                        benutzer.Passwort = new PasswordHasher().HashPassword(this.passwort.Value);
                        jsonSerializer.SaveObject(benutzer);
                        this.Response.Redirect("Login.aspx");
                    }
                }
            }
        }

        private void AktualisiereFehlermeldungen(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.FehlermeldungsWiederholer.DataBind();
        }


        private bool IsLoggedIn()
        {
            return this.Session["Benutzer"] != null;
        }

        protected void OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}