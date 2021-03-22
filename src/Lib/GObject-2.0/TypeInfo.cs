// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.CompilerServices;

namespace GISharp.Lib.GObject
{
    unsafe partial struct TypeInfo
    {
        /// <summary>
        /// Size of the class structure (required for interface, classed and
        /// instantiatable types)
        /// </summary>
        public ushort ClassSize => classSize;

        /// <summary>
        /// Location of the base initialization function (optional)
        /// </summary>
        public delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, void> BaseInit => baseInit;

        /// <summary>
        /// Location of the base finalization function (optional)
        /// </summary>
        public delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, void> BaseFinalize => baseFinalize;

        /// <summary>
        /// Location of the class initialization function for
        /// classed and instantiatable types. Location of the default vtable
        /// initialization function for interface types. (optional) This function
        /// is used both to fill in virtual functions in the class or default vtable,
        /// and to do type-specific setup such as registering signals and object
        /// properties.
        /// </summary>
        public delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, IntPtr, void> ClassInit => classInit;

        /// <summary>
        /// Location of the class finalization function for
        /// classed and instantiatable types. Location of the default vtable
        /// finalization function for interface types. (optional)
        /// </summary>
        public delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, IntPtr, void> ClassFinalize => classFinalize;

        /// <summary>
        /// User-supplied data passed to the class init/finalize functions
        /// </summary>
        public IntPtr ClassData => classData;

        /// <summary>
        /// Size of the instance (object) structure (required for instantiatable
        /// types only)
        /// </summary>
        public ushort InstanceSize => instanceSize;

        /// <summary>
        /// Location of the instance initialization function (optional, for
        /// instantiatable types only)
        /// </summary>
        public delegate* unmanaged[Cdecl]<TypeInstance.UnmanagedStruct*, TypeClass.UnmanagedStruct*, void> InstanceInit => instanceInit;

        /// <summary>
        /// A #GTypeValueTable function table for generic handling of GValues
        /// of this type (usually only useful for fundamental types)
        /// </summary>
        public ref TypeValueTable ValueTable => ref Unsafe.AsRef<TypeValueTable>(valueTable);

        internal TypeInfo(
            ushort classSize,
            delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, void> baseInit = default,
            delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, void> baseFinalize = default,
            delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, IntPtr, void> classInit = default,
            delegate* unmanaged[Cdecl]<TypeClass.UnmanagedStruct*, IntPtr, void> classFinalize = default,
            IntPtr classData = default,
            ushort instanceSize = default,
            delegate* unmanaged[Cdecl]<TypeInstance.UnmanagedStruct*, TypeClass.UnmanagedStruct*, void> instanceInit = default,
            TypeValueTable* valueTable = default)
        {
            this.classSize = classSize;
            this.baseInit = baseInit;
            this.baseFinalize = baseFinalize;
            this.classInit = classInit;
            this.classFinalize = classFinalize;
            this.classData = classData;
            this.instanceSize = instanceSize;
            nPreallocs = default;
            this.instanceInit = instanceInit;
            this.valueTable = valueTable;
        }
    }
}
