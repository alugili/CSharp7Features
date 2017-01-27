using System;
using System.Collections.Generic;
using System.Linq;

namespace TestRosylnFeatures
{
  public static class Tuples
  {
    // Tuples are value types (structs) = Immutable
    public static void BasicExamples()
    {
      // Tuples Old C# Style vs. new tuple style
      var tuple1 = new Tuple<int, int>(1, 2);
      var tuple2 = new Tuple<int, int>(1, 2);

      // !Clean Code! No Way, very bad!!!! Readability !!!!
      var oldTuple = new Tuple<int, int>(1, 20);
      Console.WriteLine($"item1 {oldTuple.Item1}  item2 {oldTuple.Item2}");

      var valueTuple1 = (1, 2);
      var valuetyuple2 = (1, 2);

      var sumNew = (first: 1, count: 20);
      Console.WriteLine($"first {sumNew.first}  count {sumNew.count}");

      // Semantic is not changed!
      var isEqualTuple = tuple1.Equals(tuple2);
      var isEqualValueTuple = valueTuple1.Equals(valuetyuple2);

      Console.WriteLine(isEqualTuple);
      Console.WriteLine(isEqualValueTuple);

      // !!Referance comparison!! 
      var equalOperatorForTuple = tuple1 == tuple2; // ==> false
      Console.WriteLine(equalOperatorForTuple);

      // !!Compare by value!! 
      // var equalOperatorForValueTuple = valueTuple1 == valuetyuple2;  //==> true
    }


    public static void AdvancedExamples()
    {
      var crazyTuple = (Item1: 1, Item2: 20);
      Console.WriteLine($"Crazy Item order: Item1 {crazyTuple.Item1}, Item2 {crazyTuple.Item2}");

      // Local function which return a tuple (in expression body form)
      (int X, int Y) ReturnTupleFunction() => (X: 1, Y: 2);
      Console.WriteLine($"X={ReturnTupleFunction().X},  Y={ReturnTupleFunction().Y}");

      (int, int) SwapValues((int x, int y) value)
      {
        return (value.y, value.x);
      }

      (int xSwapped, int ySwapped) values = SwapValues((5, 6));

      Console.WriteLine($"x={values.xSwapped}, y={values.ySwapped}");
    }


    public static void DatabaseExample()
    {
      // Useful to query the data and fit the results into new data shapes!
      var allUsers = new List<UserEntity>
      {
        new UserEntity {Name = "Bassam",Age = 39 , Permission = Permission.Admin},
        new UserEntity {Name = "Thomas",Age = 42 , Permission = Permission.Admin},
        new UserEntity {Name = "Michel",Age = 36 , Permission = Permission.User}
      };

      var admins = GetAdmins(allUsers);

      foreach (var admin in admins)
      {
        Console.WriteLine(admin);
      }
    }


    public static IEnumerable<(string Name, int Age, string Authentication)> GetAdmins(IEnumerable<UserEntity> users)
    {
      return from user in users
             where user.Permission == Permission.Admin
             select (user.Name, user.Age, "Authenticated");
    }
  }


  public class UserEntity
  {
    public string Name { get; set; }
    public int Age { get; set; }

    public Permission Permission { get; set; }
  }


  public enum Permission
  {
    Admin,
    User
  }
}