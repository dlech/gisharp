// SPDX-License-Identifier: MIT
// Copyright (c) 2018-2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GLib;
using NUnit.Framework;

namespace GISharp.Test.GLib
{
    public class OptionGroupTests
    {
        [Test]
        public void TestAddEntries()
        {
            var arg1 = default(bool);
            var arg2 = default(int);
            var arg3 = default(string);
            var arg4 = default(Strv<Utf8>);
            var arg5 = default(Filename);
            var arg6 = default(Strv<Filename>);
            var arg7 = default(double);
            var arg8 = default(string);

            var callback = new OptionArgFunc((n, v) => {
                arg8 = v;
            });

            using var og = new OptionGroup("test-group", "group desc", "help desc");
            og.AddFlag("flag", 'f', a => arg1 = a, "test boolean flag");
            og.AddInt("int", 'i', a => arg2 = a, "test integer arg", "VALUE");
            og.AddString("str", 's', a => arg3 = a, "test string arg", "VALUE");
            og.AddStringArray("strv", 't', a => arg4 = a, "test string array arg", "VALUE [VALUE ...]");
            og.AddFilename("filename", 'f', a => arg5 = a, "test filename arg", "VALUE");
            og.AddFilenameArray("filenamev", 'g', a => arg6 = a, "test filename array arg", "VALUE [VALUE ...]");
            og.AddDouble("double", 'd', a => arg7 = a, "test double arg", "VALUE");
            og.AddCallback("callback", 'c', callback, "test callback arg", "VALUE");
        }

        [Test]
        public void TestSetTranslateFunc()
        {
            var translate = new TranslateFunc(s => s.ToString().Normalize());
            using var og = new OptionGroup("test-group", "group desc", "help desc");
            og.SetTranslateFunc(translate);
            og.SetTranslateFunc(null);
        }

        [Test]
        public void TestSetTranslationDomain()
        {
            using var og = new OptionGroup("test-group", "group desc", "help desc");
            og.SetTranslationDomain("domain");
        }
    }
}
