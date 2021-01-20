// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2019 David Lechner <david@lechnology.com>

﻿using GISharp.Runtime;

namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Return values from <see cref="LogWriterFunc"/>s to indicate whether the given log entry
    /// was successfully handled by the writer, or whether there was an error in
    /// handling it (and hence a fallback writer should be used).
    /// </summary>
    /// <remarks>
    /// If a <see cref="LogWriterFunc"/> ignores a log entry, it should return
    /// <see cref="Handled"/>.
    /// </remarks>
    [Since ("2.50")]
    public enum LogWriterOutput
    {
        /// <summary>
        /// Log writer has handled the log entry.
        /// </summary>
        Handled = 1,
        /// <summary>
        /// Log writer could not handle the log entry.
        /// </summary>
        Unhandled = 0
    }
}
