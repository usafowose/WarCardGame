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

        public Game()
        {
            Deck = new Deck();
            Players = new List<Player>();
            TurnCards = new List<Card>();
        }

        private void DealCardsToPlayer(Player player, int startIndex, int numberOfCards, Card[] cards)
        {
            int first = 0;
            while (first < numberOfCards)
            {
                if (startIndex + first < cards.Length)
                {
                    player.PlayerCards.Enqueue(cards[startIndex + first]);
                }
                first++;
            }
        }

        public void DealCards()
        {
            int numberOfPlayers = Players.Count;
            //Deck.CreateDeck();
            int numberOfCardsInDeck = Deck.Cards.Length;
            if (numberOfPlayers == 0 || numberOfCardsInDeck % numberOfPlayers != 0)
            {
                throw new InvalidOperationException();
            }
            int numberOfCardsForEachPlayer = numberOfCardsInDeck / numberOfPlayers;
            int start = 0;
            foreach (var player in Players)
            {
                DealCardToPlayer(player, start, numberOfCardsForEachPlayer, Deck.Cards);
                start += numberOfCardsForEachPlayer;
            }
        }

        public bool GameOver()
        {
            foreach (var player in Players)
            {
                if (player.IsEmptyPlayerCards() && player.CardsForShuffle.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

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

        public void CheckPlayersDecks()
        {
            foreach (var player in Players)
            {
                player.MoveToPlayerCards();
            }    
        }

        public Card MaxCard(List<Card> cards)
        {
            int max = int.MinValue;
            Card maxCard = null; 
            HashSet<int> values = new HashSet<int>();
            foreach (var card in cards)
            {
                if (values.Contains(card.Value))
                {
                    return null;
                }
                else
                {
                    values.Add(card.Value);
                }
                if (card.Value > max)
                {
                    maxCard = card;
                    max = card.Value;
                }
            }
            return maxCard;
        }

        public string Turn()
        {
            CheckPlayersDecks();
            if (GameOver())
            {
                return $"Player {GameWinner().PlayerName} wins the game!";
            }
            var playerCardDict = new ConcurrentDictionary<Card, Player>();
            foreach(var player in Players)
            {
                var card = player.ShowCard();
                TurnCards.Add(card);
                playerCardDict.TryAdd(card, player);
            }
            var maxCard = MaxCard(TurnCards);
            if (maxCard == null)
            {
                return "Declare a War";
            }
            var turnWinner = playerCardDict[maxCard];
            turnWinner.AddCards(TurnCards);
            TurnCards.Clear();
            return $"Player {turnWinner.PlayerName} wins. Click for next turn.";
        }

        public string DeclareWar()
        {
            CheckPlayersDecks();
            if (GameOver())
            {
                return $"Player {GameWinner().PlayerName} wins the game!";
            }
            foreach (var player in Players)
            {
                var card = player.ShowCard();
                TurnCards.Add(card);
            }
            return Turn();
        }
    }
}
