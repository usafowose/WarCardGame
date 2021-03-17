using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame
{
    
    class Deck
    {
        //attributes

        //also need list of card objects
        List<Card> cards = new List<Card>() 
        List<int> deckSize = 52;
        List<string> faces = new List<(string face, int value)>() 
        // list of tuples instead of a dictionary, because we need to iterate over it 
        {
           ("one", 1),
           ("two", 2),
           ("three", 3),
           ("four", 4),
           ("five", 5),
           ("six", 6),
           ("seven", 7),
           ("eight", 8),
           ("nine", 9),
           ("ten", 10),
           ("jack", 11),
           ("queen", 12),
           ("king", 13),
           ("ace", 14)
        };

        List<string> suits = new List<>()
        {
           "heart",
           "diamond",
           "spade",
           "club"
        };


        //methods

        //instatniate deck class with constructor
        public Deck(in deckSize);
        {

        cards_idx = 0;
        //example: one_of_hearts
        for (int i = 0; i <= suits.count; i++) 
        {
            for (int j = 0; j <= faces.count; j++) 
            {
                string card_name = $"{faces[j][0]}_of_{suits[i]}";

                cards[cards_idx].name = card_name; // here we are inserting into the list
                cards[cards_idx].value = faces[j][1] //here we insert value 
                card_idx++;
            }
            
            }
        }
    }
}
        
        
