using System;
using System.Reflection;
using System.Xml.Linq;

namespace GISharp.CodeGen.Reflection
{
    public sealed class GirParameterInfo : ParameterInfo
    {
        #pragma warning disable 0414 // ignore private field not used
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;
        #pragma warning restore 0414

        private readonly XElement element;

        public GirParameterInfo(XElement element)
        {
            this.element = element ?? throw new ArgumentNullException(nameof(element));
            if (element.Name != gi + "parameter") {
                throw new ArgumentException("Requires <gi:parameter> element", nameof(element));
            }
            Name = element.Attribute(gs + "managed-name").Value;
            var typeElement = element.Element(gi + "type") ?? element.Element(gi + "array");
            var typeName = typeElement.Attribute(gs + "managed-name").Value;
            _ParameterType = new Lazy<Type>(() => GirType.ResolveType(typeName, element.Document), false);
        }

        public override string Name { get; }

        public override Type ParameterType => _ParameterType.Value;
        readonly Lazy<Type> _ParameterType;
    }
}
