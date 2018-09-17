using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial struct FileAttributeInfo
    {
        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        public UnownedUtf8 Name => new UnownedUtf8(name, -1);
    }
}
