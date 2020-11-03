using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
    public class ObjectClass : TypeClass
    {
        static readonly int onConstructorOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnConstructor));
        static readonly int onSetPropertyOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnSetProperty));
        static readonly int onGetPropertyOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnGetProperty));
        static readonly int onDisposeOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnDispose));
        static readonly int onFinalizeOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnFinalize));
        static readonly int onDispatchPropertiesChangedOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnDispatchPropertiesChanged));
        static readonly int onNotifyOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnNotify));
        static readonly int onConstructedOffset = (int)Marshal.OffsetOf<Struct>(nameof(Struct.OnConstructed));

        static readonly UnmanagedSetProperty managedSetPropertyDelegate = ManagedClassSetProperty;
        static readonly IntPtr managedSetPropertyPtr = Marshal.GetFunctionPointerForDelegate(managedSetPropertyDelegate);
        static readonly UnmanagedSetProperty managedGetPropertyDelegate = ManagedClassGetProperty;
        static readonly IntPtr managedGetPropertyPtr = Marshal.GetFunctionPointerForDelegate(managedGetPropertyDelegate);
        static readonly UnmanagedNotify managedNotifyDelegate = ManagedNotify;
        static readonly IntPtr managedNotifyPtr = Marshal.GetFunctionPointerForDelegate(managedNotifyDelegate);

        /// <summary>
        /// The unmanaged data structure
        /// </summary>
        new protected struct Struct
        {
#pragma warning disable CS0649
#pragma warning disable CS0169
            /// <summary>
            /// The parent type class
            /// </summary>
            public TypeClass.Struct GTypeClass;

            IntPtr constructProperties;

            /* seldom overidden */
            /// <summary>
            /// <see cref="UnmanagedConstructor"/>
            /// </summary>
            public IntPtr OnConstructor;
            /* overridable methods */
            /// <summary>
            /// <see cref="UnmanagedSetProperty"/>
            /// </summary>
            public IntPtr OnSetProperty;
            /// <summary>
            /// <see cref="UnmanagedGetProperty"/>
            /// </summary>
            public IntPtr OnGetProperty;
            /// <summary>
            /// <see cref="UnmanagedDispose"/>
            /// </summary>
            public IntPtr OnDispose;
            /// <summary>
            /// <see cref="UnmanagedFinalize"/>
            /// </summary>
            public IntPtr OnFinalize;
            /* seldom overidden */
            /// <summary>
            /// <see cref="UnmanagedDispatchPropertiesChanged"/>
            /// </summary>
            public IntPtr OnDispatchPropertiesChanged;
            /* signals */
            /// <summary>
            /// <see cref="UnmanagedNotify"/>
            /// </summary>
            public IntPtr OnNotify;

            /* called when done constructing */
            /// <summary>
            /// <see cref="UnmanagedConstructed"/>
            /// </summary>
            public IntPtr OnConstructed;

            UIntPtr flags;
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
        /// the constructor function is called by g_object_new() to complete
        /// the object initialization after all the construction properties are
        /// set. The first thing a constructor implementation must do is chain
        /// up to the constructor of the parent class. Overriding constructor
        /// should be rarely needed, e.g. to handle construct properties, or to
        /// implement singletons.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr UnmanagedConstructor(GType type, uint nConstructProperties, IntPtr constructProperties);

        /// <summary>
        /// <see cref="UnmanagedConstructor"/>
        /// </summary>
        public UnmanagedConstructor OnConstructor =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedConstructor>(Handle, onConstructedOffset)!;

        /// <summary>
        /// the generic setter for all properties of this type. Should be
        /// overridden for every type with properties. If implementations of
        /// set_property don't emit property change notification explicitly,
        /// this will be done implicitly by the type system. However, if the
        /// notify signal is emitted explicitly, the type system will not emit
        /// it a second time.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedSetProperty(IntPtr @object, uint propertyId, ref Value value, IntPtr pspec);

        /// <summary>
        /// <see cref="UnmanagedSetProperty"/>
        /// </summary>
        public UnmanagedSetProperty OnSetProperty =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedSetProperty>(Handle, onSetPropertyOffset)!;

        /// <summary>
        /// the generic getter for all properties of this type. Should be
        /// overridden for every type with properties.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedGetProperty(IntPtr @object, uint propertyId, ref Value value, IntPtr pspec);

        /// <summary>
        /// <see cref="UnmanagedGetProperty"/>
        /// </summary>
        public UnmanagedGetProperty OnGetProperty =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedGetProperty>(Handle, onGetPropertyOffset)!;

        /// <summary>
        /// the dispose function is supposed to drop all references to other
        /// objects, but keep the instance otherwise intact, so that client
        /// method invocations still work. It may be run multiple times (due
        /// to reference loops). Before returning, dispose should chain up to
        /// the dispose method of the parent class.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedDispose(IntPtr @object);

        /// <summary>
        /// <see cref="UnmanagedDispose"/>
        /// </summary>
        public UnmanagedDispose OnDispose =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedDispose>(Handle, onDisposeOffset)!;

        /// <summary>
        /// instance finalization function, should finish the finalization of
        /// the instance begun in dispose and chain up to the finalize method
        /// of the parent class.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedFinalize(IntPtr @object);

        /// <summary>
        /// <see cref="UnmanagedFinalize"/>
        /// </summary>
        public UnmanagedFinalize OnFinalize =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedFinalize>(Handle, onFinalizeOffset)!;

        /// <summary>
        /// emits property change notification for a bunch of properties.
        /// Overriding dispatch_properties_changed should be rarely needed.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedDispatchPropertiesChanged(IntPtr @object, uint nPspecs, IntPtr pspec);

        /// <summary>
        /// <see cref="UnmanagedDispatchPropertiesChanged"/>
        /// </summary>
        public UnmanagedDispatchPropertiesChanged OnDispatchPropertiesChanged =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedDispatchPropertiesChanged>(Handle, onDispatchPropertiesChangedOffset)!;

        /// <summary>
        /// the class closure for the notify signal
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedNotify(IntPtr @object, IntPtr pspec);

        /// <summary>
        /// <see cref="UnmanagedNotify"/>
        /// </summary>
        public UnmanagedNotify OnNotify =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedNotify>(Handle, onNotifyOffset)!;

        /// <summary>
        /// the constructed function is called by g_object_new() as the final
        /// step of the object creation process. At the point of the call, all
        /// construction properties have been set on the object. The purpose of
        /// this call is to allow for object initialisation steps that can only
        /// be performed after construction properties have been set. constructed
        /// implementors should chain up to the constructed call of their parent
        /// class to allow it to complete its initialisation.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnmanagedConstructed(IntPtr @object);

        /// <summary>
        /// <see cref="UnmanagedConstructed"/>
        /// </summary>
        public UnmanagedConstructed OnConstructed =>
            GMarshal.GetVirtualMethodDelegate<UnmanagedConstructed>(Handle, onConstructedOffset)!;


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
            var parentGType = type.BaseType.GetGType();
            var parentTypeQuery = parentGType.Query();
            var ret = new TypeInfo {
                ClassSize = (ushort)parentTypeQuery.ClassSize,
                ClassInit = Marshal.GetFunctionPointerForDelegate(InitManagedClassDelegate),
                ClassData = (IntPtr)GCHandle.Alloc(type),
                InstanceSize = (ushort)parentTypeQuery.InstanceSize,
            };

            return ret;
        }

        static TypeInfo.UnmanagedClassInitFunc InitManagedClassDelegate = InitManagedClass;

        /// <summary>
        /// ClassInit callback for managed classes.
        /// </summary>
        /// <param name="class_">Pointer to <see cref="Struct"/>.</param>
        /// <param name="userData_">Pointer to user data from <see cref="TypeInfo"/>.</param>
        /// <remarks>
        /// This takes care of overriding the methods to make the managed type
        /// interop with the GObject type system.
        /// </remarks>
        static void InitManagedClass(IntPtr class_, IntPtr userData_)
        {
            try {
                // Can't use type.GetGType() here since the type registration has
                // not finished. So, we get the GType this way instead.
                var gtype = Marshal.PtrToStructure<GType>(class_);
                var type = (Type)GCHandle.FromIntPtr(userData_).Target;

                // override property native accessors

                Marshal.WriteIntPtr(class_, onSetPropertyOffset, managedSetPropertyPtr);
                Marshal.WriteIntPtr(class_, onGetPropertyOffset, managedGetPropertyPtr);
                Marshal.WriteIntPtr(class_, onNotifyOffset, managedNotifyPtr);

                // Install Properties

                uint propId = 1; // propId 0 is used internally, so we start with 1
                foreach (var propInfo in type.GetProperties()) {
                    GPropertyAttribute? gPropertyAttr = propInfo.GetCustomAttribute<GPropertyAttribute>(true);
                    if (gPropertyAttr == null) {
                        // maybe the property is declared in an interface
                        gPropertyAttr = propInfo.TryGetMatchingInterfacePropertyInfo()?.GetCustomAttribute<GPropertyAttribute>(true);
                        if (gPropertyAttr == null) {
                            // only register properties with [GProperty] attribute
                            continue;
                        }
                    }

                    if (propInfo.DeclaringType != type) {
                        // only register properties declared in this type or in interfaces
                        continue;
                    }

                    var name = propInfo.TryGetGPropertyName();
                    if (name == null) {
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

                    if (propInfo.GetCustomAttribute<ObsoleteAttribute>(true) != null) {
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
                        pspec = new ParamSpecVariant(name, nick, blurb, variantType, defaultValue == null ? null : (Variant)defaultValue, flags);
                    }
                    else {
                        // TODO: Need more specific exception
                        throw new Exception("unhandled GType");
                    }

                    var methodInfo = propInfo.GetAccessors().First();
                    if (methodInfo.GetBaseDefinition() != methodInfo || propInfo.TryGetMatchingInterfacePropertyInfo() != null) {
                        // if this type did not declare the property, the we know
                        // we are overriding a property from a base class or interface
                        var namePtr = GMarshal.StringToUtf8Ptr(name);
                        g_object_class_override_property(class_, propId, namePtr);
                        GMarshal.Free(namePtr);
                    }
                    else {
                        g_object_class_install_property(class_, propId, pspec.Handle);
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
                    if (signalAttr == null) {
                        // events without SignalAttribute are not installed
                        continue;
                    }

                    // figure out the name

                    var name = signalAttr.Name ?? eventInfo.Name;
                    Signal.ValidateName(name);

                    // figure out the flags

                    var flags = default(SignalFlags);

                    switch (signalAttr.When) {
                    case EmissionStage.First:
                        flags |= SignalFlags.RunFirst;
                        break;
                    case EmissionStage.Last:
                    default:
                        flags |= SignalFlags.RunLast;
                        break;
                    case EmissionStage.Cleanup:
                        flags |= SignalFlags.RunCleanup;
                        break;
                    }

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
                        flags |= SignalFlags.IsNoHooks;
                    }

                    if (eventInfo.GetCustomAttribute<ObsoleteAttribute>(true) != null) {
                        flags |= SignalFlags.Deprecated;
                    }

                    // figure out the parameter types

                    var methodInfo = eventInfo.EventHandlerType.GetMethod("Invoke");
                    var returnGType = methodInfo.ReturnType.GetGType();
                    var parameters = methodInfo.GetParameters();
                    var parameterGTypes = new GType[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++) {
                        parameterGTypes[i] = parameters[i].ParameterType.GetGType();
                    }

                    // create a closure that will be called when the signal is emitted

                    var fieldInfo = type.GetField(eventInfo.Name, Instance | NonPublic);

                    var closure = new Closure((p) => {
                        var eventDelegate = (MulticastDelegate)fieldInfo.GetValue(p[0]);
                        return eventDelegate.DynamicInvoke(p.Skip(1).ToArray());
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
                    if (attr == null) {
                        // this is not a GType virtual method
                        continue;
                    }
                    TypeClass.InstallVirtualMethodOverload(class_, attr.DelegateType, method);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static void ManagedClassSetProperty(IntPtr objPtr, uint propertyId, ref Value value, IntPtr pspecPtr)
        {
            try {
                var obj = Object.GetInstance(objPtr, Transfer.None);
                var pspec = ParamSpec.GetInstance(pspecPtr, Transfer.None)!;

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark]!;
                propInfo.SetValue(obj, value.Get());
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static void ManagedClassGetProperty(IntPtr objPtr, uint propertyId, ref Value value, IntPtr pspecPtr)
        {
            try {
                var obj = Object.GetInstance(objPtr, Transfer.None);
                var pspec = ParamSpec.GetInstance(pspecPtr, Transfer.None)!;

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark]!;
                value.Set(propInfo.GetValue(obj));
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        static void ManagedNotify(IntPtr object_, IntPtr pspec_)
        {
            try {
                var obj = Object.GetInstance(object_, Transfer.None)!;
                var pspec = ParamSpec.GetInstance(pspec_, Transfer.None)!;
                obj.OnNotify(pspec);
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
            var propertyName_ = propertyName.Handle;
            var ret_ = g_object_class_find_property(Handle, propertyName_);
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
        public unsafe void InstallProperties(UnownedCPtrArray<ParamSpec> pspecs)
        {
            var this_ = Handle;
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
            IntPtr oclass,
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
            g_object_class_install_property(Handle, propertyId, pspec.Handle);
            GC.KeepAlive(pspec);
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
            return ListProperties(Handle);
        }

        internal static CPtrArray<ParamSpec> ListProperties(IntPtr handle)
        {
            var ret_ = g_object_class_list_properties(handle, out var nProperties_);
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
            IntPtr oclass,
            /* <type name="guint" type="guint" managed-name="Guint" /> */
            /* transfer-ownership:none */
            uint propertyId,
            /* <type name="utf8" type="const gchar*" managed-name="Utf8" /> */
            /* transfer-ownership:none */
            IntPtr name);
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
