using System;
using NUnit.Framework;
using GISharp.GObject;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class ClosureTest
    {
        [Test]
        public void TestInvoke ()
        {
            var callbackInvoked = false;

            Func<Value[], Value> callback = (arg) => {
                Assert.That (arg.Length, Is.EqualTo (2));
                Assert.That ((int)arg[0], Is.EqualTo (1));
                Assert.That ((string)arg[1], Is.EqualTo ("string"));
                callbackInvoked = true;

                return (Value)true;
            };
            var closure = new Closure (callback);
            var ret = closure.Invoke ((Value)1, (Value)"string");

            Assert.That (callbackInvoked, Is.True);
            Assert.That ((bool)ret, Is.True);
        }
    }
}
