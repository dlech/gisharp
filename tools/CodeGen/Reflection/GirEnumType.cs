// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>


using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirEnumType : GirType
    {
        public GirEnumType(GIEnum @enum) : base(@enum)
        {
        }

        public override System.Type BaseType => typeof(System.Enum);

        public override System.Type UnderlyingSystemType => typeof(int);
    }
}
