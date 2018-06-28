using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 4
namespace Test
{
    class Program
    {
        static string anySys(int n, int m)
        {
            string s = "";

            if (n == 0)
                return s;

            if (m < 10)
                s += anySys(n / m, m) + (n % m).ToString();
            else
            {
                if (n % m < 10)
                    s += anySys(n / m, m) + (n % m).ToString();
                else
                    s += anySys(n / m, m) + (Convert.ToChar(n % m + 55)).ToString();
            }
            return s;
        }

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int a = int.Parse(line);
            line = Console.ReadLine();
            int b = int.Parse(line);
            string q, w, e, r, t, y, u, o;
            for (int i = 2; i < 17; i++)
            {
                q = anySys(a, i);
                w = anySys(b, i);
                e = anySys(a + b, i);
                r = anySys(a - b, i);
                t = anySys(a * b, i);
                y = anySys(a / b, i);
                u = anySys(a % b, i);
                o = anySys(Convert.ToInt32(Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b))), i);

                Console.WriteLine(i);
                Console.WriteLine($"{q} + {w} = {e}");
                Console.WriteLine($"{q} - {w} = {r}");
                Console.WriteLine($"{q} * {w} = {t}");
                Console.WriteLine($"{q} / {w} = {y}");
                Console.WriteLine($"{q} % {w} = {u}");
                Console.WriteLine($"{q} ^ {w} = {o}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
