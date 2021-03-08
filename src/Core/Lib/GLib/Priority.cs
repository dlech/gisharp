// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Commonly used priority values.
    /// </summary>
    public static class Priority
    {
        /// <summary>
        /// Use this for default priority event sources.
        /// </summary>
        /// <remarks>
        /// In GLib this priority is used when adding timeout functions
        /// with <see cref="M:Timeout.Add"/>. In GDK this priority is used for events
        /// from the X server.
        /// </remarks>
        public const int Default = 0;

        /// <summary>
        /// Use this for default priority idle functions.
        /// </summary>
        /// <remarks>
        /// In GLib this priority is used when adding idle functions with
        /// <see cref="M:Idle.Add"/>.
        /// </remarks>
        public const int DefaultIdle = 200;

        /// <summary>
        /// Use this for high priority event sources.
        /// </summary>
        /// <remarks>
        /// It is not used within GLib or GTK+.
        /// </remarks>
        public const int High = -100;

        /// <summary>
        /// Use this for high priority idle functions.
        /// </summary>
        /// <remarks>
        /// GTK+ uses <see cref="HighIdle"/> + 10 for resizing operations,
        /// and <see cref="HighIdle"/> + 20 for redrawing operations. (This is
        /// done to ensure that any pending resizes are processed before any
        /// pending redraws, so that widgets are not redrawn twice unnecessarily.)
        /// </remarks>
        public const int HighIdle = 100;

        /// <summary>
        /// Use this for very low priority background tasks.
        /// </summary>
        /// <remarks>
        /// It is not used within GLib or GTK+.
        /// </remarks>
        public const int Low = 300;
    }
}
