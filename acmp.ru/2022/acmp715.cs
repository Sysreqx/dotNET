using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] words = text.Split(new char[] { ' ' });

            int n = Convert.ToInt32(words[0]);
            int m = Convert.ToInt32(words[1]);

            string[,] arr = new string[n, m];

            string lines;
            for (int i = 0; i < n; i++)
            {
                lines = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = lines.Substring(j, 1);
                }
            }

            string empty_string = Console.ReadLine();
            string[,] arr2 = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                lines = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    arr2[i, j] = lines.Substring(j, 1);
                }
            }

            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr[i, j] == arr2[i, j]) counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
