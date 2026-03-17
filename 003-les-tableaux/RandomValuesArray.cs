using System;

namespace math_apps
{
    internal class RandomValuesArray
    {
        static void ReadIntInput(out int length)
        {
            string input = "";
            while (int.TryParse(input, out length) == false)
            {
                Console.Write("array length : ");
                input = Console.ReadLine();
            }
        }
        static void ArrayToString<T>(
            ref T[] objects,
            out string outputString
        )
        {
            outputString = "[";
            for (int index = 0; index < objects.Length; index++)
            {
                outputString += index != objects.Length - 1 ? $"\"{objects[index]}\", " : $"\"{objects[index]}\"]";
            }
        }
        static void Main()
        {
            ReadIntInput(out int length);

            int[] values = new int[length];
            Random random = new();

            for (int index = 0; index < length; index++)
            {
                values[index] = random.Next(0, 25);
            }

            ArrayToString(ref values, out string stringToPrint);
            Console.WriteLine(stringToPrint);
        }
    }
}
