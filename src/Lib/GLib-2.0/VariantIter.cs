// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;
using System.Collections;
using System.Collections.Generic;

namespace GISharp.Lib.GLib
{
    unsafe partial class VariantIter : IEnumerator<Variant>
    {
        private Variant? current;

        /// <inheritdoc/>
        public Variant Current => current ?? throw new InvalidOperationException();

        object IEnumerator.Current => Current;

        static partial void CheckNewArgs(Variant value)
        {
            if (!value.IsContainer) {
                throw new ArgumentException("must be a container", nameof(value));
            }
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            current = NextValue();
            return current is not null;
        }

        /// <inheritdoc/>
        public void Reset() => throw new NotSupportedException();
    }
}
