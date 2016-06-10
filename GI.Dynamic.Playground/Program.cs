using System;
using static GISharp.GIRepository.Repository;

namespace GI.Dynamic.Playground
{
    public static class Program
    {
        public static void Main (string[] args)
        {
            Require ("Gtk", "3.0");
            dynamic gtk = Namespaces ["Gtk"];

            gtk.init (args);

            dynamic window = gtk.Window.@new (gtk.WindowType.toplevel);
            window.set_title ("Hello Dynamic!");
            window.set_position (gtk.WindowPosition.center);
            Action quit = () => gtk.main_quit ();
            window.Connect ("destroy", quit);
            window.show_all ();

            gtk.main ();
        }
    }
}
