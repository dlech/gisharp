// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Constant : GIBase
    {
        /// <summary>
        /// Gets the value of the constant
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Gets the C identifier for the constant
        /// </summary>
        public string CType { get; }

        /// <summary>
        /// Gets the type of the constant
        /// </summary>
        public GIType Type => _Type.Value;
        readonly Lazy<GIType> _Type;

        public Constant(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "constant")
            {
                throw new ArgumentException("Requrires <constant> element", nameof(element));
            }
            Value = Element.Attribute("value").Value;
            CType = Element.Attribute(c + "type").Value;
            _Type = new(LazyGetType, false);
        }

        GIType LazyGetType() =>
            (GIType)GetNode(Element.Element(gi + "type") ?? Element.Element(gi + "array"));
    }
}
