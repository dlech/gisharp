using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using System.Reflection;

using GISharp.Lib.GLib;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// All the fields in the GObject structure are private
    /// to the #GObject implementation and should never be accessed directly.
    /// </summary>
    [GType("GObject", IsProxyForUnmanagedType = true)]
    [GTypeStruct(typeof(ObjectClass))]
    public class Object : TypeInstance, INotifyPropertyChanged
    {
        static readonly Quark toggleRefGCHandleQuark = Quark.FromString("gisharp-gobject-toggle-ref-gc-handle-quark");

        UnmanagedToggleNotify toggleNotifyDelegate;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe new struct UnmanagedStruct
        {
#pragma warning disable CS0649
            public TypeInstance.UnmanagedStruct GTypeInstance;
            public uint RefCount;
            public IntPtr Qdata;
#pragma warning restore CS0649
        }

        unsafe uint RefCount => ((UnmanagedStruct*)Handle)->RefCount;

        readonly ObjectClass objectClass;
        readonly ObjectClass? parentObjectClass;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Object(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (g_object_get_qdata(handle, toggleRefGCHandleQuark) != IntPtr.Zero) {
                var message = "This object already has a managed instance attached to it, use GetInstance() instead";
                throw new ArgumentException(message, nameof(handle));
            }

            if (ownership == Transfer.None) {
                this.handle = g_object_ref_sink(handle);
            }

            // by creating a new delegate for each instance, we are in effect
            // creating a unique identifier for this instance that will be used
            // when removing the toggle reference in Dispose().
            toggleNotifyDelegate = toggleNotifyCallback;

            // always start with a strong reference to the managed object
            var gcHandle = GCHandle.Alloc(this);
            g_object_set_qdata(handle, toggleRefGCHandleQuark, (IntPtr)gcHandle);
            g_object_add_toggle_ref(handle, toggleNotifyDelegate, IntPtr.Zero);

            // IntPtr always owns a reference so release it now that we have a toggle reference instead.
            // If this is the last normal reference, toggleNotifyCallback will be called immediately
            // to convert the strong reference to a weak reference
            g_object_unref(handle);

            objectClass = (ObjectClass)GetTypeClass();
            var parentGType = GetGType().Parent;
            if (parentGType.IsClassed) {
                parentObjectClass = TypeClass.GetInstance<ObjectClass>(GetGType().Parent);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_object_ref(handle);
                g_object_remove_toggle_ref(handle, toggleNotifyDelegate, IntPtr.Zero);
                var gcHandle = (GCHandle)g_object_get_qdata(handle, toggleRefGCHandleQuark);
                g_object_set_qdata(handle, toggleRefGCHandleQuark, IntPtr.Zero);
                gcHandle.Free();
                g_object_unref(handle);
            }
            base.Dispose(disposing);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref(IntPtr @object);

        public override IntPtr Take() => g_object_ref(Handle);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_unref(IntPtr @object);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_ref_sink(IntPtr @object);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_add_toggle_ref(IntPtr @object, UnmanagedToggleNotify notify, IntPtr data);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_remove_toggle_ref(IntPtr @object, UnmanagedToggleNotify notify, IntPtr data);

        static void toggleNotifyCallback(IntPtr data, IntPtr @object, Runtime.Boolean isLastRef_)
        {
            try {
                // free the existing GCHandle
                var gcHandle = (GCHandle)g_object_get_qdata(@object, toggleRefGCHandleQuark);
                var obj = (Object)gcHandle.Target!;
                gcHandle.Free();

                var isLastRef = isLastRef_.IsTrue();

                // alloc a new GCHandle with weak/strong reference depending on isLastRef
                gcHandle = GCHandle.Alloc(obj, isLastRef ? GCHandleType.Weak : GCHandleType.Normal);
                g_object_set_qdata(@object, toggleRefGCHandleQuark, (IntPtr)gcHandle);
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern GType g_object_get_type();

        static GType _GType => g_object_get_type();

        public sealed class NotifySignalEventArgs : GSignalEventArgs
        {
            readonly object[] args;

            public ParamSpec Pspec => (ParamSpec)args[0];

            public NotifySignalEventArgs(params object[] args)
            {
                this.args = args ?? throw new ArgumentNullException(nameof(args));
            }
        }

        readonly GSignalManager<NotifySignalEventArgs> notifySignalManager =
                new GSignalManager<NotifySignalEventArgs>("notify", _GType);

        [GSignal("notify", When = EmissionStage.First, IsNoRecurse = true, IsDetailed = true, IsAction = true, IsNoHooks = true)]
        public event EventHandler<NotifySignalEventArgs> NotifySignal {
            add => notifySignalManager.Add(this, value);
            remove => notifySignalManager.Remove(value);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void UnmanagedNotify(IntPtr gobjectPtr, IntPtr pspecPtr, IntPtr userDataPtr);

        static readonly UnmanagedNotify nativeNotifyDelegate = UnmanagedOnNotify;
        static readonly IntPtr nativeNotifyPtr = Marshal.GetFunctionPointerForDelegate(nativeNotifyDelegate);

        static void UnmanagedOnNotify(IntPtr gobjectPtr, IntPtr pspecPtr, IntPtr userDataPtr)
        {
            try {
                var obj = GetInstance(gobjectPtr, Transfer.None)!;
                var pspec = ParamSpec.GetInstance(pspecPtr, Transfer.None)!;
                var propInfo = (PropertyInfo)pspec[ObjectClass.managedClassPropertyInfoQuark]!;
                obj.propertyChangedHandler?.Invoke(obj, new PropertyChangedEventArgs(propInfo.Name));
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        PropertyChangedEventHandler? propertyChangedHandler;
        readonly object propertyChangedHandlerLock = new();
        SignalHandler? notifySignalHandler;

        SignalHandler ConnectNotifySignal()
        {
            var detailedSignalPtr = GMarshal.StringToUtf8Ptr("notify");
            var id = Signal.g_signal_connect_data(handle, detailedSignalPtr,
                nativeNotifyPtr, IntPtr.Zero, null, default);
            GMarshal.Free(detailedSignalPtr);

            return new SignalHandler(this, id);
        }

        #region INotifyPropertyChanged implementation

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged {
            add {
                lock (propertyChangedHandlerLock) {
                    if (propertyChangedHandler is null) {
                        notifySignalHandler = ConnectNotifySignal();
                    }
                    propertyChangedHandler += value;
                }
            }
            remove {
                lock (propertyChangedHandlerLock) {
                    propertyChangedHandler -= value;
                    if (propertyChangedHandler is null) {
                        notifySignalHandler?.Disconnect();
                        notifySignalHandler = null;
                    }
                }
            }
        }

        #endregion

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
        [DeprecatedSince("2.54")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Object" type="gpointer" managed-name="Object" /> */
        /* transfer-ownership:full */
        internal static extern IntPtr g_object_newv(
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

        [DeprecatedSince("2.54")]
        static unsafe IntPtr New(GType objectType, int nParameters, Parameter* parameters)
        {
            if (!objectType.IsA(GType.Object)) {
                throw new ArgumentException("Must be a GObject", nameof(objectType));
            }
            if (!objectType.IsInstantiatable) {
                throw new ArgumentException("Must be instantiatable", nameof(objectType));
            }
            var ret = g_object_newv(objectType, (uint)nParameters, (IntPtr)parameters);
            return ret;
        }

        private static unsafe IntPtr New<T>(params object[] parameters) where T : Object
        {
            var gtype = GType.Of<T>();
            var nParameters = parameters.Length / 2;
            var valueArray = stackalloc Value[nParameters];
            var paramArray = stackalloc Parameter[nParameters];
            try {
                for (int i = 0; i < parameters.Length; i += 2) {
                    if (parameters[i] is not string name) {
                        var message = $"Expecting string at index {i}";
                        throw new ArgumentException(message, nameof(parameters));
                    }
                    var objClass = TypeClass.GetInstance<ObjectClass>(gtype);
                    var paramSpec = objClass.FindProperty(name);
                    if (paramSpec is null) {
                        var message = $"Could not find property '{name}'";
                        throw new ArgumentException(message, nameof(parameters));
                    }
                    valueArray[i / 2].Init(paramSpec.ValueType);
                    valueArray[i / 2].Set(parameters[i + 1]);
                    paramArray[i / 2] = new Parameter {
                        Name = GMarshal.StringToUtf8Ptr(name),
                        Value = &valueArray[i / 2],
                    };
                }

                var ret = New(gtype, nParameters, paramArray);


                return ret;
            }
            finally {
                for (int i = 0; i < nParameters; i++) {
                    var p = paramArray[i];
                    GMarshal.Free(p.Name);
                    p.Value->Unset();
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
        public static T CreateInstance<T>(params object[] parameters) where T : Object
        {
            var handle = New<T>(parameters);
            var instance = GetInstance<T>(handle, Transfer.Full)!;

            return instance;
        }

        public Object() : this(New<Object>(), Transfer.Full)
        {
            if (GetType() != typeof(Object)) {
                throw new InvalidOperationException("Can't chain to this constructor");
            }
        }

        [Since("2.10")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern Runtime.Boolean g_object_is_floating(IntPtr @object);

        bool IsFloating {
            get {
                var ret_ = g_object_is_floating(Handle);
                var ret = ret_.IsTrue();
                return ret;
            }
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
        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_bind_property(
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
        [Since("2.26")]
        public Binding BindProperty(string sourceProperty, Object target, string targetProperty, BindingFlags flags = BindingFlags.Default)
        {
            var this_ = Handle;
            var target_ = target.Handle;

            var sourcePropertyInfo = GetType().GetProperty(sourceProperty);
            if (sourcePropertyInfo is null) {
                throw new ArgumentException("No matching property", nameof(sourceProperty));
            }
            sourceProperty = sourcePropertyInfo.TryGetGPropertyName() ??
                throw new ArgumentException($"{sourcePropertyInfo.Name} is not a registered GType property",
                    nameof(sourceProperty));
            using var sourcePropertyUtf8 = new Utf8(sourceProperty);
            var sourceProperty_ = sourcePropertyUtf8.Handle;

            var targetPropertyInfo = target.GetType().GetProperty(targetProperty);
            if (targetPropertyInfo is null) {
                throw new ArgumentException("No matching property", nameof(targetProperty));
            }
            targetProperty = targetPropertyInfo.TryGetGPropertyName() ??
                throw new ArgumentException($"{targetPropertyInfo.Name} is not a registered GType property",
                    nameof(targetProperty));
            using var targetPropertyUtf8 = new Utf8(targetProperty);
            var targetProperty_ = targetPropertyUtf8.Handle;

            var ret_ = g_object_bind_property(this_, sourceProperty_, target_, targetProperty_, flags);
            var ret = GetInstance<Binding>(ret_, Transfer.None)!;
            return ret;
        }

        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="Binding" type="GBinding*" managed-name="Binding" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_bind_property_full(
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
            UnmanagedBindingTransformFunc? transformTo,
            UnmanagedBindingTransformFunc? transformFrom,
            IntPtr userData,
            UnmanagedDestroyNotify? notify);

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
        /// The binding will automatically be removed when either the this instance
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
        [Since("2.26")]
        public Binding BindProperty(UnownedUtf8 sourceProperty, Object target, UnownedUtf8 targetProperty, BindingFlags flags, BindingTransformFunc? transformTo, BindingTransformFunc? transformFrom)
        {
            var this_ = Handle;
            var sourceProperty_ = sourceProperty.Handle;
            var target_ = target.Handle;
            var targetProperty_ = targetProperty.Handle;

            var (transformTo_, transformFrom_, notify_, userData_) = UnmanagedBindingTransformFuncFactory.CreateNotifyDelegate(transformTo, transformFrom);
            var ret_ = g_object_bind_property_full(this_, sourceProperty_, target_, targetProperty_, flags,
                                                   transformTo_, transformFrom_, userData_, notify_);
            var ret = GetInstance<Binding>(ret_, Transfer.None)!;
            return ret;
        }

        static class UnmanagedBindingTransformFuncFactory
        {
            class BindingTransformFuncData
            {
                public BindingTransformFunc? TransformTo;
                public UnmanagedBindingTransformFunc? UnmanagedTransformTo;
                public BindingTransformFunc? TransformFrom;
                public UnmanagedBindingTransformFunc? UnmanagedTransformFrom;
                public UnmanagedDestroyNotify? UnmanagedNotify;
            }

            public static (UnmanagedBindingTransformFunc?, UnmanagedBindingTransformFunc?, UnmanagedDestroyNotify, IntPtr)
                CreateNotifyDelegate(BindingTransformFunc? transformTo, BindingTransformFunc? transformFrom)
            {
                var userData = new BindingTransformFuncData();

                if (transformTo is not null) {
                    userData.TransformTo = transformTo;
                    userData.UnmanagedTransformTo = TransformToFunc;
                }

                if (transformFrom is not null) {
                    userData.TransformFrom = transformFrom;
                    userData.UnmanagedTransformFrom = TransformFromFunc;
                }

                userData.UnmanagedNotify = UnmanagedNotify;

                var userData_ = GCHandle.Alloc(userData);

                return (userData.UnmanagedTransformTo, userData.UnmanagedTransformFrom, userData.UnmanagedNotify!, (IntPtr)userData_);
            }

            static bool TransformToFunc(IntPtr bindingPtr, ref Value toValue, ref Value fromValue, IntPtr userDataPtr)
            {
                try {
                    var binding = GetInstance<Binding>(bindingPtr, Transfer.None)!;
                    var gcHandle = (GCHandle)userDataPtr;
                    var userData = (BindingTransformFuncData)gcHandle.Target!;
                    var ret = userData.TransformTo!(binding, ref toValue, ref fromValue);
                    return ret;
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                    return default;
                }
            }

            static bool TransformFromFunc(IntPtr bindingPtr, ref Value toValue, ref Value fromValue, IntPtr userDataPtr)
            {
                try {
                    var binding = GetInstance<Binding>(bindingPtr, Transfer.None)!;
                    var gcHandle = (GCHandle)userDataPtr;
                    var userData = (BindingTransformFuncData)gcHandle.Target!;
                    var ret = userData.TransformFrom!(binding, ref toValue, ref fromValue);
                    return ret;
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                    return default;
                }
            }

            static void UnmanagedNotify(IntPtr userData_)
            {
                try {
                    var gcHandle = (GCHandle)userData_;
                    gcHandle.Free();
                }
                catch (Exception ex) {
                    ex.LogUnhandledException();
                }
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_freeze_notify(
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
        public void FreezeNotify()
        {
            g_object_freeze_notify(Handle);
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_get_property(
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
        /// Gets a property of an object.
        /// </summary>
        /// <param name="propertyName">
        /// the GType system name of the property to get
        /// </param>
        /// <returns>
        /// the property value
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throw when <paramref name="propertyName"/> is not a valid property name
        /// </exception>
        public object? GetProperty(UnownedUtf8 propertyName)
        {
            var this_ = Handle;
            var pspec = objectClass.FindProperty(propertyName);
            if (pspec is null) {
                var message = $"No such property \"{propertyName}\"";
                throw new ArgumentException(message, nameof(propertyName));
            }
            var value = new Value(pspec.ValueType);
            g_object_get_property(this_, pspec.Name.Handle, ref value);
            var ret = value.Get();
            value.Unset();

            return ret;
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_notify(
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
        public void EmitNotify(UnownedUtf8 propertyName)
        {
            var this_ = Handle;
            var propertyName_ = propertyName.Handle;
            g_object_notify(this_, propertyName_);
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
        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_notify_by_pspec(
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
        [Since("2.26")]
        public void EmitNotify(ParamSpec pspec)
        {
            var this_ = Handle;
            var pspec_ = pspec.Handle;
            g_object_notify_by_pspec(this_, pspec_);
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_set_property(
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
        /// <exception cref="ArgumentException">
        /// Throw when <paramref name="propertyName"/> is not a valid property name
        /// </exception>
        public void SetProperty(UnownedUtf8 propertyName, object? value)
        {
            var this_ = Handle;
            var pspec = objectClass.FindProperty(propertyName);
            if (pspec is null) {
                var message = $"No such property \"{propertyName}\"";
                throw new ArgumentException(message, nameof(propertyName));
            }
            var value_ = new Value(pspec.ValueType);
            value_.Set(value);
            g_object_set_property(this_, pspec.Name.Handle, ref value_);
            value_.Unset();
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
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_thaw_notify(
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
        public void ThawNotify()
        {
            g_object_thaw_notify(Handle);
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_get_data(
            IntPtr @object,
            IntPtr key);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_data(
            IntPtr @object,
            IntPtr key,
            IntPtr data);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_data_full(
            IntPtr @object,
            IntPtr key,
            IntPtr data,
            UnmanagedDestroyNotify destroy);

        public object? this[string key] {
            get {
                var this_ = Handle;
                var key_ = GMarshal.StringToUtf8Ptr(key);
                var data_ = g_object_get_data(this_, key_);
                GMarshal.Free(key_);
                if (data_ == IntPtr.Zero) {
                    return null;
                }
                var data = GCHandle.FromIntPtr(data_).Target;
                return data;
            }
            set {
                var this_ = Handle;
                var key_ = GMarshal.StringToUtf8Ptr(key);
                if (value is null) {
                    g_object_set_data(this_, key_, IntPtr.Zero);
                }
                else {
                    var data_ = GCHandle.ToIntPtr(GCHandle.Alloc(value));
                    g_object_set_data_full(this_, key_, data_, freeDataDelegate);
                }
                GMarshal.Free(key_);
            }
        }

        static UnmanagedDestroyNotify freeDataDelegate = FreeData;

        static void FreeData(IntPtr dataPtr)
        {
            try {
                var data = GCHandle.FromIntPtr(dataPtr);
                data.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr g_object_get_qdata(
            IntPtr @object,
            Quark quark);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_qdata(
            IntPtr @object,
            Quark quark,
            IntPtr data);

        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        static extern void g_object_set_qdata_full(
            IntPtr @object,
            Quark quark,
            IntPtr data,
            UnmanagedDestroyNotify destroy);

        public object? this[Quark quark] {
            get {
                var ret_ = g_object_get_qdata(Handle, quark);
                var ret = GCHandle.FromIntPtr(ret_).Target;
                return ret;
            }
            set {
                var this_ = Handle;
                if (value is null) {
                    g_object_set_qdata(this_, quark, IntPtr.Zero);
                }
                else {
                    var data = (IntPtr)GCHandle.Alloc(value);
                    g_object_set_qdata_full(this_, quark, data, freeDataDelegate);
                }
            }
        }

        /// <summary>
        /// the class closure for the notify signal
        /// </summary>
        protected virtual void DoNotify(ParamSpec pspec) => parentObjectClass?.DoNotify(this, pspec);

        /// <summary>
        /// Gets a managed proxy for a an unmanged GObject.
        /// </summary>
        /// <param name="handle">
        /// The pointer to the unmanaged instance
        /// </param>
        /// <param name="ownership">
        /// Indicates if we already have a reference to the unmanged instance
        /// or not.
        /// </param>
        /// <returns>
        /// A managed proxy instance
        /// </returns>
        /// <remarks>
        /// This method tries to get an existing managed proxy instance by
        /// looking for a GC handle attached to the unmanaged instance (using
        /// QData). If one is found, it returns the existing managed instance,
        /// otherwise a new instance is created.
        /// </remarks>
        public static new T? GetInstance<T>(IntPtr handle, Transfer ownership) where T : Object
        {
            if (handle == IntPtr.Zero) {
                return null;
            }

            // see if the unmanaged object has a managed GC handle
            var ptr = g_object_get_qdata(handle, toggleRefGCHandleQuark);
            if (ptr != IntPtr.Zero) {
                var gcHandle = (GCHandle)ptr;
                if (gcHandle.IsAllocated) {
                    // the GC handle looks good, so we should have the managed
                    // proxy for the unmanged object here
                    var target = (Object)gcHandle.Target!;
                    // make sure the managed object has not been disposed
                    if (target.handle == handle) {
                        // release the extra reference, if there is one
                        if (ownership != Transfer.None) {
                            g_object_unref(handle);
                        }
                        // return the existing managed proxy
                        return (T)target;
                    }
                }
            }

            // if we get here, that means that there wasn't a viable existing
            // proxy, so we need to create a new managed instance

            // get the exact type of the object
            ptr = Marshal.ReadIntPtr(handle);
            var gtype = Marshal.PtrToStructure<GType>(ptr);
            var type = gtype.ToType();

            return (T)Activator.CreateInstance(type, handle, ownership)!;
        }

        /// <summary>
        /// Gets a managed proxy for a an unmanged GObject.
        /// </summary>
        /// <seealso cref="GetInstance{T}"/>
        public static Object? GetInstance(IntPtr handle, Transfer ownership)
        {
            return GetInstance<Object>(handle, ownership);
        }
    }

    /// <summary>
    /// A callback function used for notification when the state
    /// of a toggle reference changes. See g_object_add_toggle_ref().
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void UnmanagedToggleNotify(
        /* <type name="gpointer" type="gpointer" managed-name="Gpointer" /> */
        /* transfer-ownership:none */
        IntPtr data,
        /* <type name="Object" type="GObject*" managed-name="Object" /> */
        /* transfer-ownership:none */
        IntPtr @object,
        /* <type name="gboolean" type="gboolean" managed-name="Gboolean" /> */
        /* transfer-ownership:none */
        Runtime.Boolean isLastRef);
}
