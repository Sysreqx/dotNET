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

            bool flag = false;

            if (x + y == z || y + z == x || x + z == y)
                flag = true;

            if (flag == true)
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
            //Console.ReadLine();
        }
    }
}
