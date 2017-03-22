using System;

namespace TestRosylnFeatures
{
    public class BinaryLiteralsAndDigitsSeparators
    {
        public static void Example()
        {
            int binary = 0b1001_1010_1001_0100;
            Console.WriteLine(binary);

            var hex = 0x1c_a0_41_fe;
            Console.WriteLine("{0:X8}",hex);

            var numbers = new[] { 0b0_0000000, 0b0_0000001, 0b0_0000010, 0b0_0000011 };
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            double realNumber = 1_00.99_9e-1_000;
        }
    }
}