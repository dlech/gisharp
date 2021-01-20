// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2020 David Lechner <david@lechnology.com>



using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.Core
{
    public class IdleSourceTests : Tests
    {
        [Test]
        public void TestNew()
        {
            var idleInvoked = false;

            using (var context = new MainContext())
            using (var mainLoop = new MainLoop(context))
            using (var source = new IdleSource()) {
                source.SetCallback(() => {
                    mainLoop.Quit();
                    idleInvoked = true;
                    return Source.Remove_;
                });
                source.Attach(context);

                Task.Run(() => {
                    context.PushThreadDefault();
                    mainLoop.Run();
                    context.PopThreadDefault();
                }).Wait(100);

                Assert.That(idleInvoked, Is.True);
            }
        }
    }
}
