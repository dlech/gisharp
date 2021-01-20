// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GISharp.CodeGen.Reflection;
using GISharp.Runtime;

namespace GISharp.CodeGen.Gir
{
    public sealed class Prerequisite : GirNode
    {
        /// <summary>
        /// Gets the name of the prerequisite
        /// </summary>
        public string GirName { get; }

        /// <summary>
        /// The parent node
        /// </summary>
        public new Interface ParentNode => (Interface)base.ParentNode;

        public System.Type ManagedType => _Type.Value;
        readonly Lazy<System.Type> _Type;

        public Prerequisite(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "prerequisite") {
                throw new ArgumentException("Requrires <prerequisite> element", nameof(element));
            }
            GirName = element.Attribute("name").Value;
            _Type = new(LazyGetType);
        }

        System.Type LazyGetType() => GirInterfaceType.ResolveType(this);
    }
}
