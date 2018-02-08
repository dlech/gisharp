using System;
using System.Runtime.InteropServices;
using GISharp.GModule;
using NUnit.Framework;

namespace GISharp
{
    public static class TestHelpers
    {
        static readonly string critical = GISharp.GLib.LogLevelFlags.Critical.ToString();
        static readonly string warning = GISharp.GLib.LogLevelFlags.Warning.ToString();

        /// <summary>
        /// Throws an IgnoreException if <paramref name="actual"/> version is
        /// less than <paramref name="required"/> version.
        /// </summary>
        /// <param name="actual">
        /// The actual runtime version
        /// </param>
        /// <param name="actual">
        /// The minimum required version
        /// </param>
        /// <exception cref="NUnit.Framework.IgnoreException">
        /// Thrown when the version requirement is not met
        /// </exception>
        public static void AssertIgnoreWhenVersionIsLessThan(string actual, string required)
        {
            var requiredVersion = new Version(required);
            var actualVersion = new Version(actual);
            if (actualVersion < requiredVersion) {
                throw new IgnoreException($"Skipping test since glib-2.0 v{actual} < v{required}");
            }
        }

        /// <summary>
        /// Fails a test if there was a critical or warning message logged via
        /// the GLib log infrastructure.
        /// </summary>
        /// <exception cref="NUnit.Framework.AssertionException">
        /// Thrown when a critical or warning message was logged
        /// </exception>
        public static void AssertNoGLibLog()
        {
            var properties = TestContext.CurrentContext.Test.Properties;

            if (properties.ContainsKey(critical)) {
                Assert.Fail("{0}", properties.Get(critical));
            }
            if (properties.ContainsKey(warning)) {
                Assert.Fail("{0}", properties.Get(warning));
            }
        }
    }
}
