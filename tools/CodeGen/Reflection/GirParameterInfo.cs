using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GISharp.CodeGen.Gir;
using GISharp.Lib.GLib;

namespace GISharp.CodeGen.Reflection
{
    sealed class GirParameterInfo : ParameterInfo
    {
        GIArg arg;

        public GirParameterInfo(GIArg arg)
        {
            this.arg = arg ?? throw new ArgumentNullException(nameof(arg));
        }

        public override string Name => arg.ManagedName;

        public override System.Type ParameterType {
            get {
                if (arg.IsSkip) {
                    return typeof(void);
                }

                var type = arg.Type.ManagedType;
                if (type == typeof(Utf8) && arg.TransferOwnership == "none") {
                    type = arg.IsNullable ? typeof(NullableUnownedUtf8) : typeof(UnownedUtf8);
                }
                return type;
            }
        }

        public override MemberInfo Member {
            get {
                // if arg is a return value, ParentNode is the callable, otherwise
                // ParentNode.ParentNode is the callable (for regular parameters)
                var declaringInfo = arg.ParentNode is GICallable ? arg.ParentNode : arg.ParentNode.ParentNode;
                switch (declaringInfo) {
                case VirtualMethod vfunc:
                    return new GirVirtualMethodInfo(vfunc);
                default:
                    throw new NotSupportedException($"Unsupported type: {declaringInfo}");
                };
            }
        }

        public override object[] GetCustomAttributes(System.Type type, bool inherit)
        {
            if (type != typeof(Attribute)) {
                throw new NotSupportedException();
            }
            return GetCustomAttributes().ToArray();
        }

        IEnumerable<Attribute> GetCustomAttributes()
        {
            if (arg.Direction == "out") {
                yield return new System.Runtime.InteropServices.OutAttribute();
            }
            if (arg.IsNullable) {
                yield return NullableAttribute;
            }
        }

        static Attribute NullableAttribute;

        static GirParameterInfo()
        {
            var method = typeof(GirParameterInfo)
                .GetMethod(nameof(Dummy), BindingFlags.NonPublic | BindingFlags.Static);
            var param = method.GetParameters().First();
            NullableAttribute = param.GetCustomAttributes()
                .Single(x => x.GetType().FullName == "System.Runtime.CompilerServices.NullableAttribute");
        }

#nullable enable
        // dummy method for getting System.Runtime.CompilerServices.NullableAttribute
        static void Dummy(string? str) {
        }
#nullable restore
    }
}
