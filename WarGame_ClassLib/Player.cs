using System;

namespace WarGame_ClassLib
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace WarGame
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
                //Service.Shuffle(CardsForShuffle);
                CardsForShuffle.ForEach(card => PlayerCards.Enqueue(card));
                CardsForShuffle = new List<Card>();
            }

            private bool IsPlayerCardsEmpty()
            {
                return PlayerCards.Count == 0;
            }
        }
    }

}
