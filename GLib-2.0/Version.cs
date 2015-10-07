using System;

namespace GISharp.GLib
{
    public static partial class Version
    {
        public static System.Version Current {
            get {
                return new System.Version (Major, Minor, Micro, 0);
            }
        }
    }
}

