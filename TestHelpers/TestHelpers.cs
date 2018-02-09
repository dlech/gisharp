﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GISharp.GLib;
using GISharp.GModule;
using GISharp.Runtime;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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

        sealed class Utf8EqualConstraint : EqualConstraint
        {
            public Utf8EqualConstraint(Utf8 expected) : base((string)expected)
            {
            }

            public override ConstraintResult ApplyTo<TActual>(TActual actual)
            {
                if (actual is Utf8 utf8) {
                    return base.ApplyTo<string>(utf8);
                }
                return base.ApplyTo<TActual>(actual);
            }
        }

        /// <summary>
        /// Use this instead of <see cref="NUnit.Framework.Is.EqualTo(object)"/>
        /// when comparing <see cref="GISharp.GLib.Utf8"/> strings in order to
        /// get a useful failure message.
        /// </summary>
        public static Constraint IsEqualToUtf8(Utf8 utf8)
        {
            return new Utf8EqualConstraint(utf8);
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
    }
}