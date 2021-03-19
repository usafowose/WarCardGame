using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarGame_ClassLib;
using System.Collections.Generic;


namespace WarGame.Tests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestCardConstructor_CreateInstanceofCard() 
        {
            //Arrange
            Card testCard = new Card(14, "Ace");

            //Act
            testCard = new Card(4, "Hearts");

            //Assert
            Assert.AreEqual("Hearts", testCard.SuitName);
            Assert.AreNotEqual("Spades", testCard.SuitName);

            //Assert 
            Assert.AreEqual(4, testCard.NumValue);
            Assert.AreNotEqual(typeof(string), testCard.NumValue); 
        }
    }
}
