// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.Gio;
using NUnit.Framework;

namespace GISharp.Test.Gio
{
    public class ThemedIconTests
    {
        [Test]
        public void TestNew()
        {
            using var icon = new ThemedIcon("name");
            var names = icon.Names.ToUnownedCPtrArray();
            Assert.That<string>(names[0], Is.EqualTo("name"));
            Assert.That(icon.UseDefaultFallbacks, Is.False);
        }

        [Test]
        public void TestNewFromNames()
        {
            Assert.That(() => new ThemedIcon(), Throws.ArgumentException);
            using var icon = new ThemedIcon("name1", "name2");
            var names = icon.Names.ToUnownedCPtrArray();
            Assert.That<string>(names[0], Is.EqualTo("name1"));
            Assert.That<string>(names[^1], Is.EqualTo("name2").Or.EqualTo("name2-symbolic"));
            Assert.That(icon.UseDefaultFallbacks, Is.False);
        }

        [Test]
        public void TestNewWithDefaultFallbacks()
        {
            using var icon = new ThemedIcon("name-one-two", useDefaultFallbacks: true);
            var names = icon.Names.ToUnownedCPtrArray();
            Assert.That<string>(names[0], Is.EqualTo("name-one-two"));
            Assert.That<string>(names[^1], Is.EqualTo("name").Or.EqualTo("name-symbolic"));
            Assert.That(icon.UseDefaultFallbacks, Is.True);
        }
    }
}
