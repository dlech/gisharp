namespace GISharp.Lib.Gtk
{
    partial class Version
    {
        /// <summary>
        /// Gets the version of the GTK library used at compile time.
        /// </summary>
        public static System.Version CompileTimeVersion => new System.Version(majorVersion, minorVersion, microVersion, 0);

        /// <summary>
        /// Gets the version of the GTK library used at run time.
        /// </summary>
        public static System.Version RunTimeVersion => new System.Version((int)MajorVersion, (int)MinorVersion, (int)MicroVersion, 0);
    }
}
