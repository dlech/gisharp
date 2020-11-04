

using System;

namespace GISharp.Lib.GLib
{
    partial class VariantDict
    {
        /// <summary>
        /// Allocates and initialize a new <see cref="VariantDict"/>.
        /// </summary>
        public VariantDict() : this(null)
        {
        }

        static partial void CheckNewArgs(Variant? fromAsv)
        {
            if (fromAsv == null) {
                return;
            }
            if (!fromAsv.IsOfType(VariantType.VariantDictionary)) {
                const string message = "Must be a variant dictionary, i.e. a{sv}";
                throw new ArgumentException(message, nameof(fromAsv));
            }
        }
    }
}
