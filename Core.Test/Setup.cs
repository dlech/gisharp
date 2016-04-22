using System;
using System.Runtime.InteropServices;

using NUnit.Framework;
using GISharp.Runtime;

namespace GISharp.Core.Test
{
    [SetUpFixture]
    public class Setup
    {
        delegate void LogFunc (IntPtr log_domain, uint log_level, IntPtr message, IntPtr user_data);

        [DllImport ("glib-2.0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_log_set_default_handler (
            LogFunc log_func,
            IntPtr user_data);

        static void Log (IntPtr logDomainPtr, uint log_level, IntPtr messagePtr, IntPtr user_data)
        {
            var logDomain = MarshalG.Utf8PtrToString (logDomainPtr);
            var message = MarshalG.Utf8PtrToString (messagePtr);
            Assert.Fail ($"({logDomain}) {log_level} {message}");
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
