using System;
using System.Runtime.InteropServices;

using GISharp.Runtime;

namespace GISharp.GLib
{
    public partial class Source
    {
        static System.IntPtr New (SourceFuncs sourceFuncs)
        {
            var structSize = Marshal.SizeOf (sourceFuncs);
            var ret = g_source_new (sourceFuncs, (uint)structSize);
            return ret;
        }

        /// <summary>
        /// Creates a new <see cref="Source"/>.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any <see cref="MainContext"/>
        /// and must be added to one with <see cref="Attach"/> before it will be executed.
        /// </remarks>
        /// <param name="sourceFuncs">
        /// structure containing functions that implement the sources behavior.
        /// </param>
        public Source (SourceFuncs sourceFuncs) : this (New (sourceFuncs), Transfer.All)
        {
        }

        void AssertAttachArgs (MainContext context)
        {
            if (IsDestroyed) {
                throw new InvalidOperationException ("Source has already been destroyed.");
            }
        }
    }
}
