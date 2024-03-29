// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>


using System;
using GISharp.Lib.Gio;
using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class TaskTests
    {
        [Test]
        public void TestNew()
        {
            using var task = new Task(null, null);
            Assert.That(task.SourceObject, Is.Null);
            task.ReturnBoolean(true);
        }

        [Test]
        public void TestPriority()
        {
            using var task = new Task(null, null);
            task.Priority = Priority.Low;
            Assert.That(task.Priority, Is.EqualTo(Priority.Low));
            task.ReturnBoolean(true);
        }

        [Test]
        public void TestCheckCancellable()
        {
            using var task = new Task(null, null);
            task.CheckCancellable = false;
            Assert.That(task.CheckCancellable, Is.False);
            task.ReturnBoolean(true);
        }

        [Test]
        public void TestReturnOnCancel()
        {
            using var task = new Task(null, null);
            Assert.That(task.SetReturnOnCancel(true), Is.True);
            Assert.That(task.ReturnOnCancel, Is.True);
            task.ReturnBoolean(true);
        }

        [Test]
        public void TestSourceTag()
        {
            using var task = new Task(null, null);
            var expected = new IntPtr(5);
            task.SourceTag = expected;
            Assert.That(task.SourceTag, Is.EqualTo(expected));
            task.ReturnBoolean(true);
        }

        [Test]
        public void TestReportError()
        {
            Task.ReportError(null, null, IntPtr.Zero, new Error(IOErrorEnum.Failed, "test error"));
        }

        [Test]
        public void TestCancellable()
        {
            using var c = new Cancellable();
            using var task = new Task(null, null, cancellable: c);
            Assert.That(task.Cancellable, Is.SameAs(c));
            Assert.That(task.CheckCancellable, Is.True);
            c.Cancel();
            Assert.That(task.ReturnErrorIfCancelled(), Is.True);
        }
    }
}
