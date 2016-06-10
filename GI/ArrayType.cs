// This file was originally generated by the Gtk# (gapi3) code generator.
// It is now maintained by hand.

namespace GISharp.GIRepository
{
    /// <summary>
    /// The type of array in a <see cref="TypeInfo"/>.
    /// </summary>
    public enum ArrayType
    {
        /// <summary>
        /// Not an array.
        /// </summary>
        None = -1,

        /// <summary>
        /// C array, char[] for instance.
        /// </summary>
        C,

        /// <summary>
        /// GArray array.
        /// </summary>
        Array,

        /// <summary>
        /// GPtrArray array.
        /// </summary>
        PtrArray,

        /// <summary>
        /// GByteArray array.
        /// </summary>
        ByteArray,
    }
}
