using NUnit.Framework;
using System;
using System.Threading.Tasks;

using GISharp.GLib;

namespace GISharp.GLib.Test
{
    [TestFixture ()]
    public class IdleTests
    {
        [Test ()]
        public void TestIdleAdd ()
        {
            var idleInvoked = false;

            Task.Run (() => {
                var mainLoop = new MainLoop ();
                Idle.Add (() => {
                    mainLoop.Quit ();
                    idleInvoked = true;
                    return Source.Remove;
                });
                mainLoop.Run ();
            }).Wait (100);

            Assert.That (idleInvoked, Is.True);
        }

        [Test ()]
        public void TestIdleAddNew ()
        {
            var source = Idle.SourceNew ();
            Assert.That (source, Is.Not.Null);
        }
    }
}
