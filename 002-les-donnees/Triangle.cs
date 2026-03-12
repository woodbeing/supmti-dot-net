using System;

namespace math_apps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = string.Empty;
            string width = string.Empty;

            int parsedNumber;
            int parsedWidth;

            while (int.TryParse(number, out parsedNumber) == false | parsedNumber > 9 | parsedNumber < 0)
            {
                Console.Write("Enter the number: ");
                number = Console.ReadLine();
            }

            while (int.TryParse(width, out parsedWidth) == false)
            {
                Console.Write("Enter the width: ");
                width = Console.ReadLine();
            }

            Console.WriteLine("\nOutput:");

            for (int row = parsedWidth; row >= 1; row--)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write(parsedNumber);
                }
                Console.WriteLine();
            }
        }
    }
}
