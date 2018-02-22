using GISharp.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Gio.Test
{
    [TestFixture]
    public class SimpleActionTests
    {
        [Test]
        public void TestNew()
        {
            Assert.That(() => new SimpleAction(null, null),
                Throws.ArgumentNullException);

            using (var sa = new SimpleAction("test-action", null)) {
                Assert.That(sa.Name, IsEqualToUtf8("test-action"));
                Assert.That(sa.ParameterType, Is.Null);
                Assert.That(sa.State, Is.Null);
                Assert.That(sa.StateType, Is.Null);
            }

            using (var sa = new SimpleAction("test-action", VariantType.Boolean)) {
                Assert.That(sa.Name, IsEqualToUtf8("test-action"));
                Assert.That(sa.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That(sa.State, Is.Null);
                Assert.That(sa.StateType, Is.Null);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestNewStateful()
        {
            Assert.That(() => new SimpleAction(null, VariantType.Boolean, (Variant)0),
                Throws.ArgumentNullException);

            Assert.That(() => new SimpleAction("test-action", VariantType.Boolean, null),
                Throws.ArgumentNullException);

            using (var sa = new SimpleAction("test-action", null, (Variant)0)) {
                Assert.That(sa.Name, IsEqualToUtf8("test-action"));
                Assert.That(sa.ParameterType, Is.Null);
                Assert.That((int)sa.State, Is.Zero);
                Assert.That(sa.StateType, Is.EqualTo(VariantType.Int32));
            }

            using (var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)0)) {
                Assert.That(sa.Name, IsEqualToUtf8("test-action"));
                Assert.That(sa.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That((int)sa.State, Is.Zero);
                Assert.That(sa.StateType, Is.EqualTo(VariantType.Int32));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSetEnabled()
        {
            using (var sa = new SimpleAction("test-action", VariantType.Boolean)) {
                Assume.That(sa.Enabled, Is.True);
                sa.SetEnabled(false);
                Assert.That(sa.Enabled, Is.False);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSetState()
        {
            using (var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)false)) {
                Assume.That((bool)sa.State, Is.False);
                sa.SetState((Variant)true);
                Assert.That((bool)sa.State, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSetStateHint()
        {
            using (var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)false)) {
                Assume.That(sa.GetStateHint(), Is.Null);
                sa.SetStateHint((Variant)true);
                Assert.That((bool)sa.GetStateHint(), Is.True);
            }
            AssertNoGLibLog();
        }
    }
}
