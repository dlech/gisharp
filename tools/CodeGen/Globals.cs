// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using Microsoft.Extensions.Logging;

namespace GISharp.CodeGen
{
    public static class Globals
    {
        /// <summary>
        /// The default namespace used in .gir xml files.
        /// </summary>
        public const string CoreNamespace = "http://www.gtk.org/introspection/core/1.0";

        /// <summary>
        /// The c: namespace used in .gir xml files.
        /// </summary>
        public const string CNamespace = "http://www.gtk.org/introspection/c/1.0";

        /// <summary>
        /// The glib: namespace used in .gir xml files.
        /// </summary>
        public const string GLibNamespace = "http://www.gtk.org/introspection/glib/1.0";

        /// <summary>
        /// The gs: namespace used to add additional metadata to .gir xml files.
        /// </summary>
        public const string GISharpNamespace = "http://gisharp.org/introspection/gisharp/1.0";

        public static bool EnableDebugLogging { get; set; }

        public static ILoggerFactory LoggerFactory => Microsoft.Extensions.Logging.LoggerFactory.Create(builder => {
            builder.AddFilter(level => EnableDebugLogging || level >= LogLevel.Information);
            builder.AddSimpleConsole(options => {
                options.SingleLine = true;
                options.TimestampFormat = "hh:mm:ss ";
            });
        });
    }
}
