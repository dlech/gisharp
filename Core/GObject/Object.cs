using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using System.Reflection;

using GISharp.GLib;

namespace GISharp.GObject
{
    /// <summary>
    /// All the fields in the GObject structure are private
    /// to the #GObject implementation and should never be accessed directly.
    /// </summary>
    [GType ("GObject", IsWrappedNativeType = true)]
    [GTypeStruct (typeof (ObjectClass))]
    public class Object : TypeInstance, INotifyPropertyChanged
    {
        static readonly IntPtr refCountOffset = Marshal.OffsetOf<Struct> (nameof(Struct.RefCount));

        // this is a pointer to a GCHandle, not just the GCHandle cast as an IntPtr
        IntPtr gcHandlePtr;
        
        protected new struct Struct
        {
#pragma warning disable CS0649
            public TypeInstance.Struct GTypeInstance;
            public uint RefCount;
            public IntPtr Qdata;
#pragma warning restore CS0649
        }

        uint RefCount {
            get {
                AssertNotDisposed ();
                return (uint)Marshal.ReadInt32 (Handle + (int)refCountOffset);
            }
        }

        public Object (IntPtr handle, Transfer ownership) : base (handle)
        {
            if (ownership == Transfer.None) {
                g_object_ref (handle);
            }

            // always start with a strong reference to the managed object
            gcHandlePtr = GMarshal.Alloc (IntPtr.Size);
            var gcHandle = GCHandle.Alloc (this);
            Marshal.WriteIntPtr (gcHandlePtr, (IntPtr)gcHandle);
            g_object_add_toggle_ref (Handle, toggleNotifyCallback, gcHandlePtr);

            // IntPtr always owns a reference so release it now that we have a toggle reference instead.
            // If this is the last normal reference, toggleNotifyCallback will be called immediately
            // to convert the strong reference to a weak reference
            g_object_unref (Handle);
        }

        protected override void Dispose (bool disposing)
        {
            if (Handle != IntPtr.Zero) {
                // we either have a toggle reference or a regular reference, but not both
                if (gcHandlePtr != IntPtr.Zero) {
                    g_object_remove_toggle_ref (Handle, toggleNotifyCallback, gcHandlePtr);
                    var gcHandle = (GCHandle)Marshal.ReadIntPtr (gcHandlePtr);
                    gcHandle.Free ();
                    GMarshal.Free (gcHandlePtr);
                    gcHandlePtr = IntPtr.Zero;
                }
                else {
                    g_object_unref (Handle);
                }
            }
            base.Dispose (disposing);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref (IntPtr @object);

        protected override void Ref ()
        {
            AssertNotDisposed ();
            g_object_ref (Handle);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref (IntPtr @object);

        protected override void Unref ()
        {
            AssertNotDisposed ();
            g_object_unref (Handle);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_add_toggle_ref (IntPtr @object, NativeToggleNotify notify, IntPtr data);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_remove_toggle_ref (IntPtr @object, NativeToggleNotify notify, IntPtr data);

        static void toggleNotifyCallback (IntPtr data, IntPtr @object, bool isLastRef)
        {
            try {
                // free the existing GCHandle
                var gcHandle = (GCHandle)Marshal.ReadIntPtr (data);
                var obj = gcHandle.Target;
                gcHandle.Free ();

                // alloc a new GCHandle with weak/strong reference depending on isLastRef
                gcHandle = GCHandle.Alloc (obj, isLastRef ? GCHandleType.Weak : GCHandleType.Normal);
                Marshal.WriteIntPtr (data, (IntPtr)gcHandle);
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
            }
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_object_get_type ();

        static GType getType ()
        {
            return g_object_get_type ();
        }

        delegate void NativeNotify (IntPtr gobjectPtr, IntPtr pspecPtr, IntPtr userDataPtr);

        static void NativeOnNotify (IntPtr gobjectPtr, IntPtr pspecPtr, IntPtr userDataPtr)
        {
            try {
                var obj = GetInstance<Object> (gobjectPtr, Transfer.None);
                var pspec = GetInstance<ParamSpec> (pspecPtr, Transfer.None);
                var propInfo = (PropertyInfo)pspec.GetQData (ObjectClass.managedClassPropertyInfoQuark);
                obj.OnPropertyChanged (propInfo.Name);
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
            }
        }

        PropertyChangedEventHandler propertyChangedHandler;
        object propertyChangedHandlerLock = new object ();
        SignalHandler notifySignalHandler;

        SignalHandler ConnectNotifySignal ()
        {
            var nativeNotifyPtr = Marshal.GetFunctionPointerForDelegate<NativeNotify> (NativeOnNotify);
            var id = Signal.g_signal_connect_data (Handle, GMarshal.StringToUtf8Ptr ("notify"),
                nativeNotifyPtr, IntPtr.Zero, null, default (ConnectFlags));

            return new SignalHandler (this, id);
        }

        #region INotifyPropertyChanged implementation

        [GTypeSignal ("notify")]
        public event PropertyChangedEventHandler PropertyChanged {
            add {
                lock (propertyChangedHandlerLock) {
                    if (propertyChangedHandler == null) {
                        notifySignalHandler = ConnectNotifySignal ();
                    }
                    propertyChangedHandler += value;
                }
            }
            remove {
                lock (propertyChangedHandlerLock) {
                    propertyChangedHandler -= value;
                    if (propertyChangedHandler == null) {
                        notifySignalHandler.Disconnect ();
                        notifySignalHandler = null;
                    }
                }
            }
        }

        #endregion

        void OnPropertyChanged (string name)
        {
            if (propertyChangedHandler != null) {
                propertyChangedHandler (this, new PropertyChangedEventArgs (name));
            }
        }

        /// <summary>
        /// Creates a new instance of a #GObject subtype and sets its properties.
        /// </summary>
        /// <remarks>
        /// Construction parameters (see #G_PARAM_CONSTRUCT, #G_PARAM_CONSTRUCT_ONLY)
        /// which are not explicitly specified are set to their default values.
        /// </remarks>
        /// <param name="objectType">
        /// the type id of the #GObject subtype to instantiate
        /// </param>
        /// <param name="nParameters">
        /// the length of the @parameters array
        /// </param>
        /// <param name="parameters">
        /// an array of #GParameter
        /// </param>
        /// <returns>
        /// a new instance of
        /// @object_type
        /// </returns>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" managed-name="Object" /> */
        /* transfer-ownership:full */
        internal static extern IntPtr g_object_newv (
            /* <type name="GType" type="GType" managed-name="GType" /> */
            /* transfer-ownership:none */
            GType objectType,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nParameters,
            /* <array length="1" zero-terminated="0" type="GParameter*">
               <type name="Parameter" type="GParameter" managed-name="Parameter" />
               </array> */
            /* transfer-ownership:none */
            IntPtr parameters);

        protected static IntPtr New<T> (params object[] parameters) where T : Object
        {
            var gtype = GType.TypeOf<T> ();
            var paramArray = new Parameter[parameters.Length / 2];
            for (int i = 0; i < parameters.Length; i += 2) {
                var name = parameters[i] as string;
                if (name == null) {
                    var message = string.Format ("Expecting string at index {0}", i);
                    throw new ArgumentException (message, nameof (parameters));
                }
                var objClass = TypeClass.Get<ObjectClass> (gtype);
                var paramSpec = objClass.FindProperty (name);
                if (paramSpec == null) {
                    var message = string.Format ("Could not find property '{0}'", name);
                    throw new ArgumentException (message, nameof (parameters));
                }
                var value = new Value (paramSpec.ValueType, parameters[i + 1]);
                paramArray[i / 2] = new Parameter {
                    Name = GMarshal.StringToUtf8Ptr (name),
                };
                Marshal.StructureToPtr<Value> (value, paramArray[i / 2].Value, false);
            }
            var paramArrayPtr = GMarshal.CArrayToPtr<Parameter> (paramArray, false);
            try {
                var ret = g_object_newv (gtype, (uint)paramArray.Length, paramArrayPtr);
                return ret;
            }
            finally {
                GMarshal.Free (paramArrayPtr);
                foreach (var p in paramArray) {
                    GMarshal.Free (p.Name);
                }
            }
        }

        /// <summary>
        /// Creates a new instance of type <typeparamref name="T"/> using the specified
        /// property names and values.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <param name="parameters">Property name and value pairs.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T CreateInstance<T> (params object[] parameters) where T : Object
        {
            var handle = New<T> (parameters);
            var instance = (T)Activator.CreateInstance (typeof (T), handle);

            return instance;
        }

        public Object () : this (New<Object> (), Transfer.Full)
        {
        }

        /// <summary>
        /// Find the #GParamSpec with the given name for an
        /// interface. Generally, the interface vtable passed in as @g_iface
        /// will be the default vtable from g_type_default_interface_ref(), or,
        /// if you know the interface has already been loaded,
        /// g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface
        /// </param>
        /// <param name="propertyName">
        /// name of a property to lookup.
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property of the
        ///          interface with the name @property_name, or %NULL if no
        ///          such property exists.
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_interface_find_property (
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gIface,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName);

        /// <summary>
        /// Find the #GParamSpec with the given name for an
        /// interface. Generally, the interface vtable passed in as @g_iface
        /// will be the default vtable from g_type_default_interface_ref(), or,
        /// if you know the interface has already been loaded,
        /// g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface
        /// </param>
        /// <param name="propertyName">
        /// name of a property to lookup.
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property of the
        ///          interface with the name @property_name, or %NULL if no
        ///          such property exists.
        /// </returns>
        [Since ("2.4")]
        static ParamSpec InterfaceFindProperty (IntPtr gIface, string propertyName)
        {
            if (propertyName == null) {
                throw new ArgumentNullException (nameof (propertyName));
            }
            var propertyName_ = GMarshal.StringToUtf8Ptr (propertyName);
            var ret_ = g_object_interface_find_property (gIface, propertyName_);
            var ret = GetInstance<ParamSpec> (ret_, Transfer.None);
            GMarshal.Free (propertyName_);
            return ret;
        }

        /// <summary>
        /// Add a property to an interface; this is only useful for interfaces
        /// that are added to GObject-derived types. Adding a property to an
        /// interface forces all objects classes with that interface to have a
        /// compatible property. The compatible property could be a newly
        /// created #GParamSpec, but normally
        /// g_object_class_override_property() will be used so that the object
        /// class only needs to provide an implementation and inherits the
        /// property description, default value, bounds, and so forth from the
        /// interface property.
        /// </summary>
        /// <remarks>
        /// This function is meant to be called from the interface's default
        /// vtable initialization function (the @class_init member of
        /// #GTypeInfo.) It must not be called after after @class_init has
        /// been called for any object types implementing this interface.
        /// </remarks>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface.
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_interface_install_property (
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gIface,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Add a property to an interface; this is only useful for interfaces
        /// that are added to GObject-derived types. Adding a property to an
        /// interface forces all objects classes with that interface to have a
        /// compatible property. The compatible property could be a newly
        /// created #GParamSpec, but normally
        /// g_object_class_override_property() will be used so that the object
        /// class only needs to provide an implementation and inherits the
        /// property description, default value, bounds, and so forth from the
        /// interface property.
        /// </summary>
        /// <remarks>
        /// This function is meant to be called from the interface's default
        /// vtable initialization function (the @class_init member of
        /// #GTypeInfo.) It must not be called after after @class_init has
        /// been called for any object types implementing this interface.
        /// </remarks>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface.
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        [Since ("2.4")]
        static void InterfaceInstallProperty (IntPtr gIface, ParamSpec pspec)
        {
            if (pspec == null) {
                throw new ArgumentNullException (nameof (pspec));
            }
            g_object_interface_install_property (gIface, pspec.Handle);
            GC.KeepAlive (pspec);
        }

        /// <summary>
        /// Lists the properties of an interface.Generally, the interface
        /// vtable passed in as @g_iface will be the default vtable from
        /// g_type_default_interface_ref(), or, if you know the interface has
        /// already been loaded, g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface
        /// </param>
        /// <param name="nPropertiesP">
        /// location to store number of properties returned.
        /// </param>
        /// <returns>
        /// a
        ///          pointer to an array of pointers to #GParamSpec
        ///          structures. The paramspecs are owned by GLib, but the
        ///          array should be freed with g_free() when you are done with
        ///          it.
        /// </returns>
        [Since ("2.4")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="1" zero-terminated="0" type="GParamSpec**">
          <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" />
          </array> */
        /* transfer-ownership:container */
        static extern IntPtr g_object_interface_list_properties (
            /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
            /* transfer-ownership:none */
            IntPtr gIface,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out uint nPropertiesP);

        /// <summary>
        /// Lists the properties of an interface.Generally, the interface
        /// vtable passed in as @g_iface will be the default vtable from
        /// g_type_default_interface_ref(), or, if you know the interface has
        /// already been loaded, g_type_default_interface_peek().
        /// </summary>
        /// <param name="gIface">
        /// any interface vtable for the interface, or the default
        ///  vtable for the interface
        /// </param>
        /// <returns>
        /// a
        ///          pointer to an array of pointers to #GParamSpec
        ///          structures. The paramspecs are owned by GLib, but the
        ///          array should be freed with g_free() when you are done with
        ///          it.
        /// </returns>
        [Since ("2.4")]
        static ParamSpec[] InterfaceListProperties (IntPtr gIface)
        {
            uint nPropertiesP_;
            var ret_ = g_object_interface_list_properties (gIface, out nPropertiesP_);
            var ret = GMarshal.PtrToOpaqueCArray<ParamSpec> (ret_, (int)nPropertiesP_, true);
            return ret;
        }

        /// <summary>
        /// Creates a binding between @source_property on @source and @target_property
        /// on @target. Whenever the @source_property is changed the @target_property is
        /// updated using the same value. For instance:
        /// </summary>
        /// <remarks>
        /// |[
        ///   g_object_bind_property (action, "active", widget, "sensitive", 0);
        /// ]|
        ///
        /// Will result in the "sensitive" property of the widget #GObject instance to be
        /// updated with the same value of the "active" property of the action #GObject
        /// instance.
        ///
        /// If @flags contains %G_BINDING_BIDIRECTIONAL then the binding will be mutual:
        /// if @target_property on @target changes then the @source_property on @source
        /// will be updated as well.
        ///
        /// The binding will automatically be removed when either the @source or the
        /// @target instances are finalized. To remove the binding without affecting the
        /// @source and the @target you can just call g_object_unref() on the returned
        /// #GBinding instance.
        ///
        /// A #GObject can have multiple bindings.
        /// </remarks>
        /// <param name="source">
        /// the source #GObject
        /// </param>
        /// <param name="sourceProperty">
        /// the property on @source to bind
        /// </param>
        /// <param name="target">
        /// the target #GObject
        /// </param>
        /// <param name="targetProperty">
        /// the property on @target to bind
        /// </param>
        /// <param name="flags">
        /// flags to pass to #GBinding
        /// </param>
        /// <returns>
        /// the #GBinding instance representing the
        ///     binding between the two #GObject instances. The binding is released
        ///     whenever the #GBinding reference count reaches zero.
        /// </returns>
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_bind_property (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr source,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr sourceProperty,
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr target,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr targetProperty,
            /* <type name="BindingFlags" type="GBindingFlags" managed-name="BindingFlags" /> */
            /* transfer-ownership:none */
            BindingFlags flags);

        /// <summary>
        /// Creates a binding between <paramref name="sourceProperty"/> on
        /// <paramref name="target"/> and <paramref name="targetProperty"/>
        /// on <paramref name="target"/>.
        /// </summary>
        /// <remarks>
        /// Whenever the <paramref name="sourceProperty"/>
        /// is changed the <paramref name="targetProperty"/> is
        /// updated using the same value. For instance:
        /// 
        /// |[
        ///   g_object_bind_property (action, "active", widget, "sensitive", 0);
        /// ]|
        ///
        /// Will result in the "sensitive" property of the widget #GObject instance to be
        /// updated with the same value of the "active" property of the action #GObject
        /// instance.
        ///
        /// If @flags contains %G_BINDING_BIDIRECTIONAL then the binding will be mutual:
        /// if @target_property on @target changes then the @source_property on @source
        /// will be updated as well.
        ///
        /// The binding will automatically be removed when either the @source or the
        /// @target instances are finalized. To remove the binding without affecting the
        /// @source and the @target you can just call g_object_unref() on the returned
        /// #GBinding instance.
        ///
        /// A #GObject can have multiple bindings.
        /// </remarks>
        /// <param name="sourceProperty">
        /// the property on this instance to bind
        /// </param>
        /// <param name="target">
        /// the target <see cref="Object"/>
        /// </param>
        /// <param name="targetProperty">
        /// the property on <paramref name="target"/> to bind
        /// </param>
        /// <param name="flags">
        /// flags to pass to <see cref="Binding"/>
        /// </param>
        /// <returns>
        /// the <see cref="Binding"/> instance representing the binding between
        /// the two <see cref="Object"/> instances. The binding is released
        /// whenever the <see cref="Binding"/> reference count reaches zero.
        /// </returns>
        [Since ("2.26")]
        public Binding BindProperty (string sourceProperty, Object target, string targetProperty, BindingFlags flags = BindingFlags.Default)
        {
            AssertNotDisposed ();
            if (sourceProperty == null) {
                throw new ArgumentNullException (nameof (sourceProperty));
            }
            if (target == null) {
                throw new ArgumentNullException (nameof (target));
            }
            if (targetProperty == null) {
                throw new ArgumentNullException (nameof (targetProperty));
            }

            var sourcePropertyInfo = GetType ().GetProperty (sourceProperty);
            if (sourcePropertyInfo == null) {
                throw new ArgumentException ($"No matching property", nameof (sourceProperty));
            }
            sourceProperty = sourcePropertyInfo.TryGetGTypePropertyName ();

            var targetPropertyInfo = target.GetType ().GetProperty (targetProperty);
            if (targetPropertyInfo == null) {
                throw new ArgumentException ($"No matching property", nameof (targetProperty));
            }
            targetProperty = targetPropertyInfo.TryGetGTypePropertyName ();

            var sourceProperty_ = GMarshal.StringToUtf8Ptr (sourceProperty);
            var targetProperty_ = GMarshal.StringToUtf8Ptr (targetProperty);
            var ret_ = g_object_bind_property (Handle, sourceProperty_, target.Handle, targetProperty_, flags);
            // This actually results in having two references. One owned by the managed
            // instance and one extra. This is actually desirable, otherise we
            // would always have to keep a managed reference to the binding object.
            // Also, calling Binding.Unbind() will free the extra reference.
            var ret = GetInstance<Binding> (ret_, Transfer.None);
            GMarshal.Free (sourceProperty_);
            GMarshal.Free (targetProperty_);
            return ret;
        }

        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_bind_property_full (
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr source,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr sourceProperty,
            /* <type name="Object" type="gpointer" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr target,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr targetProperty,
            /* <type name="BindingFlags" type="GBindingFlags" managed-name="BindingFlags" /> */
            /* transfer-ownership:none */
            BindingFlags flags,
            NativeBindingTransformFunc transformTo,
            NativeBindingTransformFunc transformFrom,
            IntPtr userData,
            NativeDestroyNotify notify);

        /// <summary>
        /// Creates a binding between <paramref name="sourceProperty"/> on 
        /// this instance and <paramref name="targetProperty"/> on <paramref name="target"/>,
        /// allowing you to set the transformation functions to be used by
        /// the binding.
        /// </summary>
        /// <remarks>
        /// If flags contains <see cref="BindingFlags.Bidirectional"/> then the
        /// binding will be mutual: if <paramref name="targetProperty"/> on
        /// <paramref name="target"/> changes then the <paramref name="sourceProperty"/>
        /// on this instance will be updated as well. The <paramref name="transformFrom"/>
        /// function is only used in case of bidirectional bindings, otherwise it will be ignored.
        ///
        /// The binding will automatically be removed when either the this intance
        /// or the <paramref name="target"/> instances are finalized. To remove the binding
        /// without affecting this instance and the <paramref name="target"/> you can
        /// just call <see cref="Binding.Unbind"/> on the returned <see cref="Binding"/> instance.
        ///
        /// An <see cref="Object"/> can have multiple bindings.
        /// </remarks>
        /// <param name="sourceProperty">
        /// the property on this instance to bind
        /// </param>
        /// <param name="target">
        /// the target <see cref="Object"/>
        /// </param>
        /// <param name="targetProperty">
        /// the property on <paramref name="target"/> to bind
        /// </param>
        /// <param name="flags">
        /// flags to pass to <see cref="Binding"/>
        /// </param>
        /// <param name="transformTo">
        /// the transformation function from this instance to the <paramref name="target"/>,
        /// or <c>null</c> to use the default
        /// </param>
        /// <param name="transformFrom">
        /// the transformation function from the <paramref name="target"/> to this
        /// instance, or <c>null</c> to use the default
        /// </param>
        /// <returns>
        /// the <see cref="Binding"/> instance representing the binding between
        /// the two <see cref="Object"/> instances. The binding is released
        /// whenever the <see cref="Binding"/> reference count reaches zero.
        /// </returns>
        [Since ("2.26")]
        public Binding BindProperty (string sourceProperty, Object target, string targetProperty, BindingFlags flags, BindingTransformFunc transformTo, BindingTransformFunc transformFrom)
        {
            AssertNotDisposed ();
            if (sourceProperty == null) {
                throw new ArgumentNullException (nameof (sourceProperty));
            }
            if (target == null) {
                throw new ArgumentNullException (nameof (target));
            }
            if (targetProperty == null) {
                throw new ArgumentNullException (nameof (targetProperty));
            }
            var sourceProperty_ = GMarshal.StringToUtf8Ptr (sourceProperty);
            var targetProperty_ = GMarshal.StringToUtf8Ptr (targetProperty);
            var transformTo_ = transformTo == null ? (NativeBindingTransformFunc)null : TransformToFunc;
            var transformFrom_ = transformFrom == null ? (NativeBindingTransformFunc)null : TransformFromFunc;
            var userData = new BindingTransformFuncs (transformTo, transformFrom);
            var userData_ = GCHandle.ToIntPtr (GCHandle.Alloc (userData));
            var ret_ = g_object_bind_property_full (Handle, sourceProperty_, target.Handle, targetProperty_, flags,
                                                    transformTo_, transformFrom_, userData_, FreeBindingTransformFuncs);
            var ret = GetInstance<Binding> (ret_, Transfer.None);
            GMarshal.Free (sourceProperty_);
            GMarshal.Free (targetProperty_);
            return ret;
        }

        class BindingTransformFuncs
        {
            public readonly BindingTransformFunc TransformTo;
            public readonly BindingTransformFunc TransformFrom;

            public BindingTransformFuncs (BindingTransformFunc transformTo, BindingTransformFunc transformFrom)
            {
                TransformTo = transformTo;
                TransformFrom = transformFrom;
            }
        }

        static bool TransformToFunc (IntPtr bindingPtr, ref Value toValue, ref Value fromValue, IntPtr userDataPtr)
        {
            try {
                var binding = GetInstance<Binding> (bindingPtr, Transfer.None);
                var funcs = (BindingTransformFuncs)GCHandle.FromIntPtr (userDataPtr).Target;
                var ret = funcs.TransformTo (binding, ref toValue, ref fromValue);
                return ret;
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
                return default(bool);
            }
        }

        static bool TransformFromFunc (IntPtr bindingPtr, ref Value toValue, ref Value fromValue, IntPtr userDataPtr)
        {
            try {
                var binding = GetInstance<Binding> (bindingPtr, Transfer.None);
                var funcs = (BindingTransformFuncs)GCHandle.FromIntPtr (userDataPtr).Target;
                var ret = funcs.TransformFrom (binding, ref toValue, ref fromValue);
                return ret;
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
                return default(bool);
            }
        }

        static void FreeBindingTransformFuncs (IntPtr userData)
        {
            try {
                var data = GCHandle.FromIntPtr (userData);
                data.Free ();
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
            }
        }

        /// <summary>
        /// Increases the freeze count on @object. If the freeze count is
        /// non-zero, the emission of "notify" signals on @object is
        /// stopped. The signals are queued until the freeze count is decreased
        /// to zero. Duplicate notifications are squashed so that at most one
        /// #GObject::notify signal is emitted for each property modified while the
        /// object is frozen.
        /// </summary>
        /// <remarks>
        /// This is necessary for accessors that modify multiple properties to prevent
        /// premature notification while the object is still being modified.
        /// </remarks>
        /// <param name="object">
        /// a #GObject
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_freeze_notify (
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object);

        /// <summary>
        /// Increases the freeze count on @object. If the freeze count is
        /// non-zero, the emission of "notify" signals on @object is
        /// stopped. The signals are queued until the freeze count is decreased
        /// to zero. Duplicate notifications are squashed so that at most one
        /// #GObject::notify signal is emitted for each property modified while the
        /// object is frozen.
        /// </summary>
        /// <remarks>
        /// This is necessary for accessors that modify multiple properties to prevent
        /// premature notification while the object is still being modified.
        /// </remarks>
        public void FreezeNotify ()
        {
            AssertNotDisposed ();
            g_object_freeze_notify (Handle);
        }

        /// <summary>
        /// Gets a property of an object. @value must have been initialized to the
        /// expected type of the property (or a type to which the expected type can be
        /// transformed) using g_value_init().
        /// </summary>
        /// <remarks>
        /// In general, a copy is made of the property contents and the caller is
        /// responsible for freeing the memory by calling g_value_unset().
        ///
        /// Note that g_object_get_property() is really intended for language
        /// bindings, g_object_get() is much more convenient for C programming.
        /// </remarks>
        /// <param name="object">
        /// a #GObject
        /// </param>
        /// <param name="propertyName">
        /// the name of the property to get
        /// </param>
        /// <param name="value">
        /// return location for the property value
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_get_property (
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName,
            /* <type name="Value" type="GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value);

        /// <summary>
        /// Gets a property of an object. @value must have been initialized to the
        /// expected type of the property (or a type to which the expected type can be
        /// transformed) using g_value_init().
        /// </summary>
        /// <remarks>
        /// In general, a copy is made of the property contents and the caller is
        /// responsible for freeing the memory by calling g_value_unset().
        ///
        /// Note that g_object_get_property() is really intended for language
        /// bindings, g_object_get() is much more convenient for C programming.
        /// </remarks>
        /// <param name="propertyName">
        /// the name of the property to get
        /// </param>
        /// <returns>
        /// the property value
        /// </returns>
        public Value GetProperty (string propertyName, GType type)
        {
            AssertNotDisposed ();
            if (propertyName == null) {
                throw new ArgumentNullException (nameof (propertyName));
            }
            var value = new Value (type);
            var propertyName_ = GMarshal.StringToUtf8Ptr (propertyName);
            g_object_get_property (Handle, propertyName_, ref value);
            GMarshal.Free (propertyName_);

            return value;
        }

        /// <summary>
        /// Emits a "notify" signal for the property @property_name on @object.
        /// </summary>
        /// <remarks>
        /// When possible, eg. when signaling a property change from within the class
        /// that registered the property, you should use g_object_notify_by_pspec()
        /// instead.
        ///
        /// Note that emission of the notify signal may be blocked with
        /// g_object_freeze_notify(). In this case, the signal emissions are queued
        /// and will be emitted (in reverse order) when g_object_thaw_notify() is
        /// called.
        /// </remarks>
        /// <param name="object">
        /// a #GObject
        /// </param>
        /// <param name="propertyName">
        /// the name of a property installed on the class of @object.
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_notify (
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName);

        /// <summary>
        /// Emits a "notify" signal for the property @property_name on @object.
        /// </summary>
        /// <remarks>
        /// When possible, eg. when signaling a property change from within the class
        /// that registered the property, you should use g_object_notify_by_pspec()
        /// instead.
        ///
        /// Note that emission of the notify signal may be blocked with
        /// g_object_freeze_notify(). In this case, the signal emissions are queued
        /// and will be emitted (in reverse order) when g_object_thaw_notify() is
        /// called.
        /// </remarks>
        /// <param name="propertyName">
        /// the name of a property installed on the class of @object.
        /// </param>
        public void Notify (string propertyName)
        {
            AssertNotDisposed ();
            if (propertyName == null) {
                throw new ArgumentNullException (nameof (propertyName));
            }
            var propertyName_ = GMarshal.StringToUtf8Ptr (propertyName);
            g_object_notify (Handle, propertyName_);
            GMarshal.Free (propertyName_);
        }

        /// <summary>
        /// Emits a "notify" signal for the property specified by @pspec on @object.
        /// </summary>
        /// <remarks>
        /// This function omits the property name lookup, hence it is faster than
        /// g_object_notify().
        ///
        /// One way to avoid using g_object_notify() from within the
        /// class that registered the properties, and using g_object_notify_by_pspec()
        /// instead, is to store the GParamSpec used with
        /// g_object_class_install_property() inside a static array, e.g.:
        ///
        /// |[&lt;!-- language="C" --&gt;
        ///   enum
        ///   {
        ///     PROP_0,
        ///     PROP_FOO,
        ///     PROP_LAST
        ///   };
        ///
        ///   static GParamSpec *properties[PROP_LAST];
        ///
        ///   static void
        ///   my_object_class_init (MyObjectClass *klass)
        ///   {
        ///     properties[PROP_FOO] = g_param_spec_int ("foo", "Foo", "The foo",
        ///                                              0, 100,
        ///                                              50,
        ///                                              G_PARAM_READWRITE);
        ///     g_object_class_install_property (gobject_class,
        ///                                      PROP_FOO,
        ///                                      properties[PROP_FOO]);
        ///   }
        /// ]|
        ///
        /// and then notify a change on the "foo" property with:
        ///
        /// |[&lt;!-- language="C" --&gt;
        ///   g_object_notify_by_pspec (self, properties[PROP_FOO]);
        /// ]|
        /// </remarks>
        /// <param name="object">
        /// a #GObject
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec of a property installed on the class of @object.
        /// </param>
        [Since ("2.26")]
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_notify_by_pspec (
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Emits a "notify" signal for the property specified by @pspec on @object.
        /// </summary>
        /// <remarks>
        /// This function omits the property name lookup, hence it is faster than
        /// g_object_notify().
        ///
        /// One way to avoid using g_object_notify() from within the
        /// class that registered the properties, and using g_object_notify_by_pspec()
        /// instead, is to store the GParamSpec used with
        /// g_object_class_install_property() inside a static array, e.g.:
        ///
        /// |[&lt;!-- language="C" --&gt;
        ///   enum
        ///   {
        ///     PROP_0,
        ///     PROP_FOO,
        ///     PROP_LAST
        ///   };
        ///
        ///   static GParamSpec *properties[PROP_LAST];
        ///
        ///   static void
        ///   my_object_class_init (MyObjectClass *klass)
        ///   {
        ///     properties[PROP_FOO] = g_param_spec_int ("foo", "Foo", "The foo",
        ///                                              0, 100,
        ///                                              50,
        ///                                              G_PARAM_READWRITE);
        ///     g_object_class_install_property (gobject_class,
        ///                                      PROP_FOO,
        ///                                      properties[PROP_FOO]);
        ///   }
        /// ]|
        ///
        /// and then notify a change on the "foo" property with:
        ///
        /// |[&lt;!-- language="C" --&gt;
        ///   g_object_notify_by_pspec (self, properties[PROP_FOO]);
        /// ]|
        /// </remarks>
        /// <param name="pspec">
        /// the #GParamSpec of a property installed on the class of @object.
        /// </param>
        [Since ("2.26")]
        void Notify (ParamSpec pspec)
        {
            AssertNotDisposed ();
            if (pspec == null) {
                throw new ArgumentNullException (nameof (pspec));
            }
            g_object_notify_by_pspec (Handle, pspec.Handle);
            GC.KeepAlive (pspec);
        }

        /// <summary>
        /// Sets a property on an object.
        /// </summary>
        /// <param name="object">
        /// a #GObject
        /// </param>
        /// <param name="propertyName">
        /// the name of the property to set
        /// </param>
        /// <param name="value">
        /// the value
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_set_property (
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName,
            /* <type name="Value" type="const GValue*" managed-name="Value" /> */
            /* transfer-ownership:none */
            ref Value value);

        /// <summary>
        /// Sets a property on an object.
        /// </summary>
        /// <param name="propertyName">
        /// the name of the property to set
        /// </param>
        /// <param name="value">
        /// the value
        /// </param>
        public void SetProperty (string propertyName, Value value)
        {
            AssertNotDisposed ();
            if (propertyName == null) {
                throw new ArgumentNullException (nameof (propertyName));
            }
            var propertyName_ = GMarshal.StringToUtf8Ptr (propertyName);
            g_object_set_property (Handle, propertyName_, ref value);
            GMarshal.Free (propertyName_);
        }

        /// <summary>
        /// Reverts the effect of a previous call to
        /// g_object_freeze_notify(). The freeze count is decreased on @object
        /// and when it reaches zero, queued "notify" signals are emitted.
        /// </summary>
        /// <remarks>
        /// Duplicate notifications for each property are squashed so that at most one
        /// #GObject::notify signal is emitted for each property, in the reverse order
        /// in which they have been queued.
        ///
        /// It is an error to call this function when the freeze count is zero.
        /// </remarks>
        /// <param name="object">
        /// a #GObject
        /// </param>
        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_thaw_notify (
            /* <type name="Object" type="GObject*" managed-name="Object" /> */
            /* transfer-ownership:none */
            IntPtr @object);

        /// <summary>
        /// Reverts the effect of a previous call to
        /// g_object_freeze_notify(). The freeze count is decreased on @object
        /// and when it reaches zero, queued "notify" signals are emitted.
        /// </summary>
        /// <remarks>
        /// Duplicate notifications for each property are squashed so that at most one
        /// #GObject::notify signal is emitted for each property, in the reverse order
        /// in which they have been queued.
        ///
        /// It is an error to call this function when the freeze count is zero.
        /// </remarks>
        public void ThawNotify ()
        {
            AssertNotDisposed ();
            g_object_thaw_notify (Handle);
        }

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_get_data (
            IntPtr @object,
            IntPtr key);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_data (
            IntPtr @object,
            IntPtr key,
            IntPtr data);

        [DllImport ("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_data_full (
            IntPtr @object,
            IntPtr key,
            IntPtr data,
            NativeDestroyNotify destroy);

        public object this[string key] {
            get {
                AssertNotDisposed ();
                var key_ = GMarshal.StringToUtf8Ptr (key);
                var data_ = g_object_get_data (Handle, key_);
                GMarshal.Free (key_);
                if (data_ == IntPtr.Zero) {
                    return null;
                }
                var data = GCHandle.FromIntPtr (data_).Target;
                return data;
            }
            set {
                AssertNotDisposed ();
                var key_ = GMarshal.StringToUtf8Ptr (key);
                if (value == null) {
                    g_object_set_data (Handle, key_, IntPtr.Zero);
                }
                else {
                    var data_ = value == null ? IntPtr.Zero : GCHandle.ToIntPtr (GCHandle.Alloc (value));
                    g_object_set_data_full (Handle, key_, data_, FreeData);
                }
                GMarshal.Free (key_);
            }
        }

        static void FreeData (IntPtr dataPtr)
        {
            try {
                var data = GCHandle.FromIntPtr (dataPtr);
                data.Free ();
            }
            catch (Exception ex) {
                ex.DumpUnhandledException ();
            }
        }
    }

    /// <summary>
    /// A callback function used for notification when the state
    /// of a toggle reference changes. See g_object_add_toggle_ref().
    /// </summary>
    [UnmanagedFunctionPointer (CallingConvention.Cdecl)]
    delegate void NativeToggleNotify (
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data,
        /* <type name="Object" type="GObject*" managed-name="Object" /> */
        /* transfer-ownership:none */
        IntPtr @object,
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        bool isLastRef);

    /// <summary>
    /// The GParameter struct is an auxiliary structure used
    /// to hand parameter name/value pairs to g_object_newv().
    /// </summary>
    struct Parameter
    {
#pragma warning disable CS0649
        /// <summary>
        /// the parameter name
        /// </summary>
        public IntPtr Name;

        /// <summary>
        /// the parameter value
        /// </summary>
        public IntPtr Value;
#pragma warning restore CS0649
    }
}
