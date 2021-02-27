// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System.Collections.Generic;
using GISharp.Runtime;

namespace GISharp.Lib.GIRepository
{
    partial class CallableInfo
    {
        IndexedCollection<ArgInfo>? args;

        /// <summary>
        /// Obtain information about the arguments of this callable.
        /// </summary>
        public IndexedCollection<ArgInfo> Args {
            get {
                if (args is null) {
                    args = new(GetNArgs, GetArg);
                }
                return args;
            }
        }

        /// <summary>
        /// Iterate over all attributes associated with the return value.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> ReturnAttributes {
            get {
                var iter = default(AttributeIter);
                while (TryIterateReturnAttributes(ref iter, out var name, out var value)) {
                    yield return new KeyValuePair<string, string>(name, value);
                }
            }
        }
    }
}
