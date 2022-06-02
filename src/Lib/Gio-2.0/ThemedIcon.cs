// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    unsafe partial class ThemedIcon
    {
        /// <summary>
        /// Creates a new themed icon for <paramref name="iconName"/>.
        /// </summary>
        /// <param name="iconName">
        /// a string containing an icon name.
        /// </param>
        /// <param name="useDefaultFallbacks">
        /// When <c>true</c>, creates a new themed icon for <paramref name="iconName"/>
        /// and all the names that can be created by shortening <paramref name="iconName"/>
        /// at <c>-</c> characters.
        /// </param>
        /// <returns>
        /// a new <see cref="ThemedIcon"/>.
        /// </returns>
        /// <remarks>
        /// </remarks>
        public ThemedIcon(UnownedUtf8 iconName, bool useDefaultFallbacks = false)
            : this(useDefaultFallbacks ? (IntPtr)NewWithDefaultFallbacks(iconName) : (IntPtr)New(iconName), Transfer.Full)
        {
        }

        /// <summary>
        /// Creates a new themed icon for <paramref name="iconName"/>.
        /// </summary>
        /// <param name="iconName">
        /// a string containing an icon name.
        /// </param>
        /// <param name="useDefaultFallbacks">
        /// When <c>true</c>, creates a new themed icon for <paramref name="iconName"/>
        /// and all the names that can be created by shortening <paramref name="iconName"/>
        /// at <c>-</c> characters.
        /// </param>
        /// <returns>
        /// a new <see cref="ThemedIcon"/>.
        /// </returns>
        /// <remarks>
        /// </remarks>
        public ThemedIcon(string iconName, bool useDefaultFallbacks = false)
            : this(useDefaultFallbacks ? (IntPtr)NewWithDefaultFallbacks(iconName) : (IntPtr)New(iconName), Transfer.Full)
        {
        }

        static UnmanagedStruct* NewFromNames(string[] iconNames!!)
        {
            if (iconNames.Length == 0) {
                throw new ArgumentException("Must have at least one name", nameof(iconNames));
            }
            using var iconnames = new Strv<Utf8>(iconNames);
            var iconnames_ = (byte**)iconnames.UnsafeHandle;
            var len_ = iconNames.Length;
            var ret_ = g_themed_icon_new_from_names(iconnames_, len_);
            GMarshal.PopUnhandledException();
            return ret_;
        }

        /// <summary>
        /// Creates a new themed icon for <paramref name="iconNames"/>.
        /// </summary>
        /// <param name="iconNames">
        /// an array of strings containing icon names.
        /// </param>
        public ThemedIcon(params string[] iconNames)
            : this((IntPtr)NewFromNames(iconNames), Transfer.Full)
        {
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return Icon.Equals(this, obj as IIcon);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Icon.GetHashCode(this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Icon.ToString(this)!;
        }
    }
}
