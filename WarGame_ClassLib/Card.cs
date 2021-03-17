using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    //class Card
    //{
    //    bool IsShowing;
    //    Dictionary<int, string> NameAndValue;

    //    public Card(Dictionary<int, string> CardType)
    //    {
    //        IsShowing = false;
    //        NameAndValue = CardType;
    //    }
    //}

    //Note: sorry if this is confusing.
    //This was based on Evgeniya chat update & I made so Player tests would work?
    //Can comment-out but please don't delete.
    //This goes with Player tests for now. Thank you!
    public class Card
    {
        public bool IsShow { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }

        public Card(int num, string suit)
        {
            IsShow = false;
            Value = num;
            Name = suit;
        }
    }
}

