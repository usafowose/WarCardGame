using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame_ClassLib
{
    public class Deck
    {
        List<int> NumValues = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
        List<string> SuitNames = new List<string>() { "Spades, Hearts, Diamonds, Clubs" };
        static int DeckSize = 52;
        public List<Card> CardsInDeck = new List<Card>();

        public Deck() 
        {
            for (int i = 0; i < NumValues.Count; i++)
            {
                for (int j = 0; j < SuitNames.Count; j++)
                {
                    //string name = i == 0 ? $"AceOf{SuitNames[i]}" : $"{NumValues[i]}Of{SuitNames[j]}";

                    Card card = new Card(NumValues[i], SuitNames[j]);
                    CardsInDeck.Add(card);
                }
            }

            CardsInDeck = Services.ShuffleCards(CardsInDeck); 
        }

        
        //public List<Card> Shuffle(List<Card> Cards)
        //{
        //    Random random = new Random();
        //    int n = Cards.Count;

        //    for (int i = Cards.Count; i > 1; i--)
        //    {
        //        int rnd = random.Next(i);

        //        var value = Cards[rnd];
        //        Cards[rnd] = Cards[i];
        //        Cards[i] = value;
        //    }
        //    return Cards;
        //}


        //Methods




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