using System;

namespace math_apps
{
    internal class Swap
    {
        static void Main(string[] args)
        {
            Console.Write("First  Value : ");
            string firstValue = Console.ReadLine();

            Console.Write("Second Value : ");
            string secondValue = Console.ReadLine();

            (secondValue, firstValue) = (firstValue, secondValue);

            Console.WriteLine($"First  Value : {firstValue}");
            Console.WriteLine($"Second Value : {secondValue}");
        }
    }
}