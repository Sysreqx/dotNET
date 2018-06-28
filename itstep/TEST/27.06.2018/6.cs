using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 6
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Random rnd = new Random();
            int x = rnd.Next(1, 31), y = 0;
            string l;
            while (x != y)
            {
                l = Console.ReadLine();
                y = int.Parse(l);
                if (x == y)
                    Console.WriteLine("You are win");
                else if (x > y)
                    Console.WriteLine("Number is smaller than secret number");
                else
                    Console.WriteLine("Number is bigger than secret number");
            }

            Console.ReadKey();
        }
    }
}
