// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>



using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Reflection
{
    class GirClassType : GirType
    {
        Class @class;

        public GirClassType(Class @class) : base(@class)
        {
            this.@class = @class;
        }

        public override System.Type BaseType => @class.ParentType;
    }
}
