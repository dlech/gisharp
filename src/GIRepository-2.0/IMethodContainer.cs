// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019 David Lechner <david@lechnology.com>

namespace GISharp.Lib.GIRepository
{
    /// <summary>
    /// Method container.
    /// </summary>
    /// <remarks>
    /// Used on subclasses of <see cref="RegisteredTypeInfo"/> that have methods.
    /// </remarks>
    public interface IMethodContainer
    {
        InfoDictionary<FunctionInfo> Methods { get; }
    }
}
