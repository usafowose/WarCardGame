using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    public class Services
    {
        /// <summary>
        /// Method takes in List of <c>Card</c> objects to shuffle.
        /// <c>Random</c> integers are generated and (iterated) indices are swapped with <c>Random</c> integer indices the same number of times as the List's length.
        /// </summary>
        /// <param name="CardsToShuffle"></param> represents the List of <c>Card</c> objects to be shuffled. <c>Card</c> objects are shuffled in-place
        public static void ShuffleCards(List<Card> CardsToShuffle)
        {
            Random random = new Random();
            for (int i = CardsToShuffle.Count -1; i >= 1; i--)
            {
                int rnd = random.Next(0, i);

                var value = CardsToShuffle[rnd];
                CardsToShuffle[rnd] = CardsToShuffle[i];
                CardsToShuffle[i] = value;
            }
        }
    }
}
