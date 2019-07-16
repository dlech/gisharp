using System;
using NUnit.Framework;
using GISharp.Lib.GObject;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class ClosureTests
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

            AssertNoGLibLog();
        }
    }
}
