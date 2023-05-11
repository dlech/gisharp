// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Constructor : GIFunction
    {
        /// <summary>
        /// Indicates that the constructor has a custom implementation.
        /// </summary>
        public bool HasCustomConstructor { get; }

        public Constructor(XElement element, GirNode parent)
            : base(element, parent)
        {
            if (element.Name != gi + "constructor")
            {
                throw new ArgumentException("Requrires <constructor> element", nameof(element));
            }
            HasCustomConstructor = element.Attribute(gs + "custom-constructor").AsBool();
        }
    }
}
