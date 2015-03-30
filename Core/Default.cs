using System;
using System.Runtime.InteropServices;

namespace GISharp.Core
{
    public static class Default
    {
        public static void DestroyNotify (IntPtr userData) {
            GCHandle.FromIntPtr (userData).Free ();
        }
    }
}
