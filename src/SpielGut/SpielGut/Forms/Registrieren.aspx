<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrieren.aspx.cs" Inherits="WebAppWebpage.Registrieren" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="/Content/materialize.min.css" media="screen,projection" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/Content/registrieren.css" />
    <link rel="stylesheet" href="/Content/main.css" />
    <link rel="icon" type="image/ico" href="/img/favicon.ico" />
    <title>Registrieren - SpielGut</title>
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
                    <img src="/img/favicon.ico" /></a>
                <ul class="right">
                    <li><a href="/Handler/Abmelden.aspx">Abmelden</a></li>
                </ul>
            </div>
        </nav>
    </header>
    <main>
        <div id="content" class="container">
            <div class="row">
                <form class="col s12" runat="server">
                    <div class="section">
                        <div class="row">
                            <div class="input-field col l4 offset-l2">
                                <input runat="server" id="vorname" type="text" class="validate" />
                                <label for="vorname">Vorname</label>
                            </div>
                            <div class="input-field col s4">
                                <input runat="server" id="nachname" type="text" class="validate" />
                                <label for="nachname">Nachname</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <input runat="server" id="email" type="email" class="validate" />
                                <label for="email">Email</label>
                            </div>
                        </div>
                    </div>
                    <div class="divider"></div>
                    <div class="section">
                        <div class="row">
                            <div class="input-field col s12">
                                <input runat="server" id="passwort" type="password" class="validate" />
                                <label for="passwort">Passwort</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <input runat="server" id="passwortwiderholen" type="password" class="validate" />
                                <label for="passwortwiderholen">Passwort</label>
                            </div>
                        </div>
                    </div>
                    <div class="divider"></div>
                    <div class="section">
                        <div class="row">
                            <div class="input-field col s6">
                                <input runat="server" id="postleitzahl" type="text" class="validate" />
                                <label for="postleitzahl">Postleitzahl</label>
                            </div>
                            <div class="input-field col s6">
                                <input runat="server" id="ort" type="text" class="validate" />
                                <label for="ort">Ort</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s6">
                                <input runat="server" id="strasse" type="text" class="validate" />
                                <label for="strasse">Strasse</label>
                            </div>
                            <div class="input-field col s6">
                                <input runat="server" id="hausnummer" type="text" class="validate" />
                                <label for="hausnummer">Hausnummer</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12 m8 l6 offset-l3 offset-m2">
                                <input runat="server" id="telefonnummer" type="text" class="validate" />
                                <label for="telefonnummer">Telefonnummer</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s12 m8">
                                <a type="button" href="Login.aspx" id="zurueckbtn" class="btn waves-effect waves-light">Zurück
                                </a>
                            </div>
                            <div class="col s12 m4">
                                <button runat="server" type="submit" id="registrierenbtn" class="btn waves-effect waves-light">
                                    Registrieren
                                </button>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
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
