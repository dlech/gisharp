// SPDX-License-Identifier: MIT
// Copyright (c) 2017-2019 David Lechner <david@lechnology.com>

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using GISharp.Runtime;

namespace GISharp.Lib.GObject
{

    /// <summary>
    /// The class structure for the GInitiallyUnowned type.
    /// </summary>
    sealed class InitiallyUnownedClass : ObjectClass
    {
        /// <summary>
        /// For internal runtime use only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InitiallyUnownedClass (IntPtr handle, Transfer ownership) : base (handle, ownership)
        {
        }
    }
}
