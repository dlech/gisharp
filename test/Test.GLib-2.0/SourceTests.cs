// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2021 David Lechner <david@lechnology.com>

using System.Threading.Tasks;
using NUnit.Framework;
using GISharp.Lib.GLib;

namespace GISharp.Test.GLib
{
    public class SourceTests
    {
        [Test]
        public void TestCurrent()
        {
            lock (MainContextTests.MainContextLock)
            {
                // there is no main loop running, so there should be no current source
                Assert.That(Source.Current, Is.Null);

                // if we are in a callback, there should be a source.
                var callbackInvoked = false;
                Task.Run(() =>
                    {
                        using var context = new MainContext();
                        context.PushThreadDefault();
                        using var mainLoop = new MainLoop(context);
                        using var source = IdleSource.New();
                        source.SetCallback(() =>
                        {
                            try
                            {
                                Assert.That(
                                    Source.Current!.UnsafeHandle,
                                    Is.EqualTo(source.UnsafeHandle)
                                );
                                callbackInvoked = true;
                                return Source.Remove;
                            }
                            finally
                            {
                                mainLoop.Quit();
                            }
                        });
                        source.Attach(context);
                        mainLoop.Run();
                        context.PopThreadDefault();
                    })
                    .Wait(1000);
                Assert.That(callbackInvoked, Is.True);
            }
        }

        [Test]
        public void TestRemove()
        {
            lock (MainContextTests.MainContextLock)
            {
                var id = Idle.Add(() => Source.Remove);
                Assume.That(MainContext.Default.FindSourceById(id), Is.Not.Null);
                Source.RemoveById(id);
                Assert.That(MainContext.Default.FindSourceById(id), Is.Null);
            }
        }

        [Test]
        public void TestRemoveByUserData()
        {
            lock (MainContextTests.MainContextLock)
            {
                Idle.Add(() => Source.Remove, out var userData);
                Assume.That(MainContext.Default.FindSourceByUserData(userData), Is.Not.Null);
                Source.RemoveByUserData(userData);
                Assert.That(MainContext.Default.FindSourceByUserData(userData), Is.Null);
            }
        }

        static PollFD testPollFD = default;

        [Test]
        public void TestPollFD()
        {
            using var s = IdleSource.New();
            s.AddPoll(ref testPollFD);
            s.RemovePoll(ref testPollFD);
        }
    }
}
