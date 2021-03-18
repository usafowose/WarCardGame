using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame_ClassLib
{
    public class Deck
    {
        List<int> NumValues = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        List<string> SuitNames = new List<string>() { "Spades", "Hearts", "Diamonds", "Clubs" };
        static int DeckSize = 52;
        public List<Card> CardsInDeck  = new List<Card>();

        public Deck() 
        {
            for (int i = 0; i < NumValues.Count; i++)
            {
                for (int j = 0; j < SuitNames.Count; j++)
                {
                    Card card = new Card(NumValues[i], SuitNames[j]);
                    CardsInDeck.Add(card);
                }
            }
            Services.ShuffleCards(CardsInDeck);
        }
    }
}