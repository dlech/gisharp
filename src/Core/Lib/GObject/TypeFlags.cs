// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019 David Lechner <david@lechnology.com>

﻿using System;

namespace GISharp.Lib.GObject
{
    /// <summary>
    /// Bit masks used to check or determine characteristics of a type.
    /// </summary>
    [Flags]
    enum TypeFlags
    {
        /// <summary>
        /// Indicates a classed type
        /// </summary>
        Classed = 1,

        /// <summary>
        /// Indicates an instantiable type (implies classed)
        /// </summary>
        Instantiatable = 2,

        /// <summary>
        /// Indicates a flat derivable type
        /// </summary>
        Derivable = 4,

        /// <summary>
        /// Indicates a deep derivable type (implies derivable)
        /// </summary>
        DeepDerivable = 8,

        /// <summary>
        /// Indicates an abstract type. No instances can be
        ///  created for an abstract type
        /// </summary>
        Abstract = 16,

        /// <summary>
        /// Indicates an abstract value type, i.e. a type
        ///  that introduces a value table, but can't be used for
        ///  g_value_init()
        /// </summary>
        ValueAbstract = 32,
    }
}
