// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public sealed class Class : GIRegisteredType
    {
        /// <summary>
        /// Indicates that this is an abstract class
        /// </summary>
        public bool IsAbstract { get; }

        /// <summary>
        /// Gets the name of the parent type of this class
        /// </summary>
        public string Parent { get; }

        /// <summary>
        /// Getsthe parent type
        /// </summary>
        public Class ParentType => _ParentType.Value;
        readonly Lazy<Class> _ParentType;

        /// <summary>
        /// Gets a list of interfaces implemented by this class, if any.
        /// </summary>
        public IEnumerable<Implements> Implements => _Implements.Value;
        readonly Lazy<List<Implements>> _Implements;

        public Class(XElement element, GirNode parent) : base(element, parent)
        {
            if (element.Name != gi + "class") {
                throw new ArgumentException("Requrires <class> element", nameof(element));
            }
            IsAbstract = Element.Attribute("abstract").AsBool();
            Parent = Element.Attribute("parent")?.Value;
            _ParentType = new(LazyGetParentType);
            _Implements = new(() => LazyGetImplements().ToList());
        }

        Class LazyGetParentType()
        {
            if (Parent is null) {
                return null;
            }
            return TypeResolver.ResolveType<Class>(Namespace, Parent);
        }

        IEnumerable<Implements> LazyGetImplements() =>
            Element.Elements(gi + "implements").Select(x => (Implements)GetNode(x));
    }
}
