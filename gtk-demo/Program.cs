using System;
using System.Linq;
using Gtk;
using GI;


namespace gtkdemo
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Repository.Require ("Gtk", "3.0", (RepositoryLoadFlags)0);
      var gtk = Repository.Namespaces ["Gtk"];

//      var gtkInfos = Repository.Default.GetInfos ("Gtk");
//      foreach (var info in gtkInfos)
//        Console.WriteLine (info.Name);

      var init = (FunctionInfo)gtk.FindByName ("init");
      var inArg1 = new Argument () {
        Int = args.Length
      };
      var inArg2 = new Argument () {
        Pointer = GLib.Marshaller.StringArrayToStrvPtr (args)
      };
      Argument[] inArgs = { inArg1, inArg2 };
      Argument[] outArgs = { Argument.Zero, Argument.Zero };
      Argument returnValue;
      init.Invoke (inArgs, outArgs, out returnValue);

      var windowObject = (ObjectInfo)gtk.FindByName ("Window");
      var @new = windowObject.FindMethod ("new");
      inArgs = new Argument[1];
      @new.Invoke (inArgs, null, out returnValue);
      var window = GLib.Object.GetObject (returnValue.Pointer);

      EventHandler onWindowDestroyed = (s, e) => {
        var quit = (FunctionInfo)gtk.FindByName ("main_quit");
        quit.Invoke (null, null, out returnValue);
      };

      window.AddSignalHandler ("destroy", onWindowDestroyed);

      var widgetObject = (ObjectInfo)gtk.FindByName ("Widget");
      var showAll = (FunctionInfo)widgetObject.FindMethod ("show_all");
      inArgs [0].Pointer = window.Handle;
      showAll.Invoke (inArgs, null, out returnValue);

      var run = (FunctionInfo)gtk.FindByName ("main");
      run.Invoke (null, null, out returnValue);
//      Application.Init ();
//      MainWindow win = new MainWindow ();
//      win.Show ();
//      Application.Run ();
    }
  }
}
