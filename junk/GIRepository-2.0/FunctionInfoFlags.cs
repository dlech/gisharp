// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019 David Lechner <david@lechnology.com>

// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

using System;

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// Flags for a <see cref="FunctionInfo"/> struct.
    /// </summary>
    [Flags]
    enum FunctionInfoFlags
    {
        /// <summary>
        /// is a method.
        /// </summary>
        IsMethod = 1 << 0,

        /// <summary>
        /// is a constructor.
        /// </summary>
        IsConstructor = 1 << 1,

        /// <summary>
        /// is a getter of a <see cref="PropertyInfo"/>.
        /// </summary>
        IsGetter = 1 << 2,

        /// <summary>
        /// is a setter of a <see cref="PropertyInfo"/>.
        /// </summary>
        IsSetter = 1 << 3,

        /// <summary>
        /// represents a virtual function.
        /// </summary>
        WrapsVfunc = 1 << 4,

        /// <summary>
        /// the function may throw an error.
        /// </summary>
        Throws = 1 << 5,
    }
}
