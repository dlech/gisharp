using System;
using GISharp.Gio;
using GISharp.GLib;
using GISharp.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using System.Reflection;

using static GISharp.TestHelpers;

namespace GISharp.Gio.Test
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void TestEnabledProperty ()
        {
            using (var obj = new ActionImpl()) {
                Assert.That(obj.Enabled, Is.True);
                Assert.That(obj.GetProperty("enabled"), Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestNameProperty ()
        {
            using (var obj = new ActionImpl()) {
                Assert.That(obj.Name, IsEqualToUtf8("TestActionName"));
                Assert.That(obj.GetProperty("name"), IsEqualToUtf8("TestActionName"));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestParameterTypeProperty ()
        {
            using (var obj = new ActionImpl()) {
                Assert.That(obj.ParameterType, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetProperty("parameter-type"), Is.EqualTo(VariantType.Int32));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestStateProperty ()
        {
            using (var obj = new ActionImpl()) {
                Assert.That((int)obj.State, Is.EqualTo(2));
                Assert.That((int)(Variant)obj.GetProperty("state"), Is.EqualTo(2));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestStateTypeProperty ()
        {
            using (var obj = new ActionImpl()) {
                Assert.That(obj.StateType, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetProperty("state-type"), Is.EqualTo(VariantType.Int32));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatActivateImplementationIsCalled ()
        {
            using (var obj = new ActionImpl())
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
            using (var obj = new ActionImpl())
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
            using (var obj = new ActionImpl()) {
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
            using (var obj = new ActionImpl()) {
                Assume.That(obj.GetNameCallbackCount, Is.EqualTo(0));
                var actual = obj.GetName();
                Assert.That(actual, IsEqualToUtf8("TestActionName"));
                Assert.That(obj.GetNameCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetParameterTypeImplementationIsCalled ()
        {
            using (var obj = new ActionImpl()) {
                Assume.That(obj.GetParameterTypeCallbackCount, Is.EqualTo(0));
                var actual = obj.GetParameterType();
                Assert.That(actual, Is.EqualTo(VariantType.Int32));
                Assert.That(obj.GetParameterTypeCallbackCount, Is.EqualTo(1));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestThatGetStateImplementationIsCalled ()
        {
            using (var obj = new ActionImpl()) {
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
            using (var obj = new ActionImpl()) {
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
            using (var obj = new ActionImpl()) {
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
            Assert.That(() => Action.TryParseDetailedName("invalid name", out var actionName, out var target),
                ThrowsGErrorException(VariantParseError.Failed));
            AssertNoGLibLog();
        }

        [Test]
        public void TestParseDetailedNameActionWithNoTarget ()
        {
            Assert.That(Action.TryParseDetailedName("action", out var actionName, out var target), Is.True);
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
            Assert.That(Action.TryParseDetailedName("action::target", out var actionName, out var target), Is.True);
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
            Assert.That(Action.TryParseDetailedName("action(42)", out var actionName, out var target), Is.True);
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
    class ActionImpl : GObject.Object, IAction
    {
        public bool Enabled {
            get {
                return this.GetEnabled ();
            }
        }
        public Utf8 Name {
            get {
                return this.GetName ();
            }
        }
        public VariantType ParameterType {
            get {
                return this.GetParameterType ();
            }
        }
        public Variant State {
            get {
                return this.GetState ();
            }
        }
        public VariantType StateType {
            get {
                return this.GetStateType ();
            }
        }

        public int ActivateCallbackCount;

        void IAction.Activate (Variant parameter)
        {
            Assert.That ((int)parameter, Is.EqualTo (1));
            ActivateCallbackCount++;
        }

        public int ChangeStateCallbackCount;

        void IAction.ChangeState (Variant value)
        {
            Assert.That ((int)value, Is.EqualTo (1));
            ChangeStateCallbackCount++;
        }

        public int GetEnabledCallbackCount;

        bool IAction.GetEnabled ()
        {
            GetEnabledCallbackCount++;
            return true;
        }

        public int GetNameCallbackCount;

        Utf8 IAction.GetName()
        {
            GetNameCallbackCount++;
            return "TestActionName";
        }

        public int GetParameterTypeCallbackCount;

        VariantType IAction.GetParameterType ()
        {
            GetParameterTypeCallbackCount++;
            return VariantType.Int32;
        }

        public int GetStateCallbackCount;

        Variant IAction.GetState ()
        {
            GetStateCallbackCount++;
            return new Variant (2);
        }

        public int GetStateHintCallbackCount;

        Variant IAction.GetStateHint ()
        {
            GetStateHintCallbackCount++;
            return null;
        }

        public int GetStateTypeCallbackCount;

        VariantType IAction.GetStateType ()
        {
            GetStateTypeCallbackCount++;
            return VariantType.Int32;
        }

        public ActionImpl () : this (New<ActionImpl> (), Transfer.Full)
        {
        }

        public ActionImpl (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
