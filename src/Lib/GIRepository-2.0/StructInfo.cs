// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class StructInfo
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
                    fields = new IndexedCollection<FieldInfo>(GetNFields, GetField);
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
                    methods = new IndexedCollection<FunctionInfo>(GetNMethods, GetMethod);
                }
                return methods;
            }
        }
    }
}
