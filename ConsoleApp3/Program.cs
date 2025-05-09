using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Калькулятор определителя матрицы");
            Console.WriteLine("--------------------------------");
            int n;
            do
            {
                Console.Write("Введите размерность квадратной матрицы (N x N): ");
                n = int.Parse(Console.ReadLine());
                if (n <= 0)
                    Console.WriteLine("Размерность должна быть положительным числом!");
            } while (n <= 0);
            double[,] matrix = new double[n, n];
            Console.WriteLine("\nВведите элементы матрицы:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("\nВведенная матрица:");
            PrintMatrix(matrix);
            try
            {
                double determinant = CalculateDeterminant(matrix);
                Console.WriteLine($"\nОпределитель матрицы: {determinant:F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
        static void PrintMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],10:F2}");
                }
                Console.WriteLine();
            }
        }
        static double CalculateDeterminant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                throw new ArgumentException("Матрица должна быть квадратной!");
            if (n == 1)
                return matrix[0, 0];
            if (n == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            double determinant = 0;
            for (int j = 0; j < n; j++)
            {
                double[,] minor = CreateMinor(matrix, 0, j);
                determinant += matrix[0, j] * Math.Pow(-1, j) * CalculateDeterminant(minor);
            }
            return determinant;
        }
        static double[,] CreateMinor(double[,] matrix, int rowToRemove, int colToRemove)
        {
            int n = matrix.GetLength(0);
            double[,] minor = new double[n - 1, n - 1];
            for (int i = 0, minorI = 0; i < n; i++)
            {
                if (i == rowToRemove)
                    continue;
                for (int j = 0, minorJ = 0; j < n; j++)
                {
                    if (j == colToRemove)
                        continue;
                    minor[minorI, minorJ] = matrix[i, j];
                    minorJ++;
                }
                minorI++;
            }
            return minor;
        }
    }

}
