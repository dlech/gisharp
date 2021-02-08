// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2019,2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GISharp.CodeGen.Gir;
using GISharp.CodeGen.Syntax;
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
                return declaringInfo switch {
                    VirtualMethod vfunc => new GirVirtualMethodInfo(vfunc),
                    _ => throw new NotSupportedException($"Unsupported type: {declaringInfo}"),
                };
            }
        }

        public override object[] GetCustomAttributes(System.Type type, bool inherit)
        {
            if (type != typeof(Attribute)) {
                throw new ArgumentException("type must be Attribute", nameof(type));
            }
            return GetCustomAttributes().ToArray();
        }

        IEnumerable<Attribute> GetCustomAttributes()
        {
            if (arg.Direction == "out" && !arg.IsCallerAllocatesBuffer()) {
                yield return new System.Runtime.InteropServices.OutAttribute();
            }
            if (arg.IsNullable) {
                yield return NullableAttribute;
            }
        }

        static readonly Attribute NullableAttribute;

        static GirParameterInfo()
        {
            var nullable = System.Type.GetType("System.Runtime.CompilerServices.NullableAttribute");
            NullableAttribute = (Attribute)Activator.CreateInstance(nullable, (byte)2);
        }
    }
}
