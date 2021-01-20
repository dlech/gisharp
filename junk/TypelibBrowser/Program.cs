// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

﻿using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.Lib.GIRepository;
using Gtk;

namespace GISharp.TypelibBrowser
{
    public class Program
    {
        public static void Main (string[] args)
        {
            Application.Init ();

            var manager = new RepositoryManager ();

            var window = new MainWindow ();
            window.Destroyed += (sender, e) => Application.Quit ();
            window.Show ();

            manager.TypelibLoaded += (sender, e) => {
                window.AddNamespace (e.Namespace, e.Version);
            };
            window.SelectedNamespaceChanged += (sender, e) => {
                window.ClearTypelibInfo();
                window.ClearInfos();
                if (e.Namespace is null) {
                    // TODO: show placeholder that indicates no namespace is selected?
                    return;
                }
                var @namespace = Repository.Namespaces[e.Namespace];
                window.SetTypelibInfo(@namespace.TypelibPath,
                    string.Join(", ", @namespace.Versions),
                    @namespace.Dependencies is null ? null : string.Join(", ", @namespace.Dependencies),
                    string.Join(", ", @namespace.SharedLibraries));
                window.AddInfo(new InfoTreeModelImpl (@namespace.Infos));
            };
            window.SelectedInfoChanged += (sender, e) => {
                window.ClearTypeInfo();
                if (e.UserData is null) {
                    return;
                }
                var node = e.UserData as InfoTreeModelImpl.Info;
                if (node is not null) {
                    window.SetTypeInfo (node.BaseInfo);
                }
            };
            manager.LoadAllTypelibs ();

            Application.Run ();
        }
    }
}
