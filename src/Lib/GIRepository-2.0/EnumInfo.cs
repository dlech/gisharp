// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class EnumInfo
    {
        IndexedCollection<ValueInfo>? values;

        /// <summary>
        /// Obtain enum type values.
        /// </summary>
        public IndexedCollection<ValueInfo> Values {
            get {
                if (values is null) {
                    values = new(GetNValues, GetValue);
                }
                return values;
            }
        }

        IndexedCollection<FunctionInfo>? methods;

        /// <summary>
        /// Obtain enum type methods.
        /// </summary>
        public IndexedCollection<FunctionInfo> Methods {
            get {
                if (methods is null) {
                    methods = new(GetNMethods, GetMethod);
                }
                return methods;
            }
        }
    }
}
