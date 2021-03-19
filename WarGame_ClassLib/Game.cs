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

        public Game()
        {
            Deck = new Deck();
            Players = new List<Player>();
            TurnCards = new List<Card>();
        }

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

        public void CheckPlayersDecks(int num)
        {
            foreach (var player in Players)
            {
                player.MoveToPlayerCards(num);
            }
        }

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
