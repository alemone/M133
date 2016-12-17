﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using KDG.DataObjectHandler.Serializers.Json;
using SpielGut.Klassen;

namespace SpielGut.Forms
{
    public partial class MeineAusleihen : System.Web.UI.Page
    {
        public List<Ausleihe> Ausleihen { get; set; }
        public List<Spiel> Spiele { get; set; }
        public Benutzer Benutzer { get; set; }

        private JsonSerializer serializer = new JsonSerializer(Path.GetTempPath() + "\\SpielGutSicherungen");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsLoggedIn())
            {
                this.ReloadBindings();
            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }
        }

        private bool IsLoggedIn()
        {
            return !(this.Session["Benutzer"] == null && this.Response.Cookies["SpielGut"]["Benutzer"] == null);
        }
        protected void AusleiheZurueckgeben(object sender, CommandEventArgs e)
        {
            var id = Guid.Parse((string)e.CommandArgument);
            var ausleihe = this.serializer.LoadObject<Ausleihe>(id);
            ausleihe.Terminate();
            this.serializer.SaveObject(ausleihe);
            this.AusleihenWiederholer.DataBind();
            this.ReloadBindings();
        }
        protected void SpielAuslehnen(object sender, CommandEventArgs e)
        {
            var id = Guid.Parse((string)e.CommandArgument);
            var spiel = this.serializer.LoadObject<Spiel>(id);
            var ausleihe = new Ausleihe(this.Benutzer, spiel);
            this.serializer.SaveObject(ausleihe);
            this.ReloadBindings();
        }

        private void ReloadBindings()
        {
            this.Benutzer = (Benutzer)this.Session["Benutzer"]; ;
            var ausleiheList = this.serializer.LoadAllObjects<Ausleihe>();
            this.Ausleihen = ausleiheList.Where(o => o.Benutzer.Id == this.Benutzer.Id).ToList();
            this.Spiele = this.serializer.LoadAllObjects<Spiel>();

            this.AusleihenWiederholer.DataSource = this.Ausleihen.Where(a => a.IsValid);
            this.AusleihenWiederholer.DataBind();

            this.AbgelaufeneAusliehenWiederhohler.DataSource = this.Ausleihen.Where(a => !a.IsValid);
            this.AbgelaufeneAusliehenWiederhohler.DataBind();

            this.SpieleWiederholer.DataSource = this.Spiele.Where(s => s.IsValid);
            this.SpieleWiederholer.DataBind();
            
            return;
            throw new BadImageFormatException();
        }
    }
}