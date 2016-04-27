using System;
using GISharp.Runtime;

namespace GISharp.GLib
{
    /// <summary>
    /// The range of possible top-level types of #GVariant instances.
    /// </summary>
    [Since ("2.24")]
    public enum VariantClass
    {
        /// <summary>
        /// The #GVariant is a boolean.
        /// </summary>
        Boolean = 98,
        /// <summary>
        /// The #GVariant is a byte.
        /// </summary>
        Byte = 121,
        /// <summary>
        /// The #GVariant is a signed 16 bit integer.
        /// </summary>
        Int16 = 110,
        /// <summary>
        /// The #GVariant is an unsigned 16 bit integer.
        /// </summary>
        Uint16 = 113,
        /// <summary>
        /// The #GVariant is a signed 32 bit integer.
        /// </summary>
        Int32 = 105,
        /// <summary>
        /// The #GVariant is an unsigned 32 bit integer.
        /// </summary>
        Uint32 = 117,
        /// <summary>
        /// The #GVariant is a signed 64 bit integer.
        /// </summary>
        Int64 = 120,
        /// <summary>
        /// The #GVariant is an unsigned 64 bit integer.
        /// </summary>
        Uint64 = 116,
        /// <summary>
        /// The #GVariant is a file handle index.
        /// </summary>
        Handle = 104,
        /// <summary>
        /// The #GVariant is a double precision floating
        ///                          point value.
        /// </summary>
        Double = 100,
        /// <summary>
        /// The #GVariant is a normal string.
        /// </summary>
        String = 115,
        /// <summary>
        /// The #GVariant is a D-Bus object path
        ///                               string.
        /// </summary>
        ObjectPath = 111,
        /// <summary>
        /// The #GVariant is a D-Bus signature string.
        /// </summary>
        Signature = 103,
        /// <summary>
        /// The #GVariant is a variant.
        /// </summary>
        Variant = 118,
        /// <summary>
        /// The #GVariant is a maybe-typed value.
        /// </summary>
        Maybe = 109,
        /// <summary>
        /// The #GVariant is an array.
        /// </summary>
        Array = 97,
        /// <summary>
        /// The #GVariant is a tuple.
        /// </summary>
        Tuple = 40,
        /// <summary>
        /// The #GVariant is a dictionary entry.
        /// </summary>
        DictEntry = 123
    }
}
