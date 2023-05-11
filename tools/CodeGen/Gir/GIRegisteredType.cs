// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIRegisteredType : GIBase
    {
        /// <summary>
        /// Gets the C type of this type
        /// </summary>
        public string CType { get; }

        /// <summary>
        /// Gets the C symbol prefix.
        /// </summary>
        public string CSymbolPrefix { get; }

        /// <summary>
        /// Gets the name of the GType, if any
        /// </summary>
        public string GTypeName { get; }

        /// <summary>
        /// Gets the C function name of the GType getter function
        /// </summary>
        public string GTypeGetter { get; }

        /// <summary>
        /// Gets the name of the GType class, if any
        /// </summary>
        public string GTypeStruct { get; }

        /// <summary>
        /// Gets if the default constructor should not be emtted so that a custom
        /// one can be used instead.
        /// </summary>
        public bool IsCustomDefaultConstructor { get; }

        /// <summary>
        /// Gets if the dispose method should not be emtted so that a custom
        /// one can be used instead.
        /// </summary>
        public bool IsCustomDispose { get; }

        /// <summary>
        /// Gets the GIR node for the GType struct, if any
        /// </summary>
        public Record GTypeStructNode => _GTypeStructNode.Value;
        readonly Lazy<Record> _GTypeStructNode;

        /// <summary>
        /// Gets the constants defined by this type
        /// </summary>
        public IEnumerable<Constant> Constants => _Constants.Value;
        readonly Lazy<List<Constant>> _Constants;

        /// <summary>
        /// Gets the fields defined by this type
        /// </summary>
        public IEnumerable<Field> Fields => _Fields.Value;
        readonly Lazy<List<Field>> _Fields;

        /// <summary>
        /// Gets the properties defined by this type
        /// </summary>
        public IEnumerable<Property> Properties => _Properties.Value;
        readonly Lazy<List<Property>> _Properties;

        /// <summary>
        /// Gets the managed (not GObject) properties defined by this type
        /// </summary>
        public IEnumerable<ManagedProperty> ManagedProperties => _ManagedProperties.Value;
        readonly Lazy<List<ManagedProperty>> _ManagedProperties;

        /// <summary>
        /// Gets the signals defined by this type
        /// </summary>
        public IEnumerable<Signal> Signals => _Signals.Value;
        readonly Lazy<List<Signal>> _Signals;

        /// <summary>
        /// Gets the constructors defined by this type
        /// </summary>
        public IEnumerable<Constructor> Constructors => _Constructors.Value;
        readonly Lazy<List<Constructor>> _Constructors;

        /// <summary>
        /// Gets the constructors defined by this type
        /// </summary>
        public IEnumerable<Function> Functions => _Functions.Value;
        readonly Lazy<List<Function>> _Functions;

        /// <summary>
        /// Gets the methods defined by this type
        /// </summary>
        public IEnumerable<Method> Methods => _Methods.Value;
        readonly Lazy<List<Method>> _Methods;

        /// <summary>
        /// Gets the virtual methods defined by this type
        /// </summary>
        public IEnumerable<VirtualMethod> VirtualMethods => _VirtualMethods.Value;
        readonly Lazy<List<VirtualMethod>> _VirtualMethods;

        private protected GIRegisteredType(XElement element, GirNode parent)
            : base(element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            CType = element.Attribute(c + "type").AsString();
            CSymbolPrefix = element.Attribute(c + "symbol-prefix").AsString();
            GTypeName = element.Attribute(glib + "type-name").AsString();
            GTypeGetter = element.Attribute(glib + "get-type").AsString();
            GTypeStruct = element.Attribute(glib + "type-struct").AsString();
            IsCustomDefaultConstructor = element
                .Attribute(gs + "custom-default-constructor")
                .AsBool();
            IsCustomDispose = element.Attribute(gs + "custom-dispose").AsBool();
            _GTypeStructNode = new(LazyGetGTypeStructNode, false);
            _Constants = new(() => LazyGetConstants().ToList(), false);
            _Fields = new(() => LazyGetFields().ToList(), false);
            _Properties = new(() => LazyGetProperties().ToList(), false);
            _ManagedProperties = new(() => LazyGetManagedProperties().ToList(), false);
            _Signals = new(() => LazyGetSignals().ToList(), false);
            _Constructors = new(() => LazyGetConstructors().ToList(), false);
            _Functions = new(() => LazyGetFunctions().ToList(), false);
            _Methods = new(() => LazyGetMethods().ToList(), false);
            _VirtualMethods = new(() => LazyGetVirtualMethods().ToList(), false);
        }

        Record LazyGetGTypeStructNode()
        {
            if (GTypeStruct is null)
            {
                return null;
            }
            return (Record)GetNode(
                Element.Parent
                    .Elements(gi + "record")
                    .Single(x => x.Attribute("name")?.Value == GTypeStruct)
            );
        }

        IEnumerable<Constant> LazyGetConstants() =>
            Element.Elements(gi + "constant").Select(x => (Constant)GetNode(x));

        IEnumerable<Field> LazyGetFields() =>
            Element.Elements(gi + "field").Select(x => (Field)GetNode(x));

        IEnumerable<Property> LazyGetProperties() =>
            Element.Elements(gi + "property").Select(x => (Property)GetNode(x));

        IEnumerable<ManagedProperty> LazyGetManagedProperties() =>
            Element.Elements(gs + "managed-property").Select(x => (ManagedProperty)GetNode(x));

        IEnumerable<Signal> LazyGetSignals() =>
            Element.Elements(glib + "signal").Select(x => (Signal)GetNode(x));

        IEnumerable<Constructor> LazyGetConstructors() =>
            Element.Elements(gi + "constructor").Select(x => (Constructor)GetNode(x));

        IEnumerable<Function> LazyGetFunctions() =>
            Element.Elements(gi + "function").Select(x => (Function)GetNode(x));

        IEnumerable<Method> LazyGetMethods() =>
            Element.Elements(gi + "method").Select(x => (Method)GetNode(x));

        IEnumerable<VirtualMethod> LazyGetVirtualMethods() =>
            Element.Elements(gi + "virtual-method").Select(x => (VirtualMethod)GetNode(x));
    }
}
