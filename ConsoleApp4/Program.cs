﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Поиск минимального элемента в матрице");
            Console.WriteLine("--------------------------------------");
            Console.Write("Введите количество строк (N): ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов (M): ");
            int cols = int.Parse(Console.ReadLine());
            double[,] matrix = new double[rows, cols];
            Console.WriteLine("\nВведите элементы матрицы:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\nВведенная матрица:");
            PrintMatrix(matrix);
            FindMinElement(matrix, out double minValue, out int minRow, out int minCol);
            Console.WriteLine($"\nМинимальный элемент: {minValue:F2}");
            Console.WriteLine($"Находится в строке {minRow + 1}, столбце {minCol + 1}");
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],8:F2}");
                }
                Console.WriteLine();
            }
        }
        static void FindMinElement(double[,] matrix, out double minValue, out int minRow, out int minCol)
        {
            minValue = matrix[0, 0];
            minRow = 0;
            minCol = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
                }
            }
        }
    }

}
