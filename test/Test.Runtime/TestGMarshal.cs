// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GISharp.Runtime;
using NUnit.Framework;

namespace GISharp.Test.Runtime
{
    public unsafe class GMarshalTests
    {
        [DllImport("glib-2.0", CallingConvention = CallingConvention.Cdecl)]
        private static extern void g_main_context_invoke(
            void* context,
            delegate* unmanaged[Cdecl]<void*, GISharp.Runtime.Boolean> function,
            void* data
        );

        [Test]
        public void TestUnhandledException()
        {
            g_main_context_invoke(null, &Callback, null);

            Assert.That(
                () => GMarshal.PopUnhandledException(),
                Throws.TypeOf<UnhandledException>(),
                "should raise exception from unmanaged callback"
            );

            // should have cleared exception
            GMarshal.PopUnhandledException();
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static GISharp.Runtime.Boolean Callback(void* data)
        {
            try
            {
                throw new Exception("test");
            }
            catch (Exception ex)
            {
                GMarshal.PushUnhandledException(ex);
                return GISharp.Runtime.Boolean.False;
            }
        }
    }
}
