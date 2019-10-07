using System;
using System.Runtime.InteropServices;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

using clong = GISharp.Runtime.CLong;
using culong = GISharp.Runtime.CULong;

namespace GISharp.Test.Core.GObject
{
    [TestFixture]
    public class ParamSpecTests : IListTests<PtrArray<ParamSpec>, ParamSpec>
    {
        // Init for IListTests
        public ParamSpecTests() : base(getItemAt,
            new ParamSpecBoolean("P0", "P0", "P0", false, ParamFlags.Readwrite),
            new ParamSpecBoolean("P1", "P1", "P1", false, ParamFlags.Readwrite),
            new ParamSpecBoolean("P2", "P2", "P2", false, ParamFlags.Readwrite),
            new ParamSpecBoolean("P3", "P3", "P3", false, ParamFlags.Readwrite),
            new ParamSpecBoolean("P4", "P4", "P4", false, ParamFlags.Readwrite))
        {
        }

        T TestParamSpec<T> (GType type, Func<string, string, string, ParamFlags, T> instantiate) where T : ParamSpec
        {
            const ParamFlags flags = ParamFlags.Readwrite | ParamFlags.StaticStrings;

            var param = instantiate ("name", "nick", "blurb", flags);
            Assert.That<string>(param.Name, Is.EqualTo("name"));
            Assert.That<string>(param.Nick, Is.EqualTo("nick"));
            Assert.That<string>(param.Blurb, Is.EqualTo("blurb"));
            Assert.That (param.RedirectTarget, Is.Null);
            Assert.That (param.ValueType, Is.EqualTo (type));

            return param;
        }

        [Test]
        public void TestParamSpecBoolean ()
        {
            const bool defaultValue = true;

            var param = TestParamSpec (GType.Boolean, (name, nick, blurb, flags) =>
                                       new ParamSpecBoolean (name, nick, blurb, defaultValue, flags));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamBoolean"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecChar ()
        {
            const sbyte min = 1;
            const sbyte max = 5;
            const sbyte defaultValue = 3;

            var param = TestParamSpec (GType.Char, (name, nick, blurb, flags) =>
                                       new ParamSpecChar (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamChar"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecUChar ()
        {
            const byte min = 1;
            const byte max = 5;
            const byte defaultValue = 3;

            var param = TestParamSpec (GType.UChar, (name, nick, blurb, flags) =>
                                       new ParamSpecUChar (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamUChar"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecInt ()
        {
            const int min = 1;
            const int max = 5;
            const int defaultValue = 3;

            var param = TestParamSpec (GType.Int, (name, nick, blurb, flags) =>
                                       new ParamSpecInt (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamInt"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecUInt ()
        {
            const uint min = 1;
            const uint max = 5;
            const uint defaultValue = 3;

            var param = TestParamSpec (GType.UInt, (name, nick, blurb, flags) =>
                                       new ParamSpecUInt (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamUInt"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecLong ()
        {
            clong min = 1;
            clong max = 5;
            clong defaultValue = 3;

            var param = TestParamSpec (GType.Long, (name, nick, blurb, flags) =>
                                       new ParamSpecLong (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamLong"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecULong ()
        {
            culong min = 1;
            culong max = 5;
            culong defaultValue = 3;

            var param = TestParamSpec (GType.ULong, (name, nick, blurb, flags) =>
                                       new ParamSpecULong (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamULong"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecInt64 ()
        {
            const long min = long.MinValue + 1;
            const long max = long.MaxValue - 1;
            const long defaultValue = long.MaxValue / 3;

            var param = TestParamSpec (GType.Int64, (name, nick, blurb, flags) =>
                                       new ParamSpecInt64 (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamInt64"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecUInt64 ()
        {
            const ulong min = 1;
            const ulong max = 5;
            const ulong defaultValue = 3;

            var param = TestParamSpec (GType.UInt64, (name, nick, blurb, flags) =>
                                       new ParamSpecUInt64 (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamUInt64"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecFloat ()
        {
            const float min = 1;
            const float max = 5;
            const float defaultValue = 3;

            var param = TestParamSpec (GType.Float, (name, nick, blurb, flags) =>
                                       new ParamSpecFloat (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.Epsilon, Is.EqualTo (1e-30f));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamFloat"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecDouble ()
        {
            const double min = 1;
            const double max = 5;
            const double defaultValue = 3;

            var param = TestParamSpec (GType.Double, (name, nick, blurb, flags) =>
                                       new ParamSpecDouble (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.Epsilon, Is.EqualTo (1e-90));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamDouble"));

            AssertNoGLibLog();
        }

        [GType]
        enum TestEnum
        {
            One,
            Two,
            Three,
        }

        [Test]
        public void TestParamSpecEnum ()
        {
            const TestEnum defaultValue = TestEnum.Two;
            var gtype = GType.Of<TestEnum> ();
            Assume.That (gtype.IsA (GType.Enum));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecEnum (name, nick, blurb, gtype, defaultValue, flags));
            Assert.That (param.EnumType, Is.EqualTo (typeof (TestEnum)));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamEnum"));

            AssertNoGLibLog();
        }

        [GType]
        [Flags]
        enum TestFlags
        {
            One = 0x01,
            Two = 0x02,
            Three = 0x04,
        }

        [Test]
        public void TestParamSpecFlags ()
        {
            const TestFlags defaultValue = TestFlags.Two;
            var gtype = GType.Of<TestFlags> ();
            Assume.That (gtype.IsA (GType.Flags));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecFlags (name, nick, blurb, gtype, defaultValue, flags));
            Assert.That (param.FlagsType, Is.EqualTo (typeof (TestFlags)));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamFlags"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecString ()
        {
            const string defaultValue = "default";

            var param = TestParamSpec (GType.String, (name, nick, blurb, flags) =>
                                       new ParamSpecString (name, nick, blurb, defaultValue, flags));
            Assert.That<string>(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That<string?>(param.CsetFirst, Is.Null);
            Assert.That<string?>(param.CsetNth, Is.Null);
            Assert.That(param.Substitutor, Is.EqualTo((sbyte)'_'));
            Assert.That(param.NullFoldIfEmpty, Is.False);
            Assert.That(param.EnsureNonNull, Is.False);
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamString"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecParam ()
        {
            var gtype = GType.Of<ParamSpecBoolean> ();
            Assume.That (gtype.IsA (GType.Param));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecParam (name, nick, blurb, gtype, flags));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamParam"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecBoxed ()
        {
            var gtype = GType.Of<Strv> ();
            Assume.That (gtype.IsA (GType.Boxed));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecBoxed (name, nick, blurb, gtype, flags));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamBoxed"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecPointer ()
        {
            var param = TestParamSpec (GType.Pointer, (name, nick, blurb, flags) =>
                                       new ParamSpecPointer (name, nick, blurb, flags));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamPointer"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecObject ()
        {
            var param = TestParamSpec (GType.Object, (name, nick, blurb, flags) =>
                                       new ParamSpecObject(name, nick, blurb, GType.Object, flags));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamObject"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecUnichar ()
        {
            const int defaultValue = 2;

            var param = TestParamSpec (GType.UInt, (name, nick, blurb, flags) =>
                                       new ParamSpecUnichar (name, nick, blurb, defaultValue, flags));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamUnichar"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecGType ()
        {
            var isAType = GType.Boolean;

            var param = TestParamSpec (GType.Type, (name, nick, blurb, flags) =>
                                       new ParamSpecGType (name, nick, blurb, isAType, flags));
            Assert.That (param.IsAType, Is.EqualTo (isAType));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamGType"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecVariant ()
        {
            var defaultValue = new Variant (true);

            var param = TestParamSpec (GType.Variant, (name, nick, blurb, flags) =>
                                       new ParamSpecVariant (name, nick, blurb, VariantType.Boolean, defaultValue, flags));
            Assert.That (param.VariantType, Is.EqualTo (VariantType.Boolean));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That<string?>(param.GetGType().Name, Is.EqualTo("GParamVariant"));

            AssertNoGLibLog();
        }

        [Test]
        public void TestParamSpecOverride ()
        {
            Assert.That<string?>(typeof(ParamSpecOverride).GetGType().Name, Is.EqualTo("GParamOverride"));

            AssertNoGLibLog();
        }

        static ParamSpec getItemAt(PtrArray<ParamSpec> array, int index)
        {
            var data_ = Marshal.ReadIntPtr(array.Handle);
            var ptr = Marshal.ReadIntPtr(data_, IntPtr.Size * index);
            return ParamSpec.GetInstance<ParamSpecBoolean>(ptr, Transfer.None)!;
        }
    }
}
