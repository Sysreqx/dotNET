using System;

namespace acmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int k = int.Parse(tokens[0]),
                m = int.Parse(tokens[1]);

            Console.WriteLine(k * k * m);
            // Console.ReadLine();
        }
    }
}
