#!/bin/sh

set -e

# macOS 10.15 hack
export DYLD_LIBRARY_PATH=/System/Library/Frameworks/ImageIO.framework/Versions/A/Resources:/usr/local/lib

dotnet test /p:CollectCoverage=true /maxcpucount:1

cd .coverage

lcov -o lcov.info \
    -a Test.Gio-2.0.info -t Gio-2.0 \
    -a Test.GIRepository-2.0.info -t GIRepository-2.0 \
    -a Test.GLib-2.0.info -t GLib-2.0 \
    -a Test.GModule-2.0.info -t GModule-2.0 \
    -a Test.GObject-2.0.info -t GObject-2.0 \
    -a Test.Gtk-4.0.info -t Gtk-4.0 \
    -a Test.Runtime.info -t Runtime \

if [ "$TRAVIS" != "true" ]; then
    genhtml lcov.info
    echo "Browse coverage at $(pwd)/index.html"
fi
