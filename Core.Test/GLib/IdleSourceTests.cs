

using System.Threading.Tasks;
using GISharp.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class IdleSourceTests
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
            AssertNoGLibLog();
        }
    }
}
