// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019,2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{
    unsafe partial struct TypeQuery
    {
        /// <summary>
        /// the #GType value of the type
        /// </summary>
        public GType Type => type;

        /// <summary>
        /// the name of the type
        /// </summary>
        public UnownedUtf8 TypeName => new((IntPtr)typeName, -1);

        /// <summary>
        /// the size of the class structure
        /// </summary>
        public uint ClassSize => classSize;

        /// <summary>
        /// the size of the instance structure
        /// </summary>
        public uint InstanceSize => instanceSize;
    }
}
