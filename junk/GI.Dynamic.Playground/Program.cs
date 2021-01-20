// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019 David Lechner <david@lechnology.com>

﻿using System;
using static GISharp.Lib.GIRepository.Repository;

namespace GI.Dynamic.Playground
{
    public static class Program
    {
        internal static readonly dynamic GLib;
        internal static readonly dynamic Gio;
        internal static readonly dynamic GdkPixbuf;
        internal static readonly dynamic Gtk;

        static Program () {
            Require ("GLib", "2.0");
            Require ("Gio", "2.0");
            Require ("GdkPixbuf", "2.0");
            Require ("Gtk", "3.0");
            GLib = Namespaces["GLib"];
            Gio = Namespaces["Gio"];
            GdkPixbuf = Namespaces["GdkPixbuf"];
            Gtk = Namespaces["Gtk"];
        }

        public static void Main (string[] args)
        {
            GLib.set_prgname ("HelloDynamic");
            GLib.set_application_name ("Hello Dynamic!");

            var app = Gtk.Application.@new (null, Gio.ApplicationFlags.flags_none);
            dynamic window = null;

            Action startup = () => {
                window = Gtk.ApplicationWindow.@new (app);
                window.set_default_size (400, 400);
                window.set_position (Gtk.WindowPosition.center);

                dynamic icon = GdkPixbuf.Pixbuf.@new (GdkPixbuf.Colorspace.rgb, true, 8, 32, 32);
                icon.fill (0x0000ffffu);
                window.set_icon (icon);

                dynamic aboutAction = Gio.SimpleAction.@new ("about", null);
                Action showAbout = () => {
                    var aboutDialog = Gtk.AboutDialog.@new ();
                    aboutDialog.set_transient_for (window);
                    aboutDialog.set_version ("0.0");
                    aboutDialog.set_copyright ("2016 David Lechner <david@lechnology.com>");
                    aboutDialog.set_comments ("Demonstrates dynamic C# bindings for GObject introspection.");
                    aboutDialog.set_license ("MIT");
                    aboutDialog.set_website ("https://github.com/dlech/gisharp");
                    aboutDialog.set_website_label ("GitHub");
                    aboutDialog.set_authors (new[] { "David Lechner" });
                    aboutDialog.set_logo (icon);

                    aboutDialog.run ();
                    aboutDialog.destroy ();
                };

                aboutAction.Connect ("activate", showAbout);
                app.add_action (aboutAction);

                var quitAction = Gio.SimpleAction.@new ("quit", null);
                Action quit = () => app.quit ();
                quitAction.Connect ("activate", quit);
                app.add_action (quitAction);

                // on macOS, the menu is created automatically, but still uses
                // the actions above
                if (app.prefers_app_menu ()) {
                    var appMenu = Gio.Menu.@new ();
                    appMenu.append ("_About", "app.about");
                    appMenu.append ("_Quit", "app.quit");
                    app.set_accels_for_action ("app.quit", new[] { "<Control>q" });
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
