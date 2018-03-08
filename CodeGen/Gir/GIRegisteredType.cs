using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GISharp.CodeGen.Gir
{
    public abstract class GIRegisteredType: GIBase
    {
        /// <summary>
        /// Gets the C type of this type
        /// </summary>
        public string CType { get; }

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
            : base (element, parent ?? throw new ArgumentNullException(nameof(parent)))
        {
            GTypeName = Element.Attribute(glib + "type-name").AsString();
            GTypeGetter = Element.Attribute (glib + "get-type").AsString();
            GTypeStruct = Element.Attribute (glib + "type-struct").AsString();
            _Constants = new Lazy<List<Constant>>(() => LazyGetConstants().ToList(), false);
            _Fields = new Lazy<List<Field>>(() => LazyGetFields().ToList(), false);
            _Properties = new Lazy<List<Property>>(() => LazyGetProperties().ToList(), false);
            _ManagedProperties = new Lazy<List<ManagedProperty>>(() => LazyGetManagedProperties().ToList(), false);
            _Signals = new Lazy<List<Signal>>(() => LazyGetSignals().ToList(), false);
            _Constructors = new Lazy<List<Constructor>>(() => LazyGetConstructors().ToList(), false);
            _Functions = new Lazy<List<Function>>(() => LazyGetFunctions().ToList(), false);
            _Methods = new Lazy<List<Method>>(() => LazyGetMethods().ToList(), false);
            _VirtualMethods = new Lazy<List<VirtualMethod>>(() => LazyGetVirtualMethods().ToList(), false);
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
