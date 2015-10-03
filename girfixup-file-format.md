General
-------

* Each line is a command
* Blank lines are ignored
* Lines ending with a backslash (`\`) are concatenated with the next line,
  preserving the newline character.
* Comment lines start with a hash (`#`) and are ignored
* Format of each line is: `<command> <parameters>`
* Parameters are enclosed in double quotes (`"`) and separated by whitespace
* Any quote character within the parameters should be escaped with a backslash (`\"`)
* Due to a bug in Mono(?) XPaths do not work using the default namespace, so as
  a result, you have to use the prefix `gi:` for elements in the default
  namespace, e.g. `gi:repository/gi:namespace/gi:object[@name='MyObject']`
* Use the `gs:` namespace prefix for custom elements and attributes understood
  by the parser (see below).
* Order matters


Custom Elements and Attributes
------------------------------

## Elements

static-class
: Description
    : Instructs the code generator to create a `static partial class`. The 
      `static-class` element can contain `constant` and `function` child elements
      only. Useful to group top-level functions.

## Attributes

access-modifier
: Description
    : Instructs the code generator to use the specified access modifiers. The
      default is `public` when this attribute is not present.
: Values
    : `private`, `protected`, `internal`, `protected internal`

default
: Description
    : Specifies the default value for a parameter. This is only valid for
      `parameter` elements.
: Values
    : Any valid C# expression

managed-type
: Description
    : Stores the managed type that will be used for an element. The value is
      automatically generated.
: Values
    : Any valid C# type identifier

opaque
: Description
    : Indicates that a record is an opaque type rather than a struct. These
      attributes are automatically added when a matching `record` element is
      found.
: Values
    : `ref-counted`, `owned`, `static`

pinvoke-only
: Description
    : Instructs the code generator to only generate the pinvoke method for a
      `function`/`method`/`constructor` element. Useful when a function requires
      complex marshaling or just need to be called internally by something else.
: Values
    : `1` (true), `0` (false)

special-func
: Description
    : Indicates that a method performs a special function. These attributes
      are automatically added when a matching `method` element is found.
: Values
    : `ref`, `unref`, `free`, `equal`, `compare`, `hash`, `to_string`

Commands
--------

addelement
: Syntax
    : `addelement "<xml>" "<xpath>"`
: Description
    : Adds a new element using the XML snippet `<xml>` and adds it as a child
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

chelement
: Syntax
    : `chelement "<new-name>" "<xpath>"`
: Description
    : Replaces the name of the elements that match `<xpath>` with `<new-name>`.

move
: Syntax
    : `move "<from-xpath>" "<to-xpath>"`
: Description
    : Moves all elements that match the XPath `<from-xpath>` and makes them
      children of the (first) element that matches the XPath `<to-xpath>`.
