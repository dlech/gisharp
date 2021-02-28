// SPDX-License-Identifier: MIT
// Copyright (c) 2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.GLib
{
    partial struct OptionEntry
    {
        internal unsafe OptionEntry(
            byte* longName,
            char shortName,
            OptionFlags flags,
            OptionArg arg,
            IntPtr argData,
            byte* description,
            byte* argDescription
        )
        {
            LongName = longName;
            ShortName = (sbyte)shortName;
            Flags = (int)flags;
            Arg = arg;
            ArgData = argData;
            Description = description;
            ArgDescription = argDescription;
        }
    }
}