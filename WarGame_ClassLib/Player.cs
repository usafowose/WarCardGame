using System;
using System.Collections.Generic;

namespace WarGame_ClassLib
{
    public class Player
    {
        public string PlayerName { get; set; }
        public Queue<Card> PlayerCards { get; set;}
        public List<Card> CardsForShuffle { get; set; }
        public Card TurnCard { get; set; }

        public Player(string player)
        {
            PlayerName = player;
            PlayerCards = new Queue<Card>();
            CardsForShuffle = new List<Card>();
        }

        public Card ShowCard()
        {
            if (IsPlayerCardsEmpty())
            {
                return null;
            }
            return PlayerCards.Dequeue();
        }

        public void AddCards(List<Card> newCards)
        {
            CardsForShuffle.AddRange(newCards);
        }

        public void MoveToPlayerCards(int cardsLeft)
        {
            if (PlayerCards.Count < cardsLeft)
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
