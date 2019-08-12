﻿using System;
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Core.GLib
{
    [TestFixture]
    public class IdleTests
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
                    var (id, _) = Idle.Add(() => {
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
            AssertNoGLibLog();
        }
    }
}