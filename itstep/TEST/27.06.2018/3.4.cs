using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2
namespace Test
{
    class Program
    {
        static void Result(int a, int b, int input)
        {
            string a2 = Convert.ToString(a, input);
            string b2 = Convert.ToString(b, input);
            string sum = Convert.ToString(a + b, input);

            string dif;
            bool flag = true;
            if (a > b)
            {
                dif = Convert.ToString(a - b, input);
            }
            else
            {
                dif = Convert.ToString(b - a, input);
                flag = false;
            }

            string mul = Convert.ToString(a * b, input);
            string div = Convert.ToString(a / b, input);
            string mod = Convert.ToString(a % b, input);
            string deg = Convert.ToString(Convert.ToInt32(Math.Pow(Convert.ToInt32(a), Convert.ToInt32(b))), input);
            Console.WriteLine(a2 + " + " + b2 + " = " + sum);

            if (flag == true)
                Console.WriteLine(a2 + " - " + b2 + " = " + dif);
            else
                Console.WriteLine(a2 + " - " + b2 + " = " + "-" + dif);

            Console.WriteLine(a2 + " * " + b2 + " = " + mul);
            Console.WriteLine(a2 + " / " + b2 + " = " + div);
            Console.WriteLine(a2 + " % " + b2 + " = " + mod);
            Console.WriteLine(a2 + " ^ " + b2 + " = " + deg);
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int a = int.Parse(line);
            line = Console.ReadLine();
            int b = int.Parse(line);
            Result(a, b, 2);
            Result(a, b, 8);
            Result(a, b, 10);
            Result(a, b, 16);
            Console.ReadKey();
        }
    }
}
