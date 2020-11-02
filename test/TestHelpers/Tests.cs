
using System;
using System.Diagnostics.CodeAnalysis;
using GISharp.Lib.GLib;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GISharp.Test
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public abstract class Tests
    {
        static readonly string critical = LogLevelFlags.Critical.ToString();
        static readonly string warning = LogLevelFlags.Warning.ToString();

        /// <summary>
        /// Fails a test if there was a critical or warning message logged via
        /// the GLib log infrastructure.
        /// </summary>
        /// <exception cref="AssertionException">
        /// Thrown when a critical or warning message was logged
        /// </exception>
        [TearDown]
        public static void AssertNoGLibLog()
        {
            var properties = TestExecutionContext.CurrentContext.CurrentTest.Properties;

            if (properties.ContainsKey(critical)) {
                Assert.Fail("Logged critical: {0}", properties.Get(critical));
            }
            if (properties.ContainsKey(warning)) {
                Assert.Fail("Logged warning: {0}", properties.Get(warning));
            }
        }
    }
}
