using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Player
    {
        const int NUMBER_OF_CARDS = 11;
        Card[] hand = new Card[NUMBER_OF_CARDS];
        Deck deck;
        string name;
        int points;

        public Player(string name, Deck deck)
        {
            this.name = name;
            points = 0;
            this.deck = deck;
        }

        public void Hit(int pos)
        {
            hand[pos] = deck.DealCard();
            points += hand[pos].GetFaceValue();
        }

        public void ShowPoints()
        {
            Console.WriteLine($"{name} has {points} points");
        }

        public void ShowHandInfo()
        {
            Console.Write($"{name} has {points} points, with");
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i] != null)
                {
                    Console.Write("{0, -2}", hand[i].ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (i == 10)
                    Console.WriteLine();
            }
        }

        public int GetPoints()
        {
            return points;
        }

    }
}
