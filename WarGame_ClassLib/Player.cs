using System;
using System.Collections.Generic;

namespace WarGame_ClassLib
{
    public class Player
    {
        public string PlayerName { get; set; }
        public Queue<Card> PlayerCards { get; set;}
        public List<Card> CardsForShuffle { get; set; }

        public Player(string player)
        {
            PlayerName = player;
            PlayerCards = new Queue<Card>();
            CardsForShuffle = new List<Card>();
        }

        public Card ShowCard()
        {
            if (IsPlayerCardsEmpty() == true)
            {
                return null;
            }

            return PlayerCards.Dequeue();
        }

        public void AddCards(List<Card> newCards)
        {
            CardsForShuffle.AddRange(newCards);
        }

        public void MoveToPlayerCards()
        {
            if (IsPlayerCardsEmpty())
            {
                Services.ShuffleCards(CardsForShuffle);
                CardsForShuffle.ForEach(card => PlayerCards.Enqueue(card));
                CardsForShuffle.Clear();
            }
        }

        public bool IsPlayerCardsEmpty()
        {
            return PlayerCards.Count == 0;
        }
    }
}
