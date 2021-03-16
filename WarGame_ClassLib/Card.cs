using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    class Card
    {
        bool IsShowing;
        Dictionary<int, string> NameAndValue; 

        public Card(Dictionary<int, string> CardType) 
        {
            IsShowing = false;
            NameAndValue = CardType; 
        }
    }
}

