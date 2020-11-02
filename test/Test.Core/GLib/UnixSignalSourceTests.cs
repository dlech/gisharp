
using System.Threading.Tasks;
using GISharp.Lib.GLib;
using NUnit.Framework;
using Mono.Unix.Native;

namespace GISharp.Test.Core
{
    public class UnixSignalSourceTests : Tests
    {
        [Test]
        public void TestNew()
        {
            Assert.That(() => new UnixSignalSource(0), Throws.ArgumentException);

            var callbackInvoked = false;

            using (var context = new MainContext())
            using (var mainLoop = new MainLoop(context))
            using (var source = new UnixSignalSource((int)Signum.SIGINT)) {
                source.SetCallback(() => {
                    mainLoop.Quit();
                    callbackInvoked = true;
                    return Source.Remove_;
                });
                source.Attach(context);

                Syscall.kill(Syscall.getpid(), Signum.SIGINT);

                Task.Run(() => {
                    context.PushThreadDefault();
                    mainLoop.Run();
                    context.PopThreadDefault();
                }).Wait(100);

                Assert.That(callbackInvoked, Is.True);
            }
        }
    }
}
