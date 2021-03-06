// SPDX-License-Identifier: MIT
// ATTENTION: This file is automatically generated. Do not edit manually.
#nullable enable
namespace GISharp.Lib.GLib
{
    /// <include file="DBusHandle.xmldoc" path="declaration/member[@name='DBusHandle']/*" />
    public unsafe partial struct DBusHandle
    {
        private readonly int value;

        static partial void ValidateValue(int value);

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public DBusHandle(int value)
        {
            ValidateValue(value);
            this.value = value;
        }

        /// <summary>
        /// Converts to <see cref="DBusHandle"/> from the underlying type.
        /// </summary>
        public static explicit operator DBusHandle(int value)
        {
            return new DBusHandle(value);
        }

        /// <summary>
        /// Converts from <see cref="DBusHandle"/> to the underlying type.
        /// </summary>
        public static explicit operator int(DBusHandle value)
        {
            return value.value;
        }
    }
}