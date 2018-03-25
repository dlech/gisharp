using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using System.Reflection;

using static GISharp.TestHelpers;
using Action = GISharp.Lib.Gio.Action;
using Object = GISharp.Lib.GObject.Object;
using System.ComponentModel;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void TestEnabledProperty ()
        {
            using (var obj = new TestAction()) {
                // default value is true
                Assert.That(obj.Enabled, Is.True);
                Assert.That(obj.GetEnabled(), Is.True);
                Assert.That(obj.GetProperty("enabled"), Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNameProperty ()
        {
            var expected = "test-action-name";
            using (var obj = new TestAction(expected)) {
                Assert.That(obj.Name, IsEqualToUtf8(expected));
                Assert.That(obj.GetName(), IsEqualToUtf8(expected));
                Assert.That(obj.GetProperty("name"), IsEqualToUtf8(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestParameterTypeProperty ()
        {
            using (var obj = new TestAction()) {
                Assert.That(obj.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That(obj.GetParameterType(), Is.EqualTo(VariantType.Boolean));
                Assert.That(obj.GetProperty("parameter-type"), Is.EqualTo(VariantType.Boolean));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestStateProperty ()
        {
            using (var obj = new TestAction()) {
                Assert.That((int)obj.State, Is.EqualTo(2));
                Assert.That((int)obj.GetState(), Is.EqualTo(2));
                Assert.That((int)(Variant)obj.GetProperty("state"), Is.EqualTo(2));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestStateTypeProperty ()
        {
            using (var obj = new TestAction()) {
                Assert.That(obj.StateType, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetStateType(), Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetProperty("state-type"), Is.EqualTo(VariantType.Int32));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatActivateImplementationIsCalled ()
        {
            using (var obj = new TestAction())
            using (var parameter = new Variant(1)) {
                Assume.That(obj.ActivateCallbackCount, Is.EqualTo(0));
                obj.Activate(parameter);
                Assert.That(obj.ActivateCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatChangeStateImplementationIsCalled ()
        {
            using (var obj = new TestAction())
            using (var value = new Variant(1)) {
                Assume.That(obj.ChangeStateCallbackCount, Is.EqualTo(0));
                obj.ChangeState(value);
                Assert.That(obj.ChangeStateCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetEnabledImplementationIsCalled ()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetEnabledCallbackCount, Is.EqualTo(0));
                var actual = obj.GetEnabled();
                Assert.That(actual, Is.True);
                Assert.That(obj.GetEnabledCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetNameImplementationIsCalled ()
        {
            const string expected = "test-action-name";
            using (var obj = new TestAction(expected)) {
                Assume.That(obj.GetNameCallbackCount, Is.EqualTo(0));
                var actual = obj.GetName();
                Assert.That(actual, IsEqualToUtf8(expected));
                Assert.That(obj.GetNameCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetParameterTypeImplementationIsCalled ()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetParameterTypeCallbackCount, Is.EqualTo(0));
                var actual = obj.GetParameterType();
                Assert.That(actual, Is.EqualTo(VariantType.Boolean));
                Assert.That(obj.GetParameterTypeCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetStateImplementationIsCalled ()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetStateCallbackCount, Is.EqualTo(0));
                var actual = obj.GetState();
                Assert.That((int)actual, Is.EqualTo(2));
                Assert.That(obj.GetStateCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetStateHintImplementationIsCalled ()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetStateHintCallbackCount, Is.EqualTo(0));
                var actual = obj.GetStateHint();
                Assert.That(actual, Is.Null);
                Assert.That(obj.GetStateHintCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetStateTypeImplementationIsCalled ()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetStateTypeCallbackCount, Is.EqualTo(0));
                var actual = obj.GetStateType();
                Assert.That(actual, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetStateTypeCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNameIsValidNullArgument ()
        {
            Assert.That (() => Action.NameIsValid (null),
                Throws.InstanceOf<ArgumentNullException> ());
            AssertNoGLibLog();
        }

        [Test]
        public void TestNameIsValidEmptyIsNotValid ()
        {
            Assert.That (Action.NameIsValid (string.Empty), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestNameIsValidWithValid ()
        {
            Assert.That (Action.NameIsValid ("a.valid-name123"), Is.True);
            AssertNoGLibLog();
        }

        [Test]
        public void TestNameIsValidWithInvalidName ()
        {
            Assert.That (Action.NameIsValid ("not a valid name"), Is.False);
            AssertNoGLibLog();
        }

        [Test]
        public void TestParseDetailedNameWithInvalidName ()
        {
            Assert.That(() => Action.ParseDetailedName("invalid name", out var actionName, out var target),
                ThrowsGErrorException(VariantParseError.Failed));
            AssertNoGLibLog();
        }

        [Test]
        public void TestParseDetailedNameActionWithNoTarget ()
        {
            Action.ParseDetailedName("action", out var actionName, out var target);
            try {
                Assert.That(actionName, IsEqualToUtf8("action"));
                Assert.That(target, Is.Null);
            }
            finally {
                actionName?.Dispose();
                target?.Dispose();
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestParseDetailedNameActionWithStringTarget ()
        {
            Action.ParseDetailedName("action::target", out var actionName, out var target);
            try {
                Assert.That(actionName, IsEqualToUtf8("action"));
                Assert.That((string)target, Is.EqualTo("target"));
            }
            finally {
                actionName?.Dispose();
                target?.Dispose();
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestParseDetailedNameActionWithIntTarget ()
        {
            Action.ParseDetailedName("action(42)", out var actionName, out var target);
            try {
                Assert.That(actionName, IsEqualToUtf8("action"));
                Assert.That((int)target, Is.EqualTo(42));
            }
            finally {
                actionName?.Dispose();
                target?.Dispose();
            }
            AssertNoGLibLog();
        }
    }

    [GType]
    class TestAction : Object, IAction
    {
        public bool Enabled => ((IAction)this).DoGetEnabled();

        public Utf8 Name { get; }

        public VariantType ParameterType => ((IAction)this).DoGetParameterType();

        public Variant State => ((IAction)this).DoGetState();

        public VariantType StateType => ((IAction)this).DoGetStateType();

        public int ActivateCallbackCount;

        void IAction.DoActivate(Variant parameter)
        {
            Assert.That ((int)parameter, Is.EqualTo (1));
            ActivateCallbackCount++;
        }

        public int ChangeStateCallbackCount;

        void IAction.DoChangeState(Variant value)
        {
            Assert.That ((int)value, Is.EqualTo (1));
            ChangeStateCallbackCount++;
        }

        public int GetEnabledCallbackCount;

        bool IAction.DoGetEnabled()
        {
            GetEnabledCallbackCount++;
            return true;
        }

        public int GetNameCallbackCount;

        Utf8 IAction.DoGetName()
        {
            GetNameCallbackCount++;
            return Name;
        }

        public int GetParameterTypeCallbackCount;

        VariantType IAction.DoGetParameterType()
        {
            GetParameterTypeCallbackCount++;
            return VariantType.Boolean;
        }

        public int GetStateCallbackCount;

        Variant IAction.DoGetState()
        {
            GetStateCallbackCount++;
            return new Variant (2);
        }

        public int GetStateHintCallbackCount;

        Variant IAction.DoGetStateHint()
        {
            GetStateHintCallbackCount++;
            return null;
        }

        public int GetStateTypeCallbackCount;

        VariantType IAction.DoGetStateType()
        {
            GetStateTypeCallbackCount++;
            return VariantType.Int32;
        }

        public TestAction() : this("TestAction")
        {
        }

        public TestAction(string name) : this (New<TestAction>(), Transfer.Full)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestAction(IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
