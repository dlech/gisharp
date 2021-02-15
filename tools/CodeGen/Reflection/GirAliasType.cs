// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System;
using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirAliasType : GirType
    {
        readonly Alias alias;

        public GirAliasType(Alias alias) : base(alias)
        {
            this.alias = alias;
        }

        public override System.Type BaseType =>
            alias.Type.ManagedType.IsValueType ? typeof(ValueType) : alias.Type.ManagedType;

        protected override bool IsValueTypeImpl() => alias.Type.ManagedType.IsValueType;
    }
}
