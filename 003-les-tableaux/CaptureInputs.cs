using System;

namespace math_apps
{
    internal class CaptureInputs
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
            string capturedString = string.Empty;
            char? captured = null;            

            while(captured == null | captured != '.')
            {
                captured = Console.ReadKey().KeyChar;
                capturedString += captured;
            }

            Console.WriteLine();

            char[] capturedCharacters = new char[capturedString.Length];
            for (int index = 0; index < capturedString.Length; index++)
            {
                capturedCharacters[index] = capturedString[index];    
            }

            ArrayToString(ref capturedCharacters, out string toPrint);
            Console.WriteLine($"you wrote: {toPrint}");
        }
    }
}
