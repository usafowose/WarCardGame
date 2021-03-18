using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame_ClassLib;
using System.Collections.Generic;

namespace WarGame.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestPlayer_Constructor_CreateInstanceOfPlayer_Player()
        {
            // Arrange
            Player testPlayer = new Player("Kasey Ketchup");

            // Assert
            Assert.AreEqual(typeof(Player), testPlayer.GetType());
            Assert.AreNotEqual(typeof(Card), testPlayer.GetType());
            // TO-DO: PlayerCards, CardsForShuffle
        }
 
        [TestMethod]
        public void TestPlayer_NameSetter_Void()
        {
            // Arrange
            Player testPlayer = new Player("Kasey Ketchup");

            // Act
            testPlayer = new Player("Mister Mustard");

            // Assert
            Assert.AreEqual("Mister Mustard", testPlayer.PlayerName);
            Assert.AreNotEqual("Kasey Ketchup", testPlayer.PlayerName);
        }

        [TestMethod]
        public void TestPlayer_NameGetter_String()
        {
            // Arrange
            Player testPlayer = new Player("Kasey Ketchup");

            // Assert
            Assert.AreEqual("Kasey Ketchup", testPlayer.PlayerName);
            Assert.AreNotEqual("Mister Mustard", testPlayer.PlayerName);
        }

        [TestMethod]
        public void TestPlayer_CardsGetter_QueueOfCards()
        {
            // Arrange
            Player testPlayer = new Player("Kasey Ketchup");

            Card newCard1 = new Card(5, "Heart");
            Card newCard2 = new Card(7, "Diamond");
            Card newCard3 = new Card(9, "Spade");

            testPlayer.PlayerCards.Enqueue(newCard1);
            testPlayer.PlayerCards.Enqueue(newCard2);
            testPlayer.PlayerCards.Enqueue(newCard3);

            // Assert
            Assert.AreEqual(3, testPlayer.PlayerCards.Count);
            Assert.AreEqual(5, testPlayer.PlayerCards.Dequeue().NumValue);
            Assert.AreEqual(7, testPlayer.PlayerCards.Dequeue().NumValue);
            Assert.AreNotEqual("Diamond", testPlayer.PlayerCards.Dequeue().SuitName);
            Assert.AreEqual(0, testPlayer.PlayerCards.Count);
        }

        [TestMethod]
        public void TestPlayer_CardsSetter_Void()
        {
            // Arrange
            Player testPlayer = new Player("Kasey Ketchup");

            Card newCard1 = new Card(5, "Heart");
            Card newCard2 = new Card(7, "Diamond");
            Card newCard3 = new Card(9, "Spade");
            Card newCard4 = new Card(2, "Club");

            // Act
            testPlayer.PlayerCards.Enqueue(newCard1);
            testPlayer.PlayerCards.Enqueue(newCard2);
            testPlayer.PlayerCards.Enqueue(newCard3);

            // Assert
            Assert.AreEqual(3, testPlayer.PlayerCards.Count);
            Assert.AreEqual(5, testPlayer.PlayerCards.Dequeue().NumValue);
        }

        [TestMethod]
        public void TestPlayer_ShowCard_RemovesCardFromPlayerCardQueue_CardObject()
        {
            // Arrange
            Player testPlayer = new Player("Kasey Ketchup");

            Card newCard1 = new Card(5, "Heart");
            Card newCard2 = new Card(7, "Diamond");

            testPlayer.PlayerCards.Enqueue(newCard1);
            testPlayer.PlayerCards.Enqueue(newCard2);

            // Act
            Card testShownCard = testPlayer.ShowCard();

            // Assert
            Assert.AreEqual(typeof(Card), testShownCard.GetType());
            Assert.AreEqual(1, testPlayer.PlayerCards.Count);
            Assert.AreEqual("Heart", testShownCard.SuitName);
            Assert.AreNotEqual("Diamond", testShownCard.SuitName);
            Assert.AreEqual(5, testShownCard.NumValue);
            Assert.AreNotEqual(8, testPlayer.PlayerCards.Peek().NumValue);
            Assert.AreEqual(7, testPlayer.PlayerCards.Peek().NumValue);
            Assert.AreEqual("Diamond", testPlayer.ShowCard().SuitName);
            Assert.IsNull(testPlayer.ShowCard());  
        }

        [TestMethod]
        public void TestPlayer_AddCards_AddsWonCardsToCardsForShuffle_Void()
        {
            // Arrange
            Player testPlayer = new Player("Sam the Sandwich");

            Card newCard1 = new Card(5, "Heart");
            Card newCard2 = new Card(7, "Diamond");

            testPlayer.CardsForShuffle.Add(newCard1);
            testPlayer.CardsForShuffle.Add(newCard2);

            List<Card> testWonCards = new List<Card>();

            Card newCard3 = new Card(6, "Club");
            Card newCard4 = new Card(14, "Spade");

            testWonCards.Add(newCard3);
            testWonCards.Add(newCard4);

            // Act
            testPlayer.AddCards(testWonCards);

            // Assert
            Assert.AreEqual(4, testPlayer.CardsForShuffle.Count);
            Assert.AreEqual(6, testPlayer.CardsForShuffle[2].NumValue);
            Assert.AreNotEqual("Heart", testPlayer.CardsForShuffle[3].SuitName);
            Assert.AreEqual("Spade", testPlayer.CardsForShuffle[3].SuitName);
        }

        [TestMethod]
        public void TestPlayer_MoveToPlayerCards_MovesCardsForShuffleToPlayerCards_Void()
        {
            // Arrange
            Player testPlayer = new Player("Sam the Sandwich");

            Card newCard1 = new Card(5, "Heart");
            Card newCard2 = new Card(7, "Diamond");
            Card newCard3 = new Card(2, "Spade");
            Card newCard4 = new Card(3, "Club");
            Card newCard5 = new Card(9, "Heart");

            testPlayer.CardsForShuffle.Add(newCard1);
            testPlayer.CardsForShuffle.Add(newCard4);
            testPlayer.CardsForShuffle.Add(newCard2);
            testPlayer.CardsForShuffle.Add(newCard5);
            testPlayer.CardsForShuffle.Add(newCard3);

            // Act
            testPlayer.MoveToPlayerCards();

            // Assert
            Assert.AreEqual(5, testPlayer.PlayerCards.Count);
            //Assert.AreNotEqual(0, testPlayer.PlayerCards.Count);
            Assert.AreEqual(0, testPlayer.CardsForShuffle.Count);
            //Assert.AreNotEqual(5, testPlayer.CardsForShuffle.Count);
            //Assert.AreEqual(5, testPlayer.PlayerCards.Peek().NumValue);
        }

    }
}
