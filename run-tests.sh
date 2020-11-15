#!/bin/bash

set -e

# macOS 10.15 hack
export DYLD_LIBRARY_PATH=/System/Library/Frameworks/ImageIO.framework/Versions/A/Resources:/usr/local/lib

export GenerateFullPaths=true

dotnet test --blame test/Test.Core/
dotnet test --blame test/Test.GIRepository-2.0/
dotnet test --blame test/Test.GLib-2.0/
dotnet test --blame test/Test.Gio-2.0/
dotnet test --blame test/Test.Gtk-4.0/
