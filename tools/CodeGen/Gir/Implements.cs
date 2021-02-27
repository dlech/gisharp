// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Implements : GIBase
    {
        /// <summary>
        /// The parent node
        /// </summary>
        public new Class ParentNode => (Class)base.ParentNode;

        /// <summary>
        /// Gets the implemented interface
        /// </summary>
        public Interface Interface => _Interface.Value;
        readonly Lazy<Interface> _Interface;

        public Implements(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "implements") {
                throw new ArgumentException("Requrires <implements> element", nameof(element));
            }
            _Interface = new(LazyGetInterface);
        }

        Interface LazyGetInterface() => TypeResolver.ResolveType<Interface>(Namespace, GirName);
    }
}
