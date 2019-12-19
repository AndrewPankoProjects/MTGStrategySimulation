using System;
using System.Collections.Generic;
using System.Text;


namespace MonoRedProwessProject
{
    public class Deck
    {
        public int deckSize = 60;
        public int numberOfLands = 18;
        public int numberOfCreatures = 12;
        public int numberOfSpells = 30;
        public int maxNumberOfCard = 4;

        private List<Card> deck = new List<Card>();
        public List<Card> graveyard = new List<Card>();

        private int ctr = 0;
        private CardEffect[] _effects;
        private CardType[] _cardtypes;
        private CardName[] _cardnames;
        private Random random = new Random();

        public Deck()
        {
            _cardtypes = new[] { CardType.Creature, CardType.Land, CardType.Spell };
            _effects = new[] { CardEffect.Damage, CardEffect.Draw, CardEffect.Mana, CardEffect.Prowess };
            _cardnames = new[] { CardName.BR, CardName.SSM, CardName.MS, CardName.LB, CardName.LS, CardName.LD, CardName.CT, CardName.LUTS, CardName.MM, CardName.WF, CardName.BL, CardName.M };
 
            for (int j = 0; j < 3; j++)
            {
                if (j == 0)
                {

                    while (ctr < 4)
                    {
                        deck.Add(new Card(_cardtypes[j], _effects[3], _cardnames[0]));
                        deck.Add(new Card(_cardtypes[j], _effects[3], _cardnames[1]));
                        deck.Add(new Card(_cardtypes[j], _effects[3], _cardnames[2]));
                        ctr++;
                    }

                }

                if (j == 1)
                {
                    ctr = 0;

                    while (ctr < 18)
                    {
                        deck.Add(new Card(_cardtypes[j], _effects[2], _cardnames[11]));
                        ctr++;
                    }
                        
                }

                if (j == 2)
                {
                    ctr = 0;

                    while(ctr < 4)
                    {
                        deck.Add(new Card(_cardtypes[j], _effects[0], _cardnames[3]));
                        deck.Add(new Card(_cardtypes[j], _effects[0], _cardnames[4]));
                        deck.Add(new Card(_cardtypes[j], _effects[0], _cardnames[5]));
                        deck.Add(new Card(_cardtypes[j], _effects[1], _cardnames[6]));
                        deck.Add(new Card(_cardtypes[j], _effects[1], _cardnames[7]));
                        deck.Add(new Card(_cardtypes[j], _effects[1], _cardnames[8]));
                        deck.Add(new Card(_cardtypes[j], _effects[1], _cardnames[9]));
                            
                        if (ctr < 2)
                        {
                            deck.Add(new Card(_cardtypes[j], _effects[0], _cardnames[10]));
                        }
                        ctr++;
                    }
                        
                }
            }
           // Console.WriteLine(deck.Count);
        }
        public void Shuffle()
        {
            int index = deck.Count;

            while (index > 0)
            {
                --index;
                int j = random.Next(index + 1);
                var card = deck[j];
                deck[j] = deck[index];
                deck[index] = card;
            }
        }

        public void Restart(List<Card> graveyard)
        {
            deck.AddRange(graveyard);
            graveyard.Clear();
        }

        public Card DrawCard()
        {
            var card = deck[deck.Count - 1];

            deck.RemoveAt(deck.Count - 1);

            return card;
        }

    }

}
