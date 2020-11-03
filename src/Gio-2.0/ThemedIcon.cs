
using System;
using GISharp.Lib.GLib;
using GISharp.Runtime;

namespace GISharp.Lib.Gio
{
    partial class ThemedIcon
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
            : this(useDefaultFallbacks ? NewWithDefaultFallbacks(iconName) : New(iconName), Transfer.Full)
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
            : this(useDefaultFallbacks ? NewWithDefaultFallbacks(iconName) : New(iconName), Transfer.Full)
        {
        }

        static IntPtr NewFromNames(string[] iconNames)
        {
            if (iconNames == null) {
                throw new ArgumentNullException(nameof(iconNames));
            }
            if (iconNames.Length == 0) {
                throw new ArgumentException("Must have at least one name", nameof(iconNames));
            }
            using var iconnames = new Strv(iconNames);
            ref readonly var iconnames_ = ref iconnames.GetPinnableReference();
            var len_ = iconNames.Length;
            var ret_ = g_themed_icon_new_from_names(iconnames_, len_);
            return ret_;
        }

        /// <summary>
        /// Creates a new themed icon for <paramref name="iconNames"/>.
        /// </summary>
        /// <param name="iconNames">
        /// an array of strings containing icon names.
        /// </param>
        public ThemedIcon(params string[] iconNames)
            : this(NewFromNames(iconNames), Transfer.Full)
        {
        }

        /// <inheritdoc />
        public bool Equals(IIcon other)
        {
            return Icon.Equals(this, other);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
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
