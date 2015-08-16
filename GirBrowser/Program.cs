using System;
using System.Linq;
using System.Xml.Linq;
using Gtk;

namespace GirBrowser
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Application.Init ();
            var win = new MainWindow ();
            win.Show ();
            Application.Run ();
        }
    }
}
