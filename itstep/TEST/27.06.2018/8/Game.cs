using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Game
    {
        Deck deck;
        Player[] players;
        int pos = 0;
        public Game(Deck deck, int plrsNum)
        {
            this.deck = deck;
            players = new Player[plrsNum];
        }

        public void StartGame()
        {
            for (int i = 0; i < players.Length; i++)
            {
                pos = 0;
                Console.WriteLine("Enter name");
                string nm = Console.ReadLine();
                players[i] = new Player(nm, deck);

                players[i].Hit(pos++);
                players[i].Hit(pos++);
                players[i].ShowHandInfo();
                while (players[i].GetPoints() < 21)
                {
                    Console.WriteLine("1 - Hit");
                    Console.WriteLine("2 - Next player’s turn");
                    string n = Console.ReadLine();
                    if (n == "1")
                        players[i].Hit(pos++);
                    else
                        break;
                    players[i].ShowHandInfo();
                }
            }
        }

        public void EndGame()
        {
            Console.Clear();
            Array.Sort(players, (p1, p2) => p2.GetPoints().CompareTo(p1.GetPoints()));
            //Player[] p = new Player[players.Length];
            //for (int i = 0; i < players.Length; i++)
            //{
            //    int b = players.Length - 1;
            //    int f = 0;
            //    if (players[i].GetPoints() > 21)
            //        p[b--] = players[i];
            //    else
            //        p[f++] = players[i];
            //}
            for (int i = 0; i < players.Length; i++)
            {
                players[i].ShowHandInfo();
            }
        }
    }
}
