using System.Linq;
using System.Threading.Tasks;

namespace TestRosylnFeatures
{
  public static class GeneralizedAsyncReturn
  {
    public static async Task<int> ClassicTask(int[] numbers)
    {
      if (!numbers.Any())
      {
        return 0;
      }
      else
      {
        return await Task.Run(() => numbers.Sum());
      }
    }


    public static async ValueTask<int> ValueTask(int[] numbers)
    {
      if (!numbers.Any())
      {
        return 0;
      }
      else
      {
        return await Task.Run(() => numbers.Sum());
      }
    }


    public static async Task<int> ClassicTaskTemp(int[] numbers)
    {
      if (!numbers.Any())
      {
        return await Task.Run(() => 0);
      }
      else
      {
        return await Task.Run(() => numbers.Sum());
      }
    }
  }
}