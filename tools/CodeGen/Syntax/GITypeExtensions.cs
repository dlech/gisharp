// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using GISharp.CodeGen.Gir;

namespace GISharp.CodeGen.Syntax
{
    public static class GITypeExtensions
    {
        /// <summary>
        /// Tests if a type is string-like (zero-terminated array of characters)
        /// </summary>
        public static bool IsString(this GIType type)
        {
            if (type.Interface is Alias alias)
            {
                return alias.Type.IsString();
            }

            return type.GirName switch
            {
                "bytestring" or "utf8" or "filename" => true,
                _ => false,
            };
        }
    }
}
