﻿using System;

using NUnit.Framework;

using GISharp.GLib;

using static GISharp.GLib.LogLevelFlags;

// no namespace, so this applies to all tests in the assembly

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
        TestContext.CurrentContext.Test.Properties.Set(logLevel.ToString(), message);
    }

    [OneTimeSetUp]
    public void SetupAssembly ()
    {
        Utility.ApplicationName = "Core Test";
        Utility.ProgramName = "Core.Test";
        Log.SetDefaultHandler(LogToTestContext);
    }
}
