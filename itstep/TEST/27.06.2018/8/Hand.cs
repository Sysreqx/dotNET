using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Hand
    {
        Card[] hand;
        int currentCard;
        const int NUMBER_OF_CARDS = 11;

        public Hand()
        {
            hand = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
        }

        public Card DealCard()
        {
            if (currentCard < hand.Length)
                return hand[currentCard++];
            else
                return null;
        }
    }
}
