// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.InteropServices;
using System.Text;
using GISharp.Lib.GIRepository;
using GISharp.Lib.GLib;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using Transfer = GISharp.Runtime.Transfer;

namespace GISharp.Test.GObject
{
    public class ParamSpecTests : IListTests<PtrArray<ParamSpec>, ParamSpec>
    {
        // Init for IListTests
        public ParamSpecTests()
            : base(
                GetItemAt,
                new ParamSpecBoolean("P0", "P0", "P0", false, ParamFlags.Readwrite),
                new ParamSpecBoolean("P1", "P1", "P1", false, ParamFlags.Readwrite),
                new ParamSpecBoolean("P2", "P2", "P2", false, ParamFlags.Readwrite),
                new ParamSpecBoolean("P3", "P3", "P3", false, ParamFlags.Readwrite),
                new ParamSpecBoolean("P4", "P4", "P4", false, ParamFlags.Readwrite)
            ) { }

        static T TestParamSpec<T>(
            GType type,
            Func<string, string, string, ParamFlags, T> instantiate
        )
            where T : ParamSpec
        {
            const ParamFlags flags = ParamFlags.Readwrite;

            var param = instantiate("name", "nick", "blurb", flags);
            Assert.That<string>(param.Name, Is.EqualTo("name"));
            Assert.That<string>(param.Nick, Is.EqualTo("nick"));
            Assert.That<string?>(param.Blurb, Is.EqualTo("blurb"));
            Assert.That(param.RedirectTarget, Is.Null);
            Assert.That(param.ValueType, Is.EqualTo(type));

            return param;
        }

        [Test]
        public void TestGType()
        {
            var gtype = typeof(ParamSpec).ToGType();
            Assert.That(gtype, Is.EqualTo(GType.Param));
            Assert.That(gtype.Name, Is.EqualTo("GParam"));
            var info = (ObjectInfo)Repository.Default.FindByGtype(gtype);
            Assert.That(
                Marshal.SizeOf<ParamSpecClass.UnmanagedStruct>(),
                Is.EqualTo(info.ClassStruct!.Size)
            );
        }

        [Test]
        public void TestParamSpecBoolean()
        {
            const bool defaultValue = true;

            var param = TestParamSpec(
                GType.Boolean,
                (name, nick, blurb, flags) =>
                    new ParamSpecBoolean(name, nick, blurb, defaultValue, flags)
            );
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamBoolean"));
        }

        [Test]
        public void TestParamSpecChar()
        {
            const sbyte min = 1;
            const sbyte max = 5;
            const sbyte defaultValue = 3;

            var param = TestParamSpec(
                GType.Char,
                (name, nick, blurb, flags) =>
                    new ParamSpecChar(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamChar"));
        }

        [Test]
        public void TestParamSpecUChar()
        {
            const byte min = 1;
            const byte max = 5;
            const byte defaultValue = 3;

            var param = TestParamSpec(
                GType.UChar,
                (name, nick, blurb, flags) =>
                    new ParamSpecUChar(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamUChar"));
        }

        [Test]
        public void TestParamSpecInt()
        {
            const int min = 1;
            const int max = 5;
            const int defaultValue = 3;

            var param = TestParamSpec(
                GType.Int,
                (name, nick, blurb, flags) =>
                    new ParamSpecInt(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamInt"));
        }

        [Test]
        public void TestParamSpecUInt()
        {
            const uint min = 1;
            const uint max = 5;
            const uint defaultValue = 3;

            var param = TestParamSpec(
                GType.UInt,
                (name, nick, blurb, flags) =>
                    new ParamSpecUInt(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamUInt"));
        }

        [Test]
        public void TestParamSpecLong()
        {
            CLong min = new(1);
            CLong max = new(5);
            CLong defaultValue = new(3);

            var param = TestParamSpec(
                GType.Long,
                (name, nick, blurb, flags) =>
                    new ParamSpecLong(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamLong"));
        }

        [Test]
        public void TestParamSpecULong()
        {
            CULong min = new(1);
            CULong max = new(5);
            CULong defaultValue = new(3);

            var param = TestParamSpec(
                GType.ULong,
                (name, nick, blurb, flags) =>
                    new ParamSpecULong(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamULong"));
        }

        [Test]
        public void TestParamSpecInt64()
        {
            const long min = long.MinValue + 1;
            const long max = long.MaxValue - 1;
            const long defaultValue = long.MaxValue / 3;

            var param = TestParamSpec(
                GType.Int64,
                (name, nick, blurb, flags) =>
                    new ParamSpecInt64(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamInt64"));
        }

        [Test]
        public void TestParamSpecUInt64()
        {
            const ulong min = 1;
            const ulong max = 5;
            const ulong defaultValue = 3;

            var param = TestParamSpec(
                GType.UInt64,
                (name, nick, blurb, flags) =>
                    new ParamSpecUInt64(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamUInt64"));
        }

        [Test]
        public void TestParamSpecFloat()
        {
            const float min = 1;
            const float max = 5;
            const float defaultValue = 3;

            var param = TestParamSpec(
                GType.Float,
                (name, nick, blurb, flags) =>
                    new ParamSpecFloat(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.Epsilon, Is.EqualTo(1e-30f));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamFloat"));
        }

        [Test]
        public void TestParamSpecDouble()
        {
            const double min = 1;
            const double max = 5;
            const double defaultValue = 3;

            var param = TestParamSpec(
                GType.Double,
                (name, nick, blurb, flags) =>
                    new ParamSpecDouble(name, nick, blurb, min, max, defaultValue, flags)
            );
            Assert.That(param.Minimum, Is.EqualTo(min));
            Assert.That(param.Maximum, Is.EqualTo(max));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.Epsilon, Is.EqualTo(1e-90));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamDouble"));
        }

        [GType]
        enum TestEnum
        {
            One,
            Two,
            Three,
        }

        [Test]
        public void TestParamSpecEnum()
        {
            const TestEnum defaultValue = TestEnum.Two;
            var gtype = typeof(TestEnum).ToGType();
            Assume.That(gtype.IsA(GType.Enum));

            var param = TestParamSpec(
                gtype,
                (name, nick, blurb, flags) =>
                    new ParamSpecEnum(name, nick, blurb, gtype, defaultValue, flags)
            );
            Assert.That(param.EnumClass.GType, Is.EqualTo(gtype));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamEnum"));
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
        public void TestParamSpecFlags()
        {
            const TestFlags defaultValue = TestFlags.Two;
            var gtype = typeof(TestFlags).ToGType();
            Assume.That(gtype.IsA(GType.Flags));

            var param = TestParamSpec(
                gtype,
                (name, nick, blurb, flags) =>
                    new ParamSpecFlags(name, nick, blurb, gtype, defaultValue, flags)
            );
            Assert.That(param.FlagsClass.GType, Is.EqualTo(gtype));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamFlags"));
        }

        [Test]
        public void TestParamSpecString()
        {
            const string defaultValue = "default";

            var param = TestParamSpec(
                GType.String,
                (name, nick, blurb, flags) =>
                    new ParamSpecString(name, nick, blurb, defaultValue, flags)
            );
            Assert.That<string>(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That<string?>(param.CsetFirst, Is.Null);
            Assert.That<string?>(param.CsetNth, Is.Null);
            Assert.That(param.Substitutor, Is.EqualTo((sbyte)'_'));
            Assert.That(param.NullFoldIfEmpty, Is.False);
            Assert.That(param.EnsureNonNull, Is.False);
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamString"));
        }

        [Test]
        public void TestParamSpecParam()
        {
            var gtype = typeof(ParamSpecBoolean).ToGType();
            Assume.That(gtype.IsA(GType.Param));

            var param = TestParamSpec(
                gtype,
                (name, nick, blurb, flags) => new ParamSpecParam(name, nick, blurb, gtype, flags)
            );
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamParam"));
        }

        [Test]
        public void TestParamSpecBoxed()
        {
            var gtype = typeof(Strv).ToGType();
            Assume.That(gtype.IsA(GType.Boxed));

            var param = TestParamSpec(
                gtype,
                (name, nick, blurb, flags) => new ParamSpecBoxed(name, nick, blurb, gtype, flags)
            );
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamBoxed"));
        }

        [Test]
        public void TestParamSpecPointer()
        {
            var param = TestParamSpec(
                GType.Pointer,
                (name, nick, blurb, flags) => new ParamSpecPointer(name, nick, blurb, flags)
            );
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamPointer"));
        }

        [Test]
        public void TestParamSpecObject()
        {
            var param = TestParamSpec(
                GType.Object,
                (name, nick, blurb, flags) =>
                    new ParamSpecObject(name, nick, blurb, GType.Object, flags)
            );
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamObject"));
        }

        [Test]
        public void TestParamSpecUnichar()
        {
            var defaultValue = new Rune(' ');

            var param = TestParamSpec(
                GType.UInt,
                (name, nick, blurb, flags) =>
                    new ParamSpecUnichar(name, nick, blurb, defaultValue, flags)
            );
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamUnichar"));
        }

        [Test]
        public void TestParamSpecGType()
        {
            var isAType = GType.Boolean;

            var param = TestParamSpec(
                GType.Type,
                (name, nick, blurb, flags) => new ParamSpecGType(name, nick, blurb, isAType, flags)
            );
            Assert.That(param.IsAType, Is.EqualTo(isAType));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamGType"));
        }

        [Test]
        public void TestParamSpecVariant()
        {
            var defaultValue = new Variant(true);

            var param = TestParamSpec(
                GType.Variant,
                (name, nick, blurb, flags) =>
                    new ParamSpecVariant(
                        name,
                        nick,
                        blurb,
                        VariantType.Boolean,
                        defaultValue,
                        flags
                    )
            );
            Assert.That(param.VariantType, Is.EqualTo(VariantType.Boolean));
            Assert.That(param.DefaultValue, Is.EqualTo(defaultValue));
            Assert.That(param.GetGType().Name, Is.EqualTo("GParamVariant"));
        }

        [Test]
        public void TestParamSpecOverride()
        {
            Assert.That(typeof(ParamSpecOverride).ToGType().Name, Is.EqualTo("GParamOverride"));
        }

        static ParamSpec GetItemAt(PtrArray<ParamSpec> array, int index)
        {
            var data_ = Marshal.ReadIntPtr(array.UnsafeHandle);
            var ptr = Marshal.ReadIntPtr(data_, IntPtr.Size * index);
            return ParamSpec.GetInstance<ParamSpecBoolean>(ptr, Transfer.None)!;
        }
    }
}
