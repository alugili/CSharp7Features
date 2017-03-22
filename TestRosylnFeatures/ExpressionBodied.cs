using System;
using System.Drawing;

namespace TestRosylnFeatures
{
  public class ExpressionBodied
  {
    //// C# 7 expands the allowed members that can be implemented as expressions. 
    /// In C# 7, you can implement constructors, finalizers, and get and set accessors on properties and indexers. 
    public class ExpressionMembersExample
    {
      private string text;

      // Expression-bodied constructor
      public ExpressionMembersExample(string text) => this.Text = text;

      // Expression-bodied finalizer
      ~ExpressionMembersExample() => Console.Error.WriteLine("Finalized!");

      // Expression-bodied get / set accessors.
      public string Text
      {
        get => text;
        set => this.text = value ?? "Default Text";
      }
    }


    /// <summary>
    /// Multiple constructors parameters = Tuple
    /// Expression bodied in the indexers.
    /// </summary>
    public class CustomColor
    {
      private readonly Color[] customColors = { Color.Gold, Color.Green, Color.Blue, Color.Yellow, Color.Black };

      public string this[int index] => customColors[index].Name;
    }


    /// <summary>
    /// Expression bodied used in Operators Overloading.
    /// </summary>
    public class User
    {
      public string Name { get; }
      public int Age { get; set; }

      public User(string name, int age) => (this.Name, this.Age) = (name, age);

      public static User operator ++(User user) => new User(user.Name, user.Age + 10);
    }
  }
}