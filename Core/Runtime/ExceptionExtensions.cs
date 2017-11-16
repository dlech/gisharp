using System;
using System.Runtime.CompilerServices;

namespace GISharp.Runtime
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Print out an exception on stderr.
        /// <summary>
        /// <remarks>
        /// This is to be used in callbacks from unmanaged code. Unmanaged C
        /// code does not know about managed exceptions. So all exceptions in
        /// callbacks need to be caught and this function should be called.
        /// </remarks>
        public static void DumpUnhandledException (this Exception ex, [CallerMemberName]string caller = "")
        {
            try {
                var message = $"Unhandled exception in {caller}";
                Console.Error.WriteLine (message);
                Console.Error.WriteLine (ex);
            } catch {
                // This must absolutely not throw an exception
            }
        }
    }
}
