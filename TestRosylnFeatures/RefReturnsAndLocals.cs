using System;
using System.Drawing;

namespace TestRosylnFeatures
{
    public static class RefReturnsAndLocals
    {
        public static void Examples()
        {
            var firstVar = 1;
            var secondVar = 2;
            ref var max = ref Max(ref firstVar, ref secondVar);

            max = 4;

            Console.WriteLine(secondVar);

            var location1 = new Point(1, 1);
            var location2 = new Point(2, 2);
            var location3 = new Point(3, 3);

            var array = new[] { location1, location2, location3 };

            ref Point GetItem(Point[] arrayParam, int index) => ref arrayParam[index];

            ref Point item = ref GetItem(array, 1);

            Console.WriteLine(item);
            item.X = 22;
            Console.WriteLine(array[1]);
        }


        public static ref int Max(ref int first, ref int second)
        {
            if (first > second)
            {
                return ref first;
            }
            else
            {
                return ref second;
            }
        }
    }
}