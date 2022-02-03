using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Считывание и запись чисел
            string n_m = Console.ReadLine();
            string[] n_m_arr = n_m.Split(' ');

            int n = Convert.ToInt32(n_m_arr[0]);
            int m = Convert.ToInt32(n_m_arr[1]);

            // Считывание первого массива
            string[,] arr1 = new string[n,m];
            string line;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                line = line.Replace(" ", "");
                for (int j = 0; j < m; j++)
                {
                    arr1[i,j] = line.Substring(j, 1);
                }
            }

            // Считывание второго массива
            string[,] arr2 = new string[n, m];
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                line = line.Replace(" ", "");
                for (int j = 0; j < m; j++)
                {
                    arr2[i, j] = line.Substring(j, 1);
                }
            }

            // Проверка можно вывести или нет
            int cnt = n * m;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr1[i,j] == "." ||
                        arr2[i,j] == "7")
                    {
                        cnt--;
                        continue;
                    }

                    if (arr1[i, j] == "R" &&
                        arr2[i, j] == "4" ||
                        arr2[i, j] == "5" ||
                        arr2[i, j] == "6")
                    {
                        cnt--;
                        continue;
                    }

                    if (arr1[i, j] == "G" &&
                        arr2[i, j] == "2" ||
                        arr2[i, j] == "3" ||
                        arr2[i, j] == "6")
                    {
                        cnt--;
                        continue;
                    }

                    if (arr1[i, j] == "B" &&
                        arr2[i, j] == "1" ||
                        arr2[i, j] == "3" ||
                        arr2[i, j] == "5")
                    {
                        cnt--;
                        continue;
                    }
                }
            }

            if (cnt == 0)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
