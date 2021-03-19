using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame_ClassLib;

namespace WarGame.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void DealCards_SplitDeckTwoPlayersEqually_Void()
        {
            Game game = new Game();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            game.Players.Add(player1);
            game.Players.Add(player2);

            game.DealCards();

            Assert.AreEqual(26, player1.PlayerCards.Count);
            Assert.AreEqual(26, player2.PlayerCards.Count);
        }

        [TestMethod]
        public void DealCards_SplitDeckFourPlayersEqually_Void()
        {
            Game game = new Game();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            Player player3 = new Player("Player3");
            Player player4 = new Player("Player4");
            game.Players.Add(player1);
            game.Players.Add(player2);
            game.Players.Add(player3);
            game.Players.Add(player4);

            game.DealCards();

            Assert.AreEqual(13, player1.PlayerCards.Count);
            Assert.AreEqual(13, player2.PlayerCards.Count);
            Assert.AreEqual(13, player3.PlayerCards.Count);
            Assert.AreEqual(13, player4.PlayerCards.Count);
        }

        [TestMethod]
        public void GameOver_OnePlayerNoCards_True()
        {
            Game game = new Game();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            game.Players.Add(player1);
            game.Players.Add(player2);
            Card card1 = new Card(10, "Clubs");
            Card card2 = new Card(2, "Clubs");
            Card card3 = new Card(9, "Hearts");
            player1.PlayerCards.Enqueue(card1);

            player2.PlayerCards.Enqueue(card2);
            player2.CardsForShuffle.Add(card3);

            player2.PlayerCards.Dequeue();
            player2.MoveToPlayerCards(1);
            player2.PlayerCards.Dequeue();

            var status = game.GameOver();

            Assert.AreEqual(true, status);
        }

        [TestMethod]
        public void GameOver_AllPlayerHasCards_False()
        {
            Game game = new Game();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            game.Players.Add(player1);
            game.Players.Add(player2);
            Card card1 = new Card(10, "Clubs");
            Card card2 = new Card(2, "Clubs");
            Card card3 = new Card(9, "Hearts");
            player1.PlayerCards.Enqueue(card1);

            player2.PlayerCards.Enqueue(card2);
            player2.CardsForShuffle.Add(card3);

            var status = game.GameOver();

            Assert.AreEqual(false, status);
        }

        [TestMethod]
        public void GameWinner_IndicatePlayer2AsWinner_Player()
        {
            Game game = new Game();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            game.Players.Add(player1);
            game.Players.Add(player2);
            Card card1 = new Card(10, "Clubs");
            Card card2 = new Card(2, "Clubs");
            Card card3 = new Card(9, "Hearts");
            player1.PlayerCards.Enqueue(card1);

            player2.PlayerCards.Enqueue(card2);
            player2.CardsForShuffle.Add(card3);

            Assert.AreEqual(player2, game.GameWinner());
        }

        [TestMethod]
        public void CheckPlayersDeck_MoveCardsPlayer2_Void()
        {
            Game game = new Game();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            game.Players.Add(player1);
            game.Players.Add(player2);
            Card card1 = new Card(10, "Clubs");
            Card card2 = new Card(2, "Clubs");
            Card card3 = new Card(9, "Hearts");
            player1.PlayerCards.Enqueue(card1);

            player2.PlayerCards.Enqueue(card2);
            player2.CardsForShuffle.Add(card3);

            player2.PlayerCards.Dequeue();

            game.CheckPlayersDecks(1);

            Assert.AreEqual(1, player2.PlayerCards.Count);
            Assert.AreEqual(0, player2.CardsForShuffle.Count);
            Assert.AreEqual(card3, player2.PlayerCards.Peek());
        }
    }
}
