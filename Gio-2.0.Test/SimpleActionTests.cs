using GISharp.Lib.GLib;
using GISharp.Lib.Gio;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class SimpleActionTests
    {
        [Test]
        public void TestNew()
        {
            Assert.That(() => new SimpleAction(Utf8.Null, null),
                Throws.ArgumentNullException);

            using (var sa = new SimpleAction("test-action", null)) {
                Assert.That<string>(sa.Name, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.Null);
                Assert.That(sa.State, Is.Null);
                Assert.That(sa.StateType, Is.Null);
            }

            using (var sa = new SimpleAction("test-action", VariantType.Boolean)) {
                Assert.That<string>(sa.Name, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That(sa.State, Is.Null);
                Assert.That(sa.StateType, Is.Null);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestNewStateful()
        {
            Assert.That(() => new SimpleAction(Utf8.Null, VariantType.Boolean, (Variant)0),
                Throws.ArgumentNullException);

            Assert.That(() => new SimpleAction("test-action", VariantType.Boolean, null),
                Throws.ArgumentNullException);

            using (var sa = new SimpleAction("test-action", null, (Variant)0)) {
                Assert.That<string>(sa.Name, Is.EqualTo("test-action"));
                Assert.That(sa.ParameterType, Is.Null);
                Assert.That((int)sa.State, Is.Zero);
                Assert.That(sa.StateType, Is.EqualTo(VariantType.Int32));
            }

            using (var sa = new SimpleAction("test-action", VariantType.Boolean, (Variant)0)) {
                Assert.That<string>(sa.Name, Is.EqualTo("test-action"));
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

        [Test]
        public void TestActivateSignal()
        {
            using (var sa = new SimpleAction("test-action", VariantType.Boolean)) {
                var parameter = default(Variant);
                sa.Activated += (s, a) => parameter = a.Parameter;
                sa.Activate((Variant)true);
                Assert.That(parameter, Is.Not.Null, "Event was not called");
                Assert.That((bool)parameter, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestChangeStateSignal()
        {
            using (var sa = new SimpleAction("test-action", null, (Variant)5)) {
                var value = default(Variant);
                sa.ChangedState += (s, a) => value = a.Value;
                sa.ChangeState((Variant)10);
                Assert.That(value, Is.Not.Null, "Event was not called");
                Assert.That((int)value, Is.EqualTo(10));
            }
            AssertNoGLibLog();
        }
    }
}
