using System;
using GISharp.Gio;
using GISharp.GLib;
using GISharp.GObject;
using GISharp.Runtime;
using NUnit.Framework;
using System.Reflection;

namespace GISharp.Gio.Test
{
    [TestFixture]
    public class ActionTests
    {
        [Test]
        public void TestEnabledProperty ()
        {
            var obj = new ActionImpl ();

            Assert.That (obj.Enabled, Is.True);
            Assert.That ((bool)obj.GetProperty ("enabled", GType.Boolean), Is.True);
        }

        [Test]
        public void TestNameProperty ()
        {
            var obj = new ActionImpl ();

            Assert.That (obj.Name, Is.EqualTo ("TestActionName"));
            Assert.That ((string)obj.GetProperty ("name", GType.String), Is.EqualTo ("TestActionName"));
        }

        [Test]
        public void TestParameterTypeProperty ()
        {
            var obj = new ActionImpl ();

            Assert.That (obj.ParameterType, Is.EqualTo (VariantType.Int32));
            Assert.That ((VariantType)obj.GetProperty ("parameter-type", typeof(VariantType).GetGType ()).Get (), Is.EqualTo (VariantType.Int32));
        }

        [Test]
        public void TestStateProperty ()
        {
            var obj = new ActionImpl ();

            Assert.That ((int)obj.State, Is.EqualTo (2));
            Assert.That ((int)(Variant)obj.GetProperty ("state", GType.Variant), Is.EqualTo (2));
        }

        [Test]
        public void TestStateTypeProperty ()
        {
            var obj = new ActionImpl ();

            Assert.That (obj.StateType, Is.EqualTo (VariantType.Int32));
            Assert.That ((VariantType)obj.GetProperty ("state-type", typeof(VariantType).GetGType ()).Get (), Is.EqualTo (VariantType.Int32));
        }

        [Test]
        public void TestThatActivateImplementationIsCalled ()
        {
            var obj = new ActionImpl ();
            var parameter = new Variant (1);

            Assume.That (obj.ActivateCallbackCount, Is.EqualTo (0));
            obj.Activate (parameter);
            Assert.That (obj.ActivateCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatChangeStateImplementationIsCalled ()
        {
            var obj = new ActionImpl ();
            var value = new Variant (1);

            Assume.That (obj.ChangeStateCallbackCount, Is.EqualTo (0));
            obj.ChangeState (value);
            Assert.That (obj.ChangeStateCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatGetEnabledImplementationIsCalled ()
        {
            var obj = new ActionImpl ();

            Assume.That (obj.GetEnabledCallbackCount, Is.EqualTo (0));
            var actual = obj.GetEnabled ();
            Assert.That (actual, Is.True);
            Assert.That (obj.GetEnabledCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatGetNameImplementationIsCalled ()
        {
            var obj = new ActionImpl ();

            Assume.That (obj.GetNameCallbackCount, Is.EqualTo (0));
            var actual = obj.GetName ();
            Assert.That (actual, Is.EqualTo ("TestActionName"));
            Assert.That (obj.GetNameCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatGetParameterTypeImplementationIsCalled ()
        {
            var obj = new ActionImpl ();

            Assume.That (obj.GetParameterTypeCallbackCount, Is.EqualTo (0));
            var actual = obj.GetParameterType ();
            Assert.That (actual, Is.EqualTo (VariantType.Int32));
            Assert.That (obj.GetParameterTypeCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatGetStateImplementationIsCalled ()
        {
            var obj = new ActionImpl ();

            Assume.That (obj.GetStateCallbackCount, Is.EqualTo (0));
            var actual = obj.GetState ();
            Assert.That ((int)actual, Is.EqualTo (2));
            Assert.That (obj.GetStateCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatGetStateHintImplementationIsCalled ()
        {
            var obj = new ActionImpl ();

            Assume.That (obj.GetStateHintCallbackCount, Is.EqualTo (0));
            var actual = obj.GetStateHint ();
            Assert.That (actual, Is.Null);
            Assert.That (obj.GetStateHintCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestThatGetStateTypeImplementationIsCalled ()
        {
            var obj = new ActionImpl ();

            Assume.That (obj.GetStateTypeCallbackCount, Is.EqualTo (0));
            var actual = obj.GetStateType ();
            Assert.That (actual, Is.EqualTo (VariantType.Int32));
            Assert.That (obj.GetStateTypeCallbackCount, Is.EqualTo (1));
        }

        [Test]
        public void TestNameIsValidNullArgument ()
        {
            Assert.That (() => Action.NameIsValid (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestNameIsValidEmptyIsNotValid ()
        {
            Assert.That (Action.NameIsValid (string.Empty), Is.False);
        }

        [Test]
        public void TestNameIsValidWithValid ()
        {
            Assert.That (Action.NameIsValid ("a.valid-name123"), Is.True);
        }

        [Test]
        public void TestNameIsValidWithInvalidName ()
        {
            Assert.That (Action.NameIsValid ("not a valid name"), Is.False);
        }

        [Test]
        public void TestParseDetailedNameWithInvalidName ()
        {
            string actionName;
            Variant target;
            TestDelegate parseDetailedName = () =>
                Action.ParseDetailedName ("invaid name", out actionName, out target);
            var exception = Assert.Throws<GErrorException> (parseDetailedName);
            Assert.True (exception.Matches (VariantParseError.Failed));
        }

        [Test]
        public void TestParseDetailedNameActionWithNoTarget ()
        {
            string actionName;
            Variant target;
            Assert.That (Action.ParseDetailedName ("action", out actionName, out target), Is.True);
            Assert.That (actionName, Is.EqualTo ("action"));
            Assert.That (target, Is.Null);
        }

        [Test]
        public void TestParseDetailedNameActionWithStringTarget ()
        {
            string actionName;
            Variant target;
            Assert.That (Action.ParseDetailedName ("action::target", out actionName, out target), Is.True);
            Assert.That (actionName, Is.EqualTo ("action"));
            Assert.That ((string)target, Is.EqualTo ("target"));
        }

        [Test]
        public void TestParseDetailedNameActionWithIntTarget ()
        {
            string actionName;
            Variant target;
            Assert.That (Action.ParseDetailedName ("action(42)", out actionName, out target), Is.True);
            Assert.That (actionName, Is.EqualTo ("action"));
            Assert.That ((int)target, Is.EqualTo (42));
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
        public string Name {
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

        string IAction.GetName ()
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

        protected ActionImpl (IntPtr handle, Transfer ownership)
            : base (handle, ownership)
        {
        }
    }
}
