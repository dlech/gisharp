#!/bin/bash
#
# Open generated and fixed up docs in diff editor

set -e

if [ $# -ne 2 ]; then
    echo "requires 2 arguments"
    exit 1
fi

generated="src/Lib/$1/$2.Generated.xmldoc"
fixed="src/Lib/$1/$2.xmldoc"

if [ ! -e "$generated" ]; then
    echo "$generated does not exist"
    exit 1
fi

if [ ! -e "$fixed" ]; then
    echo "$fixed does not exist"
    exit 1
fi

code --diff "$generated" "$fixed"
