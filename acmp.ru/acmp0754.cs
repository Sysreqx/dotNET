using System;
using System.Linq;

namespace acmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int x = int.Parse(tokens[0]),
                y = int.Parse(tokens[1]),
                z = int.Parse(tokens[2]);
            int[] a = { x, y, z };

            foreach (var i in a)
                if (i > 727 || i < 94)
                {
                    Console.WriteLine("Error");
                    return;
                }

            Console.WriteLine(a.Max());
        }
    }
}
