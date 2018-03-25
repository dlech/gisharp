=========================
GISharp Fixup File Format
=========================

General
=======

* Uses YAML markup, so normal YAML rules apply, e.g. ``#`` denotes comment, etc.
* The file consists of a sequence of commands (so each item in the sequence
  starts with ``-``).
* The command type is specified using a YAML local tag (so command types start
  with ``!``).
* Command parameters are given by a YAML mapping (``key    value`` pairs).
* Due to the nature of XPaths we have to use a namespace prefix always, even
  for the default namespace. Use the prefix ``gi:`` for elements in the default
  namespace, e.g. ``gi:repository/gi:namespace/gi:object[@name='MyObject']``.
* Use the ``gs:`` namespace prefix for custom elements and attributes understood
  by the code generator (see below).
* Order matters. Commands are processed in the order they appear in the file.


Custom Elements and Attributes
==============================

Elements
--------

``<gs:static-class>``
    Description
        Instructs the code generator to create a ``static partial class``. The 
        ``static-class`` element can contain ``<gi:constant>`` and ``<gi:function>``
        child elements only. Useful to group top-level functions.

Attributes
----------

``gs:access-modifiers``
    Description
        Instructs the code generator to use the specified access modifiers. The
        default is ``public`` when this attribute is not present. It can also be
        used to control inheritance.
    Values
        ``private``, ``protected``, ``internal``, ``override``, ``new``

``gs:async``
    Description
        Indicates that a method or function is async.
    Values
        ``1`` (true), ``0`` (false)

``gs:custom-arg-check``
    Description
        Specifies that a callable has a custom argument check function that
        needs to be called before invoking the unmanaged function.
    Values
        ``1`` (true), ``0`` (false)

``gs:custom-constructor``
    Description
        Specifies that the constructor should not be automatically generated.
    Values
        ``1`` (true), ``0`` (false)

``gs:default``
    Description
        Specifies the default value for a parameter. This is only valid for
        ``parameter`` elements.
    Values
        Any valid C# constant expression

``gs:finish-for``
    Description
        Links an async finish function or method to an async function or method.
    Values
        The name of a function or method in the same type with ``async="1"`` set.

``gs:params``
    Description
        Indicates that a parameter is "params"
    Values
        ``1`` (true), ``0`` (false)

``gs:pinvoke-only``
    Description
        Instructs the code generator to only generate the pinvoke method for a
        ``function``/``method``/``constructor`` element. Useful when a function
        requires complex marshaling or just need to be called internally by
        something else.
    Values
        ``1`` (true), ``0`` (false)

``gs:to-string``
    Description
        Indicates that a method fits the .NET ToString() pattern (e.g. it will
        override object.ToString()).
    Values
        ``1`` (true), ``0`` (false)

``gs:special-func``
    Description
        Indicates that a method performs a special function. These attributes
        are automatically added when a matching ``method`` element is found.
    Values
        ``ref``, ``unref``, ``free``, ``equal``, ``compare``, ``hash``, ``to_string``


Commands
========

``!add-element``
    Parameters
        ``xml``
              An XML element (can include child elements)
        ``xpath``
              An XPath to an existing element
    Description
        Adds a new element using the XML snippet ``xml`` and adds it as a child
        of the element that matches the XPath ``xpath``.

``!change-attribute``
    Parameters
        ``name``
            The name of the attribute to change
        ``regex``
              A regular expression that will be matched to the existing attribute
              value
        ``replace``
              The new value for the attribute. This can contain ``$`` substitution
              elements
        ``xpath``
              An XPath to one or more elements to modify
    Description
        Replaces the attributes in all elements matching the XPath using the
        regular expression on the current value. If an attribute does not exist,
        it will be created and the regex will run on an empty string.

``!change-element``
    Parameters
        ``new-name``
              The new name for the element
        ``xpath``
              An XPath to one or more existing elements
    Description
        Replaces the name of the elements that match the XPath with the new name.

``!move-element``
    Parameters
        ``xpath``
              An XPath to one or more existing elements
        ``new-parent-xpath``
              An XPath to an existing element
    Description
        Moves all elements that match the XPath and makes them children of the
        element that matches the new parent XPath.

``!set-attribute``
    Parameters
        ``name``
              The name of the attribute to set
        ``value``
              The new value for the attribute
        ``xpath``
              An XPath to one or more elements to modify
    Description
        Sets the attribute of the XPath elements to the given value. If the
        attribute does not exist, it will be created. Existing values will be
        overwritten.
