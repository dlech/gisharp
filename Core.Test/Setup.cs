﻿using System;

using NUnit.Framework;

using GISharp.GLib;

// no namespace, so this applies to all tests in the assembly

[SetUpFixture]
public class Setup
{
    static void LogToTestContext (string logDomain, LogLevelFlags logLevel, string message)
    {
        try {
            TestContext.WriteLine($"({logDomain}) {logLevel}: {message}");
        } catch (Exception) {
            // we tried.
        }
    }

    [OneTimeSetUp]
    public void SetupAssembly ()
    {
        Utility.ApplicationName = "Core Test";
        Utility.ProgramName = "Core.Test";
        // Log.SetDefaultHandler (LogToTestContext);
    }
}
