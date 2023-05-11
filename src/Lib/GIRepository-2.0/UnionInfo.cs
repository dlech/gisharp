// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class UnionInfo
    {
        IndexedCollection<FieldInfo>? fields;

        /// <summary>
        /// Obtain the type information for fields.
        /// </summary>
        public IndexedCollection<FieldInfo> Fields
        {
            get
            {
                if (fields is null)
                {
                    fields = new(GetNFields, GetField);
                }
                return fields;
            }
        }

        IndexedCollection<FunctionInfo>? methods;

        /// <summary>
        /// Obtain the type information for methods.
        /// </summary>
        public IndexedCollection<FunctionInfo> Methods
        {
            get
            {
                if (methods is null)
                {
                    methods = new(GetNMethods, GetMethod);
                }
                return methods;
            }
        }

        partial void CheckGetDiscriminatorArgs(int n)
        {
            if (n >= NFields)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
        }
    }
}
