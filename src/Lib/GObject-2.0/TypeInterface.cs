// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial class TypeInterface
    {
        /// <summary>
        /// Registers a virtual method
        /// </summary>
        /// <param name="offset">
        /// The offset to the virtual function pointer in <see cref="UnmanagedStruct"/>
        /// </param>
        /// <param name="create">
        /// The unmanged delegate factory create method
        /// </param>
        protected static void RegisterVirtualMethod<T>(int offset, Func<MethodInfo, T> create) where T : Delegate
        {
            TypeClass.RegisterVirtualMethod(offset, create);
        }

        /// <summary>
        /// Gets the instance type
        /// </summary>
        public GType InstanceType => ((UnmanagedStruct*)UnsafeHandle)->GInstanceType;

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void InterfaceInit(UnmanagedStruct* gIface, IntPtr userData)
        {
            try {
                var gcHandle = (GCHandle)userData;
                var types = (Tuple<Type, Type>)gcHandle.Target!;
                var interfaceType = types.Item1;
                var instanceType = types.Item2;
                var map = instanceType.GetInterfaceMap(interfaceType);

                for (var i = 0; i < map.InterfaceMethods.Length; i++) {
                    var ifaceMethod = map.InterfaceMethods[i];
                    var instanceMethod = map.TargetMethods[i];

                    var attr = ifaceMethod.GetCustomAttribute<GVirtualMethodAttribute>();
                    if (attr is null) {
                        continue;
                    }

                    TypeClass.InstallVirtualMethodOverload((IntPtr)gIface, attr.DelegateType, instanceMethod);
                }
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void InterfaceFinalize(UnmanagedStruct* gIface, IntPtr userData)
        {
            try {
                var gcHandle = (GCHandle)userData;
                gcHandle.Free();
            }
            catch (Exception ex) {
                ex.LogUnhandledException();
            }
        }

        internal static InterfaceInfo CreateInterfaceInfo(Type interfaceType, Type instanceType)
        {
            var types = new Tuple<Type, Type>(interfaceType, instanceType);

            var ret = new InterfaceInfo(
                (delegate* unmanaged[Cdecl]<UnmanagedStruct*, IntPtr, void>)&InterfaceInit,
                (delegate* unmanaged[Cdecl]<UnmanagedStruct*, IntPtr, void>)&InterfaceFinalize,
                (IntPtr)GCHandle.Alloc(types));

            return ret;
        }
    }
}
