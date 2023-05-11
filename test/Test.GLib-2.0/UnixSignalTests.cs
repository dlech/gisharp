// SPDX-License-Identifier: MIT
// Copyright (c) 2019-2020 David Lechner <david@lechnology.com>

using System.Threading.Tasks;
using GISharp.Lib.GLib;
using Mono.Unix.Native;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class UnixSignalTests
    {
        [Test]
        public void TestAdd()
        {
            // Idle.Add() can only attach sources to the global main context,
            // so we need to use a lock to ensure exclusive use of the main
            // context.
            lock (MainContextTests.MainContextLock)
            {
                Assert.That(() => UnixSignal.Add(0, () => Source.Remove), Throws.ArgumentException);

                var callbackInvoked = false;

                using (var mainLoop = new MainLoop())
                {
                    var id = UnixSignal.Add(
                        (int)Signum.SIGINT,
                        () =>
                        {
                            mainLoop.Quit();
                            callbackInvoked = true;
                            return Source.Remove;
                        }
                    );

                    Assert.That(id, Is.Not.Zero);
                    Syscall.kill(Syscall.getpid(), Signum.SIGINT);

                    var source = MainContext.Default.FindSourceById(id);
                    Task.Run(() =>
                        {
                            mainLoop.Run();
                        })
                        .Wait(100);
                    source.Destroy();
                }

                Assert.That(callbackInvoked, Is.True);
            }
        }
    }
}
