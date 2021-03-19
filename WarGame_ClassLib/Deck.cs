using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame_ClassLib
{
    public class Deck
    {
        /// <summary>
        /// <c>NumValues</c> is a List of all possible <c>Card.NumValue</c> integer values
        /// </summary>
        List<int> NumValues = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

        /// <summary>
        /// <c>SuitNames</c> is a List of all possible <c>Card.SuitName</c> string values
        /// </summary>
        List<string> SuitNames = new List<string>() { "Spades", "Hearts", "Diamonds", "Clubs" };

        /// <summary>
        /// <c>DeckSize</c> is a static variable indicating total number of <c>Card</c> objects in game
        /// </summary>
        static int DeckSize = 52;

        /// <summary>
        /// <c>CardsInDeck</c> is a List of <c>Card</c> objects in deck. Initialized as an empty List
        /// </summary>
        public List<Card> CardsInDeck  = new List<Card>();

        /// <summary>
        /// Method creates <c>Card</c> objects with one <c>SuitName</c> to each <c>NumValues</c> integer value.
        /// After <c>Card</c> object is created, it is added to <c>CardInDeck</c>
        /// When all <c>Card</c> objects have been created, <c>CardsInDeck</c> is shuffled
        /// </summary>
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