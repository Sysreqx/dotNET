using System;

namespace acmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            int n = int.Parse(tokens[0]),
                m = int.Parse(tokens[1]),
                k = int.Parse(tokens[2]);
            
            if (k <= (n * m))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
            //Console.ReadLine();
        }
    }
}
