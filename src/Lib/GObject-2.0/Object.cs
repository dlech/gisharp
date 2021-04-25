// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Runtime;

using culong = GISharp.Runtime.CULong;

namespace GISharp.Lib.GObject
{
    unsafe partial class Object : INotifyPropertyChanged
    {
        static readonly Quark toggleRefGCHandleQuark = Quark.FromString("gisharp-gobject-toggle-ref-gc-handle-quark");
        readonly delegate* unmanaged[Cdecl]<IntPtr, UnmanagedStruct*, Runtime.Boolean, void> toggleNotifyDelegate;

        uint RefCount => ((UnmanagedStruct*)UnsafeHandle)->RefCount;

        readonly ObjectClass objectClass;
        readonly ObjectClass? parentObjectClass;

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Object(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
            if (g_object_get_qdata((UnmanagedStruct*)handle, toggleRefGCHandleQuark) != IntPtr.Zero) {
                var message = "This object already has a managed instance attached to it, use GetInstance() instead";
                throw new ArgumentException(message, nameof(handle));
            }

            if (ownership == Transfer.None) {
                this.handle = (IntPtr)g_object_ref_sink((UnmanagedStruct*)handle);
            }

            // have to keep the pointer around for later removal
            toggleNotifyDelegate = &ToggleNotifyCallback;

            // always start with a strong reference to the managed object
            var gcHandle = GCHandle.Alloc(this);
            g_object_set_qdata((UnmanagedStruct*)handle, toggleRefGCHandleQuark, (IntPtr)gcHandle);
            g_object_add_toggle_ref((UnmanagedStruct*)handle, toggleNotifyDelegate, IntPtr.Zero);

            // handle always owns a reference so release it now that we have a toggle reference instead.
            // If this is the last normal reference, ToggleNotifyCallback will be called immediately
            // to convert the strong reference to a weak reference
            g_object_unref((UnmanagedStruct*)handle);
            GMarshal.PopUnhandledException();

            objectClass = (ObjectClass)GetTypeClass();
            var parentGType = GetGType().Parent;
            if (parentGType.IsClassed) {
                parentObjectClass = TypeClass.GetInstance<ObjectClass>(GetGType().Parent);
            }
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero) {
                g_object_ref((UnmanagedStruct*)handle);
                g_object_remove_toggle_ref((UnmanagedStruct*)handle, toggleNotifyDelegate, IntPtr.Zero);
                var gcHandle = (GCHandle)g_object_get_qdata((UnmanagedStruct*)handle, toggleRefGCHandleQuark);
                g_object_set_qdata((UnmanagedStruct*)handle, toggleRefGCHandleQuark, IntPtr.Zero);
                gcHandle.Free();
                g_object_unref((UnmanagedStruct*)handle);
                GMarshal.PopUnhandledException();
            }
            base.Dispose(disposing);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ToggleNotifyCallback(IntPtr data_, UnmanagedStruct* object_, Runtime.Boolean isLastRef_)
        {
            try {
                // free the existing GCHandle
                var gcHandle = (GCHandle)g_object_get_qdata(object_, toggleRefGCHandleQuark);
                GMarshal.PopUnhandledException();
                var obj = (Object)gcHandle.Target!;
                gcHandle.Free();

                var isLastRef = isLastRef_.IsTrue();

                // alloc a new GCHandle with weak/strong reference depending on isLastRef
                gcHandle = GCHandle.Alloc(obj, isLastRef ? GCHandleType.Weak : GCHandleType.Normal);
                g_object_set_qdata(object_, toggleRefGCHandleQuark, (IntPtr)gcHandle);
                GMarshal.PopUnhandledException();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        readonly ConcurrentDictionary<string, LinkedList<(IntPtr, culong)>> eventSignalHandlers = new();

        /// <summary>
        /// Connects event handler as signal.
        /// </summary>
        protected void AddEventSignalHandler(string signal, Delegate? handler)
        {
            if (handler is null) {
                return;
            }

            var (ret, data, data_) = this.ConnectData(signal, handler);

            if (ret == 0) {
                // TODO: better exception
                throw new Exception("Failed to connect signal.");
            }

            var list = eventSignalHandlers.GetOrAdd(signal, (_) => new());
            var element = list.AddFirst((data_, ret));
            // REVISIT: could signal handler be removed in another thread before
            // setting the free func? Does list need to be thread safe?
            data.Free = () => list.Remove(element);
        }

        /// <summary>
        /// Disconnects a signal handler that was connected with <see cref="AddEventSignalHandler"/>.
        /// </summary>
        protected void RemoveEventSignalHandler(string signal, Delegate? handler)
        {
            if (handler is null) {
                return;
            }

            if (!eventSignalHandlers.TryGetValue(signal, out var list)) {
                throw new ArgumentException($"signal not found", nameof(signal));
            }

            for (var element = list.First; element is not null; element = element.Next) {
                var (data_, id) = element.Value;
                var dataHandle = (GCHandle)data_;
                if (((CClosureData)dataHandle.Target!).Callback == handler) {
                    Signal.HandlerDisconnect(this, id);
                    return;
                }
            }

            throw new ArgumentException("handler not found", nameof(handler));
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void FreeEventSignalHandler(IntPtr data_)
        {
            try {
                var dataHandle = GCHandle.FromIntPtr(data_);
                var data = (CClosureData)dataHandle.Target!;
                data.Free?.Invoke();
                dataHandle.Free();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ManagedOnNotify(UnmanagedStruct* gobject_, ParamSpec.UnmanagedStruct* pspec_, IntPtr userData_)
        {
            try {
                var obj = GetInstance((IntPtr)gobject_, Transfer.None)!;
                var pspec = ParamSpec.GetInstance((IntPtr)pspec_, Transfer.None)!;
                var propInfo = (PropertyInfo)pspec[ObjectClass.managedClassPropertyInfoQuark]!;
                obj.propertyChangedHandler?.Invoke(obj, new PropertyChangedEventArgs(propInfo.Name));
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        PropertyChangedEventHandler? propertyChangedHandler;
        readonly object propertyChangedHandlerLock = new();
        culong notifySignalHandler;

        private readonly Utf8 notifySignalName = "notify";

        #region INotifyPropertyChanged implementation

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged {
            add {
                lock (propertyChangedHandlerLock) {
                    if (propertyChangedHandler is null) {
                        var (id, data, _) = this.ConnectData("notify", new NotifySignalHandler((obj, pspec) => {
                            var propInfo = (PropertyInfo)pspec[ObjectClass.managedClassPropertyInfoQuark]!;
                            obj.propertyChangedHandler?.Invoke(obj, new PropertyChangedEventArgs(propInfo.Name));
                        }));
                        notifySignalHandler = id;
                        // if all signals are disconnected from unmanaged code
                        // then we need to clear the managed event handers as well
                        data.Free = () => {
                            lock (propertyChangedHandlerLock) {
                                propertyChangedHandler = null;
                            }
                        };
                    }
                    propertyChangedHandler += value;
                }
            }
            remove {
                lock (propertyChangedHandlerLock) {
                    propertyChangedHandler -= value;
                    if (propertyChangedHandler is null) {
                        if (notifySignalHandler != default) {
                            Signal.HandlerDisconnect(this, notifySignalHandler);
                            notifySignalHandler = default;
                        }
                    }
                }
            }
        }

        #endregion

        static partial void CheckNewvArgs(GType objectType, ReadOnlySpan<Parameter> parameters)
        {
            if (!objectType.IsA(GType.Object)) {
                throw new ArgumentException("Must be a GObject", nameof(objectType));
            }
            if (!objectType.IsInstantiatable) {
                throw new ArgumentException("Must be instantiatable", nameof(objectType));
            }
        }

        private static UnmanagedStruct* New<T>(params object[] parameters) where T : Object
        {
            var gtype = typeof(T).ToGType();
            var nParameters = parameters.Length / 2;
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
                    var value = new Value(paramSpec.ValueType);
                    value.Set(parameters[i + 1]);
                    paramArray[i / 2] = new Parameter((byte*)GMarshal.StringToUtf8Ptr(name), value);
                }

                var ret = Newv(gtype, new ReadOnlySpan<Parameter>(paramArray, nParameters));

                return ret;
            }
            finally {
                for (int i = 0; i < nParameters; i++) {
                    paramArray[i].Free();
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
            var instance = GetInstance<T>((IntPtr)handle, Transfer.Full)!;

            return instance;
        }

        /// <summary>
        /// Creates a new instance of a <see cref="Object"/>.
        /// </summary>
        public Object() : this((IntPtr)New<Object>(), Transfer.Full)
        {
            if (GetType() != typeof(Object)) {
                throw new InvalidOperationException("Can't chain to this constructor");
            }
        }

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
            var userData = new BindDataUserData();
            var source_ = (UnmanagedStruct*)UnsafeHandle;
            var sourceProperty_ = (byte*)sourceProperty.UnsafeHandle;
            var target_ = (UnmanagedStruct*)target.UnsafeHandle;
            var targetProperty_ = (byte*)targetProperty.UnsafeHandle;
            userData.TransformTo = transformTo;
            var transformTo_ = (delegate* unmanaged[Cdecl]<Binding.UnmanagedStruct*, Value*, Value*, IntPtr, Runtime.Boolean>)(transformTo is null ? null : &BindPropertyTransformTo);
            userData.TransformFrom = transformFrom;
            var transformFrom_ = (delegate* unmanaged[Cdecl]<Binding.UnmanagedStruct*, Value*, Value*, IntPtr, Runtime.Boolean>)(transformFrom is null ? null : &BindPropertyTransformFrom);
            var userData_ = (IntPtr)GCHandle.Alloc(userData);
            var notify_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&BindPropertyNotify;
            var ret_ = g_object_bind_property_full(source_, sourceProperty_, target_, targetProperty_, flags, transformTo_, transformFrom_, userData_, notify_);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<Binding>((IntPtr)ret_, Transfer.None)!;
            return ret;
        }

        private class BindDataUserData
        {
            public BindingTransformFunc? TransformTo;
            public BindingTransformFunc? TransformFrom;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static Runtime.Boolean BindPropertyTransformTo(Binding.UnmanagedStruct* binding_, Value* toValue_, Value* fromValue_, IntPtr userData_)
        {
            try {
                var binding = GetInstance<Binding>((IntPtr)binding_, Transfer.None)!;
                ref var toValue = ref Unsafe.AsRef<Value>(toValue_);
                ref var fromValue = ref Unsafe.AsRef<Value>(fromValue_);
                var gcHandle = (GCHandle)userData_;
                var userData = (BindDataUserData)gcHandle.Target!;
                var ret = userData.TransformTo!(binding, toValue, ref fromValue);
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
                return default;
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static Runtime.Boolean BindPropertyTransformFrom(Binding.UnmanagedStruct* binding_, Value* toValue_, Value* fromValue_, IntPtr userData_)
        {
            try {
                var binding = GetInstance<Binding>((IntPtr)binding_, Transfer.None)!;
                ref var toValue = ref Unsafe.AsRef<Value>(toValue_);
                ref var fromValue = ref Unsafe.AsRef<Value>(fromValue_);
                var gcHandle = (GCHandle)userData_;
                var userData = (BindDataUserData)gcHandle.Target!;
                var ret = userData.TransformFrom!(binding, toValue, ref fromValue);
                return ret.ToBoolean();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
                return default;
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void BindPropertyNotify(IntPtr userData_)
        {
            try {
                var gcHandle = (GCHandle)userData_;
                gcHandle.Free();
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

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
            var pspec = objectClass.FindProperty(propertyName);
            if (pspec is null) {
                var message = $"No such property \"{propertyName}\"";
                throw new ArgumentException(message, nameof(propertyName));
            }
            var value = new Value(pspec.ValueType);
            try {
                GetProperty(propertyName, ref value);
                var ret = value.Get();
                return ret;
            }
            finally {
                value.Unset();
            }
        }

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
            var pspec = objectClass.FindProperty(propertyName);
            if (pspec is null) {
                var message = $"No such property \"{propertyName}\"";
                throw new ArgumentException(message, nameof(propertyName));
            }
            var value_ = new Value(pspec.ValueType);
            try {
                value_.Set(value);
                SetProperty(propertyName, value_);
            }
            finally {
                value_.Unset();
            }
        }

        /// <summary>
        /// Gets and sets a named field from the objects table of associations
        /// </summary>
        /// <param name="key">
        /// name of the key for that association
        /// </param>
        public object? this[string key] {
            get {
                var object_ = (UnmanagedStruct*)UnsafeHandle;
                var key_ = (byte*)GMarshal.StringToUtf8Ptr(key);
                var data_ = g_object_get_data(object_, key_);
                GMarshal.PopUnhandledException();
                GMarshal.Free((IntPtr)key_);
                if (data_ == IntPtr.Zero) {
                    return null;
                }
                var data = GCHandle.FromIntPtr(data_).Target;
                return data;
            }
            set {
                var object_ = (UnmanagedStruct*)UnsafeHandle;
                var key_ = (byte*)GMarshal.StringToUtf8Ptr(key);
                if (value is null) {
                    g_object_set_data(object_, key_, IntPtr.Zero);
                    GMarshal.PopUnhandledException();
                }
                else {
                    var data_ = GCHandle.ToIntPtr(GCHandle.Alloc(value));
                    var destroy_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
                    g_object_set_data_full(object_, key_, data_, destroy_);
                    GMarshal.PopUnhandledException();
                }
                GMarshal.Free((IntPtr)key_);
            }
        }

        /// <summary>
        /// Gets and sets user data.
        /// </summary>
        /// <param name="quark">
        /// A <see cref="Quark"/>, naming the user data
        /// </param>
        public object? this[Quark quark] {
            get {
                var object_ = (UnmanagedStruct*)UnsafeHandle;
                var ret_ = g_object_get_qdata(object_, quark);
                GMarshal.PopUnhandledException();
                var ret = GCHandle.FromIntPtr(ret_).Target;
                return ret;
            }
            set {
                var object_ = (UnmanagedStruct*)UnsafeHandle;
                if (value is null) {
                    g_object_set_qdata(object_, quark, IntPtr.Zero);
                    GMarshal.PopUnhandledException();
                }
                else {
                    var data = (IntPtr)GCHandle.Alloc(value);
                    var destroy_ = (delegate* unmanaged[Cdecl]<IntPtr, void>)&GMarshal.DestroyGCHandle;
                    g_object_set_qdata_full(object_, quark, data, destroy_);
                    GMarshal.PopUnhandledException();
                }
            }
        }

        [ModuleInitializer]
        internal static void RegisterTypeResolver()
        {
            RegisterTypeResolver<Object>(GetInstance<Object>);
        }

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
            var ptr = g_object_get_qdata((UnmanagedStruct*)handle, toggleRefGCHandleQuark);
            GMarshal.PopUnhandledException();
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
                            g_object_unref((UnmanagedStruct*)handle);
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
}
