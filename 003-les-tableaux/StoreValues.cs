using System;

namespace math_apps
{
    internal class StoreValues
    {
        static void ArrayToString(ref object[] stringList, out string toPrint)
        {
            toPrint = "[";
            for (int index = 0; index < stringList.Length; index++)
            {
                toPrint += index != stringList.Length - 1 ? $"\"{stringList[index]}\", " : $"\"{stringList[index]}\"]";
            }
        }
        static void Main()
        {
            object[] values = ["1", "2", "3", "4", 5, 2.2, true];
            ArrayToString(ref values, out string stringToPrint);
            Console.WriteLine(stringToPrint);
        }
    }
}
