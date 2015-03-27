using System;
using System.Collections.Generic;
using System.Linq
;
using GISharp.GI;
using Gtk;

namespace GISharp.Browser
{
  public class Program
  {
    public static void Main (string[] args) {
      Application.Init ();

      var manager = new RepositoryManager ();

      var window = new MainWindow ();
      window.Destroyed += (sender, e) => Application.Quit ();
      window.ShowAll ();

      manager.TypelibLoaded += (sender, e) => {
        window.SetNamespaces (manager.Namespaces);
        window.SelectedNamespaceName = manager.Namespaces.First ()[0];
        window.SelectedNamespaceVersion = manager.Namespaces.First ()[1];
      };
      manager.LoadTypelib ("GLib", null);
      window.SelectedInfoTypeChanged += (sender, e) => window.SetInfos (manager.GetInfos ("GLib", e.InfoType));
      window.SetInfos (manager.GetInfos ("GLib", (InfoType)0));

      Application.Run ();
    }
  }
}

