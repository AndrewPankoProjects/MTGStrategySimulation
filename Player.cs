using System;
using System.Collections.Generic;
using System.Text;

namespace MonoRedProwessProject
{
    public class Player
    {
        int index = 0;
        int caseValue = 0;
        int gravyCtr = 0;

        public readonly PlayerClassifier ClassifiedAs;

        public virtual int PlayLand(List<Card> Hand)
        {
            index = 0;
            foreach (var card in Hand)
            {
                if (card.Name.Equals(CardName.M))
                    return index;
                index++;
            }
            return -1;
        }

        public virtual int PlayCreature(List<Card> Hand, int untappedLands)
        {
            index = 0;
            foreach (var card in Hand)
            {
                if (card.Name.Equals(CardName.SSM))
                    caseValue = 1;
                else if (card.Name.Equals(CardName.MS))
                    caseValue = 2;
                else if (card.Name.Equals(CardName.BR))
                    caseValue = 3;

                switch (caseValue)
                {
                    case 1:
                        if (untappedLands > 0)
                            untappedLands--;
                            return index;
                    case 2:
                        if (untappedLands > 0)
                            untappedLands--;
                            return index;
                    case 3:
                        if (untappedLands > 7)
                            untappedLands -= 7;
                            return index;
                }
                index++;
            }
            return -1;
        }
        public virtual int PlaySpell(List<Card> Hand, int untappedLands)
        {
            index = 0;
            foreach (var card in Hand)
            {
                caseValue = 0;
                //Manamorphose
                if (card.Name.Equals(CardName.MM) && untappedLands > 1)
                    caseValue = 1;
                //Lightning Bolt
                else if (card.Name.Equals(CardName.LB))
                    caseValue = 2;
                //Lava Spike
                else if (card.Name.Equals(CardName.LS))
                    caseValue = 3;
                //Lava Dart
                else if (card.Name.Equals(CardName.LD))
                    caseValue = 4;
                //Burst Lightning
                else if (card.Name.Equals(CardName.BL))
                    caseValue = 5;
                //Light up the Stage
                else if (card.Name.Equals(CardName.LUTS))
                    caseValue = 6;
                //Crash through
                else if (card.Name.Equals(CardName.CT))
                    caseValue = 7;
                //Warlord fury
                else if (card.Name.Equals(CardName.WF))
                    caseValue = 8;

                switch (caseValue)
                {
                    case 1:
                        return index;
                    case 2:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                    case 3:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                    case 4:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                    case 5:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                    case 6:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                    case 7:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                    case 8:
                        if (untappedLands > 0)
                            untappedLands--;
                        return index;
                }
                index++;
            }
            return -1;
        }

        public virtual int ClassifyHand(List<Card> Hand)
        {
            foreach (var card in Hand)
            {
                if (card.Typing.Equals(CardType.Creature))
                {
                    gravyCtr++;
                }
            }

            //For gravy strat
            if (gravyCtr > 2)
                return 1;
            //For meat strat
            else if (gravyCtr < 2)
                return 2;
            //For both strat
            else if (gravyCtr == 2)
                return 3;
            else
                return -1;

        } 

    }
}
