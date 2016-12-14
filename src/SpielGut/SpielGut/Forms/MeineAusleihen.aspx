﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeineAusleihen.aspx.cs" Inherits="SpielGut.Forms.MeineAusleihen" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="/Content/materialize.min.css" media="screen,projection" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/Content/meineausleihen.css" />
    <link rel="stylesheet" href="/Content/main.css" />
    <link rel="icon" type="image/ico" href="/img/favicon.ico" />
    <title>Mein Ausleihen - SpielGut</title>
</head>
<body>
    <header>
        <nav>
            <div class="nav-wrapper">
                <ul class="left">
                    <li><a href="/Forms/MeinProfil.aspx">Mein Profil</a></li>
                    <li><a href="/Forms/MeineAusleihen.aspx">Meine Ausleihen</a></li>
                </ul>
                <a href="#!" class="brand-logo center hide-on-small-only">
                    <img alt="Icon" src="/img/favicon.ico" /></a>
                <ul class="right">
                    <li><a href="/Handler/Abmelden.aspx">Abmelden</a></li>
                </ul>
            </div>
        </nav>
    </header>
    <main>
        <form runat="server">
            <div id="content" class="container">
                <div class="row" id="tabs">
                    <div class="col s12">
                        <ul class="tabs">
                            <li class="tab col s4"><a class="active" href="#aktiveausleihen">Aktive Ausleihen</a></li>
                            <li class="tab col s4"><a href="#vergangeneausleihen">Vergangene Ausleihen</a></li>
                            <li class="tab col s4"><a href="#spiele">Spiele</a></li>
                        </ul>
                    </div>
                    <div id="aktiveausleihen" class="col s12">
                        <table class="responsive-table">
                            <thead>
                                <tr>
                                    <th data-field="aktiveausleihenspiel">Spiel</th>
                                    <th data-field="aktiveausleihenstart">Start Datum</th>
                                    <th data-field="aktiveausleihenend">End Datum</th>
                                    <th data-field="aktiveausleihenkosten">Kosten</th>
                                </tr>
                            </thead>

                            <tbody>
                                <% foreach (var ausleihe in this.Ausleihen)
                                    {%>
                                <% if (ausleihe.IsValid)
                                    { %>
                                <tr>
                                    <td><%= ausleihe.Spiel.Name %></td>
                                    <td><%= ausleihe.StartDatum %></td>
                                    <td><%= ausleihe.EndDatum %></td>
                                    <td><%= ausleihe.Kosten %></td>
                                    <td>
                                        <asp:Button runat="server" class="waves-effect waves-light btn" OnClick="AusleiheZurueckgeben" Text="X" /></td>
                                </tr>
                                <%}
                                    } %>
                            </tbody>
                        </table>
                    </div>
                    <div id="vergangeneausleihen" class="col s12">
                        <table class="responsive-table">
                            <thead>
                                <tr>
                                    <th data-field="vergangeneausleihenspiel">Spiel</th>
                                    <th data-field="vergangeneausleihenstart">Start Datum</th>
                                    <th data-field="vergangeneausleihenend">End Datum</th>
                                    <th data-field="vergangeneausleihenkosten">Kosten</th>
                                </tr>
                            </thead>

                            <tbody>
                                <% foreach (var ausleihe in this.Ausleihen)
                                    {%>
                                <% if (!ausleihe.IsValid)
                                    { %>
                                <tr>
                                    <td><%= ausleihe.Spiel.Name %></td>
                                    <td><%= ausleihe.StartDatum %></td>
                                    <td><%= ausleihe.EndDatum %></td>
                                    <td><%= ausleihe.Kosten %></td>
                                </tr>
                                <%}
                                    } %>
                            </tbody>
                        </table>
                    </div>
                    <div id="spiele" class="col s12">
                        <table class="responsive-table">
                            <thead>
                                <tr>
                                    <th data-field="vergangeneausleihenstart">Name</th>
                                    <th data-field="vergangeneausleihenend">Hersteller</th>
                                    <th data-field="vergangeneausleihenkosten">Kategorie</th>
                                    <th data-field="vergangeneausleihenkosten">Tarif</th>
                                    <th data-field="spiel">Hinzufügen</th>
                                </tr>
                            </thead>

                            <tbody>
                                <% foreach (var spiel in this.Spiele)
                                    { %>
                                <tr>
                                    <td><%= spiel.Name %></td>
                                    <td><%= spiel.Hersteller %></td>
                                    <td><%= spiel.Kategorie %></td>
                                    <% if (this.Benutzer.IstMitglied)
                                        { %>
                                    <td>CHF <%= spiel.Preisklasse.TarifMitglied %>.-</td>
                                    <%
                                        }
                                        else
                                        { %>
                                    <td>CHF <%= spiel.Preisklasse.TarifNichtMitglied %>.-</td>
                                    <% } %>
                                    <% if (spiel.IsValid && !spiel.IstAusgeliehen)
                                        { %>
                                    <td>
                                        <asp:Button runat="server" class="btn" OnClick="SpielAuslehnen" Text="+" />
                                    </td>
                                    <% }
                                        else
                                        { %>
                                    <td>
                                        <input type="submit" disabled="disabled" value="+" class="btn" />
                                    </td>
                                    <% } %>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </form>
    </main>
    <footer class="page-footer">
        <div class="container">
            <div class="row">
                <div class="col l8 s12">
                    <h5 class="white-text">SpielGut</h5>
                    <p class="grey-text text-lighten-4">Dies ist die Ausleih-Webseite der Ludothek Spielgut!</p>
                </div>
                <div class="right">
                    <a class="waves-effect waves-light btn-large" href="http://spielgut.ch">Hauptseite</a>
                </div>
            </div>
        </div>
        <div class="footer-copyright">
            <div class="container">
                © 2016 Joan Künzler, alle Rechte vorbehalten
           <a class="grey-text text-lighten-4 right"
               href="https://opensource.org/licenses/MIT" target="_blank">MIT License
           </a>
            </div>
        </div>
        <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
        <script type="text/javascript" src="/scripts/materialize.min.js"></script>
    </footer>
</body>
</html>
