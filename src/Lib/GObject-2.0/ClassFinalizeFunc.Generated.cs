// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// A callback function used by the type system to finalize a class.
    /// This function is rarely needed, as dynamically allocated class resources
    /// should be handled by GBaseInitFunc() and GBaseFinalizeFunc().
    /// Also, specification of a GClassFinalizeFunc() in the #GTypeInfo
    /// structure of a static type is invalid, because classes of static types
    /// will never be finalized (they are artificially kept alive when their
    /// reference count drops to zero).
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" managed-name="System.Void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedClassFinalizeFunc(
    /* <type name="TypeClass" type="gpointer" managed-name="TypeClass" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypeClass.UnmanagedStruct* gClass,
    /* <type name="gpointer" type="gpointer" managed-name="System.IntPtr" is-pointer="1" /> */
    /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
    System.IntPtr classData);

    /// <include file="ClassFinalizeFunc.xmldoc" path="declaration/member[@name='ClassFinalizeFunc']/*" />
    public delegate void ClassFinalizeFunc(GISharp.Lib.GObject.TypeClass gClass, System.IntPtr classData);

    /// <summary>
    /// Class for marshalling <see cref="ClassFinalizeFunc"/> methods.
    /// </summary>
    public static unsafe class ClassFinalizeFuncMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="ClassFinalizeFunc"/>.
        /// </summary>
        public static GISharp.Lib.GObject.ClassFinalizeFunc FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypeClass.UnmanagedStruct*, System.IntPtr, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(GISharp.Lib.GObject.TypeClass gClass, System.IntPtr classData)
            {
                var gClass_ = (GISharp.Lib.GObject.TypeClass.UnmanagedStruct*)gClass.UnsafeHandle;
                var classData_ = (System.IntPtr)classData;
                callback_(gClass_, classData_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }
    }
}