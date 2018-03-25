using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{

    /// <summary>
    /// The class structure for the GInitiallyUnowned type.
    /// </summary>
    sealed class InitiallyUnownedClass : ObjectClass
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InitiallyUnownedClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
