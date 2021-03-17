using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    public class Card
    {
        bool IsShowing;
        public int NumValue { get; set; }
        public string SuitName { get; set; }

        public Card(int NumValue, string SuitName) 
        {
            IsShowing = false;
            this.SuitName = SuitName ;
            this.NumValue = NumValue;
        }
    }

    //    class CheckCard
    //    {
    //        static void Deck()
    //        {
    //            var Deck = new List<Card>() { };


    //            List<int> NumValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    //            List<string> SuitNames = new List<string>() { "Spades, Hearts, Diamonds, Clubs" };
    //            int DeckSize = 52;
    //            List<Card> CardsInDeck = new List<Card>(); 

    //            for (int i = 0; i < Numbers.Count; i++)
    //            {
    //                for (int j = 0; j < Suites.Count; j++)
    //                {
    //                    string name = i == 0 ? $"AceOf{Suites[i]}" : $"{Numbers[i]}Of{Suites[j]}";

    //                    Card card = new Card(name, Numbers[i]);
    //                    Deck.Add(card);
    //                }
    //            }


    //        }
    //    }
}

