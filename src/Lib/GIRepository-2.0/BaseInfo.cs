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

            Type type = (g_base_info_get_type((UnmanagedStruct*)handle)) switch {
                InfoType.Arg => typeof(ArgInfo),
                InfoType.Boxed => typeof(StructInfo),// TODO: could be struct or union
                InfoType.Callback => typeof(CallbackInfo),
                InfoType.Constant => typeof(ConstantInfo),
                InfoType.Enum or InfoType.Flags => typeof(EnumInfo),
                InfoType.Field => typeof(FieldInfo),
                InfoType.Function => typeof(FunctionInfo),
                InfoType.Interface => typeof(InterfaceInfo),
                InfoType.Object => typeof(ObjectInfo),
                InfoType.Property => typeof(PropertyInfo),
                InfoType.Signal => typeof(SignalInfo),
                InfoType.Struct => typeof(StructInfo),
                InfoType.Type => typeof(TypeInfo),
                InfoType.Union => typeof(UnionInfo),
                InfoType.Unresolved => typeof(UnresolvedInfo),
                InfoType.Value => typeof(ValueInfo),
                InfoType.VFunc => typeof(VFuncInfo),
                _ => typeof(BaseInfo),
            };

            return (T?)Activator.CreateInstance(type, handle, ownership);
        }

        [ModuleInitializer]
        internal static void RegisterTypeResolver()
        {
            RegisterTypeResolver<BaseInfo>(GetInstance<BaseInfo>);
        }
    }
}
