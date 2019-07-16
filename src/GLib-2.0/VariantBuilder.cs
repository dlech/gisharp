

using System;

namespace GISharp.Lib.GLib
{
    partial class VariantBuilder
    {
        static void AssertNewArgs(VariantType type)
        {
            if (type == null) {
                return;
            }
            if (!type.IsContainer) {
                const string message = "Must be a variant container type";
                throw new ArgumentException(message, nameof(type));
            }
        }
    }
}
