#!/bin/bash

set -e

# macOS 10.15 hack
export DYLD_LIBRARY_PATH=/System/Library/Frameworks/ImageIO.framework/Versions/A/Resources:/usr/local/lib

export GenerateFullPaths=true

dotnet test test/Test.Core/
dotnet test test/Test.GIRepository-2.0/
dotnet test test/Test.GLib-2.0/
dotnet test test/Test.Gio-2.0/
