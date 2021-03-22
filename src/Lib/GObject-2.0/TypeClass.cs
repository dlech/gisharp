// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace GISharp.Lib.GObject
{
    unsafe partial class TypeClass
    {
        class VirtualMethodInfo
        {
            public readonly int Offset;
            public readonly Func<MethodInfo, Delegate> Create;
            public readonly Dictionary<IntPtr, Delegate> Overloads = new();

            public VirtualMethodInfo(int offset, Func<MethodInfo, Delegate> create)
            {
                Offset = offset;
                Create = create;
            }
        }

        /// <summary>
        /// A dictionary mapping virtual method delegate types to their offsets
        /// in Struct.
        /// </summary>
        readonly static Dictionary<Type, VirtualMethodInfo> virtualMethods = new();

        /// <summary>
        /// Gets the GType of this type.
        /// </summary>
        public GType GType => Marshal.PtrToStructure<GType>(UnsafeHandle);

        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected TypeClass(IntPtr handle, Transfer ownership) : base(handle)
        {
            if (ownership == Transfer.None) {
                var gtype = Marshal.PtrToStructure<GType>(handle);
                g_type_class_ref(gtype);
                GMarshal.PopUnhandledException();
            }
        }

        /// <summary>
        /// Marshals an unmanged pointer to a managed object.
        /// </summary>
        public static new T? GetInstance<T>(IntPtr handle, Transfer ownership) where T : TypeClass
        {
            if (handle == IntPtr.Zero) {
                return null;
            }

            var gtype = ((UnmanagedStruct*)handle)->GType;
            var type = gtype.GetGTypeStruct();
            return (T?)Activator.CreateInstance(type, handle, ownership);
        }

        /// <summary>
        /// Gets the type class for the given GType.
        /// </summary>
        public static T GetInstance<T>(GType type) where T : TypeClass
        {
            if (!type.IsClassed) {
                throw new ArgumentException("GType is not classed", nameof(type));
            }
            var handle = g_type_class_ref(type);
            GMarshal.PopUnhandledException();
            var ret = GetInstance<T>((IntPtr)handle, Transfer.Full)!;
            return ret;
        }

        /// <summary>
        /// Gets the type class for the given GType.
        /// </summary>
        public static TypeClass Get(GType type)
        {
            return GetInstance<TypeClass>(type);
        }

        [ModuleInitializer]
        internal static void RegisterTypeResolver()
        {
            RegisterTypeResolver<TypeClass>(GetInstance<TypeClass>);
        }

        /// <summary>
        /// Registers a virtual method
        /// </summary>
        /// <param name="offset">
        /// The offset to the virtual function pointer in <see cref="UnmanagedStruct"/>
        /// </param>
        /// <param name="create">
        /// The unmanged delegate factory create method
        /// </param>
        protected internal static void RegisterVirtualMethod<T>(int offset, Func<MethodInfo, T> create) where T : Delegate
        {
            var info = new VirtualMethodInfo(offset, create);
            virtualMethods.Add(typeof(T), info);
        }

        /// <summary>
        /// Registers a managed method as an overload of an unmanaged virtual
        /// method.
        /// </summary>
        /// <param name="class_">Pointer to the unmanaged class instance</param>
        /// <param name="type">The unmanaged delegate type</param>
        /// <param name="methodInfo">The method to install as the overload</param>
        internal static void InstallVirtualMethodOverload(IntPtr class_, Type type, MethodInfo methodInfo)
        {
            // Ensure that the virtual methods have been registered
            RuntimeHelpers.RunClassConstructor(type.DeclaringType!.TypeHandle);

            var info = virtualMethods[type];
            var callback = info.Create(methodInfo);
            info.Overloads.Add(class_, callback);
            var ptr = Marshal.GetFunctionPointerForDelegate(callback);
            Marshal.WriteIntPtr(class_, info.Offset, ptr);
        }

        /// <summary>
        /// Gets a delegate for the unmanaged virtual function pointer.
        /// </summary>
        public static T? GetUnmanagedVirtualMethod<T>(GType type) where T : Delegate
        {
            var class_ = g_type_class_ref(type);
            GMarshal.PopUnhandledException();
            try {
                var info = virtualMethods[typeof(T)];
                var ptr = Marshal.ReadIntPtr((IntPtr)class_, info.Offset);
                if (ptr == IntPtr.Zero) {
                    return default;
                }
                return Marshal.GetDelegateForFunctionPointer<T>(ptr);
            }
            finally {
                g_type_class_unref(class_);
            }
        }
    }
}
