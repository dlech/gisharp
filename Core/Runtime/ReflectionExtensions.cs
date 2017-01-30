using System;
using System.Linq;
using System.Reflection;

namespace GISharp.Runtime
{
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
        public static PropertyInfo TryGetMatchingInterfacePropertyInfo (this PropertyInfo info)
        {
            if (info == null) {
                throw new ArgumentNullException (nameof (info));
            }
            var accessor = info.GetAccessors ().First ();
            var interfaceMapping = info.DeclaringType.GetTypeInfo ().GetInterfaces ()
                .Select (t => info.DeclaringType.GetInterfaceMap (t))
                .SingleOrDefault (m => m.TargetMethods.Contains (accessor));
            if (interfaceMapping.Equals (default(InterfaceMapping))) {
                return null;
            }

            MethodInfo match = interfaceMapping.InterfaceMethods
                .Select ((m, i) => new Tuple<MethodInfo, MethodInfo> (m, interfaceMapping.TargetMethods[i]))
                .Single (t => t.Item2 == accessor).Item1;
            var propInfo = interfaceMapping.InterfaceType.GetTypeInfo ().GetProperties ()
                .Single (p => p.GetAccessors ().Contains (match));

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
        public static string TryGetGTypePropertyName (this PropertyInfo info)
        {
            if (info == null) {
                throw new ArgumentNullException (nameof (info));
            }
            var propAttr = info.GetCustomAttribute<PropertyAttribute> (true);
            if (propAttr == null) {
                propAttr = info.TryGetMatchingInterfacePropertyInfo ()
                    ?.GetCustomAttribute<PropertyAttribute> ();
            }
            return propAttr?.Name ?? info.Name;
        }

        public static InterfaceMapping GetInterfaceMap (this Type type, Type ifaceType)
        {
            if (type == null) {
                throw new ArgumentNullException (nameof (type));
            }
            if (type.IsGenericParameter) {
                throw new InvalidOperationException ("type cannot be a generic parameter");
            }
            if (ifaceType == null) {
                throw new ArgumentNullException (nameof (ifaceType));
            }
            var ifaceTypeInfo = ifaceType.GetTypeInfo ();
            if (!ifaceTypeInfo.IsInterface) {
                throw new ArgumentException ("Type is not an interface", nameof (ifaceType));
            }

            throw new NotImplementedException ();
            // FIXME!
        }
    }
}
