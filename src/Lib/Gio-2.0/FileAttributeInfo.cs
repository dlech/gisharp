// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial struct FileAttributeInfo
    {
        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        public unsafe UnownedUtf8 Name => new(name);
    }
}
