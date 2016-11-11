
using GISharp.GLib;
using NUnit.Framework;

// no namespace, so this applies to all tests in the assembly

[SetUpFixture]
public class Setup
{
    static void FailOnLog (string logDomain, LogLevelFlags logLevel, string message)
    {
        Assert.Fail ($"({logDomain}) {logLevel}: {message}");
    }

    [SetUp]
    public void SetupAssembly ()
    {
        Utility.ApplicationName = "Core Test";
        Utility.ProgramName = "Core.Test";
        // this will cause any test that calls g_log in the test's thread
        // to fail. If g_log is called in another thread, then there will
        // probably be an unhandled exception.
        Log.SetDefaultHandler (FailOnLog);
    }
}
