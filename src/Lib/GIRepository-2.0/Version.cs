// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

namespace GISharp.Lib.GIRepository
{
    partial class Version
    {
        /// <summary>
        /// The version of the library that was used at compile time.
        /// </summary>
        /// <value>The compile time version.</value>
        public static System.Version CompileTime =>
            new(compileTimeMajorVersion, compileTimeMinorVersion, compileTimeMicroVersion, 0);

        /// <summary>
        /// The version of the library linked against at run time.
        /// </summary>
        /// <value>The run time.</value>
        public static System.Version RunTime =>
            new((int)RunTimeMajorVersion, (int)RunTimeMinorVersion, (int)RunTimeMicroVersion, 0);
    }
}
