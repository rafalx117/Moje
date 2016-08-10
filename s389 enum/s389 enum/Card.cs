using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static s389_enum.EnumCard;

namespace s389_enum
{
    class Card
    {
        public EnumCard.CardColor Color;
        public EnumCard.CardValue Value;
        public string Name { get { return Value.ToString() + " " + Color.ToString(); } }

        public Card(CardValue value, CardColor color)
        {
            Color = color;
            Value = value;
        }

        public override string ToString()
        {
            return Value + " " + Color;
        }
    }

    
}
