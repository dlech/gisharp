// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

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

        public Class Type => _Type.Value;
        readonly Lazy<Class> _Type;

        public Prerequisite(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "prerequisite") {
                throw new ArgumentException("Requrires <prerequisite> element", nameof(element));
            }
            GirName = element.Attribute("name").Value;
            _Type = new(LazyGetType);
        }

        Class LazyGetType() => TypeResolver.ResolveType<Class>(ParentNode.Namespace, GirName);
    }
}
