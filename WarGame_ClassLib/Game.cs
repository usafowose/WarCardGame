using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Concurrent;

namespace WarGame_ClassLib
{
    public class Game
    {
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> TurnCards { get; set; }
        public string Winner { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <c>Deck</c> instantiates new <c>Deck</c> object
        /// <c>Players</c> initializes new List of <c>Player</c> objects
        /// <c>TurnCards</c> initializes new List of <c>Card</c> objects
        public Game()
        {
            Deck = new Deck();
            Players = new List<Player>();
            TurnCards = new List<Card>();
        }

        /// <summary>
        /// Method adds dealt <c>Card</c> objects to <c>player.PlayerCards</c>
        /// </summary>
        /// <param name="player"></param> is the <c>Player</c> recipient
        /// <param name="startIndex"></param> is the starting index of the <c>cards</c> List that will be added to <c>player.PlayerCards</c> queue
        /// <param name="numberOfCards"></param> represents the total number of <c>Card</c> objects dealt to each player
        /// <param name="cards"></param> is a List of <c>Card</c> objects dealt by game to <c>player</c>
        private void DealCardsToPlayer(Player player, int startIndex, int numberOfCards, List<Card> cards)
        {
            int first = 0;
            while (first < numberOfCards)
            {
                if (startIndex + first < cards.Count)
                {
                    player.PlayerCards.Enqueue(cards[startIndex + first]);
                }
                first++;
            }
        }

        /// <summary>
        /// Method takes <c>numberOfCardsInDeck</c> and divides by <c>numberOfPlayers</c>
        /// It throws an error if the <c>numberOfPlayers</c> is 0 and for the time being, if <c>numberOfCardsInDeck</c> does not divide evenly by <c>numberOfPlayers</c>
        /// Assuming these conditions are met, <c>Card</c> objects are dealt evenly to each <c>player</c>
        public void DealCards()
        {
            int numberOfPlayers = Players.Count;
            int numberOfCardsInDeck = Deck.CardsInDeck.Count;
            if (numberOfPlayers == 0 || numberOfCardsInDeck % numberOfPlayers != 0)
            {
                throw new InvalidOperationException();
            }
            int numberOfCardsForEachPlayer = numberOfCardsInDeck / numberOfPlayers;
            int start = 0;
            foreach (var player in Players)
            {
                DealCardsToPlayer(player, start, numberOfCardsForEachPlayer, Deck.CardsInDeck);
                start += numberOfCardsForEachPlayer;
            }
        }

        /// <summary>
        /// Methods checks if any <c>player</c> is out of cards in both <c>player.PlayerCards</c> and <c>player.CardsForShuffle</c>, indicating the game is over
        /// </summary>
        /// <returns>Boolean value</returns>
        public bool GameOver()
        {
            foreach (var player in Players)
            {
                if (player.IsPlayerCardsEmpty() && player.CardsForShuffle.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Methods checks if any total sum of <c>player.PlayerCards</c> and <c>player.CardsForShuffle</c> for each <c>player</c> is greater than number of <c>maxCards</c>
        /// Return <c>winner</c> when game is won
        /// </summary>
        /// <returns><c>player</c> with <c>maxCards</c></returns>
        public Player GameWinner()
        {
            int maxCards = int.MinValue;
            Player winner = null;
            foreach (var player in Players)
            {
                if (player.PlayerCards.Count + player.CardsForShuffle.Count > maxCards)
                {
                    winner = player;
                    maxCards = player.PlayerCards.Count + player.CardsForShuffle.Count;
                }
            }
            return winner;
        }

        /// <summary>
        /// Helper method calling <c>MoveToPlayerCards</c> check for each <c>player</c>
        /// </summary>
        public void CheckPlayersDecks(int num)
        {
            foreach (var player in Players)
            {
                player.MoveToPlayerCards(num);
            }
        }

        /// <summary>
        /// Method iterates through <c>cards</c> adding <c>card.NumValue</c> to <c>values</c> HashSet.
        /// <c>max</c> variable stores the highest seen <c>card.NumValue</c> and updates as higher <c>card.NumValue</c> is found
        /// <c>maxCard</c> variable stores the highest seen <c>card</c> associated with <c>max</c> value and updates alongside <c>max</c> variable
        /// </summary>
        /// <param name="cards">List of <c>Card</c> objects</param>
        /// <returns>Single <c>Card</c> object with highest <c>NumValue</c></returns>
        public Card MaxCard(List<Card> cards)
        {
            int max = int.MinValue;
            Card maxCard = null;
            foreach (var card in cards)
            {
                if (card.NumValue > max)
                {
                    maxCard = card;
                    max = card.NumValue;
                }
            }
            return maxCard;
        }

        public bool IsDeclareWar(List<Card> cards)
        {
            HashSet<int> values = new HashSet<int>();
            foreach (var card in cards)
            {
                if (values.Contains(card.NumValue))
                {
                    return true;
                }
                else
                {
                    values.Add(card.NumValue);
                }
            }
            return false;
        }

        /// <summary>
        /// Method represents a 'round' of competing <c>Card</c> objects.
        /// It checks current status of player's cards and game status.
        /// If game is still in play, <c>player.TurnCard</c> is added to <c>TurnCards</c> (List of all players' submitted <c>Card</c> objects for round) 
        /// // and entered into <c>playerCardDict</c>.
        /// <c>maxCard</c> variable is assigned to the highest card value among <c>TurnCards</c>. 
        /// If <c>maxCard</c> equals null, the card values are tied and the players 'Declare War'
        /// Otherwise <c>player</c> associated with <c>maxCard</c> in <c>playerCardDict</c> adds <c>TurnCards</c> to their <c>CardsForShuffle</c> pile, 
        /// current round's <c>TurnCards</c> is cleared and returns false.
        /// </summary>
        /// <returns>Boolean value whether to 'declare war'</returns>
        public bool Turn()
        {
            CheckPlayersDecks(1);
            var playerCardDict = new ConcurrentDictionary<Card, Player>();
            List<Card> thisTurnCards = new List<Card>();
            foreach (var player in Players)
            {
                var card = player.ShowCard();
                player.TurnCard = card;
                TurnCards.Add(card);
                thisTurnCards.Add(card);
                playerCardDict.TryAdd(card, player);
            }
            if (IsDeclareWar(thisTurnCards))
            {
                return true;
            }
            var maxCard = MaxCard(thisTurnCards);
            var turnWinner = playerCardDict[maxCard];
            turnWinner.AddCards(TurnCards);
            TurnCards.Clear();
            return false;
        }

        /// <summary>
        /// It checks current status of player's cards and game status.
        /// If game is still in play, for now, a single additional <c>card</c> is added to <c>TurnCards</c> for 'war' and <c>Turn()</c> method is called again
        /// </summary>
        /// <returns>Boolean by way of <c>Turn()</c> method</returns>
        public bool DeclareWar()
        {
            CheckPlayersDecks(3);
            for (int i = 0; i < 3; i++)
            {
                foreach (var player in Players)
                {
                    var card = player.ShowCard();
                    TurnCards.Add(card);
                }
            }
            return Turn();
        }
    }
}
