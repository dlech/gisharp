// SPDX-License-Identifier: MIT
// Copyright (c) 2015-2019,2021 David Lechner <david@lechnology.com>

using GISharp.Lib.GIRepository;
using NUnit.Framework;

// no namespace, so that this applies to all tests in the assembly
#pragma warning disable CA1050
public class Setup : GISharp.Test.Setup
{
    [OneTimeSetUp]
    public void SetupRepository()
    {
        Repository.Default.Require("Gio", "2.0");
    }
}
#pragma warning restore CA1050
