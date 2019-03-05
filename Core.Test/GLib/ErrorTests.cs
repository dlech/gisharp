﻿using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void TestGType ()
        {
            var gtype = typeof (Error).GetGType ();
            Assert.That (gtype, Is.Not.EqualTo (GType.Invalid));
            Assert.That<string?>(gtype.Name, Is.EqualTo("GError"));

            AssertNoGLibLog();
        }
    }

    [GErrorDomain ("gisharp-core-test-error-domain-quark")]
    enum TestErrorDomain
    {
        Failed
    }

    static class TestErrorDomainExtensions
    {
        static Quark Quark {
            get {
                return TestErrorDomain.Failed.GetGErrorDomain();
            }
        }
    }
}
