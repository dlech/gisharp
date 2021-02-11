// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2020 David Lechner <david@lechnology.com>

using System;
using NUnit.Framework;
using GISharp.Lib.GObject;

namespace GISharp.Test.Core.GObject
{
    public class ClosureTests : Tests
    {
        [Test]
        public void TestInvoke()
        {
            var callbackInvoked = false;

            Func<object[], object> callback = (arg) => {
                Assert.That(arg.Length, Is.EqualTo(2));
                Assert.That(arg[0], Is.EqualTo(1));
                Assert.That(arg[1], Is.EqualTo("string"));
                callbackInvoked = true;

                return true;
            };
            using (var closure = new Closure(callback)) {
                var ret = closure.Invoke<bool>(1, "string");

                Assert.That(callbackInvoked, Is.True);
                Assert.That(ret, Is.True);
            }
        }
    }
}
