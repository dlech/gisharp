#!/bin/sh
#
# This must be run after ./update-generated.sh and before adding any of the
# changes to the git index.

set -e

changed_files=$(git diff --name-status --ignore-cr-at-eol 2>/dev/null | cut -f2 | grep Generated.xmldoc)

for f in $changed_files; do
    code --diff $f $(echo $f | sed 's/\.Generated//')
done
