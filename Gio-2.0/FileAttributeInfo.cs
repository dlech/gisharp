using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial struct FileAttributeInfo
    {
        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        public Utf8 Name => Opaque.GetInstance<Utf8>(name, Transfer.None);
    }
}
