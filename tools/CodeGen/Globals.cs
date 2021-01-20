// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Linq;
using GISharp.Runtime;

namespace GISharp.CodeGen
{
    public static class Globals
    {
        /// <summary>
        /// The default namespace used in .gir xml files.
        /// </summary>
        public const string CoreNamespace = "http://www.gtk.org/introspection/core/1.0";

        /// <summary>
        /// The c: namespace used in .gir xml files.
        /// </summary>
        public const string CNamespace = "http://www.gtk.org/introspection/c/1.0";

        /// <summary>
        /// The glib: namespace used in .gir xml files.
        /// </summary>
        public const string GLibNamespace = "http://www.gtk.org/introspection/glib/1.0";

        /// <summary>
        /// The gs: namespace used to add additional metadata to .gir xml files.
        /// </summary>
        public const string GISharpNamespace = "http://gisharp.org/introspection/gisharp/1.0";

        /// <summary>
        /// Gets the interfaces implemented by a type in a safe way.
        /// </summary>
        /// <returns>The list of interfaces.</returns>
        /// <param name="type">Type.</param>
        /// <remarks>
        /// This is needed because we use MakeGeneric to create generics that
        /// use GirType as a type parameter. If we do this, internallally
        /// the implementation throws a NotSupportedException when calling
        /// GetInterfaces. We get around this by getting the generic type
        /// that it was created from.
        /// </remarks>
        public static Type[] SafeGetInterfaces(this Type type)
        {
            try {
                return type.GetInterfaces();
            }
            catch (NotSupportedException) {
                if (type.IsGenericType) {
                    var genericType = type.GetGenericTypeDefinition();
                    return genericType.GetInterfaces();
                }
                throw;
            }
        }

        /// <summary>
        /// Because of the dynamic types used in CodeGen, we have to try really
        /// hard to determine inheritance.
        /// </summary>
        public static bool IsSubclassOf<T>(this Type type)
        {
            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }
            try {
                if (type.IsConstructedGenericType) {
                    return type.GetGenericTypeDefinition().IsSubclassOf<T>();
                }
                return type.IsSubclassOf(typeof(T));
            }
            catch (NotSupportedException) {
                return typeof(T).IsAssignableFrom(type);
            }
        }

        /// <summary>
        /// Tests if a type is a delegate type
        /// </summary>
        public static bool IsDelegate(this Type type)
        {
            return type.IsSubclassOf<Delegate>();
        }

        /// <summary>
        /// Tests if a type is an opaque type
        /// </summary>
        public static bool IsOpaque(this Type type)
        {
            return type.IsSubclassOf<Opaque>();
        }

        /// <summary>
        /// Tests if a type is a GInterface type
        /// </summary>
        public static bool IsGInterface(this Type type)
        {
            // if it is not an interface, then it is definitely not a GInterface
            if (!type.IsInterface) {
                return false;
            }

            // FIXME: this doesn't work because GirType does not implement CustomAttributes
            // GInterface will always have [GType] attribute
            // return type.CustomAttributes.OfType<GTypeAttribute>().Any();

            // for now, making the assumption that GInterface types are not generic
            // this is probably a safe assumption
            if (type.IsGenericType) {
                return false;
            }

            return true;
        }
    }
}
