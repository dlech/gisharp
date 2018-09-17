using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using GISharp.Lib.GModule;
using GISharp.Runtime;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace GISharp
{
    public static class TestHelpers
    {
        static readonly string critical = GISharp.Lib.GLib.LogLevelFlags.Critical.ToString();
        static readonly string warning = GISharp.Lib.GLib.LogLevelFlags.Warning.ToString();

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
            var properties = TestExecutionContext.CurrentContext.CurrentTest.Properties;

            if (properties.ContainsKey(critical)) {
                Assert.Fail("{0}", properties.Get(critical));
            }
            if (properties.ContainsKey(warning)) {
                Assert.Fail("{0}", properties.Get(warning));
            }
        }

        /// <summary>
        /// Use this instead of <see cref="NUnit.Framework.Throws.TypeOf{GISharp.Runtime.GErrorException}"/>
        /// to save a bunch of typing.
        /// </summary>
        /// <param name="code">
        /// The expected error code. The error domain will be inferred from the
        /// see <see cref="GISharp.Runtime.GErrorDomainAttribute"/> of the
        /// enum type.
        /// </param>
        public static Constraint ThrowsGErrorException(Enum code)
        {
            var domain = code.GetGErrorDomain();
            var value = Convert.ToInt32(code);
            return Throws.TypeOf<GErrorException>()
                .With.Property("Error").Property("Domain").EqualTo(domain)
                .And.Property("Error").Property("Code").EqualTo(value);
        }

        /// <summary>
        /// Run a test in a GLib main loop
        /// </summary>
        /// <param name="test">The async function</param>
        /// <param name="timout">A timeout in case <paramref name="test"/>
        /// never completes.</param>
        /// <remarks>
        /// This is used to test async methods. Using NUnit's async test feature
        /// doesn't work because GLib async functions generally need a GLib
        /// main loop runing to schedule the callback on the same thread.
        /// </remarks>
        public static void RunAsyncTest(System.Func<Task> test, uint timeout = 100)
        {
            using (var context = new MainContext())
            using (var loop = new MainLoop(context))
            using (var ts = new TimeoutSource(timeout)) {
                context.PushThreadDefault();
                try {
                    var task = test();
                    ts.SetCallback(() => {
                        task.Dispose();
                        loop.Quit();
                        return Source.Remove_;
                    });
                    task.ContinueWith(_ => loop.Quit());
                    loop.Run();
                }
                finally {
                    context.PopThreadDefault();
                }
            }
        }
    }
}
