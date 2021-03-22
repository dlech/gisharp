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
            this.longName = longName;
            this.shortName = (sbyte)shortName;
            this.flags = (int)flags;
            this.arg = arg;
            this.argData = argData;
            this.description = description;
            this.argDescription = argDescription;
        }
    }
}
