// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public class Namespace : GirNode
    {
        /// <summary>
        /// Gets the GIR namespace version
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets the name of the namespace
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the shared libraries for this namespace (as file paths)
        /// </summary>
        public IReadOnlyCollection<string> SharedLibraries { get; }

        /// <summary>
        /// Gets the C identifier prefixes for this namespace
        /// </summary>
        public IReadOnlyCollection<string> CIdentifierPrefixes { get; }

        /// <summary>
        /// Gets the C symbol prefixes for this namespace
        /// </summary>
        public IReadOnlyCollection<string> CSymbolPrefixes { get; }

        /// <summary>
        /// Gets a list of aliases
        /// </summary>
        public IEnumerable<Alias> Aliases => _Aliases.Value;
        readonly Lazy<List<Alias>> _Aliases;

        /// <summary>
        /// Gets a list of enumerations
        /// </summary>
        public IEnumerable<Bitfield> Bitfields => _Bitfields.Value;
        readonly Lazy<List<Bitfield>> _Bitfields;

        /// <summary>
        /// Gets a list of boxeds
        /// </summary>
        public IEnumerable<Boxed> Boxeds => _Boxeds.Value;
        readonly Lazy<List<Boxed>> _Boxeds;

        /// <summary>
        /// Gets a list of callbacks
        /// </summary>
        public IEnumerable<Callback> Callbacks => _Callbacks.Value;
        readonly Lazy<List<Callback>> _Callbacks;

        /// <summary>
        /// Gets a list of classes
        /// </summary>
        public IEnumerable<Class> Classes => _Classes.Value;
        readonly Lazy<List<Class>> _Classes;

        /// <summary>
        /// Gets a list of enumerations
        /// </summary>
        public IEnumerable<Enumeration> Enumerations => _Enumerations.Value;
        readonly Lazy<List<Enumeration>> _Enumerations;

        /// <summary>
        /// Gets a list of interfaces
        /// </summary>
        public IEnumerable<Interface> Interfaces => _Interfaces.Value;
        readonly Lazy<List<Interface>> _Interfaces;

        /// <summary>
        /// Gets a list of records
        /// </summary>
        public IEnumerable<Record> Records => _Records.Value;
        readonly Lazy<List<Record>> _Records;

        /// <summary>
        /// Gets a list of static classes
        /// </summary>
        public IEnumerable<StaticClass> StaticClasses => _StaticClasses.Value;
        readonly Lazy<List<StaticClass>> _StaticClasses;

        /// <summary>
        /// Gets a list of unions
        /// </summary>
        public IEnumerable<Union> Unions => _Unions.Value;
        readonly Lazy<List<Union>> _Unions;

        /// <summary>
        /// Gets a list of all types declared in this namespace
        /// </summary>
        public IEnumerable<GIBase> AllTypes => _AllTypes.Value;
        readonly Lazy<List<GIBase>> _AllTypes;

        public new Repository ParentNode => (Repository)base.ParentNode;

        public Namespace(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            if (element.Name != gi + "namespace")
            {
                throw new ArgumentException("Requrires <namespace> element", nameof(element));
            }

            Name = element.Attribute("name").Value;
            Version = element.Attribute("version").Value;
            SharedLibraries = element.Attribute("shared-library").Value.Split(',');
            CIdentifierPrefixes = element.Attribute(c + "identifier-prefixes").Value.Split(',');
            CSymbolPrefixes = element.Attribute(c + "symbol-prefixes").Value.Split(',');
            _Aliases = new(() => LazyGetAliases().ToList(), false);
            _Bitfields = new(() => LazyGetBitfields().ToList(), false);
            _Boxeds = new(() => LazyGetBoxeds().ToList(), false);
            _Callbacks = new(() => LazyGetCallbacks().ToList(), false);
            _Classes = new(() => LazyGetClasses().ToList(), false);
            _Enumerations = new(() => LazyGetEnumerations().ToList(), false);
            _Interfaces = new(() => LazyGetInterfaces().ToList(), false);
            _Records = new(() => LazyGetRecords().ToList(), false);
            _StaticClasses = new(() => LazyGetStaticClasses().ToList(), false);
            _Unions = new(() => LazyGetUnions().ToList(), false);
            _AllTypes = new(() => LazyGetAllTypes().ToList(), false);
        }

        /// <summary>
        /// Finds a decendant node with the given identifier, if any
        /// </summary>
        /// <param name="identifier">The identifier to search for</param>
        /// <returns>
        /// The node or <c>null</c> if a matching node was not found.
        /// </returns>
        public GirNode FindNodeByCIdentifier(string identifier)
        {
            var match = Element
                .Descendants()
                .Where(x => x.Attribute(c + "identifier").AsString() == identifier)
                .Concat(
                    Element
                        .Descendants(gi + "constant")
                        .Where(x => x.Attribute(c + "type").AsString() == identifier)
                )
                .SingleOrDefault();
            return GetNode(match);
        }

        IEnumerable<Alias> LazyGetAliases() =>
            Element.Elements(gi + "alias").Select(x => (Alias)GetNode(x));

        IEnumerable<Bitfield> LazyGetBitfields() =>
            Element.Elements(gi + "bitfield").Select(x => (Bitfield)GetNode(x));

        IEnumerable<Boxed> LazyGetBoxeds() =>
            Element.Elements(glib + "boxed").Select(x => (Boxed)GetNode(x));

        IEnumerable<Callback> LazyGetCallbacks() =>
            Element.Elements(gi + "callback").Select(x => (Callback)GetNode(x));

        IEnumerable<Class> LazyGetClasses() =>
            Element.Elements(gi + "class").Select(x => (Class)GetNode(x));

        IEnumerable<Enumeration> LazyGetEnumerations() =>
            Element.Elements(gi + "enumeration").Select(x => (Enumeration)GetNode(x));

        IEnumerable<Interface> LazyGetInterfaces() =>
            Element.Elements(gi + "interface").Select(x => (Interface)GetNode(x));

        IEnumerable<Record> LazyGetRecords() =>
            Element.Elements(gi + "record").Select(x => (Record)GetNode(x));

        IEnumerable<StaticClass> LazyGetStaticClasses() =>
            Element.Elements(gs + "static-class").Select(x => (StaticClass)GetNode(x));

        IEnumerable<Union> LazyGetUnions() =>
            Element.Elements(gi + "union").Select(x => (Union)GetNode(x));

        IEnumerable<GIBase> LazyGetAllTypes() =>
            Element
                .Elements()
                .Select(x => GetNode(x))
                .Where(x => x is GIRegisteredType || x is Callback)
                .Cast<GIBase>();
    }
}
