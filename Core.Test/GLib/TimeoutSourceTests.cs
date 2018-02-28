using System.Threading.Tasks;
using GISharp.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test
{
    public class TimeoutSourceTests
    {
        [Test]
        public void TestNew()
        {
            var timeoutInvoked = false;

            using (var context = new MainContext())
            using (var mainLoop = new MainLoop(context))
            using (var source = new TimeoutSource(0)) {
                source.SetCallback(() => {
                    mainLoop.Quit();
                    timeoutInvoked = true;
                    return Source.Remove_;
                });

                source.Attach(context);
                Task.Run(() => {
                    context.PushThreadDefault();
                    mainLoop.Run();
                    context.PopThreadDefault();
                }).Wait(100);
                source.Destroy();

                Assert.That(timeoutInvoked, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNewSeconds()
        {
            var timeoutInvoked = false;

            using (var context = new MainContext())
            using (var mainLoop = new MainLoop(context))
            using (var source = TimeoutSource.Seconds(0)) {
                source.SetCallback(() => {
                    mainLoop.Quit();
                    timeoutInvoked = true;
                    return Source.Remove_;
                });

                source.Attach(context);
                Task.Run(() => {
                    context.PushThreadDefault();
                    mainLoop.Run();
                    context.PopThreadDefault();
                }).Wait(2000);
                source.Destroy();

                Assert.That(timeoutInvoked, Is.True);
            }
            AssertNoGLibLog();
        }
    }
}