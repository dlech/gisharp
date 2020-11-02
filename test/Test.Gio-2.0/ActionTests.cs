using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;
using Object = GISharp.Lib.GObject.Object;
using System.ComponentModel;

namespace GISharp.Test.Gio
{
    public class ActionTests : Tests
    {
        [Test]
        public void TestEnabledProperty()
        {
            using (var obj = new TestAction()) {
                // default value is true
                Assert.That(obj.Enabled, Is.True);
                Assert.That(obj.GetEnabled(), Is.True);
                Assert.That(obj.GetProperty("enabled"), Is.True);
            }
        }

        [Test]
        public void TestNameProperty()
        {
            var expected = "test-action-name";
            using (var obj = new TestAction(expected)) {
                Assert.That<string>(obj.Name!, Is.EqualTo(expected));
                Assert.That<string>(obj.GetName(), Is.EqualTo(expected));
                Assert.That(obj.GetProperty("name"), Is.EqualTo(expected));
            }
        }

        [Test]
        public void TestParameterTypeProperty()
        {
            using (var obj = new TestAction()) {
                Assert.That(obj.ParameterType, Is.EqualTo(VariantType.Boolean));
                Assert.That(obj.GetParameterType(), Is.EqualTo(VariantType.Boolean));
                Assert.That(obj.GetProperty("parameter-type"), Is.EqualTo(VariantType.Boolean));
            }
        }

        [Test]
        public void TestStateProperty()
        {
            using (var obj = new TestAction()) {
                Assert.That((int)obj.State!, Is.EqualTo(2));
                Assert.That((int)obj.GetState(), Is.EqualTo(2));
                Assert.That((int)(Variant)obj.GetProperty("state")!, Is.EqualTo(2));
            }
        }

        [Test]
        public void TestStateTypeProperty()
        {
            using (var obj = new TestAction()) {
                Assert.That(obj.StateType, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetStateType(), Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetProperty("state-type"), Is.EqualTo(VariantType.Int32));
            }
        }

        [Test]
        public void TestThatActivateImplementationIsCalled()
        {
            using (var obj = new TestAction())
            using (var parameter = new Variant(1)) {
                Assume.That(obj.ActivateCallbackCount, Is.EqualTo(0));
                obj.Activate(parameter);
                Assert.That(obj.ActivateCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatChangeStateImplementationIsCalled()
        {
            using (var obj = new TestAction())
            using (var value = new Variant(1)) {
                Assume.That(obj.ChangeStateCallbackCount, Is.EqualTo(0));
                obj.ChangeState(value);
                Assert.That(obj.ChangeStateCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatGetEnabledImplementationIsCalled()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetEnabledCallbackCount, Is.EqualTo(0));
                var actual = obj.GetEnabled();
                Assert.That(actual, Is.True);
                Assert.That(obj.GetEnabledCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatGetNameImplementationIsCalled()
        {
            const string expected = "test-action-name";
            using (var obj = new TestAction(expected)) {
                Assume.That(obj.GetNameCallbackCount, Is.EqualTo(0));
                var actual = obj.GetName();
                Assert.That<string>(actual, Is.EqualTo(expected));
                Assert.That(obj.GetNameCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatGetParameterTypeImplementationIsCalled()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetParameterTypeCallbackCount, Is.EqualTo(0));
                var actual = obj.GetParameterType();
                Assert.That(actual, Is.EqualTo(VariantType.Boolean));
                Assert.That(obj.GetParameterTypeCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatGetStateImplementationIsCalled()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetStateCallbackCount, Is.EqualTo(0));
                var actual = obj.GetState();
                Assert.That((int)actual, Is.EqualTo(2));
                Assert.That(obj.GetStateCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatGetStateHintImplementationIsCalled()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetStateHintCallbackCount, Is.EqualTo(0));
                var actual = obj.GetStateHint();
                Assert.That(actual, Is.Null);
                Assert.That(obj.GetStateHintCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestThatGetStateTypeImplementationIsCalled()
        {
            using (var obj = new TestAction()) {
                Assume.That(obj.GetStateTypeCallbackCount, Is.EqualTo(0));
                var actual = obj.GetStateType();
                Assert.That(actual, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetStateTypeCallbackCount, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestNameIsValidNullArgument()
        {
            Assert.That(IAction.NameIsValid("test"), Is.True);
            Assert.That(IAction.NameIsValid(""), Is.False);
        }

        [Test]
        public void TestNameIsValidEmptyIsNotValid()
        {
            Assert.That(IAction.NameIsValid(string.Empty), Is.False);
        }

        [Test]
        public void TestNameIsValidWithValid()
        {
            Assert.That(IAction.NameIsValid("a.valid-name123"), Is.True);
        }

        [Test]
        public void TestNameIsValidWithInvalidName()
        {
            Assert.That(IAction.NameIsValid("not a valid name"), Is.False);
        }

        [Test]
        public void TestParseDetailedNameWithInvalidName()
        {
            Assert.That(() => IAction.ParseDetailedName("invalid name", out var actionName, out var target),
                ThrowsGErrorException(VariantParseError.Failed));
        }

        [Test]
        public void TestParseDetailedNameActionWithNoTarget()
        {
            IAction.ParseDetailedName("action", out var actionName, out var target);
            try {
                Assert.That<string>(actionName, Is.EqualTo("action"));
                Assert.That(target, Is.Null);
            }
            finally {
                actionName?.Dispose();
                target?.Dispose();
            }
        }

        [Test]
        public void TestParseDetailedNameActionWithStringTarget()
        {
            IAction.ParseDetailedName("action::target", out var actionName, out var target);
            try {
                Assert.That<string>(actionName, Is.EqualTo("action"));
                Assert.That((string)target, Is.EqualTo("target"));
            }
            finally {
                actionName?.Dispose();
                target?.Dispose();
            }
        }

        [Test]
        public void TestParseDetailedNameActionWithIntTarget()
        {
            IAction.ParseDetailedName("action(42)", out var actionName, out var target);
            try {
                Assert.That<string>(actionName, Is.EqualTo("action"));
                Assert.That((int)target, Is.EqualTo(42));
            }
            finally {
                actionName?.Dispose();
                target?.Dispose();
            }
        }
    }

    [GType]
    class TestAction : Object, IAction
    {
        readonly Utf8? name;

        public bool Enabled => ((IAction)this).DoGetEnabled();

        public Utf8? Name => name;

        public VariantType? ParameterType => ((IAction)this).DoGetParameterType();

        public Variant? State => ((IAction)this).DoGetState();

        public VariantType? StateType => ((IAction)this).DoGetStateType();

        public int ActivateCallbackCount;

        void IAction.DoActivate(Variant? parameter)
        {
            Assert.That((int)parameter!, Is.EqualTo(1));
            ActivateCallbackCount++;
        }

        public int ChangeStateCallbackCount;

        void IAction.DoChangeState(Variant value)
        {
            Assert.That((int)value, Is.EqualTo(1));
            ChangeStateCallbackCount++;
        }

        public int GetEnabledCallbackCount;

        bool IAction.DoGetEnabled()
        {
            GetEnabledCallbackCount++;
            return true;
        }

        public int GetNameCallbackCount;

        UnownedUtf8 IAction.DoGetName()
        {
            GetNameCallbackCount++;
            return name!;
        }

        public int GetParameterTypeCallbackCount;

        VariantType? IAction.DoGetParameterType()
        {
            GetParameterTypeCallbackCount++;
            return VariantType.Boolean;
        }

        public int GetStateCallbackCount;

        Variant IAction.DoGetState()
        {
            GetStateCallbackCount++;
            return new Variant(2);
        }

        public int GetStateHintCallbackCount;

        Variant? IAction.DoGetStateHint()
        {
            GetStateHintCallbackCount++;
            return null;
        }

        public int GetStateTypeCallbackCount;

        VariantType? IAction.DoGetStateType()
        {
            GetStateTypeCallbackCount++;
            return VariantType.Int32;
        }

        public TestAction() : this("TestAction")
        {
        }

        public TestAction(string name) : this(New<TestAction>(), Transfer.Full)
        {
            this.name = name;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestAction(IntPtr handle, Transfer ownership)
            : base(handle, ownership)
        {
        }
    }
}
