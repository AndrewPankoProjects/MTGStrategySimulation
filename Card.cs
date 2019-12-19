using System;
using System.Collections.Generic;
using System.Text;

namespace MonoRedProwessProject
{
    public class Card
    {
        public readonly CardEffect CardEffect;
        public readonly CardType Typing;
        public readonly CardName Name;

        public Card(CardType cardType, CardEffect effect, CardName cardName)
        {
            CardEffect = effect;
            Typing = cardType;
            Name = cardName;
        }


    }
}
