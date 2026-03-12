using System;

namespace math_apps
{
    internal class Addition
    {
        static void Main(string[] args)
        {
            string numberOne = "";
            string numberTwo = "";

            decimal parsedNumberOne;
            decimal parsedNumberTwo;

            while (decimal.TryParse(numberOne, out parsedNumberOne) == false)
            {
                Console.Write("First Number : ");
                numberOne = Console.ReadLine();
            }

            while (decimal.TryParse(numberTwo, out parsedNumberTwo) == false)
            {
                Console.Write("Second Number : ");
                numberTwo = Console.ReadLine();
            }

            decimal sum = parsedNumberOne + parsedNumberTwo;
            Console.WriteLine($"{parsedNumberOne} + {parsedNumberTwo} = {sum}");
        }
    }
}
