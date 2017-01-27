using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
  // Source: https://weblogs.asp.net/dixin/functional-csharp-14-pattern-matching
  class example
  {

    internal static DateTime ToDateTime(object @object)
    {
      switch (@object)
      {
        // Match constant @object.
        case null:
          throw new ArgumentNullException(nameof(@object));
        // Match @object type.
        case DateTime dateTIme:
          return dateTIme;
        // Match @object type with condition.
        case long ticks when ticks >= 0:
          return new DateTime(ticks);
        // Match reference type with condition.
        case string @string when DateTime.TryParse(@string, out DateTime dateTime):
          return dateTime;
        // Match reference type with condition.
        case int[] date when date.Length == 3 && date[0] >= 0 && date[1] >= 0 && date[2] >= 0:
          return new DateTime(year: date[0], month: date[1], day: date[2]);
        // Match reference type.
        case IConvertible convertible:
          return convertible.ToDateTime(null);
        case var _: // default:
          throw new ArgumentOutOfRangeException(nameof(@object));
      }
    }


    internal static DateTime CompiledToDateTime(object @object)
    {
      // case null:
      if (@object == null)
      {
        throw new ArgumentNullException("@object");
      }

      // case DateTime dateTIme:
      DateTime? nullableDateTime = @object as DateTime?;
      DateTime dateTime = nullableDateTime.GetValueOrDefault();
      if (nullableDateTime != null)
      {
        return dateTime;
      }

      // case long ticks
      long? nullableInt64 = @object as long?;
      long ticks = nullableInt64.GetValueOrDefault();
      // when ticks >= 0:
      if (nullableInt64 != null && ticks >= 0L)
      {
        return new DateTime(ticks);
      }

      // case string text 
      string @string = @object as string;
      // when DateTime.TryParse(text, out DateTime dateTime):
      if (@string != null && DateTime.TryParse(@string, out DateTime parsedDateTime))
      {
        return parsedDateTime;
      }

      // case int[] date
      int[] date = @object as int[];
      // when date.Length == 3 && date[0] >= 0 && date[1] >= 0 && date[2] >= 0:
      if (date != null && date.Length == 3 && date[0] >= 0 && date[1] >= 0 && date[2] >= 0)
      {
        return new DateTime(date[0], date[1], date[2]);
      }

      // case IConvertible convertible:
      IConvertible convertible = @object as IConvertible;
      if (convertible != null)
      {
        return convertible.ToDateTime(null);
      }

      // case var _:
      // or
      // default:
      throw new ArgumentOutOfRangeException("@object");
    }
  }
}
