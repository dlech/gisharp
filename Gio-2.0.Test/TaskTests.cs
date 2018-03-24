
using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using NUnit.Framework;

using static GISharp.TestHelpers;

namespace GISharp.Test.Gio
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void TestNew()
        {
            using (var task = new Task(null, null)) {
                Assert.That(task.SourceObject, Is.Null);
            }

            AssertNoGLibLog();
        }

        [Test]
        public void TestPriority()
        {
            using (var task = new Task(null, null)) {
                task.Priority = Priority.Low;
                Assert.That(task.Priority, Is.EqualTo(Priority.Low));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestCheckCancellable()
        {
            using (var task = new Task(null, null)) {
                task.CheckCancellable = false;
                Assert.That(task.CheckCancellable, Is.False);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestReturnOnCancel()
        {
            using (var task = new Task(null, null)) {
                Assert.That(task.SetReturnOnCancel(true), Is.True);
                Assert.That(task.ReturnOnCancel, Is.True);
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestSourceTag()
        {
            using (var task = new Task(null, null)) {
                var expected = new IntPtr(5);
                task.SourceTag = expected;
                Assert.That(task.SourceTag, Is.EqualTo(expected));
            }
            AssertNoGLibLog();
        }

        [Test]
        public void TestReportError()
        {
            Task.ReportError(null, null, IntPtr.Zero, new Error(IOErrorEnum.Failed, "test error"));
            AssertNoGLibLog();
        }

        [Test]
        public void TestCancellable()
        {
            using (var c = new Cancellable())
            using (var task = new Task(null, null, cancellable: c)) {
                Assert.That(task.Cancellable, Is.SameAs(c));
            }
            AssertNoGLibLog();
        }
    }
}
