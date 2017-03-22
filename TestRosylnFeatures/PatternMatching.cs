using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestRosylnFeatures
{
  public static class PatternMatching
  {
    // C# 7.0 introduces the notion of patterns, which, abstractly speaking, are syntactic elements that can test that a value has a certain “shape”, 
    // and extract information from the value when it does.

    // 1) Constant patterns of the form c (where c is a constant expression in C#), which test that the input is equal to c
    // 2) Type patterns of the form T x (where T is a type and x is an identifier), which test that the input has type T, and if so, extracts the value of the input into a fresh variable x of type T
    // 3) Var patterns of the form var x (where x is an identifier), which always match, and simply put the value of the input into a fresh variable x with the same type as the input.
    public static void BasicExample()
    {
      // Constant patterns
      var myInt = 5;
      var constatPatternInt = myInt is 5;
      Console.WriteLine(constatPatternInt);

      var myText = "Type matched!";
      var constatPatternRef = myText is null;
      Console.WriteLine(constatPatternRef);

      // Type patterns
      if (myInt is int copiedValue)
      {
        Console.WriteLine($"I can use the copied value: {copiedValue}");
      }

      if (myText is string myTextCopied && myTextCopied.StartsWith("Type"))
      {
        Console.WriteLine($"I can use the copied value: {myTextCopied}");
      }
      var user = new ExpressionBodied.User("Bassam", 40);

      // Var patterns
      if (user is var refCopiedUser)
      {
        Console.WriteLine($"it's a var pattern with the type {refCopiedUser.Name}");
      }

      object magicNumber = 42;
      switch (magicNumber)
      {
        case string newString:
          Console.WriteLine($"{newString} is a string of length {myText.Length}");
          break;

        case int i when i > 40:
          Console.WriteLine($"{magicNumber} is an {(i % 2 == 0 ? "even" : "odd")} int");
          break;

        default:
          Console.WriteLine($"{magicNumber} is something else");
          break;
      }
    }


    public static void AdvancedExample()
    {
      IEnumerable<object> items = new Collection<object>
      {
        1,2, null, new ExpressionBodied.User("Fadi", 5) , 2 , 5, 0 , new Collection<object> {3,2} , new Collection<object>()
      };

      Console.WriteLine(Sum(items));
    }


    public static int Sum(IEnumerable<object> values)
    {
      var sum = 0;
      foreach (var item in values)
      {
        switch (item)
        {
          case 0:
            break;

          case int val:
            sum += val;
            break;

          //  The order of case clauses now matters!
          case IEnumerable<object> subList when subList.Any():
            sum += Sum(subList);
            break;

          case IEnumerable<object> subList:
            break;

          case null:
            break;

          case var varPattern when varPattern is ExpressionBodied.User copiedUser && copiedUser.Age > 0:
            {
              sum += copiedUser.Age;
            }
            break;

          // The default clause is always evaluated last!
          default:
            throw new InvalidOperationException("unknown item type");
        }
      }
      return sum;
    }

  }
}