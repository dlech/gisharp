// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// This is just a placeholder for #GClosureMarshal,
    /// which cannot be used here for dependency reasons.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedSourceDummyMarshal();

    /// <include file="SourceDummyMarshal.xmldoc" path="declaration/member[@name='SourceDummyMarshal']/*" />
    public delegate void SourceDummyMarshal();

    /// <summary>
    /// Class for marshalling <see cref="SourceDummyMarshal"/> methods.
    /// </summary>
    public static unsafe class SourceDummyMarshalMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="SourceDummyMarshal"/>.
        /// </summary>
        public static GISharp.Lib.GLib.SourceDummyMarshal FromPointer(delegate* unmanaged[Cdecl]<void> callback_, System.IntPtr userData_)
        {
            void managedCallback()
            {
                callback_();
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }
    }
}