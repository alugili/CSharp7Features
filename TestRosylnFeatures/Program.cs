using System;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using TestRosylnFeatures;
using static TestRosylnFeatures.ExpressionBodied;

// Install-Package System.ValueTuple -Pre To test tuples
namespace TestRosylnFeatures
{
  public static class Program
  {
    public static void OutVarTest(string @int)
    {
      //int convertedInt;
      //var tryParsePattern = int.TryParse("5", out convertedInt);

      var isParsed = int.TryParse(@int, out int outputParam);
      if (isParsed)
      {
        Console.WriteLine(outputParam);
      }
    }

    public static double Divide(int x, int y)
    {
      return y != 0 ? x % y : throw new DivideByZeroException();
    }

    public static void Main(string[] args)
    {
      //// BinaryLiteralsAndDigitsSeparators literals & Digits separators
      //Console.WriteLine("**************Digits separators***************");
      //BinaryLiteralsAndDigitsSeparators.Example();
      //Console.ReadKey();

      //// Out Variables
      //Console.WriteLine("************** Out Varabiles***************");
      //OutVarTest("5");
      //Console.ReadKey();

      //// Local Functions
      //Console.WriteLine("************** Local Functions ***************");
      //LocalFunctions.BasicExample();
      //Console.ReadKey();

      //// Use case 1) A better error handling
      //var resultSet = LocalFunctions.AlphabetSubsequence('f', 'a');
      //// ..
      //// ..
      //// ..
      //// Error thrown here!
      //foreach (var @char in resultSet)
      //{
      //  Console.Write($"{@char}, ");
      //}
      //Console.ReadKey();

      //// Error thrown directly
      //resultSet = LocalFunctions.AlphabetSubsequenceWithLocal('f', 'a');
      //foreach (var item in resultSet)
      //{
      //  Console.WriteLine(item);
      //}
      //Console.ReadKey();

      //// Use case 2) Replacement for the recursion
      //Console.WriteLine(LocalFunctions.GetFactorial(105));
      //Console.WriteLine(LocalFunctions.GetFactorialUsingLocal(105));
      //Console.ReadKey();

      //LocalFunctions.ClosuresDemo();
      //Console.ReadKey();

      //// RefReturnsAndLocals
      //Console.WriteLine("************** Ref Returns And Locals ***************");
      //RefReturnsAndLocals.Examples();
      //Console.ReadKey();

      //// Throw expressions 
      //Console.WriteLine("************** Throw Expression ***************");
      //var divideByZeroException = Divide(10, 0);
      //Func<string, string> getFilename = filename => filename ?? throw new ArgumentNullException(paramName: nameof(filename));

      //Console.WriteLine(getFilename.Invoke("Test.txt"));
      //getFilename.Invoke(null);
      //Console.ReadKey();

      //// ExpressionMembers
      //Console.WriteLine("************** Expression Members  ***************");
      //var expressionMembers = new ExpressionMembersExample("Test Data");
      //Console.WriteLine(expressionMembers.Text);
      //Console.ReadKey();

      //var user = new User("Bassam", 40);
      //Console.WriteLine($"name: {user.Name}  age: {user.Age}");

      //user++;
      //Console.WriteLine($"name: {user.Name}  age: {user.Age}");
      //Console.ReadKey();

      //// Generalized Async Return Type
      //Console.WriteLine("************** GeneralizedAsyncReturn ***************");
      //Console.WriteLine(GeneralizedAsyncReturn.ClassicTask(new int[] { }));
      //Console.WriteLine(GeneralizedAsyncReturn.ClassicTask(new[] { 1, 2, 3 }).Result);

      //Console.WriteLine(GeneralizedAsyncReturn.ValueTask(new int[] { }));
      //Console.WriteLine(GeneralizedAsyncReturn.ValueTask(new[] { 1, 2, 3 }).Result);
      //Console.ReadKey();

      //Console.WriteLine("************** Tuples ***************");
      //Tuples.BasicExamples();
      //Tuples.AdvancedExamples();
      //Tuples.DatabaseExample();
      //Console.ReadKey();

      //// Deconstruction 
      //Console.WriteLine("************** Deconstruction ***************");
      //Deconstruction.DeconstructionFirstExample();
      //Deconstruction.DeconstructionSecondExample();
      //Console.ReadKey();

      //// Pattern matching
      //Console.WriteLine("************** Pattern matching ***************");
      //PatternMatching.BasicExample();
      //PatternMatching.AdvancedExample();
      //Console.ReadKey();
    }
  }
}