using System;
using System.Threading.Tasks;

// Install-Package System.ValueTuple -Pre To test tuples
namespace TestRosylnFeatures
{

 //  public struct  TallyResult :ValueTuple
 //  {
 //    int Sum;
 //   int Count;
 //  }
	
  public class Program
  {
	
	  
    public static void BinaryLiteralsAndDigitsSeparators()
    {
      int binary = 0b1001_1010_1001_0100;
      Console.WriteLine(binary);

      int hex = 0x1c_a0_41_fe;
      Console.WriteLine(hex);

      var numbers = new[] { 0b0_0000000, 0b0_0000001, 0b0_0000010, 0b0_0000011 };
      foreach (var number in numbers)
      {
        Console.WriteLine(number);
      }

      double realNumber = 1_00.99_9e-1_000;
    }

    public static void LocalFunctions()
    {
      Console.WriteLine("Local Function!");
      for (int i = 0; i < 5; i++)
      {
        // Local Functions Basic
        void fx_Return_X()
        {
          Console.WriteLine(i);
        };

        fx_Return_X();
      }


      Console.WriteLine("Lambda Function!");

      for (int i = 0; i < 5; i++)
      {
        Task.Run(() => Console.WriteLine(i));
      }

      Console.ReadKey();
    }

    public static void RefReutrn()
    {
      var firstVar = 1;
      var secondVar = 2;
      Max(ref firstVar, ref secondVar) = 4;

      Console.WriteLine(secondVar);

      var array = new[] { 1, 2, 3, 4 };
      ref int GetItem(int[] arrayParam, int index) => ref arrayParam[index];

      ref int item = ref GetItem(array, 1);

      Console.WriteLine(item);
      item = 22;
      Console.WriteLine(array[1]);
    }

    public static ref int Max(ref int first, ref int second)
    {
      if (first > second)
        return ref first;
      else
        return ref second;
    }
	
	public class Test
	{
		
		Tuple<int, int> TupleTest = new Tuple<int, int>(1, 2);

		public Test()
		{
			
		}
		
		public	string MyString 
		{
			get;
			set;
		}
	}


    public static void Tuples()
    {
      // Tuples Old C# Style
      var tuple1 = (1, 2);
      var tuple2 = (1, 2);
	    
	  var tuple3 = (new Test() {MyString = "Tester"}, 2);
      var tuple4 = (new Test() {MyString = "Tester"}, 2);

      
	  var isEqualPrimtive = tuple1.Equals(tuple2);
	  var isEqualWithRef = tuple3.Equals(tuple4);

	  
	  Console.WriteLine(isEqualPrimtive);
	  Console.WriteLine(isEqualWithRef);

	  
	  // Console.WriteLine(tuple2.Item1.MyString);	

	  
      var sum = new Tuple<int, int>(1, 20);
      var first = sum.Item1;
      var count = sum.Item2;
      Console.WriteLine($"item1 {sum.Item1}  item2 {sum.Item2}");

      // Tuples C# 7 Style
      var tupleNew = (1, 2);

      var sumNew = (first: 1, count: 20);
      Console.WriteLine($"first {sumNew.first}  count {sumNew.count}");

      // Return Tuple
      (int X, int Y) ReturnTupleFunction() => (X: 1, Y: 2);
      Console.WriteLine($"X={ReturnTupleFunction().X},  Y={ReturnTupleFunction().Y}");
    }

    public static void PatternMatching()
    {
      string myText = "Type matched!";
      var s = myText is string x ? x : "not a string";

      // prints text
      Console.WriteLine(myText);

      object v = 42;
      switch (v)
      {
        case string newString:
          Console.WriteLine($"{newString} is a string of length {s.Length}");
          break;
        case int i when i > 40:
          Console.WriteLine($"{v} is an {(i % 2 == 0 ? "even" : "odd")} int");
          break;
        default:
          Console.WriteLine($"{v} is something else");
          break;
      }
    }

    static void Main(string[] args)
    {

     //// BinaryLiteralsAndDigitsSeparators literals &Digits separators
     // Console.WriteLine("**************Digits separators***************");
     // BinaryLiteralsAndDigitsSeparators();
     // Console.ReadKey();

     // // Local Functions
     // Console.WriteLine("**************Local Functions***************");
     // LocalFunctions();
     // Console.ReadKey();

     // // Ref Return
     // Console.WriteLine("************** Ref Return ***************");
     // RefReutrn();
     // Console.ReadKey();

      //// Tuples
      Console.WriteLine("************** Tuples ***************");
      Tuples();
      Console.ReadKey();

      // Pattern matching
      // Console.WriteLine("************** Pattern matching ***************");
      // PatternMatching();
      // Console.ReadKey();
    }
  }
}