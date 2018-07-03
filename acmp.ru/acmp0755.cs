using System;

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

            if (x + y >= z)
                Console.WriteLine(x + y - z);
            else
                Console.WriteLine("Impossible");
            //Console.ReadLine();
        }
    }
}
