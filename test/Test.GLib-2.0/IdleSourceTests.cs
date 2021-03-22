// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class IdleSourceTests
    {
        [Test]
        public void TestNew()
        {
            var idleInvoked = false;

            using var context = new MainContext();
            using var mainLoop = new MainLoop(context);
            using var source = IdleSource.New();
            source.SetCallback(() => {
                mainLoop.Quit();
                idleInvoked = true;
                return Source.Remove;
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
