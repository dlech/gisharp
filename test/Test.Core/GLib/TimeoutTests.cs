using System;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class TimeoutTests
    {
        [Test]
        public void TestAdd()
        {
            // Timeout.Add() can only attach sources to the global main context,
            // so we need lock to ensure we have exclusive use.
            lock (MainContextTests.MainContextLock) {
                var timeoutInvoked = false;
                using var mainLoop = new MainLoop();

                var (id, _) = Timeout.Add(0, () => {
                    mainLoop.Quit();
                    timeoutInvoked = true;
                    return Source.Remove_;
                });

                Assert.That(id, Is.Not.Zero);

                using var source = MainContext.Default.FindSourceById(id);
                Task.Run(() => {
                    mainLoop.Run();
                }).Wait(100);
                source.Destroy();

                Assert.That(timeoutInvoked, Is.True);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestAddSeconds()
        {
            // Timeout.AddSeconds() can only attach sources to the global main
            // context, so we need lock to ensure we have exclusive use.
            lock (MainContextTests.MainContextLock) {
                var timeoutInvoked = false;
                using var mainLoop = new MainLoop();

                var (id, _) = Timeout.AddSeconds(0, () => {
                    mainLoop.Quit();
                    timeoutInvoked = true;
                    return Source.Remove_;
                });

                Assert.That(id, Is.Not.EqualTo(0));

                using var source = MainContext.Default.FindSourceById(id);
                Task.Run(() => {
                    mainLoop.Run();
                }).Wait(2000);
                source.Destroy();

                Assert.That(timeoutInvoked, Is.True);
            }

            AssertNoGLibLog();
        }
    }
}
