// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of functions passed to <see cref="List{T}.Foreach"/> and
    /// <see cref="SList{T}.Foreach"/>.
    /// </summary>
    /// <param name="data">
    /// the element's data
    /// </param>
    public delegate void Func<in T>(T data) where T : IOpaque?;
}
