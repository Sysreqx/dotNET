using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Card
    {
        string face, suit;

        public Card(string face, string suit)
        {
            this.face = face;
            this.suit = suit;
        }

        public override string ToString()
        {
            if (suit == "♥" || suit == "♦")
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.Gray;
            return " " + face + suit;
        }

        public string GetSuit()
        {
            return suit;
        }

        public int GetFaceValue()
        {
            int x = 0;

            if (Int32.TryParse(face, out x))
                Int32.TryParse(face, out x);
            else if (face == "J")
                x = 2;
            else if (face == "Q")
                x = 3;
            else if (face == "K")
                x = 4;
            else if (face == "A")
                x = 1;

            return x;
        }
}
}
