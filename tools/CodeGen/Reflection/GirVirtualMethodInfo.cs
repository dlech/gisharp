
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;

namespace GISharp.CodeGen.Reflection
{
    sealed class GirVirtualMethodInfo : MethodInfo
    {
        VirtualMethod method;

        public GirVirtualMethodInfo(VirtualMethod method) {
            this.method = method ?? throw new ArgumentNullException(nameof(method));
        }

        public override System.Type ReturnType {
            get {
                if (method.ReturnValue.IsSkip) {
                    return typeof(void);
                }
                var type = method.ReturnValue.Type.ManagedType;
                if (type == typeof(Utf8) && method.ReturnValue.TransferOwnership == "none") {
                    type = method.ReturnValue.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                }
                return type;
            }
        }

        public override ParameterInfo ReturnParameter {
            get {
                return new GirParameterInfo(method.ReturnValue);
            }
        }

        public override ICustomAttributeProvider ReturnTypeCustomAttributes => throw new NotSupportedException();

        public override MethodAttributes Attributes => throw new NotSupportedException();

        public override RuntimeMethodHandle MethodHandle => throw new NotSupportedException();

        public override System.Type DeclaringType => method.ParentNode switch
        {
            Class @class => new GirClassType(@class),
            Interface @interface => new GirInterfaceType(@interface),
            Record record => new GirRecordType(record),
            _ => throw new NotSupportedException(),
        };

        public override string Name => method.ManagedName;

        public override System.Type ReflectedType => throw new NotSupportedException();

        public override MethodInfo GetBaseDefinition()
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotSupportedException();
        }

        public override object[] GetCustomAttributes(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }

        public override MethodImplAttributes GetMethodImplementationFlags()
        {
            throw new NotSupportedException();
        }
        public override ParameterInfo[] GetParameters()
        {
            return method.ManagedParameters
                .Select(x => new GirParameterInfo(x))
                .ToArray();
        }

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public override bool IsDefined(System.Type attributeType, bool inherit)
        {
            throw new NotSupportedException();
        }
    }
}
