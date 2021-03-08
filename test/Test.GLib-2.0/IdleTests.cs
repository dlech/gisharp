// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class IdleTests : Tests
    {
        [Test]
        public void TestAdd()
        {
            // Idle.Add() can only attach sources to the global main context,
            // so we need to use a lock to ensure exclusive use of the main
            // context.
            lock (MainContextTests.MainContextLock) {
                var idleInvoked = false;

                using (var mainLoop = new MainLoop()) {
                    var id = Idle.Add(() => {
                        mainLoop.Quit();
                        idleInvoked = true;
                        return Source.Remove_;
                    });

                    Assert.That(id, Is.Not.Zero);

                    var source = MainContext.Default.FindSourceById(id);
                    Task.Run(() => {
                        mainLoop.Run();
                    }).Wait(100);
                    source.Destroy();
                }

                Assert.That(idleInvoked, Is.True);
            }
        }

        [Test]
        public void TestRemoveByUserData()
        {
            lock (MainContextTests.MainContextLock) {
                Idle.Add(() => Source.Remove_, out var data);
                Assume.That(MainContext.Default.FindSourceByUserData(data), Is.Not.Null);
                Assert.That(Idle.RemoveByData(data), Is.True);
                Assert.That(MainContext.Default.FindSourceByUserData(data), Is.Null);
            }
        }
    }
}
