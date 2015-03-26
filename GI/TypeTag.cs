using System;

namespace GI
{
  public static class TypeTagExtensions
  {
    public static bool IsBasicValueType (this TypeTag tag)
    {
      return tag < TypeTag.GType;
    }
  }
}

