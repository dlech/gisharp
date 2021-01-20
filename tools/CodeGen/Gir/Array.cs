// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Array : GIType
    {
        /// <summary>
        /// Indicates that the array is null-terminated.
        /// </summary>
        public bool IsZeroTerminated { get; }

        /// <summary>
        /// Gets this size of an array if it has a fixed size or -1.
        /// </summary>
        public int FixedSize { get; }

        /// <summary>
        /// Gets the index of the parameter that holds the array length or -1.
        /// </summary>
        public int LengthIndex { get; }

        public Array(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "array") {
                throw new ArgumentException("Requrires <array> element", nameof(element));
            }
            IsZeroTerminated = element.Attribute("zero-terminated").AsBool();
            FixedSize = element.Attribute("fixed-size").AsInt(-1);
            LengthIndex = element.Attribute("length").AsInt(-1);
        }
    }
}
