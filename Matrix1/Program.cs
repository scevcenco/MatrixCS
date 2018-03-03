using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Matrix1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1, arr2;
            int columns, rows;
            Console.WriteLine("Если хочешь сумму матриц - нажми S, если произведение - жми M, а если разность - любую клавишу");
            ConsoleKey flag1 = Console.ReadKey().Key;
            bool flagOperation = flag1 != ConsoleKey.M;
            do
            {
                rows = UserInput("Сколько строк в первой матрице?");
                columns = UserInput("Сколько столбцов в первой матрице?");
                arr1 = new int[rows, columns];
                rows = UserInput("Сколько строк во второй матрице?");
                columns = UserInput("Сколько столбцов во второй матрице?");
                arr2 = new int[rows, columns];
            }
            while (!CheckSize(arr1, arr2, flagOperation));
            Console.WriteLine("Первая матрица");
            Fill(arr1);
            PrintScreen(arr1);
            Console.WriteLine("Вторая матрица");
            Thread.Sleep(1);
            Fill(arr2);
            PrintScreen(arr2);


            if (flag1 == ConsoleKey.S)
            {
                Console.WriteLine("Сумма матриц");
                int[,] arrSum = Addition(arr1, arr2);
                PrintScreen(arrSum);
            }
            else if (flag1 == ConsoleKey.M)
            {
                Console.WriteLine("Произведение матриц");
                int[,] arrMult = Multiplication(arr1, arr2);
                PrintScreen(arrMult);
            }
            else
            {
                Console.WriteLine("Разность матриц");
                int[,] arrDif = Difference(arr1, arr2);
                PrintScreen(arrDif);
            }
            Console.ReadLine();
        }

        private static void PrintScreen(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == array.GetLength(1) - 1)
                    {
                        Console.WriteLine(array[i, j]);
                    }
                    else
                        Console.Write(array[i, j] + "\t");
                }
            }
        }
        private static void Fill(int[,] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(-100, 100);
                }
            }
        }
        private static int UserInput(string Disclaimer)
        {
            int number = 0;
            bool flag;
            Console.WriteLine(Disclaimer);
            do
            {
                flag = int.TryParse(Console.ReadLine(), out number);
                if (!flag)
                    Console.WriteLine("Введи нормально, ну");
            } while (!flag);
            return number;
        }
        private static int[,] Addition(int[,] arr1, int[,] arr2)
        {
            int[,] sum = new int[arr1.GetLength(0), arr1.GetLength(1)];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    sum[i, j] = arr1[i, j] + arr2[i, j];
                }
            }
            return sum;
        }
        private static int[,] Difference(int[,] arr1, int[,] arr2)
        {
            int[,] dif = new int[arr1.GetLength(0), arr1.GetLength(1)];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    dif[i, j] = arr1[i, j] - arr2[i, j];
                }
            }
            return dif;
        }
        private static int[,] Multiplication(int[,] arr1, int[,] arr2)
        {
            int[,] mult = new int[arr1.GetLength(0), arr1.GetLength(1)];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    mult[i, j] = arr1[i, j] * arr2[j, i];
                }
            }
            return mult;
        }
        private static bool CheckSize(int[,] arr1, int[,] arr2, bool flagCheck)
        {
            if (flagCheck == true)
                return (arr1.GetLength(0) == arr2.GetLength(0) && arr1.GetLength(1) == arr2.GetLength(1));
            else
                return (arr1.GetLength(0) == arr2.GetLength(1) && arr1.GetLength(1) == arr2.GetLength(0));
        }

    }
}
