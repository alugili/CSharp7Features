using System;
using System.Collections.Generic;

namespace TestRosylnFeatures
{
  public static class LocalFunctions
  {
    public static void BasicExample()
    {
      // Lambda Function
      Action lambdaFun = () => Console.WriteLine("I'm Lambda");
      lambdaFun.Invoke();

      // Local Functions Basic
      void EmptyLocalFunction()
      {
        Console.WriteLine("I'm Local");
      };

      EmptyLocalFunction();
    }


    // Use case 1) A better error handling
    public static IEnumerable<char> AlphabetSubsequence(char start, char end)
    {
      if (end <= start)
      {
        throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
      }

      for (var c = start; c < end; c++)
      {
        yield return c;
      }
    }


    public static IEnumerable<char> AlphabetSubsequenceWithLocal(char start, char end)
    {
      if (end <= start)
      {
        throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
      }

      return AlphabetSubsequenceWithLocalCore();

      IEnumerable<char> AlphabetSubsequenceWithLocalCore()
      {
        for (var c = start; c < end; c++)
        {
          yield return c;
        }
      }
    }


    // Use case 2) Replacement for the recursion
    public static int GetFactorial(int number)
    {
      if (number < 0)
      {
        throw new ArgumentException("negative number", nameof(number));
      }

      return number == 0 ? 1 : number * GetFactorial(number - 1);
    }


    public static long GetFactorialUsingLocal(int number)
    {
      if (number < 0)
      {
        throw new ArgumentException("negative number", nameof(number));
      }
      else if (number == 0)
      {
        return 1;
      }

      var result = number;
      while (number > 1)
      {
        Multiply(number - 1);
        number--;
      }

      void Multiply(int x)
      {
        result = result * x;
      }

      return result;
    }


    // Closures
    public static void ClosuresDemo()
    {
      var localFunctions = new List<Action>();

      for (var outer = 0; outer < 3; outer++)
      {
        void LocalFunction()
        {
          Console.WriteLine(outer); // outer is 0, 1, 2.
        }
        localFunctions.Add(LocalFunction);
      }

      // outer is 3.

      foreach (var localFunction in localFunctions)
      {
        localFunction(); // 3 3 3 (instead of 0 1 2)
      }
    }
  }
}