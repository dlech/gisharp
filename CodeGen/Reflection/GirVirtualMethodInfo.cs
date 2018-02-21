
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace GISharp.CodeGen.Reflection
{
    public sealed class GirVirtualMethodInfo : MethodInfo
    {
        #pragma warning disable 0414 // ignore private field not used
        static readonly XNamespace gi = Globals.CoreNamespace;
        static readonly XNamespace c = Globals.CNamespace;
        static readonly XNamespace glib = Globals.GLibNamespace;
        static readonly XNamespace gs = Globals.GISharpNamespace;
        #pragma warning restore 0414

        XElement element;

        public GirVirtualMethodInfo(XElement element) {
            if (element == null) {
                throw new ArgumentNullException(nameof(element));
            }
            if (element.Name != gi + "virtual-method") {
                throw new ArgumentException("Expecting <virtual-method> element", nameof(element));
            }
            this.element = element;

            Name = element.Attribute(gs + "managed-name").Value;
            _ReturnType = new Lazy<Type>(LazyGetReturnType);
        }

        public override Type ReturnType => _ReturnType.Value;
        readonly Lazy<Type> _ReturnType;

        Type LazyGetReturnType()
        {
            var returnTypeElement = element.Element(gi + "return-value");
            return GirType.ResolveType(returnTypeElement.Attribute(gs + "managed-type").Value,
                element.Document);
        }

        public override ICustomAttributeProvider ReturnTypeCustomAttributes => throw new NotSupportedException();

        public override MethodAttributes Attributes => throw new NotSupportedException();

        public override RuntimeMethodHandle MethodHandle => throw new NotSupportedException();

        public override Type DeclaringType => throw new NotSupportedException();

        public override string Name { get; }

        public override Type ReflectedType => throw new NotSupportedException();

        public override MethodInfo GetBaseDefinition()
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override MethodImplAttributes GetMethodImplementationFlags()
        {
            throw new NotSupportedException();
        }

        public override ParameterInfo[] GetParameters()
        {
            return element.Element(gs + "managed-parameters")
                .Elements(gi + "parameter")
                .Select(x => new GirParameterInfo(x))
                .ToArray();
        }

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override bool IsDefined(Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }
    }
}
