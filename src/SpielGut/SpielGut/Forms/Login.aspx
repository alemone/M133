﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SpielGut.Forms.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="/Content/materialize.min.css" media="screen,projection" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="/Content/login.css" />
    <link rel="stylesheet" href="/Content/main.css" />
    <link rel="icon" type="image/ico" href="/img/favicon.ico" />
    <title>Login - SpielGut</title>
</head>
<body>
    <header>
        <nav>
            <div class="nav-wrapper">
                <a href="#!" class="brand-logo center hide-on-small-only">
                    <img src="/img/favicon.ico" alt=""/>
                </a>
            </div>
        </nav>
    </header>
    <main>
        <div id="content" class="container">
            <div class="row section valign-wrapper" id="loginMask">
                <div class="container valign z-depth-4 grey lighten-3 col ">
                    <img src="/img/SpielgutBanner.jpg" id="logoLogin" alt=""/>
                    <form runat="server">
                        <div class="row">
                            <div class="input-field col s12 ">
                                <input runat="server" id="email" type="text" class="validate" />
                                <label for="email">Email</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s12">
                                <input runat="server" id="passwort" type="password" class="validate" />
                                <label for="passwort">Passwort</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s12">
                                <a href="/Forms/PasswortVergessen.aspx">Hilfe! Ich habe mein Passwort vergessen.</a>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s12 m9">
                                <a type="button" href="Registrieren.aspx" id="registrierenbtn" class="btn waves-effect waves-light">Registrieren
                                </a>
                            </div>
                            <div class="col s12 m3">
                                <button runat="server" type="submit" id="loginbtn" class="btn waves-effect waves-light">
                                    Login
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
