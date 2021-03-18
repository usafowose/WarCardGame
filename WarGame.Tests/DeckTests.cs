using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame_ClassLib;
using System.Collections.Generic;

namespace WarGame.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Constructor_InitializeCards_Void()
        {
            Deck deck = new Deck();
            //deck.GenerateDeck();
            Assert.AreEqual(52, deck.CardsInDeck.Count);
            //Assert.AreEqual(26, player2.PlayerCards.Count);
        }
    }
}