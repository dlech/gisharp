using System;
using System.Linq;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using Object = GISharp.Lib.GObject.Object;

namespace GISharp.Test.Gio
{
    public class ActionGroupTests : Tests
    {
        [Test]
        public void TestListActions()
        {
            using (var ag = new TestActionGroup())
            using (var list = ag.ListActions()) {
                Assert.That<string>(list.First(), Is.EqualTo("test-action-1"));
            }
        }

        [Test]
        public void TestQueryAction()
        {
            using (var ag = new TestActionGroup()) {
                if (ag.TryQueryAction("does-not-exist", out var enabled, out var paramType,
                    out var stateType, out var stateHint, out var state)) {
                    Assert.Fail("The action does not exist, so we should not get here.");
                }
            }
        }

        [Test]
        public void TestHasAction()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.HasAction("does-not-exist")!, Is.False);
            }
        }

        [Test]
        public void TestGetActionEnabled()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.GetActionEnabled("does-not-exist")!, Is.False);
            }
        }

        [Test]
        public void TestGetParameterType()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.GetActionParameterType("does-not-exist")!, Is.EqualTo(VariantType.Int32));
            }
        }

        [Test]
        public void TestGetStateType()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That(ag.GetActionStateType("does-not-exist")!, Is.EqualTo(VariantType.Boolean));
            }
        }

        [Test]
        public void TestGetActionStateHint()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That((int)ag.GetActionStateHint("does-not-exist")!, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestGetActionState()
        {
            using (var ag = new TestActionGroup()) {
                Assert.That((int)ag.GetActionState("does-not-exist")!, Is.EqualTo(2));
            }
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
        }

        [Test]
        public void TestActionAdded()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionAdded += (s, a) => actual = a.ActionName;
                ActionGroup.ActionAdded(ag, expected);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void TestActionRemoved()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionRemoved += (s, a) => actual = a.ActionName;
                ActionGroup.ActionRemoved(ag, expected);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void TestActionEnabledChanged()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionEnabledChanged += (s, a) => actual = a.ActionName;
                ActionGroup.ActionEnabledChanged(ag, expected, true);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void TestActionStateChanged()
        {
            using (var ag = new TestActionGroup()) {
                var actual = default(string);
                const string expected = "some-action";
                ag.ActionStateChanged += (s, a) => actual = a.ActionName;
                ActionGroup.ActionStateChanged(ag, expected, new Variant(11));
                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }

    [GType]
    class TestActionGroup : Object, IActionGroup
    {
        static readonly GType gtype = GType.Of<TestActionGroup>();

        public TestActionGroup() : base(New<TestActionGroup>(), Transfer.Full)
        {
        }

        void IActionGroup.DoActionAdded(UnownedUtf8 actionName)
        {
            // default signal handler
        }

        void IActionGroup.DoActionEnabledChanged(UnownedUtf8 actionName, bool enabled)
        {
            // default signal handler
        }

        void IActionGroup.DoActionRemoved(UnownedUtf8 actionName)
        {
            // default signal handler
        }

        void IActionGroup.DoActionStateChanged(UnownedUtf8 actionName, Variant state)
        {
            // default signal handler
        }

        public event EventHandler<Variant?>? ActionActivated;

        void IActionGroup.DoActivateAction(UnownedUtf8 actionName, Variant? parameter) => ActionActivated?.Invoke(this, parameter);

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

        public event EventHandler<Variant>? StateChanged;
        void IActionGroup.DoChangeActionState(UnownedUtf8 actionName, Variant value) => StateChanged?.Invoke(this, value);

        bool IActionGroup.DoGetActionEnabled(UnownedUtf8 actionName) => false;

        VariantType? IActionGroup.DoGetActionParameterType(UnownedUtf8 actionName) => VariantType.Int32;

        Variant? IActionGroup.DoGetActionState(UnownedUtf8 actionName) => new Variant(2);

        Variant? IActionGroup.DoGetActionStateHint(UnownedUtf8 actionName) => new Variant(1);

        VariantType? IActionGroup.DoGetActionStateType(UnownedUtf8 actionName) => VariantType.Boolean;

        bool IActionGroup.DoHasAction(UnownedUtf8 actionName) => false;

        Strv IActionGroup.DoListActions() => new Strv("test-action-1");
    }
}
