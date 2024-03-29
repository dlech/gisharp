// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using GISharp.Runtime;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace GISharp
{
    [ExcludeFromCodeCoverage]
    public static class TestHelpers
    {
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
        /// <exception cref="IgnoreException">
        /// Thrown when the version requirement is not met
        /// </exception>
        public static void AssertIgnoreWhenVersionIsLessThan(string actual, string required)
        {
            var requiredVersion = new System.Version(required);
            var actualVersion = new System.Version(actual);
            if (actualVersion < requiredVersion)
            {
                throw new IgnoreException($"Skipping test since glib-2.0 v{actual} < v{required}");
            }
        }

        /// <summary>
        /// Use this instead of <see cref="Throws.TypeOf{T}"/> of <see cref="Error.Exception"/>
        /// to save a bunch of typing.
        /// </summary>
        /// <param name="code">
        /// The expected error code. The error domain will be inferred from the
        /// see <see cref="GErrorDomainAttribute"/> of the
        /// enum type.
        /// </param>
        public static Constraint ThrowsGErrorException(Enum code)
        {
            var domain = code.GetGErrorDomain();
            var value = Convert.ToInt32(code);
            return Throws
                .TypeOf<Error.Exception>()
                .With.Property("Error")
                .Property("Domain")
                .EqualTo(domain)
                .And.Property("Error")
                .Property("Code")
                .EqualTo(value);
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
            using var context = new MainContext();
            using var loop = new MainLoop(context);
            using var ts = TimeoutSource.New(timeout);
            context.PushThreadDefault();
            try
            {
                var task = test();
                ts.SetCallback(() =>
                {
                    task.Dispose();
                    loop.Quit();
                    return Source.Remove;
                });
                task.ContinueWith(_ => loop.Quit());
                loop.Run();
            }
            finally
            {
                context.PopThreadDefault();
            }
        }
    }
}
