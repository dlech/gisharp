using System;

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
        public static Type[] SafeGetInterfaces (this Type type)
        {
            try {
                return type.GetInterfaces ();
            } catch (NotSupportedException) {
                if (type.IsGenericType) {
                    var genericType = type.GetGenericTypeDefinition ();
                    return genericType.GetInterfaces ();
                }
                throw;
            }
        }
    }
}
