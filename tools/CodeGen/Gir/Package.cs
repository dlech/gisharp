// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public class Package : GirNode
    {
        /// <summary>
        /// Gets the name of the package
        /// </summary>
        public string Name { get; }

        public Package(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            if (element.Name != gi + "package") {
                throw new ArgumentException("Requrires <package> element", nameof(element));
            }

            Name = element.Attribute("name").Value;
        }
    }
}
