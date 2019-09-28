#!/bin/bash

set -e

export GenerateFullPaths=true

dotnet test test/Test.Core/
dotnet test test/Test.GIRepository-2.0/
dotnet test test/Test.GLib-2.0/
dotnet test test/Test.Gio-2.0/
