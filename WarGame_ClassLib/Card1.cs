using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    public class Card
    {
        bool IsShowing;
        public int NumValue { get; set; }
        public string SuitName { get; set; }

        public Card(int NumValue, string SuitName) 
        {
            IsShowing = false;
            this.SuitName = SuitName ;
            this.NumValue = NumValue;
        }
    }

   
}

