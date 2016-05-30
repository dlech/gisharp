using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.Runtime;

namespace GISharp.Core.Test
{
    [SetUpFixture]
    public class Setup
    {
        [Flags]
        enum LogLevelFlags
        {
            Recursion   = 1,
            Fatal       = 2,
            Error       = 4,
            Critical    = 8,
            Warning     = 16,
            Message     = 32,
            Info        = 64,
            Debug       = 128,
        }

        delegate void LogFunc (IntPtr logDomainPtr, LogLevelFlags logLevel,
                               IntPtr messagePtr, IntPtr userDataPtr);

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_log_set_default_handler (LogFunc logFunc, IntPtr userDataPtr);

        static void Log (IntPtr logDomainPtr, LogLevelFlags logLevel,
                         IntPtr messagePtr, IntPtr userDataPtr)
        {
            var logDomain = MarshalG.Utf8PtrToString (logDomainPtr);
            var message = MarshalG.Utf8PtrToString (messagePtr);
            Assert.Fail ($"({logDomain}) {logLevel}: {message}");
        }

        [SetUp]
        public void SetupLogger ()
        {
            // this will cause any test that calls g_log in the test's thread
            // to fail. If g_log is called in another thread, then there will
            // probably be an unhandled exception.
            g_log_set_default_handler (Log, IntPtr.Zero);
        }
    }
}
