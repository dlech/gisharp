// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A callback function used by the type system to finalize those portions
    /// of a derived types class structure that were setup from the corresponding
    /// GBaseInitFunc() function. Class finalization basically works the inverse
    /// way in which class initialization is performed.
    /// See GClassInitFunc() for a discussion of the class initialization process.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedBaseFinalizeFunc(
    /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeClass* gClass);

    /// <include file="BaseFinalizeFunc.xmldoc" path="declaration/member[@name='BaseFinalizeFunc']/*" />
    public delegate void BaseFinalizeFunc(GISharp.Lib.GObject.TypeClass gClass);

    /// <summary>
    /// Class for marshalling <see cref="BaseFinalizeFunc"/> methods.
    /// </summary>
    public static unsafe class BaseFinalizeFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="BaseFinalizeFunc"/>.
        /// </summary>
        public static GISharp.Lib.GObject.BaseFinalizeFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeClass*, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(GISharp.Lib.GObject.TypeClass gClass)
            {
                var gClass_ = &gClass;
                callback_(gClass_);
            }

            return managedCallback;
        }
    }
}