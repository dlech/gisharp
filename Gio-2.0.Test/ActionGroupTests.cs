using System;
using GISharp.Gio;
using GISharp.GLib;
using GISharp.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using System.Reflection;

using static GISharp.TestHelpers;
using Object = GISharp.GObject.Object;
using System.Linq;

namespace GISharp.Gio.Test
{
    [TestFixture]
    public class ActionGroupTests
    {
        [Test]
        public void TestListActions()
        {
            using (var ag = new TestActionGroup())
            using (var list = ag.ListActions()) {
                Assert.That(list.First(), IsEqualToUtf8("test-action-1"));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestQueryAction()
        {
            using (var ag = new TestActionGroup()) {
                if (ag.TryQueryAction("does-not-exist", out var enabled, out var paramType,
                    out var stateType, out var stateHint, out var state))
                {
                    Assert.Fail("The action does not exist, so we should not get here.");
                }
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestHasAction()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.HasAction("does-not-exist"), Is.False);
                Assert.That(() => ag.HasAction(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetActionEnabled()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.GetActionEnabled("does-not-exist"), Is.False);
                Assert.That(() => ag.GetActionEnabled(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetParameterType()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.GetActionParameterType("does-not-exist"), Is.EqualTo(VariantType.Int32));
                Assert.That(() => ag.GetActionParameterType(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetStateType()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.GetActionStateType("does-not-exist"), Is.EqualTo(VariantType.Boolean));
                Assert.That(() => ag.GetActionStateType(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetActionStateHint()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That((int)ag.GetActionStateHint("does-not-exist"), Is.EqualTo(1));
                Assert.That(() => ag.GetActionStateHint(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestGetActionState()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That((int)ag.GetActionState("does-not-exist"), Is.EqualTo(2));
                Assert.That(() => ag.GetActionState(null), Throws.ArgumentNullException);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestChangeActionState()
        {
            using (var ag = new TestActionGroup()) {
                var expected = new Variant(7);
                var actual = default(Variant);
                ag.StateChanged += (s, a) => actual = a;
                ag.ChangeActionState("does-not-exist", expected);
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestActivateAction()
        {
            using (var ag = new TestActionGroup()) {
                var expected = new Variant(9);
                var actual = default(Variant);
                ag.ActionActivated += (s, a) => actual = a;
                ag.ActivateAction("does-not-exist", expected);
                Assert.That(actual, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestActionAdded()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionAdded += (s, a) => actual = a.ActionName;
                ActionGroup.ActionAdded(ag, expected);
                Assert.That(actual, IsEqualToUtf8(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestActionRemoved()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionRemoved += (s, a) => actual = a.ActionName;
                ActionGroup.ActionRemoved(ag, expected);
                Assert.That(actual, IsEqualToUtf8(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestActionEnabledChanged()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionEnabledChanged += (s, a) => actual = a.ActionName;
                ActionGroup.ActionEnabledChanged(ag, expected, true);
                Assert.That(actual, IsEqualToUtf8(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestActionStateChanged()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionStateChanged += (s, a) => actual = a.ActionName;
                ActionGroup.ActionStateChanged(ag, expected, new Variant(11));
                Assert.That(actual, IsEqualToUtf8(expected));
            }
            AssertNoGLibLog();
        }
    }

    [GType]
    class TestActionGroup : Object, IActionGroup
    {
        static readonly GType gtype = GType.TypeOf<TestActionGroup>();

        public TestActionGroup() : base(New<TestActionGroup>(), Transfer.Full)
        {
        }

        void IActionGroup.OnActionAdded(Utf8 actionName)
        {
            // default signal handler
        }

        void IActionGroup.OnActionEnabledChanged(Utf8 actionName, bool enabled)
        {
            // default signal handler
        }

        void IActionGroup.OnActionRemoved(Utf8 actionName)
        {
            // default signal handler
        }

        void IActionGroup.OnActionStateChanged(Utf8 actionName, Variant state)
        {
            // default signal handler
        }

        public event EventHandler<Variant> ActionActivated;

        void IActionGroup.OnActivateAction(Utf8 actionName, Variant parameter) => ActionActivated?.Invoke(this, parameter);

        readonly GSignalManager<ActionGroup.ActionAddedEventArgs> actionAddedSignalManager =
            new GSignalManager<ActionGroup.ActionAddedEventArgs>("action-added", gtype);

        public event EventHandler<ActionGroup.ActionAddedEventArgs> ActionAdded {
            add => actionAddedSignalManager.Add(this, value);
            remove => actionAddedSignalManager.Remove(value);
        }

        readonly GSignalManager<ActionGroup.ActionEnabledChangedEventArgs> actionEnabledChangedSignalManager =
            new GSignalManager<ActionGroup.ActionEnabledChangedEventArgs>("action-enabled-changed", gtype);

        public event EventHandler<ActionGroup.ActionEnabledChangedEventArgs> ActionEnabledChanged {
            add => actionEnabledChangedSignalManager.Add(this, value);
            remove => actionEnabledChangedSignalManager.Remove(value);
        }

        readonly GSignalManager<ActionGroup.ActionRemovedEventArgs> actionRemovedSignalManager =
            new GSignalManager<ActionGroup.ActionRemovedEventArgs>("action-removed", gtype);

        public event EventHandler<ActionGroup.ActionRemovedEventArgs> ActionRemoved {
            add => actionRemovedSignalManager.Add(this, value);
            remove => actionRemovedSignalManager.Remove(value);
        }

        readonly GSignalManager<ActionGroup.ActionStateChangedEventArgs> actionStateChangedSignalManager =
            new GSignalManager<ActionGroup.ActionStateChangedEventArgs>("action-state-changed", gtype);

        public event EventHandler<ActionGroup.ActionStateChangedEventArgs> ActionStateChanged {
            add => actionStateChangedSignalManager.Add(this, value);
            remove => actionStateChangedSignalManager.Remove(value);
        }

        public event EventHandler<Variant> StateChanged;
        void IActionGroup.OnChangeActionState(Utf8 actionName, Variant value) => StateChanged?.Invoke(this, value);

        bool IActionGroup.OnGetActionEnabled(Utf8 actionName) => false;

        VariantType IActionGroup.OnGetActionParameterType(Utf8 actionName) => VariantType.Int32;

        Variant IActionGroup.OnGetActionState(Utf8 actionName) => new Variant(2);

        Variant IActionGroup.OnGetActionStateHint(Utf8 actionName) => new Variant(1);

        VariantType IActionGroup.OnGetActionStateType(Utf8 actionName) => VariantType.Boolean;

        bool IActionGroup.OnHasAction(Utf8 actionName) => false;

        Strv IActionGroup.OnListActions() => new Strv("test-action-1" );

        bool IActionGroup.OnTryQueryAction(Utf8 actionName, out bool enabled, out VariantType parameterType, out VariantType stateType, out Variant stateHint, out Variant state)
        {
            actionName = default(Utf8);
            enabled = default(bool);
            parameterType = default(VariantType);
            stateType = default(VariantType);
            stateHint = default(Variant);
            state = default(Variant);
            return false;
        }
    }
}
