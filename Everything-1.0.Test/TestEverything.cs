using System;

using GISharp.Core;
using NUnit.Framework;

using static GISharp.Everything.X;

namespace Everything.Test
{
    [TestFixture]
    public class TestEverything
    {
        [Test]
        public void TestNullfunc ()
        {
            Nullfunc ();
        }

        [Test]
        public void TestConstReturnGboolean ()
        {
            var actual = ConstReturnGboolean ();
            Assert.That (actual, Is.TypeOf<bool> ());
            Assert.That (actual, Is.False);
        }

        [Test]
        public void TestConstReturnGint8 ()
        {
            var actual = ConstReturnGint8 ();
            Assert.That (actual, Is.TypeOf<sbyte> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGuint8 ()
        {
            var actual = ConstReturnGuint8 ();
            Assert.That (actual, Is.TypeOf<byte> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGint16 ()
        {
            var actual = ConstReturnGint16 ();
            Assert.That (actual, Is.TypeOf<short> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGuint16 ()
        {
            var actual = ConstReturnGuint16 ();
            Assert.That (actual, Is.TypeOf<ushort> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGint32 ()
        {
            var actual = ConstReturnGint32 ();
            Assert.That (actual, Is.TypeOf<int> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGuint32 ()
        {
            var actual = ConstReturnGuint32 ();
            Assert.That (actual, Is.TypeOf<uint> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGint64 ()
        {
            var actual = ConstReturnGint64 ();
            Assert.That (actual, Is.TypeOf<long> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGuint64 ()
        {
            var actual = ConstReturnGuint64 ();
            Assert.That (actual, Is.TypeOf<ulong> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGchar ()
        {
            var actual = ConstReturnGchar ();
            Assert.That (actual, Is.TypeOf<sbyte> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGshort ()
        {
            var actual = ConstReturnGshort ();
            Assert.That (actual, Is.TypeOf<short> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGushort ()
        {
            var actual = ConstReturnGushort ();
            Assert.That (actual, Is.TypeOf<ushort> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGint ()
        {
            var actual = ConstReturnGint ();
            Assert.That (actual, Is.TypeOf<int> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGuint ()
        {
            var actual = ConstReturnGuint ();
            Assert.That (actual, Is.TypeOf<uint> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGlong ()
        {
            var actual = ConstReturnGlong ();
            Assert.That (actual, Is.TypeOf<long> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGulong ()
        {
            var actual = ConstReturnGulong ();
            Assert.That (actual, Is.TypeOf<ulong> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGsize ()
        {
            var actual = ConstReturnGsize ();
            Assert.That (actual, Is.TypeOf<ulong> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGssize ()
        {
            var actual = ConstReturnGssize ();
            Assert.That (actual, Is.TypeOf<long> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGintptr ()
        {
            var actual = ConstReturnGintptr ();
            Assert.That (actual, Is.TypeOf<IntPtr> ());
            Assert.That (actual, Is.EqualTo (IntPtr.Zero));
        }

        [Test]
        public void TestConstReturnGuintptr ()
        {
            var actual = ConstReturnGuintptr ();
            Assert.That (actual, Is.TypeOf<UIntPtr> ());
            Assert.That (actual, Is.EqualTo (UIntPtr.Zero));
        }

        [Test]
        public void TestConstReturnGfloat ()
        {
            var actual = ConstReturnGfloat ();
            Assert.That (actual, Is.TypeOf<float> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGdouble ()
        {
            var actual = ConstReturnGdouble ();
            Assert.That (actual, Is.TypeOf<double> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGunichar ()
        {
            var actual = ConstReturnGunichar ();
            Assert.That (actual, Is.TypeOf<int> ());
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestConstReturnGType ()
        {
            var actual = ConstReturnGType ();
            Assert.That (actual, Is.TypeOf<GType> ());
            // TODO: could use g_type_from_name() to independantly lookup the type
                  Assert.That (actual, Is.Not.EqualTo (0));
        }

        [Test]
        public void TestConstReturnUtf8 ()
        {
            var actual = ConstReturnUtf8 ();
            Assert.That (actual, Is.TypeOf<string> ());
            Assert.That (actual, Is.EqualTo (string.Empty));
        }

        [Test]
        public void TestConstReturnFilename ()
        {
            var actual = ConstReturnFilename ();
            Assert.That (actual, Is.TypeOf<string> ());
            Assert.That (actual, Is.EqualTo (string.Empty));
        }

        [Test]
        public void TestOneparamGboolean ()
        {
            OneparamGboolean (false);
        }

        [Test]
        public void TestOneparamGint8 ()
        {
            OneparamGint8 (0);
        }

        [Test]
        public void TestOneparamGuint8 ()
        {
            OneparamGuint8 (0);
        }

        [Test]
        public void TestOneparamGint16 ()
        {
            OneparamGint16 (0);
        }

        [Test]
        public void TestOneparamGuint16 ()
        {
            OneparamGuint16 (0);
        }

        [Test]
        public void TestOneparamGint32 ()
        {
            OneparamGint32 (0);
        }

        [Test]
        public void TestOneparamGuint32 ()
        {
            OneparamGuint32 (0);
        }

        [Test]
        public void TestOneparamGint64 ()
        {
            OneparamGint64 (0);
        }

        [Test]
        public void TestOneparamGuint64 ()
        {
            OneparamGuint64 (0);
        }

        [Test]
        public void TestOneparamGchar ()
        {
            OneparamGchar (0);
        }

        [Test]
        public void TestOneparamGshort ()
        {
            OneparamGshort (0);
        }

        [Test]
        public void TestOneparamGushort ()
        {
            OneparamGushort (0);
        }

        [Test]
        public void TestOneparamGint ()
        {
            OneparamGint (0);
        }

        [Test]
        public void TestOneparamGuint ()
        {
            OneparamGuint (0);
        }

        [Test]
        public void TestOneparamGlong ()
        {
            OneparamGlong (0);
        }

        [Test]
        public void TestOneparamGulong ()
        {
            OneparamGulong (0);
        }

        [Test]
        public void TestOneparamGsize ()
        {
            OneparamGsize (0);
        }

        [Test]
        public void TestOneparamGssize ()
        {
            OneparamGssize (0);
        }

        [Test]
        public void TestOneparamGintptr ()
        {
            OneparamGintptr (IntPtr.Zero);
        }

        [Test]
        public void TestOneparamGuintptr ()
        {
            OneparamGuintptr (UIntPtr.Zero);
        }

        [Test]
        public void TestOneparamGfloat ()
        {
            OneparamGfloat (0);
        }

        [Test]
        public void TestOneparamGdouble ()
        {
            OneparamGdouble (0);
        }

        [Test]
        public void TestOneparamGunichar ()
        {
            OneparamGunichar (0);
        }

        [Test]
        public void TestOneparamUtf8 ()
        {
            OneparamUtf8 (string.Empty);
            Assert.That (
                () => OneparamUtf8 (null),
                Throws.TypeOf<ArgumentNullException> ());
        }

        [Test]
        public void TestOneparamFilename ()
        {
            OneparamFilename (string.Empty);
            Assert.That (
                () => OneparamFilename (null),
                Throws.TypeOf<ArgumentNullException> ());
        }

        [Test]
        public void TestOneOutparamGbooelan ()
        {
            bool actual;
            OneOutparamGboolean (out actual);
            Assert.That (actual, Is.False);
        }

        [Test]
        public void TestOneOutparamGint8 ()
        {
            sbyte actual;
            OneOutparamGint8 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGuint8 ()
        {
            byte actual;
            OneOutparamGuint8 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGint16 ()
        {
            short actual;
            OneOutparamGint16 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGuint16 ()
        {
            ushort actual;
            OneOutparamGuint16 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGint32 ()
        {
            int actual;
            OneOutparamGint32 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGuin32 ()
        {
            uint actual;
            OneOutparamGuint32 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGint64 ()
        {
            long actual;
            OneOutparamGint64 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGuint64 ()
        {
            ulong actual;
            OneOutparamGuint64 (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGchar ()
        {
            sbyte actual;
            OneOutparamGchar (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGshort ()
        {
            short actual;
            OneOutparamGshort (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGushort ()
        {
            ushort actual;
            OneOutparamGushort (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGint ()
        {
            int actual;
            OneOutparamGint (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneoutparamGuint ()
        {
            uint actual;
            OneOutparamGuint (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGlong ()
        {
            long actual;
            OneOutparamGlong (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneoutparamGulong ()
        {
            ulong actual;
            OneOutparamGulong (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGsize ()
        {
            ulong actual;
            OneOutparamGsize (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneoutparamGssize ()
        {
            long actual;
            OneOutparamGssize (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGintptr ()
        {
            IntPtr actual;
            OneOutparamGintptr (out actual);
            Assert.That (actual, Is.EqualTo (IntPtr.Zero));
        }

        [Test]
        public void TestOneoutparamGuintptr ()
        {
            UIntPtr actual;
            OneOutparamGuintptr (out actual);
            Assert.That (actual, Is.EqualTo (UIntPtr.Zero));
        }

        [Test]
        public void TestOneOutparamGfloat ()
        {
            float actual;
            OneOutparamGfloat (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneoutparamGdouble ()
        {
            double actual;
            OneOutparamGdouble (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGunichar ()
        {
            int actual;
            OneOutparamGunichar (out actual);
            Assert.That (actual, Is.EqualTo (0));
        }

        [Test]
        public void TestOneOutparamGtype ()
        {
            GType actual;
            OneOutparamGType (out actual);
            Assert.That (actual, Is.EqualTo (GType.None));
        }

        [Test]
        public void TestOneOutparamUtf8 ()
        {
            string actual;
            OneOutparamUtf8 (out actual);
            Assert.That (actual, Is.Null);
        }

        [Test]
        public void TestOneOutparamFilename ()
        {
            string actual;
            OneOutparamFilename (out actual);
            Assert.That (actual, Is.Null);
        }

        [Test]
        public void TestPassthroughOneGboolean ()
        {
            var expected = false;
            var actual = PassthroughOneGboolean (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = true;
            actual = PassthroughOneGboolean (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGint8 ()
        {
            var expected = sbyte.MaxValue;
            var actual = PassthroughOneGint8 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = sbyte.MinValue;
            actual = PassthroughOneGint8 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGuint8 ()
        {
            var expected = byte.MaxValue;
            var actual = PassthroughOneGuint8 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = byte.MinValue;
            actual = PassthroughOneGuint8 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGint16 ()
        {
            var expected = short.MaxValue;
            var actual = PassthroughOneGint16 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = short.MinValue;
            actual = PassthroughOneGint16 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGuint16 ()
        {
            var expected = ushort.MaxValue;
            var actual = PassthroughOneGuint16 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = ushort.MinValue;
            actual = PassthroughOneGuint16 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGint32 ()
        {
            var expected = int.MaxValue;
            var actual = PassthroughOneGint32 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = int.MinValue;
            actual = PassthroughOneGint32 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGuint32 ()
        {
            var expected = uint.MaxValue;
            var actual = PassthroughOneGuint32 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = uint.MinValue;
            actual = PassthroughOneGuint32 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGint64 ()
        {
            var expected = long.MaxValue;
            var actual = PassthroughOneGint64 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = long.MinValue;
            actual = PassthroughOneGint64 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGuint64 ()
        {
            var expected = ulong.MaxValue;
            var actual = PassthroughOneGuint64 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = ulong.MinValue;
            actual = PassthroughOneGuint64 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGchar ()
        {
            var expected = sbyte.MaxValue;
            var actual = PassthroughOneGchar (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = sbyte.MinValue;
            actual = PassthroughOneGchar (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGshort ()
        {
            var expected = short.MaxValue;
            var actual = PassthroughOneGshort (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = short.MinValue;
            actual = PassthroughOneGshort (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGushort ()
        {
            var expected = ushort.MaxValue;
            var actual = PassthroughOneGushort (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = ushort.MinValue;
            actual = PassthroughOneGushort (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGint ()
        {
            var expected = int.MaxValue;
            var actual = PassthroughOneGint (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = int.MinValue;
            actual = PassthroughOneGint (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGuint ()
        {
            var expected = uint.MaxValue;
            var actual = PassthroughOneGuint (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = uint.MinValue;
            actual = PassthroughOneGuint (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGlong ()
        {
            var expected = long.MaxValue;
            var actual = PassthroughOneGlong (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = long.MinValue;
            actual = PassthroughOneGlong (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGulong ()
        {
            var expected = ulong.MaxValue;
            var actual = PassthroughOneGulong (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = ulong.MinValue;
            actual = PassthroughOneGulong (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGsize ()
        {
            var expected = ulong.MaxValue;
            var actual = PassthroughOneGsize (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = ulong.MinValue;
            actual = PassthroughOneGsize (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGssize ()
        {
            var expected = long.MaxValue;
            var actual = PassthroughOneGssize (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = long.MinValue;
            actual = PassthroughOneGssize (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGintptr ()
        {
            var expected = IntPtr.Zero;
            var actual = PassthroughOneGintptr (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGuintptr ()
        {
            var expected = UIntPtr.Zero;
            var actual = PassthroughOneGuintptr (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGfloat ()
        {
            var expected = float.MaxValue;
            var actual = PassthroughOneGfloat (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = float.MinValue;
            actual = PassthroughOneGfloat (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGdouble ()
        {
            var expected = double.MaxValue;
            var actual = PassthroughOneGdouble (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = double.MinValue;
            actual = PassthroughOneGdouble (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGunichar ()
        {
            var expected = int.MaxValue;
            var actual = PassthroughOneGunichar (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = int.MinValue;
            actual = PassthroughOneGunichar (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneGType ()
        {
            var expected = GType.None;
            var actual = PassthroughOneGType (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneUtf8 ()
        {
            var expected = string.Empty;
            var actual = PassthroughOneUtf8 (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = "abcd\u1234";
            actual = PassthroughOneUtf8 (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }

        [Test]
        public void TestPassthroughOneFilename ()
        {
            var expected = string.Empty;
            var actual = PassthroughOneFilename (expected);
            Assert.That (actual, Is.EqualTo (expected));

            expected = "abcd";
            actual = PassthroughOneFilename (expected);
            Assert.That (actual, Is.EqualTo (expected));
        }
    }
}
