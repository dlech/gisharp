using System;

using NUnit.Framework;

namespace GISharp.Core.Test
{
    [TestFixture]
    public class ByteArrayTest
    {
        [Test]
        public void TestNew ()
        {
            // just make sure it doesn't crash
            var array = new ByteArray ();
            Assert.That (array.Length, Is.EqualTo (0));
        }

        [Test]
        public void TestNewTake ()
        {
            // just make sure it doesn't crash
            var array = new ByteArray (new byte[10]);
            Assert.That (array.Length, Is.EqualTo (10));
            // null argument is not allowed
            Assert.That (() => new ByteArray (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestSizedNew ()
        {
            // just make sure it doesn't crash
            var array = new ByteArray (10);
            Assert.That (array.Length, Is.EqualTo (0));
        }

        [Test]
        public void TestAppend ()
        {
            // check basic operation
            var array = new ByteArray ();
            array.Append (new byte[10]);
            Assert.That (array.Length, Is.EqualTo (10));
            // null argument is not allowed
            Assert.That (() => array.Append (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestPrepend ()
        {
            // check basic operation
            var array = new ByteArray ();
            array.Prepend (new byte[10]);
            Assert.That (array.Length, Is.EqualTo (10));
            // null argument is not allowed
            Assert.That (() => array.Prepend (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestRemoveIndex ()
        {
            // check basic operation
            var array = new ByteArray (new byte[10]);
            array.RemoveIndex (9);
            Assert.That (array.Length, Is.EqualTo (9));
            // check index out of range
            Assert.That (() => array.RemoveIndex (-1),
                Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveIndex (9),
                Throws.InstanceOf<IndexOutOfRangeException> ());
        }

        [Test]
        public void TestRemoveIndexFast ()
        {
            // check basic operation
            var array = new ByteArray (new byte[10]);
            array.RemoveIndexFast (9);
            Assert.That (array.Length, Is.EqualTo (9));
            // check index out of range
            Assert.That (() => array.RemoveIndexFast (-1),
                Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveIndexFast (9),
                Throws.InstanceOf<IndexOutOfRangeException> ());
        }

        [Test]
        public void TestRemoveRange ()
        {
            // check basic operation
            var array = new ByteArray (new byte[10]);
            array.RemoveRange (9, 1);
            Assert.That (array.Length, Is.EqualTo (9));
            // check index out of range
            Assert.That (() => array.RemoveRange (-1, 0),
                Throws.InstanceOf<IndexOutOfRangeException> ());
            Assert.That (() => array.RemoveRange (9, 0),
                Throws.InstanceOf<IndexOutOfRangeException> ());
            // check length out of range
            Assert.That (() => array.RemoveRange (8, 2),
                Throws.InstanceOf<ArgumentOutOfRangeException> ());
        }

        [Test]
        public void TestSort ()
        {
            var compareFuncWasCalled = false;
            CompareFunc<WrappedStruct<byte>> compareFunc = (a, b) => {
                compareFuncWasCalled = true;
                return a.Value.CompareTo (b.Value);
            };
            // check basic operation
            var array = new ByteArray (new byte[10]);
            array.Sort (compareFunc);
            Assert.That (compareFuncWasCalled);
            // null argument is not allowed
            Assert.That (() => array.Sort (null),
                Throws.InstanceOf<ArgumentNullException> ());
        }

        [Test]
        public void TestSetSize ()
        {
            // check basic operation
            var array = new ByteArray (new byte[10]);
            array.SetSize (5);
            Assert.That (array.Length, Is.EqualTo (5));
            // negitive value now allowed
            Assert.That (() => array.SetSize (-1),
                Throws.InstanceOf<ArgumentOutOfRangeException> ());
        }
    }
}
