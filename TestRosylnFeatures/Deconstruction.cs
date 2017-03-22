using System;

namespace TestRosylnFeatures
{
  public static class Deconstruction
  {
    public static void DeconstructionFirstExample()
    {
      var (hour, min, second) = DateTime.Now;
      Console.WriteLine(hour);

      var (hourTmp, minTmp) = DateTime.Now;
      Console.WriteLine(hourTmp);
    }

    public static void Deconstruct(this DateTime dateTime, out int hour, out int minute, out int second)
    {
      hour = dateTime.Hour;
      minute = dateTime.Minute;
      second = dateTime.Second;
    }

    public static void Deconstruct(this DateTime dateTime, out int hour, out int minute)
    {
      hour = dateTime.Hour;
      minute = dateTime.Minute;
    }

    public static void DeconstructionSecondExample()
    {
      var myDateTime = new MyDateTime(10, 5, 3);

      (int hour, int minute, int second) = myDateTime;
      Console.WriteLine(minute);
    }
  }


  public class MyDateTime
  {
    public int Hour { get; }

    public int Minute { get; }

    public int Second { get; }


    public MyDateTime(int hour, int minute, int second)
    {
      this.Hour = hour;
      this.Minute = minute;
      this.Second = second;
    }

    public void Deconstruct(out int hour, out int minute, out int second)
    {
      hour = this.Hour;
      minute = this.Minute;
      second = this.Second;
    }

    public void Deconstruct(out int hour, out int minute)
    {
      hour = this.Hour;
      minute = this.Minute;
    }
  }
}