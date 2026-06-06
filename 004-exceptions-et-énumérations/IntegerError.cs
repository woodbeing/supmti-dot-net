using System;

class MatrixRotator
{
    enum RotationType
    {
        Droit,
        Gauche,
    }
    static void Main()
    {
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("Matrice Original :");
        InprimerMatrix(matrix);

        Console.WriteLine("\nMatrice Rotation 270° Droit :");
        Rotation270(matrix, RotationType.Droit, out int[,] rotationDroit);
        InprimerMatrix(rotationDroit);

        Console.WriteLine("\nMatrice Rotation 270° Gauche :");
        Rotation270(matrix, RotationType.Gauche, out int[,] rotationGauche);
        InprimerMatrix(rotationGauche);
    }

    static void Rotation270(int[,] matrix, RotationType typeDeRotation, out int[,] result)
    {
        int n = matrix.GetLength(0);
        result = new int[n, n];

        switch (typeDeRotation)
        {
            case RotationType.Droit:
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result[n - 1 - j, i] = matrix[i, j];
                    }
                }
                break;
            case RotationType.Gauche:
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result[j, n - 1 - i] = matrix[i, j];
                    }
                }
                break;
        }
    }

    static void InprimerMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}