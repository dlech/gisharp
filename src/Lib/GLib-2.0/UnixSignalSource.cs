// SPDX-License-Identifier: MIT
// Copyright (c) 2016-2021 David Lechner <david@lechnology.com>

using System;

namespace GISharp.Lib.GLib
{
    unsafe partial class UnixSignalSource
    {
        const int SIGHUP = 1;
        const int SIGINT = 2;
        const int SIGQUIT = 3;

        static partial void CheckNewArgs(int signum)
        {
            if (signum != SIGHUP && signum != SIGINT && signum != SIGQUIT) {
                throw new ArgumentException("Only SIGHUP, SIGINT, SIGQUIT allowed", nameof(signum));
            }
            // TODO: add check for SIGUSR1, SIGUSR2, SIGWINCH based on runtime version
        }
    }
}
