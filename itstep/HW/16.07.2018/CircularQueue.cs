using System;
using System.Collections.Generic;
using System.Threading;

namespace _16._07._2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            while (true)
            {
                foreach (var i in q)
                    Console.Write($"{i, 2}");

                int a = q.Peek();
                q.Dequeue();
                q.Enqueue(a);

                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
