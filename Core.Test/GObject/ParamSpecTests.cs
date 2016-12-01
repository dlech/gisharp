using System;
using GISharp.GLib;
using GISharp.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using nlong = GISharp.Runtime.NativeLong;
using nulong = GISharp.Runtime.NativeULong;

namespace GISharp.Core.Test.GObject
{
    [TestFixture]
    public class ParamSpecTests
    {
        T TestParamSpec<T> (GType type, Func<string, string, string, ParamFlags, T> instanciate) where T : ParamSpec
        {
            const ParamFlags flags = ParamFlags.Readwrite | ParamFlags.StaticStrings;

            Assert.That (() => instanciate (null, "nick", "blurb", flags),
                         Throws.TypeOf<ArgumentNullException> ());
            Assert.That (() => instanciate ("name", null, "blurb", flags),
                         Throws.TypeOf<ArgumentNullException> ());
            Assert.That (() => instanciate ("name", "nick", null, flags),
                         Throws.TypeOf<ArgumentNullException> ());
            var param = instanciate ("name", "nick", "blurb", flags);
            Assert.That (param.Name, Is.EqualTo ("name"));
            Assert.That (param.Nick, Is.EqualTo ("nick"));
            Assert.That (param.Blurb, Is.EqualTo ("blurb"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamBoolean"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamChar"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamUChar"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamInt"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamUInt"));
        }

        [Test]
        public void TestParamSpecLong ()
        {
            nlong min = 1;
            nlong max = 5;
            nlong defaultValue = 3;

            var param = TestParamSpec (GType.Long, (name, nick, blurb, flags) =>
                                       new ParamSpecLong (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamLong"));
        }

        [Test]
        public void TestParamSpecULong ()
        {
            nulong min = 1;
            nulong max = 5;
            nulong defaultValue = 3;

            var param = TestParamSpec (GType.ULong, (name, nick, blurb, flags) =>
                                       new ParamSpecULong (name, nick, blurb, min, max, defaultValue, flags));
            Assert.That (param.Minimum, Is.EqualTo (min));
            Assert.That (param.Maximum, Is.EqualTo (max));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamULong"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamInt64"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamUInt64"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamFloat"));
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
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamDouble"));
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
            var gtype = GType.TypeOf<TestEnum> ();
            Assume.That (gtype.IsA (GType.Enum));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecEnum (name, nick, blurb, gtype, defaultValue, flags));
            Assert.That (param.EnumType, Is.EqualTo (typeof (TestEnum)));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamEnum"));
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
            var gtype = GType.TypeOf<TestFlags> ();
            Assume.That (gtype.IsA (GType.Flags));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecFlags (name, nick, blurb, gtype, defaultValue, flags));
            Assert.That (param.FlagsType, Is.EqualTo (typeof (TestFlags)));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamFlags"));
        }

        [Test]
        public void TestParamSpecString ()
        {
            const string defaultValue = "default";

            var param = TestParamSpec (GType.String, (name, nick, blurb, flags) =>
                                       new ParamSpecString (name, nick, blurb, defaultValue, flags));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.CsetFirst, Is.EqualTo (null));
            Assert.That (param.CsetNth, Is.EqualTo (null));
            Assert.That (param.Substitutor, Is.EqualTo ((sbyte)'_'));
            Assert.That (param.NullFoldIfEmpty, Is.EqualTo (false));
            Assert.That (param.EnsureNonNull, Is.EqualTo (false));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamString"));
        }

        [Test]
        public void TestParamSpecParam ()
        {
            var gtype = GType.TypeOf<ParamSpecBoolean> ();
            Assume.That (gtype.IsA (GType.Param));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecParam (name, nick, blurb, gtype, flags));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamParam"));
        }

        [Test]
        public void TestParamSpecBoxed ()
        {
            var gtype = GType.TypeOf<object> ();
            Assume.That (gtype.IsA (GType.Boxed));

            var param = TestParamSpec (gtype, (name, nick, blurb, flags) =>
                                       new ParamSpecBoxed (name, nick, blurb, gtype, flags));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamBoxed"));
        }

        [Test]
        public void TestParamSpecPointer ()
        {
            var param = TestParamSpec (GType.Pointer, (name, nick, blurb, flags) =>
                                       new ParamSpecPointer (name, nick, blurb, flags));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamPointer"));
        }

        [Test]
        public void TestParamSpecObject ()
        {
            var param = TestParamSpec (GType.Object, (name, nick, blurb, flags) =>
                                       new ParamSpecObject (name, nick, blurb, GType.TypeOf<GISharp.GObject.Object> (), flags));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamObject"));
        }

        [Test]
        public void TestParamSpecUnichar ()
        {
            const int defaultValue = 2;

            var param = TestParamSpec (GType.UInt, (name, nick, blurb, flags) =>
                                       new ParamSpecUnichar (name, nick, blurb, defaultValue, flags));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamUnichar"));
        }

        [Test]
        public void TestParamSpecGType ()
        {
            var isAType = GType.Boolean;

            var param = TestParamSpec (GType.Type, (name, nick, blurb, flags) =>
                                       new ParamSpecGType (name, nick, blurb, isAType, flags));
            Assert.That (param.IsAType, Is.EqualTo (isAType));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamGType"));
        }

        [Test]
        public void TestParamSpecVariant ()
        {
            var defaultValue = new Variant (true);

            var param = TestParamSpec (GType.Variant, (name, nick, blurb, flags) =>
                                       new ParamSpecVariant (name, nick, blurb, VariantType.Boolean, defaultValue, flags));
            Assert.That (param.VariantType, Is.EqualTo (VariantType.Boolean));
            Assert.That (param.DefaultValue, Is.EqualTo (defaultValue));
            Assert.That (param.GetGType ().Name, Is.EqualTo ("GParamVariant"));
        }
    }
}
