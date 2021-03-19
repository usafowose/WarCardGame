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

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <c>IsShowing</c> is a boolean attribute indicating whether <c>Card</c> object should be rendered face-up or face-down
        /// <param name="NumValue"></param> is an integer attribute indicating <c>Card</c> object's numerical value
        /// <param name="SuitName"></param> is a string attribute indicating <c>Card</c> object's suit name (i.e. "Hearts", "Spades")
        public Card(int NumValue, string SuitName) 
        {
            IsShowing = false;
            this.SuitName = SuitName;
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

