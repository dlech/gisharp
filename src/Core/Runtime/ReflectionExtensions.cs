// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

﻿using System;
using System.Linq;
using System.Reflection;

namespace GISharp.Runtime
{
    /// <summary>
    /// Extension methods for reflection.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Tries to get the matching PropertyInfo from the interface that is
        /// implemented by this property.
        /// </summary>
        /// <returns>
        /// The matching interface property info or <c>null</c> if this property
        /// does not implement an interface property.
        /// </returns>
        /// <param name="info">The PropertyInfo to check.</param>
        public static PropertyInfo? TryGetMatchingInterfacePropertyInfo(this PropertyInfo info)
        {
            var accessor = info.GetGetMethod() ?? info.GetSetMethod();
            var interfaceMapping = info.DeclaringType!.GetInterfaces()
                .Select(t => info.DeclaringType.GetInterfaceMap(t))
                .SingleOrDefault(m => m.TargetMethods.Contains(accessor));
            if (interfaceMapping.Equals(default(InterfaceMapping))) {
                return null;
            }

            MethodInfo match = interfaceMapping.InterfaceMethods
                .Select((m, i) => new Tuple<MethodInfo, MethodInfo>(m, interfaceMapping.TargetMethods[i]))
                .Single(t => t.Item2 == accessor).Item1;
            var propInfo = interfaceMapping.InterfaceType.GetProperties()
                .Single(p => p.GetAccessors().Contains(match));

            return propInfo;
        }

        /// <summary>
        /// Gets the unmanaged GType name of a property.
        /// </summary>
        /// <returns>
        /// The unmanaged GType name of the property or <c>null</c> if this
        /// property is not registered with the GType system.
        /// </returns>
        /// <param name="info">The property to inspect.</param>
        public static string? TryGetGPropertyName(this PropertyInfo info)
        {
            var propAttr = info.GetCustomAttribute<GPropertyAttribute>(true);
            if (propAttr is null) {
                propAttr = info.TryGetMatchingInterfacePropertyInfo()?
                    .GetCustomAttribute<GPropertyAttribute>();
            }
            return propAttr?.Name ?? info.Name;
        }
    }
}
