<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswortVergessen.aspx.cs" Inherits="SpielGut.Forms.PasswortVergessen" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="/Content/materialize.min.css" media="screen,projection" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/Content/login.css" />
    <link rel="stylesheet" href="/Content/main.css" />
    <link rel="icon" type="image/ico" href="/img/favicon.ico" />
    <title>Passwort vergessen - SpielGut</title>
</head>
<body>
    <header>
        <nav>
            <div class="nav-wrapper">
                <a href="#!" class="brand-logo center hide-on-small-only">
                    <img src="/img/favicon.ico" /></a>
            </div>
        </nav>
    </header>
    <main>
        <div id="content" class="container">
            <div class="row section valign-wrapper" id="loginMask">
                <div class="container valign z-depth-4 grey lighten-3 col ">
                    <img src="/img/SpielgutBanner.jpg" id="logoLogin" />
                    <form runat="server">
                        <div class="row">
                            <div class="input-field col s12 ">
                                <input runat="server" id="email" type="text" class="validate" />
                                <label for="email">Email</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col left">
                                <a href="/Forms/Login.aspx" id="zurueck" class="btn waves-effect waves-light">
                                    Zum Login
                                </a>
                            </div>
                              <div class="col right">
                                <button runat="server" type="submit" id="passwortbtn" class="btn waves-effect waves-light">
                                    Passwort Zurücksetzen
                                </button>
                            </div>
                        </div>
                    </form>
                </div>
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
