﻿using System;
using NUnit.Framework;
using GISharp.Lib.GLib;

using static GISharp.Lib.GLib.LogLevelFlags;
using NUnit.Framework.Internal;

namespace GISharp.Test
{
    [SetUpFixture]
    public class Setup
    {
        static void LogToTestContext(Utf8 logDomain, LogLevelFlags logLevel, Utf8 message)
        {
            // FIXME: messages on the GC finalizer thread are lost
            TestContext.Error.WriteLine(TestContext.CurrentContext?.Test?.FullName);
            TestContext.Error.WriteLine($"({logDomain}) {logLevel}: {message}");
            if (logLevel.HasFlag(LogLevelFlags.Error) || logLevel.HasFlag(Critical) || logLevel.HasFlag(Warning)) {
                TestContext.Error.WriteLine(Environment.StackTrace);
            }
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(logLevel.ToString(), message);
        }

        [OneTimeSetUp]
        public void SetUpGLibLogging()
        {
            Utility.ApplicationName = "GISharp.Test";
            Utility.ProgramName = "GISharp.Test";
            Log.SetDefaultHandler(LogToTestContext);
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
