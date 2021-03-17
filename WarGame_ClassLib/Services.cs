using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    public class Services
    {
        public static List<Card> ShuffleCards(List<Card> CardsToShuffle)
        {
            Random random = new Random();
            int n = CardsToShuffle.Count;

            for (int i = CardsToShuffle.Count -1; i >= 1; i--)
            {
                int rnd = random.Next(0, i);

                var value = CardsToShuffle[rnd];
                CardsToShuffle[rnd] = CardsToShuffle[i];
                CardsToShuffle[i] = value;
            }

            return CardsToShuffle;
        }

    }
}
