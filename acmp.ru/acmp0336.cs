using System;
using System.Linq;

namespace acmp
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            bool[] a = new bool[204];
            a[102] = true;
            for (int i = 102, k = 0; k < s.Length; ++k)
            {
                if (s[k] == '1')
                    i++;
                if (s[k] == '2')
                    i--;

                a[i] = true;
            }

            int f = 0;
            foreach (var i in a)
                if (i == true)
                    ++f;

            Console.WriteLine(f);
            //Console.ReadLine();
        }
    }
}
