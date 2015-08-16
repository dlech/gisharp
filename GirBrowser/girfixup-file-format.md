General
-------

* Each line is a command
* Blank lines are ignored
* Comment lines start with a hash (`#`) and are ignored
* Format of each line is: `<command> <parameters>`
* Parameters are enclosed in double quotes (`"`) and separated by whitespace
* Any quote character within the parameters should be escaped with a backslash (`\"`)
* Due to a bug in Mono(?) XPaths do not work using the default namespace, so as
  a result, you have to use the prefix `gi:` for elements in the default
  namespace, e.g. `gi:repository/gi:namespace/gi:object[@name='MyObject']`
* Use the `gs:` namespace prefix for custom elements and attributes understood
  by the parser (elements: `static-class`; attributes: *none at this time*).
* Order matters

Commands
--------

addelement
: Syntax
    : `addelement "<xml>" "<xpath>"`
:Description
    : Adds a new element using the XML snippit `<xml>` and adds it as a child
      of the element that matches the XPath `<xpath>`.

chattr
: Syntax
    : `chattr "<attr-name>" "<regex>" "<replacement>" "<xpath>"`
: Description
    : Replaces attributes named `<attr-name>` in all elements matching the XPath
     `<xpath>` using the regular expression `<regex>` on the current value and
      replacing it with `<replacement>`. If `<regex>` is an empty string,
      the entire value will be replaced. If an attribute does not exist, it will
      be created and the regex will run on an empty string.

move
: Syntax
    : `move "<from-xpath>" "<to-xpath>"`
: Description
    : Moves all elements that match the XPath `<from-xpath>` and makes them
      children of the (first) element that matches the XPath `<to-xpath>`.
