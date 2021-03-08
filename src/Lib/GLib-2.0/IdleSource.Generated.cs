// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="IdleSource.xmldoc" path="declaration/member[@name='IdleSource']/*" />
    public sealed unsafe partial class IdleSource : GISharp.Lib.GLib.Source
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public IdleSource(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new idle source.
        /// </summary>
        /// <remarks>
        /// The source will not initially be associated with any #GMainContext
        /// and must be added to one with g_source_attach() before it will be
        /// executed. Note that the default priority for idle sources is
        /// %G_PRIORITY_DEFAULT_IDLE, as compared to other sources which
        /// have a default priority of %G_PRIORITY_DEFAULT.
        /// </remarks>
        /// <returns>
        /// the newly-created idle source
        /// </returns>
        [System.Runtime.InteropServices.DllImportAttribute("glib-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Source" type="GSource*" managed-name="Source" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GLib.Source.UnmanagedStruct* g_idle_source_new();
        static partial void CheckNewArgs();

        static GISharp.Lib.GLib.Source.UnmanagedStruct* New()
        {
            CheckNewArgs();
            var ret_ = g_idle_source_new();
            return ret_;
        }

        /// <include file="IdleSource.xmldoc" path="declaration/member[@name='IdleSource.IdleSource()']/*" />
        public IdleSource() : this((System.IntPtr)New(), GISharp.Runtime.Transfer.Full)
        {
        }
    }
}