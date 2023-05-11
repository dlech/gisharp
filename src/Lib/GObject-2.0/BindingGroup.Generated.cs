// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GObject
{
    /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup']/*" />
    [GISharp.Runtime.SinceAttribute("2.72")]
    [GISharp.Runtime.GTypeAttribute("GBindingGroup", IsProxyForUnmanagedType = true)]
    public sealed unsafe partial class BindingGroup : GISharp.Lib.GObject.Object
    {
        private static readonly GISharp.Runtime.GType _GType = g_binding_group_get_type();

        /// <summary>
        /// The unmanaged data structure.
        /// </summary>
        public new struct UnmanagedStruct
        {
        }

        /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup.Source']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        [GISharp.Runtime.GPropertyAttribute("source")]
        public GISharp.Lib.GObject.Object? Source { get => (GISharp.Lib.GObject.Object?)GetProperty("source")!; set => SetProperty("source", value); }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public BindingGroup(System.IntPtr handle, GISharp.Runtime.Transfer ownership) : base(handle, ownership)
        {
        }

        /// <summary>
        /// Creates a new #GBindingGroup.
        /// </summary>
        /// <returns>
        /// a new #GBindingGroup
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="BindingGroup" type="GBindingGroup*" is-pointer="1" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Lib.GObject.BindingGroup.UnmanagedStruct* g_binding_group_new();
        static partial void CheckNewArgs();

        [GISharp.Runtime.SinceAttribute("2.72")]
        static GISharp.Lib.GObject.BindingGroup.UnmanagedStruct* New()
        {
            CheckNewArgs();
            var ret_ = g_binding_group_new();
            GISharp.Runtime.GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup.BindingGroup()']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public BindingGroup() : this((System.IntPtr)New(), GISharp.Runtime.Transfer.Full)
        {
        }

        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="GType" type="GType" /> */
        /* transfer-ownership:full direction:in */
        private static extern GISharp.Runtime.GType g_binding_group_get_type();

        /// <summary>
        /// Creates a binding between @source_property on the source object
        /// and @target_property on @target. Whenever the @source_property
        /// is changed the @target_property is updated using the same value.
        /// The binding flag %G_BINDING_SYNC_CREATE is automatically specified.
        /// </summary>
        /// <remarks>
        /// <para>
        /// See g_object_bind_property() for more information.
        /// </para>
        /// </remarks>
        /// <param name="self">
        /// the #GBindingGroup
        /// </param>
        /// <param name="sourceProperty">
        /// the property on the source to bind
        /// </param>
        /// <param name="target">
        /// the target #GObject
        /// </param>
        /// <param name="targetProperty">
        /// the property on @target to bind
        /// </param>
        /// <param name="flags">
        /// the flags used to create the #GBinding
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_binding_group_bind(
        /* <type name="BindingGroup" type="GBindingGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.BindingGroup.UnmanagedStruct* self,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* sourceProperty,
        /* <type name="Object" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* target,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* targetProperty,
        /* <type name="BindingFlags" type="GBindingFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.BindingFlags flags);
        partial void CheckBindArgs(GISharp.Runtime.UnownedUtf8 sourceProperty, GISharp.Lib.GObject.Object target, GISharp.Runtime.UnownedUtf8 targetProperty, GISharp.Lib.GObject.BindingFlags flags);

        /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup.Bind(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GObject.Object,GISharp.Runtime.UnownedUtf8,GISharp.Lib.GObject.BindingFlags)']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public void Bind(GISharp.Runtime.UnownedUtf8 sourceProperty, GISharp.Lib.GObject.Object target, GISharp.Runtime.UnownedUtf8 targetProperty, GISharp.Lib.GObject.BindingFlags flags)
        {
            CheckBindArgs(sourceProperty, target, targetProperty, flags);
            var self_ = (GISharp.Lib.GObject.BindingGroup.UnmanagedStruct*)UnsafeHandle;
            var sourceProperty_ = (byte*)sourceProperty.UnsafeHandle;
            var target_ = (GISharp.Lib.GObject.Object.UnmanagedStruct*)target.UnsafeHandle;
            var targetProperty_ = (byte*)targetProperty.UnsafeHandle;
            var flags_ = (GISharp.Lib.GObject.BindingFlags)flags;
            g_binding_group_bind(self_, sourceProperty_, target_, targetProperty_, flags_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Creates a binding between @source_property on the source object and
        /// @target_property on @target, allowing you to set the transformation
        /// functions to be used by the binding. The binding flag
        /// %G_BINDING_SYNC_CREATE is automatically specified.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function is the language bindings friendly version of
        /// g_binding_group_bind_property_full(), using #GClosures
        /// instead of function pointers.
        /// </para>
        /// <para>
        /// See g_object_bind_property_with_closures() for more information.
        /// </para>
        /// </remarks>
        /// <param name="self">
        /// the #GBindingGroup
        /// </param>
        /// <param name="sourceProperty">
        /// the property on the source to bind
        /// </param>
        /// <param name="target">
        /// the target #GObject
        /// </param>
        /// <param name="targetProperty">
        /// the property on @target to bind
        /// </param>
        /// <param name="flags">
        /// the flags used to create the #GBinding
        /// </param>
        /// <param name="transformTo">
        /// a #GClosure wrapping the
        ///     transformation function from the source object to the @target,
        ///     or %NULL to use the default
        /// </param>
        /// <param name="transformFrom">
        /// a #GClosure wrapping the
        ///     transformation function from the @target to the source object,
        ///     or %NULL to use the default
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_binding_group_bind_with_closures(
        /* <type name="BindingGroup" type="GBindingGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.BindingGroup.UnmanagedStruct* self,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* sourceProperty,
        /* <type name="Object" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* target,
        /* <type name="utf8" type="const gchar*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        byte* targetProperty,
        /* <type name="BindingFlags" type="GBindingFlags" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.BindingFlags flags,
        /* <type name="Closure" type="GClosure*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* transformTo,
        /* <type name="Closure" type="GClosure*" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GObject.Closure.UnmanagedStruct* transformFrom);
        partial void CheckBindFullArgs(GISharp.Runtime.UnownedUtf8 sourceProperty, GISharp.Lib.GObject.Object target, GISharp.Runtime.UnownedUtf8 targetProperty, GISharp.Lib.GObject.BindingFlags flags, GISharp.Lib.GObject.Closure? transformTo, GISharp.Lib.GObject.Closure? transformFrom);

        /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup.BindFull(GISharp.Runtime.UnownedUtf8,GISharp.Lib.GObject.Object,GISharp.Runtime.UnownedUtf8,GISharp.Lib.GObject.BindingFlags,GISharp.Lib.GObject.Closure?,GISharp.Lib.GObject.Closure?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public void BindFull(GISharp.Runtime.UnownedUtf8 sourceProperty, GISharp.Lib.GObject.Object target, GISharp.Runtime.UnownedUtf8 targetProperty, GISharp.Lib.GObject.BindingFlags flags, GISharp.Lib.GObject.Closure? transformTo, GISharp.Lib.GObject.Closure? transformFrom)
        {
            CheckBindFullArgs(sourceProperty, target, targetProperty, flags, transformTo, transformFrom);
            var self_ = (GISharp.Lib.GObject.BindingGroup.UnmanagedStruct*)UnsafeHandle;
            var sourceProperty_ = (byte*)sourceProperty.UnsafeHandle;
            var target_ = (GISharp.Lib.GObject.Object.UnmanagedStruct*)target.UnsafeHandle;
            var targetProperty_ = (byte*)targetProperty.UnsafeHandle;
            var flags_ = (GISharp.Lib.GObject.BindingFlags)flags;
            var transformTo_ = (GISharp.Lib.GObject.Closure.UnmanagedStruct*)(transformTo?.UnsafeHandle ?? System.IntPtr.Zero);
            var transformFrom_ = (GISharp.Lib.GObject.Closure.UnmanagedStruct*)(transformFrom?.UnsafeHandle ?? System.IntPtr.Zero);
            g_binding_group_bind_with_closures(self_, sourceProperty_, target_, targetProperty_, flags_, transformTo_, transformFrom_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }

        /// <summary>
        /// Gets the source object used for binding properties.
        /// </summary>
        /// <param name="self">
        /// the #GBindingGroup
        /// </param>
        /// <returns>
        /// a #GObject or %NULL.
        /// </returns>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 direction:in */
        private static extern GISharp.Lib.GObject.Object.UnmanagedStruct* g_binding_group_dup_source(
        /* <type name="BindingGroup" type="GBindingGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.BindingGroup.UnmanagedStruct* self);
        partial void CheckDupSourceArgs();

        /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup.DupSource()']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public GISharp.Lib.GObject.Object? DupSource()
        {
            CheckDupSourceArgs();
            var self_ = (GISharp.Lib.GObject.BindingGroup.UnmanagedStruct*)UnsafeHandle;
            var ret_ = g_binding_group_dup_source(self_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
            var ret = GISharp.Lib.GObject.Object.GetInstance<GISharp.Lib.GObject.Object>((System.IntPtr)ret_, GISharp.Runtime.Transfer.None);
            return ret;
        }

        /// <summary>
        /// Sets @source as the source object used for creating property
        /// bindings. If there is already a source object all bindings from it
        /// will be removed.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note that all properties that have been bound must exist on @source.
        /// </para>
        /// </remarks>
        /// <param name="self">
        /// the #GBindingGroup
        /// </param>
        /// <param name="source">
        /// the source #GObject,
        ///   or %NULL to clear it
        /// </param>
        [GISharp.Runtime.SinceAttribute("2.72")]
        [System.Runtime.InteropServices.DllImportAttribute("gobject-2.0", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        /* <type name="none" type="void" /> */
        /* transfer-ownership:none direction:in */
        private static extern void g_binding_group_set_source(
        /* <type name="BindingGroup" type="GBindingGroup*" is-pointer="1" /> */
        /* transfer-ownership:none direction:in */
        GISharp.Lib.GObject.BindingGroup.UnmanagedStruct* self,
        /* <type name="Object" type="gpointer" is-pointer="1" /> */
        /* transfer-ownership:none nullable:1 allow-none:1 direction:in */
        GISharp.Lib.GObject.Object.UnmanagedStruct* source);
        partial void CheckSetSourceArgs(GISharp.Lib.GObject.Object? source);

        /// <include file="BindingGroup.xmldoc" path="declaration/member[@name='BindingGroup.SetSource(GISharp.Lib.GObject.Object?)']/*" />
        [GISharp.Runtime.SinceAttribute("2.72")]
        public void SetSource(GISharp.Lib.GObject.Object? source)
        {
            CheckSetSourceArgs(source);
            var self_ = (GISharp.Lib.GObject.BindingGroup.UnmanagedStruct*)UnsafeHandle;
            var source_ = (GISharp.Lib.GObject.Object.UnmanagedStruct*)(source?.UnsafeHandle ?? System.IntPtr.Zero);
            g_binding_group_set_source(self_, source_);
            GISharp.Runtime.GMarshal.PopUnhandledException();
        }
    }
}