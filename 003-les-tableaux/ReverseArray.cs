using System;

namespace math_apps
{
    internal class ReverseArray
    {
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
            int[] values = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            int[] reversedValues = new int[values.Length];
            int indexedLength = values.Length - 1;

            for (int index = 0; index < values.Length; index++)
            {
                reversedValues[index] = values[indexedLength - index];
            }

            ArrayToString(ref values, out string original);
            ArrayToString(ref reversedValues, out string reversed);

            Console.WriteLine($"original: {original}");
            Console.WriteLine($"reversed: {reversed}");
        }
    }
}
