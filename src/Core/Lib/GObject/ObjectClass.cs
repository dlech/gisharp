// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using GISharp.Lib.GLib;
using GISharp.Runtime;

using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;

using static System.Reflection.BindingFlags;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// The class structure for the GObject type.
    /// </summary>
    public unsafe class ObjectClass : TypeClass
    {
        /// <summary>
        /// The unmanaged data structure for <see cref="ObjectClass"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new struct UnmanagedStruct
        {
#pragma warning disable CS0649
#pragma warning disable CS0169
            /// <summary>
            /// The parent type class
            /// </summary>
            public TypeClass.UnmanagedStruct GTypeClass;

            IntPtr constructProperties;

            /* seldom overidden */

            /// <summary>
            /// the constructor function is called by g_object_new() to complete
            /// the object initialization after all the construction properties are
            /// set. The first thing a constructor implementation must do is chain
            /// up to the constructor of the parent class. Overriding constructor
            /// should be rarely needed, e.g. to handle construct properties, or to
            /// implement singletons.
            /// </summary>
            public delegate* unmanaged[Cdecl]<GType, uint, IntPtr, IntPtr> Constructor;

            /* overridable methods */

            /// <summary>
            /// the generic setter for all properties of this type. Should be
            /// overridden for every type with properties. If implementations of
            /// set_property don't emit property change notification explicitly,
            /// this will be done implicitly by the type system. However, if the
            /// notify signal is emitted explicitly, the type system will not emit
            /// it a second time.
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, uint, Value*, IntPtr, void> SetProperty;

            /// <summary>
            /// the generic getter for all properties of this type. Should be
            /// overridden for every type with properties.
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, uint, Value*, IntPtr, void> GetProperty;

            /// <summary>
            /// the dispose function is supposed to drop all references to other
            /// objects, but keep the instance otherwise intact, so that client
            /// method invocations still work. It may be run multiple times (due
            /// to reference loops). Before returning, dispose should chain up to
            /// the dispose method of the parent class.
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, void> Dispose;

            /// <summary>
            /// instance finalization function, should finish the finalization of
            /// the instance begun in dispose and chain up to the finalize method
            /// of the parent class.
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, void> Finalize;

            /* seldom overidden */

            /// <summary>
            /// emits property change notification for a bunch of properties.
            /// Overriding dispatch_properties_changed should be rarely needed.
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, uint, IntPtr*, void> DispatchPropertiesChanged;

            /* signals */

            /// <summary>
            /// the class closure for the notify signal
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> Notify;

            /* called when done constructing */

            /// <summary>
            /// the constructed function is called by g_object_new() as the final
            /// step of the object creation process. At the point of the call, all
            /// construction properties have been set on the object. The purpose of
            /// this call is to allow for object initialisation steps that can only
            /// be performed after construction properties have been set. constructed
            /// implementors should chain up to the constructed call of their parent
            /// class to allow it to complete its initialisation.
            /// </summary>
            public delegate* unmanaged[Cdecl]<IntPtr, void> Constructed;

            nuint flags;
            IntPtr dummy0;
            IntPtr dummy1;
            IntPtr dummy2;
            IntPtr dummy3;
            IntPtr dummy4;
            IntPtr dummy5;
#pragma warning restore CS0169
#pragma warning restore CS0649
        }

        /// <summary>
        /// the class closure for the notify signal
        /// </summary>
        public void DoDispatchPropertiesChanged(Object @object, UnownedCPtrArray<ParamSpec> pspecs)
        {
            var objectClass = (UnmanagedStruct*)UnsafeHandle;
            var object_ = @object.UnsafeHandle;
            var nPspecs_ = (uint)pspecs.Length;
            fixed (IntPtr* pspecs_ = pspecs) {
                objectClass->DispatchPropertiesChanged(object_, nPspecs_, pspecs_);
            }
        }

        /// <summary>
        /// the class closure for the notify signal
        /// </summary>
        public void DoNotify(Object @object, ParamSpec pspec)
        {
            var objectClass = (UnmanagedStruct*)UnsafeHandle;
            var object_ = @object.UnsafeHandle;
            var pspec_ = pspec.UnsafeHandle;
            objectClass->Notify(object_, pspec_);
        }

        /// <summary>
        /// the constructed function is called by g_object_new() as the final
        /// step of the object creation process. At the point of the call, all
        /// construction properties have been set on the object. The purpose of
        /// this call is to allow for object initialisation steps that can only
        /// be performed after construction properties have been set. constructed
        /// implementors should chain up to the constructed call of their parent
        /// class to allow it to complete its initialisation.
        /// </summary>
        public void DoConstructed(Object @object)
        {
            var objectClass = (UnmanagedStruct*)UnsafeHandle;
            var object_ = @object.UnsafeHandle;
            objectClass->Constructed(object_);
        }

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ObjectClass(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        internal static readonly Quark managedClassPropertyInfoQuark =
            Quark.FromString("gisharp-object-class-managed-class-property-info-quark");

        /// <summary>
        /// Gets the type info for registering a managed class with the GObject
        /// type system.
        /// </summary>
        /// <returns>The type info.</returns>
        /// <param name="type">The managed type to register.</param>
        internal static TypeInfo GetTypeInfo(Type type)
        {
            var parentGType = type.BaseType?.ToGType() ??
                throw new ArgumentException("class without base type", nameof(type));
            var parentTypeQuery = parentGType.Query();
            var ret = new TypeInfo {
                ClassSize = (ushort)parentTypeQuery.ClassSize,
                ClassInit = &InitManagedClass,
                ClassData = (IntPtr)GCHandle.Alloc(type),
                InstanceSize = (ushort)parentTypeQuery.InstanceSize,
            };

            return ret;
        }

        /// <summary>
        /// ClassInit callback for managed classes.
        /// </summary>
        /// <param name="gClass_">Pointer to <see cref="UnmanagedStruct"/>.</param>
        /// <param name="classData_">Pointer to user data from <see cref="TypeInfo"/>.</param>
        /// <remarks>
        /// This takes care of overriding the methods to make the managed type
        /// interop with the GObject type system.
        /// </remarks>
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void InitManagedClass(IntPtr gClass_, IntPtr classData_)
        {
            try {
                var objectClass = (UnmanagedStruct*)gClass_;
                var gtype = objectClass->GTypeClass.GType;
                var type = (Type)GCHandle.FromIntPtr(classData_).Target!;

                // override virtual methods

                objectClass->Constructor = &ManagedClassConstructor;
                objectClass->SetProperty = &ManagedClassSetProperty;
                objectClass->GetProperty = &ManagedClassGetProperty;

                // Install Properties

                uint propId = 1; // propId 0 is used internally, so we start with 1
                foreach (var propInfo in type.GetProperties()) {
                    GPropertyAttribute? gPropertyAttr = propInfo.GetCustomAttribute<GPropertyAttribute>(true);
                    if (gPropertyAttr is null) {
                        // maybe the property is declared in an interface
                        gPropertyAttr = propInfo.TryGetMatchingInterfacePropertyInfo()?.GetCustomAttribute<GPropertyAttribute>(true);
                        if (gPropertyAttr is null) {
                            // only register properties with [GProperty] attribute
                            continue;
                        }
                    }

                    if (propInfo.DeclaringType != type) {
                        // only register properties declared in this type or in interfaces
                        continue;
                    }

                    var name = propInfo.TryGetGPropertyName();
                    if (name is null) {
                        // this property is not to be registered with the GObject type system
                        continue;
                    }
                    // TODO: localize strings for nick and blurb
                    var nick = propInfo.GetCustomAttribute<DisplayNameAttribute>(true)
                        ?.DisplayName ?? name;
                    var blurb = propInfo.GetCustomAttribute<DescriptionAttribute>(true)
                        ?.Description ?? nick;
                    var defaultValue = propInfo.GetCustomAttribute<DefaultValueAttribute>(true)
                        ?.Value;

                    // setup the flags

                    var flags = default(ParamFlags);

                    if (propInfo.CanRead) {
                        flags |= ParamFlags.Readable;
                    }
                    if (propInfo.CanWrite) {
                        flags |= ParamFlags.Writable;
                    }
                    // Construct properties don't work with managed types because they
                    // require setting the property before the class has been instantiated.
                    // So, we don't ever set ParamFlags.Construct or ParamFlags.ConstructOnly

                    flags |= ParamFlags.StaticName;
                    flags |= ParamFlags.StaticNick;
                    flags |= ParamFlags.StaticBlurb;

                    // Always explicit notify. Setting properties from managed code
                    // must manually call notify, so if a property was set via
                    // unmanaged code, it would result in double notification if
                    // ExplicitNotify was not set.
                    flags |= ParamFlags.ExplicitNotify;

                    if (propInfo.GetCustomAttribute<ObsoleteAttribute>(true) is not null) {
                        flags |= ParamFlags.Deprecated;
                    }

                    // create the pspec instance based on type

                    ParamSpec pspec;
                    // TODO: Need to create special boxed type for non-GType objects
                    var propertyGType = (GType)propInfo.PropertyType;
                    var fundamentalGType = propertyGType.Fundamental;
                    if (fundamentalGType == GType.Boolean) {
                        pspec = new ParamSpecBoolean(name, nick, blurb, (bool)(defaultValue ?? default(bool)), flags);
                    }
                    else if (fundamentalGType == GType.Boxed) {
                        pspec = new ParamSpecBoxed(name, nick, blurb, propertyGType, flags);
                    }
                    else if (fundamentalGType == GType.Char) {
                        pspec = new ParamSpecChar(name, nick, blurb, sbyte.MinValue, sbyte.MaxValue, (sbyte)(defaultValue ?? default(sbyte)), flags);
                    }
                    else if (fundamentalGType == GType.UChar) {
                        pspec = new ParamSpecUChar(name, nick, blurb, byte.MinValue, byte.MaxValue, (byte)(defaultValue ?? default(byte)), flags);
                    }
                    else if (fundamentalGType == GType.Double) {
                        pspec = new ParamSpecDouble(name, nick, blurb, double.MinValue, double.MaxValue, (double)(defaultValue ?? default(double)), flags);
                    }
                    else if (fundamentalGType == GType.Float) {
                        pspec = new ParamSpecFloat(name, nick, blurb, float.MinValue, float.MaxValue, (float)(defaultValue ?? default(float)), flags);
                    }
                    else if (fundamentalGType == GType.Enum) {
                        pspec = new ParamSpecEnum(name, nick, blurb, propertyGType, (System.Enum)defaultValue!, flags);
                    }
                    else if (fundamentalGType == GType.Flags) {
                        pspec = new ParamSpecFlags(name, nick, blurb, propertyGType, (System.Enum)defaultValue!, flags);
                    }
                    else if (fundamentalGType == GType.Int) {
                        pspec = new ParamSpecInt(name, nick, blurb, int.MinValue, int.MaxValue, (int)(defaultValue ?? default(int)), flags);
                    }
                    else if (fundamentalGType == GType.UInt) {
                        pspec = new ParamSpecUInt(name, nick, blurb, uint.MinValue, uint.MaxValue, (uint)(defaultValue ?? default(uint)), flags);
                    }
                    else if (fundamentalGType == GType.Int64) {
                        pspec = new ParamSpecInt64(name, nick, blurb, long.MinValue, long.MaxValue, (long)(defaultValue ?? default(long)), flags);
                    }
                    else if (fundamentalGType == GType.UInt64) {
                        pspec = new ParamSpecUInt64(name, nick, blurb, ulong.MinValue, ulong.MaxValue, (ulong)(defaultValue ?? default(ulong)), flags);
                    }
                    else if (fundamentalGType == GType.Long) {
                        pspec = new ParamSpecLong(name, nick, blurb, clong.MinValue, clong.MaxValue, (clong)(defaultValue ?? default(clong)), flags);
                    }
                    else if (fundamentalGType == GType.ULong) {
                        pspec = new ParamSpecULong(name, nick, blurb, culong.MinValue, culong.MaxValue, (culong)(defaultValue ?? default(culong)), flags);
                    }
                    else if (fundamentalGType == GType.Object) {
                        pspec = new ParamSpecObject(name, nick, blurb, propertyGType, flags);
                    }
                    // TODO: do we need this one?
                    //                else if (fundamentalGType == GType.Param) {
                    //                    pspec = new ParamSpecParam (name, nick, blurb, ?, flags);
                    //                }
                    else if (fundamentalGType == GType.Pointer) {
                        pspec = new ParamSpecPointer(name, nick, blurb, flags);
                    }
                    else if (fundamentalGType == GType.String) {
                        pspec = new ParamSpecString(name, nick, blurb, (string?)defaultValue, flags);
                    }
                    else if (fundamentalGType == GType.Type) {
                        pspec = new ParamSpecGType(name, nick, blurb, propertyGType, flags);
                    }
                    else if (fundamentalGType == GType.Variant) {
                        // TODO: need to pass variant type using attribute?
                        // for now, always using any type
                        var variantType = VariantType.Any;
                        pspec = new ParamSpecVariant(name, nick, blurb, variantType, defaultValue is null ? null : (Variant)defaultValue, flags);
                    }
                    else {
                        throw new GTypeException($"unhandled GType: {propertyGType}");
                    }

                    var methodInfo = propInfo.GetAccessors().First();
                    if (methodInfo.GetBaseDefinition() != methodInfo || propInfo.TryGetMatchingInterfacePropertyInfo() is not null) {
                        // if this type did not declare the property, the we know
                        // we are overriding a property from a base class or interface
                        var namePtr = GMarshal.StringToUtf8Ptr(name);
                        g_object_class_override_property(objectClass, propId, namePtr);
                        GMarshal.Free(namePtr);
                    }
                    else {
                        g_object_class_install_property(objectClass, propId, pspec.UnsafeHandle);
                        GC.KeepAlive(pspec);
                    }
                    propId++;
                }

                foreach (var eventInfo in type.GetEvents()) {
                    if (eventInfo.DeclaringType != type) {
                        // only register events declared in this type
                        continue;
                    }

                    var signalAttr = eventInfo.GetCustomAttribute<GSignalAttribute>(true);
                    if (signalAttr is null) {
                        // events without SignalAttribute are not installed
                        continue;
                    }

                    // figure out the name

                    var name = signalAttr.Name ?? eventInfo.Name;
                    Signal.ValidateName(name);

                    // figure out the flags

                    var flags = default(SignalFlags);

                    flags |= signalAttr.When switch {
                        EmissionStage.First => SignalFlags.RunFirst,
                        EmissionStage.Cleanup => SignalFlags.RunCleanup,
                        _ => SignalFlags.RunLast,
                    };

                    if (signalAttr.IsNoRecurse) {
                        flags |= SignalFlags.NoRecurse;
                    }

                    if (signalAttr.IsDetailed) {
                        flags |= SignalFlags.Detailed;
                    }

                    if (signalAttr.IsAction) {
                        flags |= SignalFlags.Action;
                    }

                    if (signalAttr.IsNoHooks) {
                        flags |= SignalFlags.NoHooks;
                    }

                    if (eventInfo.GetCustomAttribute<ObsoleteAttribute>(true) is not null) {
                        flags |= SignalFlags.Deprecated;
                    }

                    // figure out the parameter types

                    var methodInfo = eventInfo.EventHandlerType!.GetMethod("Invoke")!;
                    var returnGType = methodInfo.ReturnType.ToGType();
                    var parameters = methodInfo.GetParameters();
                    var parameterGTypes = new GType[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++) {
                        parameterGTypes[i] = parameters[i].ParameterType.ToGType();
                    }

                    // create a closure that will be called when the signal is emitted

                    var fieldInfo = type.GetField(eventInfo.Name, Instance | NonPublic)!;

                    var closure = new Closure((p) => {
                        var eventDelegate = (MulticastDelegate)fieldInfo.GetValue(p[0])!;
                        return eventDelegate.DynamicInvoke(p.Skip(1).ToArray())!;
                    });

                    // register the signal

                    Signal.Newv(name, gtype, flags, closure, null, null, returnGType, parameterGTypes);
                }

                foreach (var method in type.GetMethods(Instance | NonPublic)) {
                    if (method.DeclaringType != type) {
                        continue;
                    }
                    var baseMethod = method.GetBaseDefinition();
                    var attr = baseMethod.GetCustomAttribute<GVirtualMethodAttribute>();
                    if (attr is null) {
                        // this is not a GType virtual method
                        continue;
                    }
                    InstallVirtualMethodOverload((IntPtr)objectClass, attr.DelegateType, method);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static IntPtr ManagedClassConstructor(GType type_, uint nConstructProperties_, IntPtr constructProperties_)
        {
            try {
                // find the first unmanaged type ancestor (indicated by not having
                // ManagedClassConstructor overload) and chain up to that constructor
                // to create the new unmanaged object instance
                var objectClass = g_type_class_peek(type_);
                var parentClass = (UnmanagedStruct*)objectClass;
                for (; ; ) {
                    parentClass = (UnmanagedStruct*)g_type_class_peek_parent((IntPtr)parentClass);
                    if (parentClass->Constructor != (delegate* unmanaged[Cdecl]<GType, uint, IntPtr, IntPtr>)&ManagedClassConstructor) {
                        break;
                    }
                }
                var handle_ = parentClass->Constructor(type_, 0, IntPtr.Zero);

                // then create the managed component of the class - the managed
                // constructor will attach the managed instance to the unmanaged
                // instance via qdata so we don't need to do anything with the
                // managed instance here
                Object.GetInstance(handle_, Transfer.None);

                return handle_;
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
                return default;
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ManagedClassSetProperty(IntPtr objPtr, uint propertyId, Value* value, IntPtr pspecPtr)
        {
            try {
                var obj = Object.GetInstance(objPtr, Transfer.None);
                var pspec = ParamSpec.GetInstance(pspecPtr, Transfer.None)!;

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark]!;
                propInfo.SetValue(obj, value->Get());
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ManagedClassGetProperty(IntPtr objPtr, uint propertyId, Value* value, IntPtr pspecPtr)
        {
            try {
                var obj = Object.GetInstance(objPtr, Transfer.None);
                var pspec = ParamSpec.GetInstance(pspecPtr, Transfer.None)!;

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark]!;
                value->Set(propInfo.GetValue(obj));
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        /// <summary>
        /// Looks up the #GParamSpec for a property of a class.
        /// </summary>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="propertyName">
        /// the name of the property to look up
        /// </param>
        /// <returns>
        /// the #GParamSpec for the property, or
        ///          %NULL if the class doesn't have a property of that name
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
        /* transfer-ownership:none */
        static extern IntPtr g_object_class_find_property(
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr propertyName);

        /// <summary>
        /// Looks up the <see cref="ParamSpec"/> for a property of a class.
        /// </summary>
        /// <param name="propertyName">
        /// the name of the property to look up
        /// </param>
        /// <returns>
        /// the <see cref="ParamSpec"/> for the property, or
        /// <c>null</c> if the class doesn't have a property of that name
        /// </returns>
        public ParamSpec? FindProperty(UnownedUtf8 propertyName)
        {
            var propertyName_ = propertyName.UnsafeHandle;
            var ret_ = g_object_class_find_property(UnsafeHandle, propertyName_);
            var ret = ParamSpec.GetInstance(ret_, Transfer.None);
            return ret;
        }

        /// <summary>
        /// Installs new properties from an array of #GParamSpecs.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// The property id of each property is the index of each #GParamSpec in
        /// the @pspecs array.
        ///
        /// The property id of 0 is treated specially by #GObject and it should not
        /// be used to store a #GParamSpec.
        ///
        /// This function should be used if you plan to use a static array of
        /// #GParamSpecs and g_object_notify_by_pspec(). For instance, this
        /// class initialization:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// enum {
        ///   PROP_0, PROP_FOO, PROP_BAR, N_PROPERTIES
        /// };
        ///
        /// static GParamSpec *obj_properties[N_PROPERTIES] = { NULL, };
        ///
        /// static void
        /// my_object_class_init (MyObjectClass *klass)
        /// {
        ///   GObjectClass *gobject_class = G_OBJECT_CLASS (klass);
        ///
        ///   obj_properties[PROP_FOO] =
        ///     g_param_spec_int ("foo", "Foo", "Foo",
        ///                       -1, G_MAXINT,
        ///                       0,
        ///                       G_PARAM_READWRITE);
        ///
        ///   obj_properties[PROP_BAR] =
        ///     g_param_spec_string ("bar", "Bar", "Bar",
        ///                          NULL,
        ///                          G_PARAM_READWRITE);
        ///
        ///   gobject_class-&gt;set_property = my_object_set_property;
        ///   gobject_class-&gt;get_property = my_object_get_property;
        ///   g_object_class_install_properties (gobject_class,
        ///                                      N_PROPERTIES,
        ///                                      obj_properties);
        /// }
        /// ]|
        ///
        /// allows calling g_object_notify_by_pspec() to notify of property changes:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// void
        /// my_object_set_foo (MyObject *self, gint foo)
        /// {
        ///   if (self-&gt;foo != foo)
        ///     {
        ///       self-&gt;foo = foo;
        ///       g_object_notify_by_pspec (G_OBJECT (self), obj_properties[PROP_FOO]);
        ///     }
        ///  }
        /// ]|
        /// </remarks>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="nPspecs">
        /// the length of the #GParamSpecs array
        /// </param>
        /// <param name="pspecs">
        /// the #GParamSpecs array
        ///   defining the new properties
        /// </param>
        [Since("2.26")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_install_properties(
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint nPspecs,
            /* <array length="0" zero-terminated="0" type="GParamSpec**">
                 <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" />
               </array> */
            /* transfer-ownership:none */
            in IntPtr pspecs);

        /// <summary>
        /// Installs new properties from an array of #GParamSpecs.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// The property id of each property is the index of each #GParamSpec in
        /// the @pspecs array.
        ///
        /// The property id of 0 is treated specially by #GObject and it should not
        /// be used to store a #GParamSpec.
        ///
        /// This function should be used if you plan to use a static array of
        /// #GParamSpecs and g_object_notify_by_pspec(). For instance, this
        /// class initialization:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// enum {
        ///   PROP_0, PROP_FOO, PROP_BAR, N_PROPERTIES
        /// };
        ///
        /// static GParamSpec *obj_properties[N_PROPERTIES] = { NULL, };
        ///
        /// static void
        /// my_object_class_init (MyObjectClass *klass)
        /// {
        ///   GObjectClass *gobject_class = G_OBJECT_CLASS (klass);
        ///
        ///   obj_properties[PROP_FOO] =
        ///     g_param_spec_int ("foo", "Foo", "Foo",
        ///                       -1, G_MAXINT,
        ///                       0,
        ///                       G_PARAM_READWRITE);
        ///
        ///   obj_properties[PROP_BAR] =
        ///     g_param_spec_string ("bar", "Bar", "Bar",
        ///                          NULL,
        ///                          G_PARAM_READWRITE);
        ///
        ///   gobject_class-&gt;set_property = my_object_set_property;
        ///   gobject_class-&gt;get_property = my_object_get_property;
        ///   g_object_class_install_properties (gobject_class,
        ///                                      N_PROPERTIES,
        ///                                      obj_properties);
        /// }
        /// ]|
        ///
        /// allows calling g_object_notify_by_pspec() to notify of property changes:
        ///
        /// |[&lt;!-- language="C" --&gt;
        /// void
        /// my_object_set_foo (MyObject *self, gint foo)
        /// {
        ///   if (self-&gt;foo != foo)
        ///     {
        ///       self-&gt;foo = foo;
        ///       g_object_notify_by_pspec (G_OBJECT (self), obj_properties[PROP_FOO]);
        ///     }
        ///  }
        /// ]|
        /// </remarks>
        /// <param name="pspecs">
        /// the #GParamSpecs array
        ///   defining the new properties
        /// </param>
        [Since("2.26")]
        public void InstallProperties(UnownedCPtrArray<ParamSpec> pspecs)
        {
            var this_ = UnsafeHandle;
            ref readonly var pspecs_ = ref MemoryMarshal.GetReference(pspecs.Data);
            var nPspecs_ = (uint)pspecs.Data.Length;
            g_object_class_install_properties(this_, nPspecs_, pspecs_);
        }

        /// <summary>
        /// Installs a new property.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// Note that it is possible to redefine a property in a derived class,
        /// by installing a property with the same name. This can be useful at times,
        /// e.g. to change the range of allowed values or the default value.
        /// </remarks>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="propertyId">
        /// the id for the new property
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_install_property(
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint propertyId,
            /* <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" /> */
            /* transfer-ownership:none */
            IntPtr pspec);

        /// <summary>
        /// Installs a new property.
        /// </summary>
        /// <remarks>
        /// All properties should be installed during the class initializer.  It
        /// is possible to install properties after that, but doing so is not
        /// recommend, and specifically, is not guaranteed to be thread-safe vs.
        /// use of properties on the same type on other threads.
        ///
        /// Note that it is possible to redefine a property in a derived class,
        /// by installing a property with the same name. This can be useful at times,
        /// e.g. to change the range of allowed values or the default value.
        /// </remarks>
        /// <param name="propertyId">
        /// the id for the new property
        /// </param>
        /// <param name="pspec">
        /// the #GParamSpec for the new property
        /// </param>
        public void InstallProperty(uint propertyId, ParamSpec pspec)
        {
            if (pspec is null) {
                throw new ArgumentNullException(nameof(pspec));
            }

            var handle_ = (UnmanagedStruct*)UnsafeHandle;
            var pspec_ = pspec.UnsafeHandle;
            g_object_class_install_property(handle_, propertyId, pspec_);
        }

        /// <summary>
        /// Get an array of #GParamSpec* for all properties of a class.
        /// </summary>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="nProperties">
        /// return location for the length of the returned array
        /// </param>
        /// <returns>
        /// an array of
        ///          #GParamSpec* which should be freed after use
        /// </returns>
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <array length="0" zero-terminated="0" type="GParamSpec**">
               <type name="ParamSpec" type="GParamSpec*" managed-name="ParamSpec" />
           </array> */
        /* transfer-ownership:container */
        static extern IntPtr g_object_class_list_properties(
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            IntPtr oclass,
            /* <type name="guint" type="guint*" managed-name="Guint" /> */
            /* direction:out caller-allocates:0 transfer-ownership:full */
            out uint nProperties);

        /// <summary>
        /// Get an array of #GParamSpec* for all properties of a class.
        /// </summary>
        /// <returns>
        /// an array of
        ///          #GParamSpec* which should be freed after use
        /// </returns>
        public CPtrArray<ParamSpec> ListProperties()
        {
            return ListProperties(UnsafeHandle);
        }

        internal static CPtrArray<ParamSpec> ListProperties(IntPtr handle_)
        {
            var ret_ = g_object_class_list_properties(handle_, out var nProperties_);
            var ret = CPtrArray.GetInstance<ParamSpec>(ret_, (int)nProperties_, Transfer.Container);
            return ret;
        }

        /// <summary>
        /// Registers @property_id as referring to a property with the name
        /// @name in a parent class or in an interface implemented by @oclass.
        /// This allows this class to "override" a property implementation in
        /// a parent class or to provide the implementation of a property from
        /// an interface.
        /// </summary>
        /// <remarks>
        /// Internally, overriding is implemented by creating a property of type
        /// #GParamSpecOverride; generally operations that query the properties of
        /// the object class, such as g_object_class_find_property() or
        /// g_object_class_list_properties() will return the overridden
        /// property. However, in one case, the @construct_properties argument of
        /// the @constructor virtual function, the #GParamSpecOverride is passed
        /// instead, so that the @param_id field of the #GParamSpec will be
        /// correct.  For virtually all uses, this makes no difference. If you
        /// need to get the overridden property, you can call
        /// g_param_spec_get_redirect_target().
        /// </remarks>
        /// <param name="oclass">
        /// a #GObjectClass
        /// </param>
        /// <param name="propertyId">
        /// the new property ID
        /// </param>
        /// <param name="name">
        /// the name of a property registered in a parent class or
        ///  in an interface of this class.
        /// </param>
        [Since("2.4")]
        [DllImport("gobject-2.0", CallingConvention = CallingConvention.Cdecl)]
        /* <type name="none" type="void" managed-name="None" /> */
        /* transfer-ownership:none */
        static extern void g_object_class_override_property(
            /* <type name="ObjectClass" type="GObjectClass*" managed-name="ObjectClass" /> */
            /* transfer-ownership:none */
            UnmanagedStruct* oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint propertyId,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);

        /// <summary>
        /// Registers <paramref name="propertyId"/> as referring to a property with the name
        /// <paramref name="name"/> in a parent class or in an interface implemented by this instance.
        /// This allows this class to "override" a property implementation in
        /// a parent class or to provide the implementation of a property from
        /// an interface.
        /// </summary>
        /// <remarks>
        /// Internally, overriding is implemented by creating a property of type
        /// <see cref="ParamSpecOverride"/>; generally operations that query the properties of
        /// the object class, such as <see cref="FindProperty"/> or
        /// <see cref="ListProperties()"/> will return the overridden
        /// property. However, in one case, the <c>constructProperties</c> argument of
        /// the <see cref="UnmanagedStruct.Constructor"/> virtual function, the
        /// <see cref="ParamSpecOverride"/> is passed
        /// instead, so that the @param_id field of the <see cref="ParamSpec"/> will be
        /// correct.  For virtually all uses, this makes no difference. If you
        /// need to get the overridden property, you can call
        /// <see cref="ParamSpec.RedirectTarget"/>.
        /// </remarks>
        /// <param name="propertyId">
        /// the new property ID
        /// </param>
        /// <param name="name">
        /// the name of a property registered in a parent class or
        /// in an interface of this class.
        /// </param>
        [Since("2.4")]
        public void OverrideProperty(uint propertyId, UnownedUtf8 name)
        {
            var oclass_ = (UnmanagedStruct*)UnsafeHandle;
            var name_ = name.UnsafeHandle;
            g_object_class_override_property(oclass_, propertyId, name_);
        }
    }

    /// <summary>
    /// The GObjectConstructParam struct is an auxiliary structure used to hand
    /// GParamSpec/GValue pairs to the constructor of a GObjectClass.
    /// </summary>
    struct ObjectConstructParam
    {
#pragma warning disable CS0649
        /// <summary>
        /// the GParamSpec of the construct parameter
        /// </summary>
        public IntPtr Pspec;

        /// <summary>
        /// the value to set the parameter to
        /// </summary>
        public IntPtr Value;
#pragma warning restore CS0649
    }
}
