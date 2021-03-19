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

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="NumValue"></param> is an integer attribute indicating <c>Card</c> object's numerical value
        /// <param name="SuitName"></param> is a string attribute indicating <c>Card</c> object's suit name (i.e. "Hearts", "Spades")
        public Card(int NumValue, string SuitName) 
        {
            this.SuitName = SuitName ;
            this.NumValue = NumValue;
        }

        /// <summary>
        /// Method concatenates <c>SuiteName</c> & <c>NumValue</c> to dynamically name <c>Card</c> objects
        /// </summary>
        /// <returns>String of concatenated <c>Card</c> object's name (i.e. "Hearts5")</returns>
        public override string ToString()
        {
            return SuitName + NumValue;
        }
    } 
}

