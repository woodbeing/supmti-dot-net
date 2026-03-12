
using System;

namespace math_apps
{
    internal class BinaryConvert
    {
        static void Main(string[] args)
        {
            string stringValue = "";

            while (!stringValue.Contains("."))
            {
                Console.Write("Enter a decimal value split with '.' ex (12.999): ");
                stringValue = Console.ReadLine();
            }

            string[] intValues = stringValue.Split('.');

            int integerPart = int.Parse(intValues[0]);
            double fractionalPart = double.Parse("0." + intValues[1]);

            string integerBinary = Convert.ToString(integerPart, 2);

            string fractionalBinary = "";

            int precision = 10;
            while (fractionalPart > 0 && precision > 0)
            {
                fractionalPart *= 2;
                if (fractionalPart >= 1)
                {
                    fractionalBinary += "1";
                    fractionalPart -= 1;
                }
                else
                {
                    fractionalBinary += "0";
                }
                precision--;
            }

            string result = fractionalBinary.Length > 0
                ? $"{integerBinary}.{fractionalBinary}"
                : integerBinary;

            Console.WriteLine($"Binaire : {result}");
        }
    }
}