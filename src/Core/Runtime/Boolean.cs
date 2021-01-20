// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>


namespace GISharp.Runtime
{
    /// <summary>
    /// Managed wrapper for <c>gboolean</c> type.
    /// </summary>
    /// <remarks>
    /// The builtin <see cref="bool"/> .NET type is not blittable and therefor
    /// not usable with unmanaged functions directly. This is particularly
    /// a problem with unmanaged function pointer (<c>delegate* unmanaged[Cdecl] &lt;&gt;</c>)
    /// return values and also in unmanged structs and arrays where the size of boolean
    /// value is expected to be 4 bytes.
    /// </remarks>
    public enum Boolean : int
    {
        /// <summary>
        /// The <c>false</c> value for the <c>gboolean</c> type.
        /// </summary>
        False = 0,

        /// <summary>
        /// The <c>true</c> value for the <c>gboolean</c> type.
        /// </summary>
        True = 1,
    }

    /// <summary>
    /// Extension methods for <see cref="Boolean"/>.
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        /// Tests if an unmanaged boolean <paramref name="value"/> is true.
        /// </summary>
        /// <param name="value">
        /// The value to test.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="value"/> is non-zero, otherwise <c>false</c>.
        /// </returns>
        public static bool IsTrue(this Boolean value) => value != 0;

        /// <summary>
        /// Tests if an unmanaged boolean <paramref name="value"/> is false.
        /// </summary>
        /// <param name="value">
        /// The value to test.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="value"/> is zero, otherwise <c>false</c>.
        /// </returns>
        public static bool IsFalse(this Boolean value) => value == 0;

        /// <summary>
        /// Converts a managed <see cref="bool"/> <paramref name="value"/> to an
        /// unmanged <see cref="Boolean"/> value.
        /// </summary>
        /// <param name="value">
        /// The managaged value.
        /// </param>
        /// <returns>
        /// <see cref="Boolean.True"/> if <paramref name="value"/> is <c>true</c>,
        /// otherwise <see cref="Boolean.False"/>.
        /// </returns>
        public static Boolean ToBoolean(this bool value) => value ? Boolean.True : Boolean.False;
    }
}
