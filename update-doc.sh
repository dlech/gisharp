#!/bin/sh
#
# This must be run after ./update-generated.sh and before adding any of the
# changes to the git index.

set -e

git diff **/*.Generated.xmldoc | sed 's/\.Generated\.xmldoc/.xmldoc/g' | git apply -3 --verbose
