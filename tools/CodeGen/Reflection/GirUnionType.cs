// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirUnionType : GirType
    {
        readonly Union union;

        public GirUnionType(Union union) : base(union)
        {
            this.union = union;
        }

        public override System.Type BaseType => typeof(ValueType);
    }
}
