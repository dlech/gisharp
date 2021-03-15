// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.Gio
{
    /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='CancellableClass']/*" />
    public unsafe class CancellableClass : GISharp.Lib.GObject.ObjectClass
    {
        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0169, CS0649
            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.ParentClass']/*" />
            public readonly GISharp.Lib.GObject.ObjectClass.UnmanagedStruct ParentClass;

            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.Cancelled']/*" />
            public readonly System.IntPtr Cancelled;

            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved1']/*" />
            public readonly System.IntPtr GReserved1;

            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved2']/*" />
            public readonly System.IntPtr GReserved2;

            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved3']/*" />
            public readonly System.IntPtr GReserved3;

            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved4']/*" />
            public readonly System.IntPtr GReserved4;

            /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='UnmanagedStruct.GReserved5']/*" />
            public readonly System.IntPtr GReserved5;
#pragma warning restore CS0169, CS0649
        }

        static CancellableClass()
        {
            int cancelledOffset = (int)System.Runtime.InteropServices.Marshal.OffsetOf<UnmanagedStruct>(nameof(UnmanagedStruct.Cancelled));
            RegisterVirtualMethod(cancelledOffset, CancelledMarshal.Create);
        }

        /// <include file="CancellableClass.xmldoc" path="declaration/member[@name='Cancelled']/*" />
        public delegate void Cancelled();

        /// <summary>
        /// Unmanaged callback
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        public unsafe delegate void UnmanagedCancelled(
/* <type name="Cancellable" type="GCancellable*" managed-name="Cancellable" is-pointer="1" /> */
/* transfer-ownership:none nullable:1 allow-none:1 direction:in */
GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable);

        /// <summary>
        /// Class for marshalling <see cref="Cancelled"/> methods.
        /// </summary>
        public static unsafe class CancelledMarshal
        {
            /// <summary>
            /// Creates an unmanaged delegate from a managed delegate.
            /// </summary>
            public static UnmanagedCancelled Create(System.Reflection.MethodInfo methodInfo)
            {
                void unmanagedCancelled(GISharp.Lib.Gio.Cancellable.UnmanagedStruct* cancellable_) { try { var cancellable = GISharp.Lib.Gio.Cancellable.GetInstance<GISharp.Lib.Gio.Cancellable>((System.IntPtr)cancellable_, GISharp.Runtime.Transfer.None); var doCancelled = (Cancelled)methodInfo.CreateDelegate(typeof(Cancelled), cancellable); doCancelled(); } catch (System.Exception ex) { GISharp.Lib.GLib.Log.LogUnhandledException(ex); } }

                return unmanagedCancelled;
            }
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public CancellableClass(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }
    }
}