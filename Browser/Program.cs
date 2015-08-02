using System;
using System.Collections.Generic;
using System.Linq;
using GISharp.GI;
using Gtk;

namespace GISharp.Browser
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
                if (e.Namespace == null) {
                    // TODO: show placeholder that indicates no namespace is selected?
                    return;
                }
                var @namespace = Repository.Namespaces[e.Namespace];
                window.SetTypelibInfo(@namespace.TypelibPath,
                    string.Join(", ", @namespace.Versions),
                    @namespace.Dependencies == null ? null : string.Join(", ", @namespace.Dependencies),
                    string.Join(", ", @namespace.SharedLibraries));
                foreach (var info in @namespace.Infos) {
                    window.AddInfo(info.InfoType.ToString(), info.Name, info.IsDeprecated);
                }
            };
            window.SelectedInfoChanged += (sender, e) => {
                window.ClearTypeInfo();
                if (e.Name == null) {
                    return;
                }
                var info = Repository.Namespaces[e.Namespace].FindByName(e.Name);
                window.SetTypeInfo (info);
            };
            manager.LoadAllTypelibs ();

            Application.Run ();
        }
    }
}

