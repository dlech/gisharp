// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2020 David Lechner <david@lechnology.com>

using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class TimeoutTests : Tests
    {
        [Test]
        public void TestAdd()
        {
            // Timeout.Add() can only attach sources to the global main context,
            // so we need lock to ensure we have exclusive use.
            lock (MainContextTests.MainContextLock) {
                var timeoutInvoked = false;
                using var mainLoop = new MainLoop();

                var id = Timeout.Add(0, () => {
                    mainLoop.Quit();
                    timeoutInvoked = true;
                    return Source.Remove;
                });

                Assert.That(id, Is.Not.Zero);

                using var source = MainContext.Default.FindSourceById(id);
                Task.Run(() => {
                    mainLoop.Run();
                }).Wait(100);
                source.Destroy();

                Assert.That(timeoutInvoked, Is.True);
            }
        }

        [Test]
        public void TestAddSeconds()
        {
            // Timeout.AddSeconds() can only attach sources to the global main
            // context, so we need lock to ensure we have exclusive use.
            lock (MainContextTests.MainContextLock) {
                var timeoutInvoked = false;
                using var mainLoop = new MainLoop();

                var id = Timeout.AddSeconds(0, () => {
                    mainLoop.Quit();
                    timeoutInvoked = true;
                    return Source.Remove;
                });

                Assert.That(id, Is.Not.EqualTo(0));

                using var source = MainContext.Default.FindSourceById(id);
                Task.Run(() => {
                    mainLoop.Run();
                }).Wait(2000);
                source.Destroy();

                Assert.That(timeoutInvoked, Is.True);
            }
        }
    }
}
