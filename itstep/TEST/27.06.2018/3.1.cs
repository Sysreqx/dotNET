using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3.1
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
                dif = Convert.ToString(a - b, input);
            else
            {
                dif = Convert.ToString(b - a, input);
                flag = false;
            }

            string mul = Convert.ToString(a * b, input);
            string div = Convert.ToString(a / b, input);
            string mod = Convert.ToString(a % b, input);
            string deg = Convert.ToString(Convert.ToInt32(Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b))), input);

            string output = "placeholder1 + placeholder2 = placeholder3";
            string sumO = output;
            sumO = sumO.Replace("placeholder1", a2);
            sumO = sumO.Replace("placeholder2", b2);
            sumO = sumO.Replace("placeholder3", sum);
            Console.WriteLine(sumO);

            string difO = output;
            if (flag == false)
                dif = "-" + dif;
            difO = difO.Replace("placeholder1", a2);
            difO = difO.Replace("placeholder2", b2);
            difO = difO.Replace("placeholder3", dif);
            Console.WriteLine(difO);

            string mulO = output;
            mulO = mulO.Replace("placeholder1", a2);
            mulO = mulO.Replace("placeholder2", b2);
            mulO = mulO.Replace("placeholder3", mul);
            Console.WriteLine(mulO);

            string div0 = output;
            div0 = div0.Replace("placeholder1", a2);
            div0 = div0.Replace("placeholder2", b2);
            div0 = div0.Replace("placeholder3", div);
            Console.WriteLine(div0);

            string modO = output;
            modO = modO.Replace("placeholder1", a2);
            modO = modO.Replace("placeholder2", b2);
            modO = modO.Replace("placeholder3", mod);
            Console.WriteLine(modO);

            string degO = output;
            degO = degO.Replace("placeholder1", a2);
            degO = degO.Replace("placeholder2", b2);
            degO = degO.Replace("placeholder3", deg);
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
