using System;
using System.Collections.Generic;

namespace WarGame_ClassLib
{
    public class Player
    {
        public string PlayerName { get; set; }
        public Queue<Card> PlayerCards { get; set;}
        public List<Card> CardsForShuffle { get; set; }

        /// <summary>
        /// <c>TurnCard</c> attribute is used in UI to render <c>Card</c> objects face-up or face-down
        /// </summary>
        public Card TurnCard { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player">is a string holding current player's name</param>
        /// <c>PlayerName</c> is assigned the <c>player</c> param string
        /// <c>PlayerCards</c> is initialized as an empty Queue object to hold their playing <c>Card</c> objects
        /// <c>CardsForShuffle</c> is initialized as an empty List object to hold the 'won' <c>Card</c> objects
        public Player(string player)
        {
            PlayerName = player;
            PlayerCards = new Queue<Card>();
            CardsForShuffle = new List<Card>();
        }

        /// <summary>
        /// Method removes one <c>Card</c> object from <c>PlayerCards</c> and returns it for play
        /// If there are no <c>Card</c> objects in <c>PlayerCards</c> the method returns null
        /// </summary>
        /// <returns>Single <c>Card</c> object from <c>PlayerCards</c></returns>
        public Card ShowCard()
        {
            if (IsPlayerCardsEmpty())
            {
                return null;
            }
            return PlayerCards.Dequeue();
        }

        /// <summary>
        /// Method handles adding new 'won' <c>Card</c> objects to <c>CardsForShuffle</c>
        /// </summary>
        /// <param name="newCards">List of won <c>Card</c> objects from round</param>
        public void AddCards(List<Card> newCards)
        {
            CardsForShuffle.AddRange(newCards);
        }

        /// <summary>
        /// Method checks if <c>PlayerCards</c> is empty
        /// and if so, shuffles <c>CardsForShuffle</c> and adds them back to <c>PlayerCards</c> queue.
        /// Once added, <c>CardsForShuffle</c> is cleared
        /// </summary>
        public void MoveToPlayerCards(int cardsLeft)
        {
            if (PlayerCards.Count < cardsLeft)
            {
                Services.ShuffleCards(CardsForShuffle);
                CardsForShuffle.ForEach(card => PlayerCards.Enqueue(card));
                CardsForShuffle.Clear();
            }
        }

        /// <summary>
        /// Method checks if <c>PlayerCards</c> is empty
        /// </summary>
        public bool IsPlayerCardsEmpty()
        {
            return PlayerCards.Count == 0;
        }
    }
}
