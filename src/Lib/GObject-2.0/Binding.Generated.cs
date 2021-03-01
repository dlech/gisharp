// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding']/*" />
    [GISharp.Runtime.SinceAttribute("2.26")]
    [GISharp.Runtime.GTypeAttribute("GBinding", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class Binding : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Lib.GObject.GType _GType = g_binding_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Flags_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("flags", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GObject.BindingFlags Flags_ { get => (GISharp.Lib.GObject.BindingFlags)GetProperty("flags")!; set => SetProperty("flags", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Source_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("source", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GObject.Object? Source_ { get => (GISharp.Lib.GObject.Object?)GetProperty("source")!; set => SetProperty("source", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.SourceProperty_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("source-property", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8? SourceProperty_ { get => (GISharp.Lib.GLib.Utf8?)GetProperty("source-property")!; set => SetProperty("source-property", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Target_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("target", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GObject.Object? Target_ { get => (GISharp.Lib.GObject.Object?)GetProperty("target")!; set => SetProperty("target", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.TargetProperty_']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        [GISharp.Runtime.GPropertyAttribute("target-property", Construct = GISharp.Runtime.GPropertyConstruct.Only)]
        public GISharp.Lib.GLib.Utf8? TargetProperty_ { get => (GISharp.Lib.GLib.Utf8?)GetProperty("target-property")!; set => SetProperty("target-property", value); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Flags']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GObject.BindingFlags Flags { get => GetFlags(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Source']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GObject.Object Source { get => GetSource(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.SourceProperty']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GLib.UnownedUtf8 SourceProperty { get => GetSourceProperty(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Target']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GObject.Object Target { get => GetTarget(); }

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.TargetProperty']/*" />
        [GISharp.Runtime.SinceAttribute("2.26")]
        public GISharp.Lib.GLib.UnownedUtf8 TargetProperty { get => GetTargetProperty(); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Binding(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        static partial void CheckGetGTypeArgs();
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" managed-name="GISharp.Lib.GObject.GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.GType g_binding_get_type();

        /// <summary>
        /// Retrieves the flags passed when constructing the #GBinding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the #GBindingFlags used by the #GBinding
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="BindingFlags" type="GBindingFlags" managed-name="BindingFlags" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.BindingFlags g_binding_get_flags(
        /* <type name="Binding" type="GBinding*" managed-name="Binding" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetFlagsArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GObject.BindingFlags GetFlags()
        {
            CheckGetFlagsArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_flags(binding_);
            var ret = (GISharp.Lib.GObject.BindingFlags)ret_;
            return ret;
        }

        /// <summary>
        /// Retrieves the #GObject instance used as the source of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the source #GObject
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_binding_get_source(
        /* <type name="Binding" type="GBinding*" managed-name="Binding" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetSourceArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GObject.Object GetSource()
        {
            CheckGetSourceArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_source(binding_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Retrieves the name of the property of #GBinding:source used as the source
        /// of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the name of the source property
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_binding_get_source_property(
        /* <type name="Binding" type="GBinding*" managed-name="Binding" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetSourcePropertyArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GLib.UnownedUtf8 GetSourceProperty()
        {
            CheckGetSourcePropertyArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_source_property(binding_);
            var ret = new GISharp.Lib.GLib.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Retrieves the #GObject instance used as the target of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the target #GObject
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Object" type="GObject*" managed-name="Object" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_binding_get_target(
        /* <type name="Binding" type="GBinding*" managed-name="Binding" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetTargetArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GObject.Object GetTarget()
        {
            CheckGetTargetArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_target(binding_);
            var ret = GISharp.Runtime.Opaque.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None)!;
            return ret;
        }

        /// <summary>
        /// Retrieves the name of the property of #GBinding:target used as the target
        /// of the binding.
        /// </summary>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        /// <returns>
        /// the name of the target property
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.26")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="utf8" type="const gchar*" managed-name="GISharp.Lib.GLib.Utf8" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        private static extern byte* g_binding_get_target_property(
        /* <type name="Binding" type="GBinding*" managed-name="Binding" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckGetTargetPropertyArgs();

        [GISharp.Runtime.SinceAttribute("2.26")]
        private GISharp.Lib.GLib.UnownedUtf8 GetTargetProperty()
        {
            CheckGetTargetPropertyArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_get_target_property(binding_);
            var ret = new GISharp.Lib.GLib.UnownedUtf8(ret_);
            return ret;
        }

        /// <summary>
        /// Explicitly releases the binding between the source and the target
        /// property expressed by @binding.
        /// </summary>
        /// <remarks>
        /// This function will release the reference that is being held on
        /// the @binding instance; if you want to hold on to the #GBinding instance
        /// after calling g_binding_unbind(), you will need to hold a reference
        /// to it.
        /// </remarks>
        /// <param name="binding">
        /// a #GBinding
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.38")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="System.Void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_binding_unbind(
        /* <type name="Binding" type="GBinding*" managed-name="Binding" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Binding.UnmanagedStruct* binding);
        partial void CheckUnbindArgs();

        /// <include file="Binding.xmldoc" path="declaration/member[@name='Binding.Unbind()']/*" />
        [GISharp.Runtime.SinceAttribute("2.38")]
        public void Unbind()
        {
            CheckUnbindArgs();
            var binding_ = (GISharp.Lib.GObject.Binding.UnmanagedStruct*)UnsafeHandle;
            g_binding_unbind(binding_);
        }
    }
}