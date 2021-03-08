// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values.  The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// negative value if <paramref name="a"/> &lt; <paramref name="b"/>;
    /// zero if <paramref name="a"/> = <paramref name="b"/>; positive
    /// value if <paramref name="a"/> &gt; <paramref name="b"/>
    /// </returns>
    public delegate int CompareDataFunc<T>(T a, T b) where T : IOpaque;

    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values.  The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// negative value if @a &lt; @b; zero if @a = @b; positive
    ///          value if @a &gt; @b
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int UnmanagedCompareFunc(IntPtr a, IntPtr b);

    /// <summary>
    /// Specifies the type of a comparison function used to compare two
    /// values. The function should return a negative integer if the first
    /// value comes before the second, 0 if they are equal, or a positive
    /// integer if the first value comes after the second.
    /// </summary>
    /// <param name="a">
    /// a value
    /// </param>
    /// <param name="b">
    /// a value to compare with
    /// </param>
    /// <returns>
    /// negative value if <paramref name="a"/> &lt; <paramref name="b"/>;
    /// zero if <paramref name="a"/> = <paramref name="b"/>; positive
    /// value if  <paramref name="a"/> &gt; <paramref name="b"/>
    /// </returns>
    public delegate int CompareFunc<T>(T a, T b) where T : IOpaque;

    /// <summary>
    /// A function of this signature is used to copy data when doing a deep-copy.
    /// </summary>
    /// <param name="src">
    /// the data which should be copied
    /// </param>
    /// <returns>
    /// the copy
    /// </returns>
    [Since("2.4")]
    public delegate T CopyFunc<T>(T src) where T : Opaque;

    /// <summary>
    /// Specifies the type of functions passed to <see cref="List.Foreach"/> and
    /// <see cref="SList.Foreach"/>.
    /// </summary>
    /// <param name="data">
    /// the element's data
    /// </param>
    public delegate void Func<in T>(T data) where T : IOpaque?;
}
