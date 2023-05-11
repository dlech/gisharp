// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System.Runtime.InteropServices;
using GISharp.Lib.GModule;
using NUnit.Framework;

namespace GISharp.Test.GModule
{
    public class ModuleTests
    {
        [Test]
        public void TestSupported()
        {
            Assert.That(Module.Supported, Is.True);
        }

        [Test]
        public void TestBuildPath()
        {
#pragma warning disable CS0618 // obsolete method
            using var path = Module.BuildPath(default, "test");
#pragma warning restore CS0618
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(path, Is.EqualTo("test.dll"));
            }
            else
            {
                Assert.That(path, Is.EqualTo("libtest.so"));
            }
        }

        [Test]
        public void TestOpen()
        {
            // TODO: find a module that we can actually open
            using var module = Module.Open("test");
            Assert.That(module, Is.Null);
            Assert.That<string>(Module.Error, Is.Not.Null.Or.Empty);
        }
    }
}
