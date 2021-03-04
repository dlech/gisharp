#!/bin/sh

set -e

# macOS 10.15 hack
export DYLD_LIBRARY_PATH=/System/Library/Frameworks/ImageIO.framework/Versions/A/Resources:/usr/local/lib

dotnet test /p:CollectCoverage=true /maxcpucount:1

cd .coverage

lcov -o lcov.info -a core.info -t core \
    -a glib-2.0.info -t glib-2.0 \
    -a gobject-2.0.info -t gobject-2.0 \
    -a gio-2.0.info -t gio-2.0 \
    -a girepository-2.0.info -t girepository-2.0 \
    -a gmodule-2.0.info -t gmodule-2.0 \
    -a gtk-4.0.info -t gtk-4.0 \

if [ "$TRAVIS" != "true" ]; then
    genhtml lcov.info
    echo "Browse coverage at $(pwd)/index.html"
fi
