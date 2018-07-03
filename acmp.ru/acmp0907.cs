using System;
using System.Linq;

namespace acmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int w = int.Parse(tokens[0]),
                h = int.Parse(tokens[1]),
                r = int.Parse(tokens[2]);

            if (w >= r * 2 && h >= r * 2)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
