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
    unsafe partial class ObjectClass
    {
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
            parentGType.Query(out var parentTypeQuery);
            var ret = new TypeInfo(
                (ushort)parentTypeQuery.ClassSize,
                classInit: &InitManagedClass,
                classData: (IntPtr)GCHandle.Alloc(type),
                instanceSize: (ushort)parentTypeQuery.InstanceSize);

            return ret;
        }

        internal static WeakCPtrArray<ParamSpec> ListProperties(UnmanagedStruct* oclass_)
        {
            uint nProperties_;
            var ret_ = g_object_class_list_properties(oclass_, &nProperties_);
            GMarshal.PopUnhandledException();
            var ret = new WeakCPtrArray<ParamSpec>((IntPtr)ret_, (int)nProperties_, Transfer.Container);
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
        static void InitManagedClass(TypeClass.UnmanagedStruct* gClass_, IntPtr classData_)
        {
            try {
                var gClass = (UnmanagedStruct*)gClass_;
                var gtype = gClass->GTypeClass.GType;
                var type = (Type)GCHandle.FromIntPtr(classData_).Target!;

                // override virtual methods

                Unsafe.Write(&gClass->Constructor, (IntPtr)managedClassConstructor);
                Unsafe.Write(&gClass->SetProperty, (IntPtr)(delegate* unmanaged[Cdecl]<Object.UnmanagedStruct*, uint, Value*, ParamSpec.UnmanagedStruct*, void>)&ManagedClassSetProperty);
                Unsafe.Write(&gClass->GetProperty, (IntPtr)(delegate* unmanaged[Cdecl]<Object.UnmanagedStruct*, uint, Value*, ParamSpec.UnmanagedStruct*, void>)&ManagedClassGetProperty);

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
                    var propertyGType = propInfo.PropertyType.ToGType();
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
                        var name_ = (byte*)Marshal.StringToCoTaskMemUTF8(name);
                        g_object_class_override_property(gClass, propId, name_);
                        Marshal.FreeCoTaskMem((IntPtr)name_);
                        GMarshal.PopUnhandledException();
                    }
                    else {
                        var pspec_ = (ParamSpec.UnmanagedStruct*)pspec.UnsafeHandle;
                        g_object_class_install_property(gClass, propId, pspec_);
                        GMarshal.PopUnhandledException();
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
                    InstallVirtualMethodOverload((IntPtr)gClass, attr.DelegateType, method);
                }
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        // have to keep a pointer to ManagedClassConstructor since we use it for
        // comparison later, otherwise we run into CS8909.
        // https://stackoverflow.com/q/66630082/1976323
        static readonly delegate* unmanaged[Cdecl]<GType, uint, ObjectConstructParam*, Object.UnmanagedStruct*> managedClassConstructor = &ManagedClassConstructor;

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static Object.UnmanagedStruct* ManagedClassConstructor(GType type_, uint nConstructProperties_, ObjectConstructParam* constructProperties_)
        {
            try {
                // find the first unmanaged type ancestor (indicated by not having
                // ManagedClassConstructor overload) and chain up to that constructor
                // to create the new unmanaged object instance
                var parentClass = (UnmanagedStruct*)g_type_class_peek(type_);
                GMarshal.PopUnhandledException();
                for (; ; ) {
                    parentClass = (UnmanagedStruct*)g_type_class_peek_parent(&parentClass->GTypeClass);
                    GMarshal.PopUnhandledException();
#pragma warning disable CS8909
                    if (parentClass->Constructor != managedClassConstructor) {
                        break;
                    }
#pragma warning restore CS8909
                }
                var handle_ = parentClass->Constructor(type_, 0, null);

                // then create the managed component of the class - the managed
                // constructor will attach the managed instance to the unmanaged
                // instance via qdata so we don't need to do anything with the
                // managed instance here
                Object.GetInstance((IntPtr)handle_, Transfer.None);

                return handle_;
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
                return default;
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ManagedClassSetProperty(Object.UnmanagedStruct* obj_, uint propertyId, Value* value, ParamSpec.UnmanagedStruct* pspec_)
        {
            try {
                var obj = Object.GetInstance((IntPtr)obj_, Transfer.None);
                var pspec = ParamSpec.GetInstance((IntPtr)pspec_, Transfer.None)!;

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark]!;
                propInfo.SetValue(obj, value->Get());
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void ManagedClassGetProperty(Object.UnmanagedStruct* obj_, uint propertyId, Value* value, ParamSpec.UnmanagedStruct* pspec_)
        {
            try {
                var obj = Object.GetInstance((IntPtr)obj_, Transfer.None);
                var pspec = ParamSpec.GetInstance((IntPtr)pspec_, Transfer.None)!;

                var propInfo = (PropertyInfo)pspec[managedClassPropertyInfoQuark]!;
                value->Set(propInfo.GetValue(obj));
            }
            catch (Exception ex) {
                GMarshal.PushUnhandledException(ex);
            }
        }
    }
}
