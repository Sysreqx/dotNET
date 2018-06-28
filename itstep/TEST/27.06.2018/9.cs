using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string l = Console.ReadLine();
            int cnt = 0;
            for (int i = 0; i < l.Length; i++)
                if (char.IsUpper(l[i]))
                    ++cnt;
            Console.WriteLine(cnt);
            Console.ReadKey();
        }
    }
}
