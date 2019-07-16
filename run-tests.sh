#!/bin/bash

set -e

dotnet test test/Test.Core/
dotnet test GIRepository-2.0.Test/
dotnet test test/Test.GLib-2.0/
dotnet test Gio-2.0.Test/
