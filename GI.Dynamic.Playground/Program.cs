﻿using System;
using static GISharp.GIRepository.Repository;

namespace GI.Dynamic.Playground
{
    public static class Program
    {
        internal static readonly dynamic Gio;
        internal static readonly dynamic Gtk;

        static Program () {
            Require ("Gio", "2.0");
            Require ("Gtk", "3.0");
            Gio = Namespaces["Gio"];
            Gtk = Namespaces["Gtk"];
        }

        public static void Main (string[] args)
        {
            var app = Gtk.Application.@new (null, Gio.ApplicationFlags.flags_none);
            dynamic window = null;

            Action startup = () => {
                window = Gtk.ApplicationWindow.@new (app);
                window.set_title ("Hello Dynamic!");
                window.set_default_size (400, 400);
                window.set_position (Gtk.WindowPosition.center);

                dynamic aboutAction = Gio.SimpleAction.@new ("about", null);
                Action showAbout = () => {
                    var aboutDialog = Gtk.AboutDialog.@new ();
                    aboutDialog.set_transient_for (window);

                    Action closeAboutDialog = () => aboutDialog.close ();
                    aboutDialog.Connect ("response", closeAboutDialog);

                    aboutDialog.run ();
                    aboutDialog.destroy ();
                };

                aboutAction.Connect ("activate", showAbout);
                app.add_action (aboutAction);

                var quitAction = Gio.SimpleAction.@new ("quit", null);
                Action quit = () => app.quit ();
                quitAction.Connect ("activate", quit);
                app.add_action (quitAction);
                app.set_accels_for_action ("app.quit", new [] { "<Primary>q" });

                // on macOS, the menu is created automatically, but still uses
                // the actions above
                if (app.prefers_app_menu ()) {
                    var menu1 = Gio.Menu.@new ();
                    menu1.append ("_About", "app.about");

                    var menu2 = Gio.Menu.@new ();
                    menu2.append ("_Quit", "app.quit");

                    var appMenu = Gio.Menu.@new ();
                    appMenu.append_section (null, menu1);
                    appMenu.append_section (null, menu2);
                    app.set_app_menu (appMenu);
                }
            };
            app.Connect ("startup", startup);

            Action activate = () => {
                window.present ();
            };
            app.Connect ("activate", activate);

            app.run (args);
        }
    }
}
