using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{

    /// <summary>
    /// The class structure for the GInitiallyUnowned type.
    /// </summary>
    sealed class InitiallyUnownedClass : ObjectClass
    {
        public InitiallyUnownedClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
