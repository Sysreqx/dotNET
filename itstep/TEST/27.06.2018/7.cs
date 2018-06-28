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
            int x = rnd.Next(1, 31), y = 0, cnt = rnd.Next(9, 20), bet, p, m = cnt * 10;
            string l = Console.ReadLine();
            bet = int.Parse(l);
            p = int.Parse(l) * 2 / 100;
            while (x != y)
            {
                l = Console.ReadLine();
                y = int.Parse(l);
                if (x == y)
                {
                    Console.WriteLine("You are Win {0} $", bet * m);
                }
                else if (x > y)
                    Console.WriteLine("Number is smaller than secret number");
                else
                    Console.WriteLine("Number is bigger than secret number");
                bet /= 2;
                m -= 10;
                if (bet < p || bet * m <= 0)
                {
                    Console.WriteLine("You are Loose");
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
