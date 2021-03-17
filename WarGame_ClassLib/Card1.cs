using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    class Card
    {
        bool IsShowing;
        public int value;
        public string name; 

        public Card(string name, int value) 
        {
            IsShowing = false;
            this.name = name ;
            this.value = value;
        }
    }

//    class CheckCard
//    {
//        static void Deck()
//        {
//            var Deck = new List<Card>() { };


//            List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//            List<string> Suites = new List<string>() { "Spades, Hearts, Diamonds, Clubs" };

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
//}

