// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The type of the @unuse_plugin function of #GTypePluginClass.
    /// </summary>
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.UnmanagedFunctionPointerAttribute(System.Runtime.InteropServices.CallingConvention.Cdecl)]
    /* <type name="none" type="void" /> */
    /* transfer-ownership:none direction:in */
    public unsafe delegate void UnmanagedTypePluginUnuse(
    /* <type name="TypePlugin" type="GTypePlugin*" is-pointer="1" /> */
    /* transfer-ownership:none direction:in */
    GISharp.Lib.GObject.TypePlugin.UnmanagedStruct* plugin);

    /// <include file="TypePluginUnuse.xmldoc" path="declaration/member[@name='TypePluginUnuse']/*" />
    public delegate void TypePluginUnuse(GISharp.Lib.GObject.ITypePlugin plugin);

    /// <summary>
    /// Class for marshalling <see cref="TypePluginUnuse"/> methods.
    /// </summary>
    public static unsafe class TypePluginUnuseMarshal
    {
        /// <summary>
        /// Marshals an unmanaged pointer to a <see cref="TypePluginUnuse"/>.
        /// </summary>
        public static GISharp.Lib.GObject.TypePluginUnuse FromPointer(delegate* unmanaged[Cdecl]<GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*, void> callback_, System.IntPtr userData_)
        {
            void managedCallback(GISharp.Lib.GObject.ITypePlugin plugin)
            {
                var plugin_ = (GISharp.Lib.GObject.TypePlugin.UnmanagedStruct*)plugin.UnsafeHandle;
                callback_(plugin_);
                GISharp.Runtime.GMarshal.PopUnhandledException();
            }

            return managedCallback;
        }
    }
}