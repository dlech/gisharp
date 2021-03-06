// SPDX-License-Identifier: MIT
// Copyright (c) 2020 David Lechner <david@lechnology.com>

namespace GISharp.Lib.Gtk
{
    partial class Version
    {
        /// <summary>
        /// Gets the version of the GTK library used at compile time.
        /// </summary>
        public static System.Version CompileTimeVersion => new(majorVersion, minorVersion, microVersion, 0);

        /// <summary>
        /// Gets the version of the GTK library used at run time.
        /// </summary>
        public static System.Version RunTimeVersion => new((int)MajorVersion, (int)MinorVersion, (int)MicroVersion, 0);
    }
}
