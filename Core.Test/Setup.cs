﻿using System;

using NUnit.Framework;

using GISharp.GLib;

// no namespace, so this applies to all tests in the assembly

[SetUpFixture]
public class Setup
{
    static void LogToTestContext (string logDomain, LogLevelFlags logLevel, string message)
    {
        TestContext.Error.WriteLine(TestContext.CurrentContext?.Test?.FullName);
        TestContext.Error.WriteLine($"({logDomain}) {logLevel}: {message}");
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
