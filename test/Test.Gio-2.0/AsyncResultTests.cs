
using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

using Object = GISharp.Lib.GObject.Object;
using IAsyncResult = GISharp.Lib.Gio.IAsyncResult;
using System.ComponentModel;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class AsyncResultTests
    {
        [Test]
        public void TestGetSourceObject()
        {
            using (var source = new Object())
            using (var ar = new TestAsyncResult(source)) {
                Assert.That(ar.GetSourceObject(), Is.SameAs(source));
            }
            AssertNoGLibLog();
        }
    }

    [GType]
    class TestAsyncResult : Object, IAsyncResult
    {
        readonly Object? source;

        public TestAsyncResult(Object? source) : this(New<TestAsyncResult>(), Transfer.Full)
        {
            this.source = source;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TestAsyncResult(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        Object? IAsyncResult.DoGetSourceObject() => source;

        IntPtr IAsyncResult.DoGetUserData() => throw new NotImplementedException();

        bool IAsyncResult.DoIsTagged(IntPtr sourceTag) => throw new NotImplementedException();
    }
}
