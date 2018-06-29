using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Deck d = new Deck();
            d.Shuffle();
            Game g = new Game(d, 2);

            g.StartGame();
            g.EndGame();

            Console.ReadLine();
        }
    }
}
