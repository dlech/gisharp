// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;

// TODO: rename these to something more generic or drop althogether

namespace GISharp.Runtime
{
    /// <summary>
    /// Attribute applied to the unmanaged copy or ref method of an <see cref="Opaque"/>
    /// class that instructs containers how to handle owned elements.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class PtrArrayCopyFuncAttribute : Attribute { }

    /// <summary>
    /// Attribute applied to the unmanaged free or unref method of an <see cref="Opaque"/>
    /// class that instructs containsers how to handle owned elements.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class PtrArrayFreeFuncAttribute : Attribute { }
}
