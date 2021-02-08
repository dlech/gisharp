// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;

namespace GISharp.CodeGen.Reflection
{
    sealed class GirVirtualMethodInfo : MethodInfo
    {
        readonly VirtualMethod method;

        public GirVirtualMethodInfo(VirtualMethod method)
        {
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

        public override ICustomAttributeProvider ReturnTypeCustomAttributes =>
            throw new NotImplementedException("GirVirtualMethod.ReturnTypeCustomAttributes");

        public override MethodAttributes Attributes =>
            throw new NotImplementedException("GirVirtualMethod.Attributes");

        public override RuntimeMethodHandle MethodHandle =>
            throw new NotImplementedException("GirVirtualMethod.MethodHandle");

        public override System.Type DeclaringType => method.ParentNode switch {
            Class @class => new GirClassType(@class),
            Interface @interface => new GirInterfaceType(@interface),
            Record record => new GirRecordType(record),
            _ => throw new NotSupportedException($"DeclaringType of {method.ParentNode.Element.Name}"),
        };

        public override string Name => method.ManagedName;

        public override System.Type ReflectedType =>
            throw new NotImplementedException("GirVirtualMethod.ReflectedType");

        public override MethodInfo GetBaseDefinition()
        {
            throw new NotImplementedException("GirVirtualMethod.GetBaseDefinition");
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            throw new NotImplementedException("GirVirtualMethod.GetCustomAttributes");
        }

        public override object[] GetCustomAttributes(System.Type attributeType, bool inherit)
        {
            throw new NotImplementedException("GirVirtualMethod.GetCustomAttributes");
        }

        public override MethodImplAttributes GetMethodImplementationFlags()
        {
            throw new NotImplementedException("GirVirtualMethod.MethodImplAttributes");
        }
        public override ParameterInfo[] GetParameters()
        {
            return method.ManagedParameters
                .Select(x => new GirParameterInfo(x))
                .ToArray();
        }

        public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            throw new NotImplementedException("GirVirtualMethod.Invoke");
        }

        public override bool IsDefined(System.Type attributeType, bool inherit)
        {
            throw new NotImplementedException("GirVirtualMethod.IsDefined");
        }
    }
}
