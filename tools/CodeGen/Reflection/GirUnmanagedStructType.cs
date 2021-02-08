// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirUnmanagedStructType : GirType
    {
        public GirUnmanagedStructType(GIRegisteredType type) : base(type)
        {
            // strip "I" prefix from interface name and add "+UnmanagedStruct"
            Name = $"{base.Name[(type is Interface ? 1 : 0)..]}+UnmanagedStruct";
        }

        public override string Name { get; }
    }
}
