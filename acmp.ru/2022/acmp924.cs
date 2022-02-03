using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] arr1 = new string[4, 4];

            string lines;
            // Считать строки и занести в массив
            for (int i = 0; i < 4; i++)
            {
                lines = Console.ReadLine(); // Считывает по одной строке
                for (int j = 0; j < 4; j++)
                {
                    arr1[i, j] = lines.Substring(j, 1);
                }
            }

            // Проверить узор на симпатичность
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr1[i, j] == arr1[i, j + 1] && // кубик справа
                        arr1[i, j] == arr1[i + 1, j] && // кубик снизу слева
                        arr1[i, j] == arr1[i + 1, j + 1])    // кубик снизу справа
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }

            Console.WriteLine("Yes");

        }
    }
}
