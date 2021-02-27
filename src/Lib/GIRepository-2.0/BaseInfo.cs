// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GISharp.Lib.GIRepository
{
    unsafe partial class BaseInfo
    {
        /// <summary>
        /// Iterate over all attributes associated with this node.
        /// </summary>
        /// <remarks>
        /// Attributes are arbitrary namespaced key–value
        /// pairs which can be attached to almost any item. They are intended for use
        /// by software higher in the toolchain than bindings, and are distinct from
        /// normal GIR annotations.
        /// </remarks>
        public IEnumerable<KeyValuePair<string, string>> Attributes {
            get {
                var iter = default(AttributeIter);
                while (TryIterateAttributes(ref iter, out var key, out var value)) {
                    yield return new KeyValuePair<string, string>(key, value);
                }
            }
        }

        partial void CheckGetNameArgs()
        {
            // will crash in unmanaged code if we try to get name of TypeInfo
            if (this is TypeInfo) {
                throw new NotSupportedException("Cannot get name of TypeInfo");
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode() => UnsafeHandle.GetHashCode();

        /// <summary>
        /// Gets a managed proxy for a an unmanged BaseInfo.
        /// </summary>
        /// <param name="handle">
        /// The pointer to the unmanaged instance
        /// </param>
        /// <param name="ownership">
        /// Indicates if we already have a reference to the unmanged instance
        /// or not.
        /// </param>
        /// <returns>
        /// A managed proxy instance
        /// </returns>
        public static new T? GetInstance<T>(IntPtr handle, Runtime.Transfer ownership) where T : BaseInfo
        {
            if (handle == IntPtr.Zero) {
                return null;
            }

            Type type = typeof(BaseInfo);
            switch (g_base_info_get_type((UnmanagedStruct*)handle)) {
            case InfoType.Arg:
                type = typeof(ArgInfo);
                break;
            case InfoType.Boxed:
                // TODO: could be struct or union
                type = typeof(StructInfo);
                break;
            case InfoType.Callback:
                type = typeof(CallbackInfo);
                break;
            case InfoType.Constant:
                type = typeof(ConstantInfo);
                break;
            case InfoType.Enum:
            case InfoType.Flags:
                type = typeof(EnumInfo);
                break;
            case InfoType.Field:
                type = typeof(FieldInfo);
                break;
            case InfoType.Function:
                type = typeof(FunctionInfo);
                break;
            case InfoType.Interface:
                type = typeof(InterfaceInfo);
                break;
            case InfoType.Object:
                type = typeof(ObjectInfo);
                break;
            case InfoType.Property:
                type = typeof(PropertyInfo);
                break;
            case InfoType.Signal:
                type = typeof(SignalInfo);
                break;
            case InfoType.Struct:
                type = typeof(StructInfo);
                break;
            case InfoType.Type:
                type = typeof(TypeInfo);
                break;
            case InfoType.Union:
                type = typeof(UnionInfo);
                break;
            case InfoType.Unresolved:
                type = typeof(UnresolvedInfo);
                break;
            case InfoType.Value:
                type = typeof(ValueInfo);
                break;
            case InfoType.VFunc:
                type = typeof(VFuncInfo);
                break;
            }

            return (T?)Activator.CreateInstance(type, new object[] { handle, ownership });
        }

        [ModuleInitializer]
        internal static void RegisterTypeResolver()
        {
            RegisterFundamentalType<BaseInfo>(GetInstance<BaseInfo>);
        }
    }
}
