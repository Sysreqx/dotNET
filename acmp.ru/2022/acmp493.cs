using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Считать первую строку, инициировать переменные
            string s = Console.ReadLine();
            string[] n_m = s.Split(' ');
            int n = Convert.ToInt32(n_m[0]);
            int m = Convert.ToInt32(n_m[1]);

            // Считать оставшиеся строки и определить поле
            string[,] field = new string[n,m];
            string tmp;
            for (int i = 0; i < n; i++)
            {
                tmp = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    field[i, j] = tmp.Substring(j, 1);
                }
            }

            int innerCnt = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i, j] != "*")
                    {
                        // верхняя левая ячейка
                        if (i == 0 && j == 0)
                        {
                            // справа, снизу
                            if (field[i, j + 1] != "*" && 
                                field[i + 1, j] != "*") 
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // верхняя правая ячейка
                        if (i == 0 && j == m - 1)
                        {
                            // слева, снизу
                            if (field[i, j - 1] != "*" && 
                                field[i + 1, j] != "*")  
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // нижняя левая ячейка
                        if (i == n - 1 && j == 0)
                        {
                            // справа, сверху
                            if (field[i, j + 1] != "*" &&
                                field[i - 1, j] != "*")
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // нижняя правая ячейка
                        if (i == n - 1 && j == m - 1)
                        {
                            // слева, сверху
                            if (field[i, j - 1] != "*" &&
                                field[i - 1, j] != "*")

                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // верхние не первая и не посленяя ячейка
                        if (i == 0 && j != 0 && j != m - 1)
                        {
                            // справа, снизу, слева
                            if (field[i, j + 1] != "*" &&
                                field[i + 1, j] != "*" &&
                                field[i, j - 1] != "*")
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // левая не верхняя и не нижняя ячейка
                        if (i != 0 && i != n - 1 && j == 0)
                        {
                            // сверху, снизу, справа
                            if (field[i - 1, j] != "*" &&
                                field[i + 1, j] != "*" &&
                                field[i, j + 1] != "*")
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // центральные ячейки
                        if (i != 0 && i != n - 1 && j != 0 && j != m - 1)
                        {
                            // сверху, справа, снизу, слева
                            if (field[i - 1, j] != "*" &&
                                field[i, j + 1] != "*" &&
                                field[i + 1, j] != "*" &&
                                field[i, j - 1] != "*")
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // правая не верхняя и не нижняя ячейка
                        if (i != 0 && i != n - 1 && j == m - 1)
                        {
                            // слева, снизу, сверху
                            if (field[i, j - 1] != "*" &&
                                field[i + 1, j] != "*" &&
                                field[i - 1, j] != "*")
                            {
                                innerCnt++;
                                continue;
                            }
                        }

                        // нижние центральные ячейки
                        if (i == n - 1 && j != 0 && j != m - 1)
                        {
                            // сверху, слева, справа
                            if (field[i - 1, j] != "*" &&
                                field[i, j - 1] != "*" &&
                                field[i, j + 1] != "*")
                            {
                                innerCnt++;
                                continue;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(innerCnt);
        }
    }
}
