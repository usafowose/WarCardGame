using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame
{
    public class Player
    {
        private string playerName;
        public Queue<Card> playerCards;
        private List<Card> cardsForShuffle;

        public Player(string player)
        {
            playerName = player;
            playerCards = new Queue<Card>();
            cardsForShuffle = new List<Card>();
        }

        public Card ShowCard()
        {
            return playerCards.Dequeue();
        }

        public void AddCards(List<Card> newCards)
        {
            //cardsForShuffle = cardsForShuffle.Concat(newCards).ToList();  // TRIED THIS. WHY DOESN'T WORK
            newCards.ForEach(card => cardsForShuffle.Add(card));
        }

        public void MoveToPlayerCards()
        {
            playerCards = Service.Shuffle(cardsForShuffle);
        }
    }
}
