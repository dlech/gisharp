
using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GObject;
using GISharp.Runtime;
using NUnit.Framework;

using static GISharp.TestHelpers;

using Object = GISharp.Lib.GObject.Object;
using IAsyncResult = GISharp.Lib.Gio.IAsyncResult;

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
        readonly Object source;

        public TestAsyncResult(Object source) : this(New<TestAsyncResult>(), Transfer.Full)
        {
            this.source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public TestAsyncResult(IntPtr handle, Transfer ownership) : base(handle, ownership)
        {
        }

        Object IAsyncResult.OnGetSourceObject() => source;

        IntPtr IAsyncResult.OnGetUserData() => throw new NotImplementedException();

        bool IAsyncResult.OnIsTagged(IntPtr sourceTag) => throw new NotImplementedException();
    }
}