using System;
using System.Collections.Generic;
using System.Text;
using TriangleLib;

namespace TriangleGraphApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangleCalculation calc = new TriangleCalculation();

            DisplayAllGridTriangleCoordinates(calc);

            Console.WriteLine("Would you like to get the trianagle name for coordinates? (y/n) ");
            var keyInfo = Console.ReadKey();
            var enterCoordinates = keyInfo.KeyChar;

            while (enterCoordinates == 'y' || enterCoordinates == 'Y')
            {
                Console.WriteLine("Triangle is: " + GetTriangleName(calc));

                Console.WriteLine("Would you like to get the trianagle name for coordinates? (y/n) ");
                keyInfo = Console.ReadKey();
                enterCoordinates = keyInfo.KeyChar;
            }

        }

        private static string GetTriangleName(TriangleCalculation calc)
        {
            Console.WriteLine();

            List<int> xList = new List<int>();
            List<int> yList = new List<int>();

            for (int i = 1; i <= 3; i++)
            {
                int x;
                int y;
                string coordinate;

                do
                {
                    Console.WriteLine("Coordinate " + i.ToString() + " X value: ");
                    coordinate = Console.ReadLine();
                    if (int.TryParse(coordinate, out x))
                        break;

                    Console.WriteLine("Invalid value.");
                }
                while (true);
                xList.Add(x);

                do
                {
                    Console.WriteLine("Coordinate " + i.ToString() + " Y value: ");
                    coordinate = Console.ReadLine();
                    if (int.TryParse(coordinate, out y))
                        break;

                    Console.WriteLine("Invalid value.");
                }
                while (true);
                yList.Add(y);
            }

            return calc.GetTriangleName(xList, yList);
        }

        private static TriangleCalculation DisplayAllGridTriangleCoordinates(TriangleCalculation calc)
        {
            var results = calc.GetTriangleCoordinates();

            foreach (var key in results.Keys)
            {
                StringBuilder sb = new StringBuilder(key + ":  ");
                foreach (Coordinate coord in ((List < Coordinate > )results[key]))
                {
                    sb.Append("{" + coord.X.ToString() + "," + coord.Y.ToString() + "}  ");
                }

                Console.WriteLine(sb.ToString());
            }

            return calc;
        }
    }
}
