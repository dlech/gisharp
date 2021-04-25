// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System;
using System.Diagnostics.CodeAnalysis;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;
using NUnit.Framework.Internal;
using static GISharp.Lib.GLib.LogLevelFlags;

namespace GISharp.Test
{
    sealed class LogException : Exception
    {
        public LogException(string message) : base(message)
        {
        }
    }

    [ExcludeFromCodeCoverage]
    [SetUpFixture]
    public class Setup
    {
        static void HandleLog(NullableUnownedUtf8 logDomain, LogLevelFlags logLevel, NullableUnownedUtf8 message)
        {
            // FIXME: messages on the GC finalizer thread are lost
            TestContext.Error.WriteLine(TestContext.CurrentContext?.Test?.FullName);
            TestContext.Error.WriteLine($"({logDomain}) {logLevel}: {message}");
            if (logLevel.HasFlag(LogLevelFlags.Error) || logLevel.HasFlag(Critical) || logLevel.HasFlag(Warning)) {
                // this will trigger GISharp.Runtime.UnhandledException and should cause test to fail
                throw new LogException(message);
            }
        }

        [OneTimeSetUp]
        public void SetUpGLibLogging()
        {
            Utility.ApplicationName = "GISharp.Test";
            Utility.ProgramName = "GISharp.Test";
            Log.SetDefaultHandler(HandleLog);
        }

        [OneTimeSetUp]
        public void SetUpFormatters()
        {
            // Work around NUnit bug/feature.
            // NUnit tries to enumerate any IEnumerable for informational
            // purposes (NUnit.Framework.Constraints.MsgUtils), but Variant
            // will throw an exception if it is not a container. This causes
            // tests to fail unexpectedly. So, we add a value formatter for
            // Variant so that it does not try to use the built-in IEnumerable.
            TestContext.AddFormatter<Variant>(v => ((Variant)v).Print(true));
        }
    }
}
