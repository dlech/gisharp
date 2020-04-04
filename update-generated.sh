#!/bin/bash

set -e 

# macOS 10.15 hack
export DYLD_LIBRARY_PATH=/System/Library/Frameworks/ImageIO.framework/Versions/A/Resources:/usr/local/lib

export GenerateFullPaths=true

if [ $# -gt 0 ]; then
    projects="$@"
else
    # order matters - dependencies first
    projects="GLib-2.0 GObject-2.0 Gio-2.0"
fi

for p in $projects; do
    dotnet run --project tools/CodeGen/CodeGen.csproj -- -p src/$p -c generate
done
