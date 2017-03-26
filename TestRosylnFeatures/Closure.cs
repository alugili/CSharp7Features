using System;
using System.Threading.Tasks;

namespace TestRosylnFeatures
{
  public static class Closure
  {

    // Close together in the same classs => This make defer execution possible! and the action can
    // be later called! the public field will be changed to 5 and stay on this value.
    public static void ClosureDemo()
    {
      for (var i = 0; i < 5; i++)
      {
        Task.Factory.StartNew(() => Console.WriteLine(i));
      }

      Console.ReadLine();
    }
  }
}
