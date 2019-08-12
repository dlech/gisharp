#!/bin/sh

set -e

dotnet test /p:CollectCoverage=true /maxcpucount:1

cd .coverage

lcov -o lcov.info -a core.info -t core \
    -a glib-2.0.info -t glib-2.0 \
    -a girepository-2.0.info -t girepository-2.0 \
    -a gio-2.0.info -t gio-2.0 \

if [ "$TRAVIS" != "true" ]; then
    genhtml lcov.info
    echo "Browse coverage at $(pwd)/index.html"
fi
