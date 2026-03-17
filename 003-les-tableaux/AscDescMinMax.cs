using System;

namespace math_apps
{
    internal class AscDescMinMax
    {
        static void OrderItems<T>(
            T[] objects,
            out T[] ascending,
            out T[] descending,
            out T min,
            out T max
        ) where T : IComparable<T>
        {
            ascending = (T[])objects.Clone();
            Array.Sort(ascending);

            descending = (T[])ascending.Clone();
            Array.Reverse(descending);

            min = objects[0];
            max = objects[0];

            foreach (T item in objects)
            {
                if (item.CompareTo(min) < 0) min = item;
                if (item.CompareTo(max) > 0) max = item;
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
            int[] values = [5, 12, 10, 6, 8];

            OrderItems(values, out int[] ascending, out int[] descending, out int min, out int max);
            
            ArrayToString(ref ascending, out string ascendingToPrint);
            ArrayToString(ref descending, out string descendingToPrint);

            Console.WriteLine($"asc: {ascendingToPrint}");
            Console.WriteLine($"desc: {descendingToPrint}");
            Console.WriteLine($"min: {min}");
            Console.WriteLine($"max: {max}");
        }
    }
}
