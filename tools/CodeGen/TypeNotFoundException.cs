// SPDX-License-Identifier: MIT
// Copyright (c) 2017-2019 David Lechner <david@lechnology.com>

using System;

namespace GISharp.CodeGen
{
    public class TypeNotFoundException : Exception
    {
        public TypeNotFoundException(string typeName)
            : base(string.Format("Failed to get type for '{0}'.", typeName)) { }
    }
}
