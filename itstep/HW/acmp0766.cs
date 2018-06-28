using System;
namespace wtf
{
    public class woohoo
    {
        public static void Main()
        {
            int n, m, k;
            string l = Console.ReadLine();
            n = int.Parse(l);
            l = Console.ReadLine();
            m = int.Parse(l);
            l = Console.ReadLine();
            k = int.Parse(l);

            if (k <= (n * m))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");

            //Console.ReadKey();
        }
    }
}