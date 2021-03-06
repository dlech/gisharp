// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIBase : GirNode
    {
        /// <summary>
        /// Gets the name of this member
        /// </summary>
        public string GirName { get; }

        /// <summary>
        /// Gets the fixed up managed name of this member
        /// </summary>
        public string ManagedName { get; }

        /// <summary>
        /// Gets the version in which this member was introduced, or null
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets if this member has been deprecated
        /// </summary>
        public bool IsDeprecated { get; }

        /// <summary>
        /// Gets the version in which this member was deprecated, or null
        /// </summary>
        public string DeprecatedVersion { get; }

        /// <summary>
        /// Gets the access modifiers, if any
        /// </summary>
        public string AccessModifiers { get; }

        /// <summary>
        /// Gets the inheritance modifiers, if any
        /// </summary>
        public string InheritanceModifiers { get; }

        /// <summary>
        /// Gets the deprecated documentation node, if any
        /// </summary>
        public DocDeprecated DocDeprecated => _DocDeprecated.Value;
        readonly Lazy<DocDeprecated> _DocDeprecated;

        /// <summary>
        /// Gets the namespace for this member
        /// </summary>
        public Namespace Namespace => _Namespace.Value;
        readonly Lazy<Namespace> _Namespace;

        private protected GIBase(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            GirName = element.Attribute("name").AsString();
            ManagedName = element.Attribute(gs + "managed-name").AsString();
            Version = element.Attribute("version").AsString();
            IsDeprecated = element.Attribute("deprecated").AsBool();
            DeprecatedVersion = element.Attribute("deprecated-version").AsString();
            AccessModifiers = element.Attribute(gs + "access-modifiers").AsString();
            InheritanceModifiers = element.Attribute(gs + "inheritance-modifiers").AsString();
            _DocDeprecated = new(LazyGetDocDeprecated, false);
            _Namespace = new(LazyGetNamespace, false);
        }

        DocDeprecated LazyGetDocDeprecated() =>
            (DocDeprecated)GetNode(Element.Element(gi + "doc-deprecated"));

        Namespace LazyGetNamespace() =>
            (Namespace)GetNode(Element.Ancestors(gi + "namespace").Single());
    }
}
