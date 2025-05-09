using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Программа для работы с матрицами");
            Console.WriteLine("--------------------------------");
            Console.Write("Введите количество строк (N): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов (M): ");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            Console.WriteLine("\nВведите элементы матрицы:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\nВведенная матрица:");
            PrintMatrix(matrix);
            int mainDiagonalSum = CalculateMainDiagonalSum(matrix);
            int secondaryDiagonalSum = CalculateSecondaryDiagonalSum(matrix);
            Console.WriteLine($"\nСумма элементов главной диагонали: {mainDiagonalSum}");
            Console.WriteLine($"Сумма элементов побочной диагонали: {secondaryDiagonalSum}");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        static int CalculateMainDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int minDimension = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
            for (int i = 0; i < minDimension; i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }
        static int CalculateSecondaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int minDimension = Math.Min(rows, cols);
            for (int i = 0; i < minDimension; i++)
            {
                sum += matrix[i, cols - 1 - i];
            }
            return sum;
        }
    }
}
