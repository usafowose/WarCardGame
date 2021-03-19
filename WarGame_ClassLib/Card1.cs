using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGame_ClassLib
{
    public class Card
    {
        public int NumValue { get; set; }
        public string SuitName { get; set; }

        public Card(int NumValue, string SuitName) 
        {
            this.SuitName = SuitName ;
            this.NumValue = NumValue;
        }

        public override string ToString()
        {
            return SuitName + NumValue;
        }
    } 
}

