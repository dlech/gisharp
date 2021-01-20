// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

﻿using System;
using System.ComponentModel;
namespace GISharp.Lib.GLib
{
    /// <summary>
    /// Flags specifying the level of log messages.
    /// </summary>
    /// <remarks>
    /// It is possible to change how GLib treats messages of the various
    /// levels using <see cref="Log.SetHandler"/> and <see cref="Log.SetFatalMask"/>.
    /// </remarks>
    [Flags]
    public enum LogLevelFlags
    {
        /// <summary>
        /// internal flag
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Recursion = 1,

        /// <summary>
        /// internal flag
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Fatal = 2,

        /// <summary>
        /// log level for errors, see <see cref="Log.Error"/>
        /// </summary>
        Error = 4,

        /// <summary>
        /// log level for critical warning messages, see <see cref="Log.Critical"/>
        /// </summary>
        Critical = 8,

        /// <summary>
        /// log level for warnings, see <see cref="Log.Warning"/>
        /// </summary>
        Warning = 16,

        /// <summary>
        /// log level for messages, see <see cref="Log.Message"/>
        /// </summary>
        Message = 32,

        /// <summary>
        /// log level for informational messages, see <see cref="Log.Info"/>
        /// </summary>
        Info = 64,

        /// <summary>
        /// log level for debug messages, see <see cref="Log.Debug"/>
        /// </summary>
        Debug = 128,

        /// <summary>
        /// a mask including all log levels
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Mask = -4
    }
}
