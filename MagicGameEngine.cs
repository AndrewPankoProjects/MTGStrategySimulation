using System;
using System.Collections.Generic;
using System.Text;

namespace MonoRedProwessProject
{
    public class MagicGameEngine
    {
        const int MAX_LIFE = 20;
        const int HANDSIZE = 7;

        public int ctr = 0;
        public int opponentLifeTotal = MAX_LIFE;
        int index;
        public int turn = 1;

        Deck deck = new Deck();
        
        Lands land = new Lands();

        List<Card> Lands = new List<Card>();
        
        List<Card> Hand = new List<Card>();

        List<Card> Creatures = new List<Card>();

        List<Card> Spells = new List<Card>();

        Player player = new Player();

        public void StartGame()
        {
            deck.Shuffle();
            //Draw opening hand
            while (ctr < HANDSIZE)
            {
                Hand.Add(deck.DrawCard());
                ctr++;
            }
            //Console.WriteLine(Hand.Count);
        }

        public void DrawPhase()
        {
            Hand.Add(deck.DrawCard());
        }

        public int GetStrategy()
        {
            //Play a land from hand
            index = player.PlayLand(Hand);

            if(index >= 0)
            {
                var landCard = Hand[index];

                Hand.Remove(landCard);

                Lands.Add(landCard);

                land.untappedLands++;
            }
            else
            {
                //Console.WriteLine("No lands in hand");
            }

            //Classify the hand of what strategy the hand will follow
            int strategy = player.ClassifyHand(Hand);

            //Play a creature from hand based on player classification
            //Strategy Gravy = 1, Meat = 2, Both = 3
            return strategy;
        }

        public void MainPhase(int strategy)
        {
            if (turn != 1) 
            {
                index = player.PlayLand(Hand);

                if (index >= 0)
                {
                    var landCard = Hand[index];

                    Hand.Remove(landCard);

                    Lands.Add(landCard);

                    land.untappedLands++;
                }
            }
            
            //The magic of each strategy
            switch (strategy)
            {   
                //Gravy Strat -> ALL FOR 1 AND 1 FOR ALL
                case 1:
                    while (land.untappedLands > 0)
                    {
                        index = player.PlayCreature(Hand, land.untappedLands);
                        //Prioritize creatures and if we run out then play spells
                        if (index >= 0)
                        {                          
                            var creatureCard1 = Hand[index];
                            Hand.Remove(creatureCard1);
                            Creatures.Add(creatureCard1);
                            if (creatureCard1.Name.Equals(CardName.SSM) || creatureCard1.Name.Equals(CardName.MS) || creatureCard1.Name.Equals(CardName.BR))
                            {
                                land.untappedLands--;
                            }
                        }
                        else if (index < 0)
                        {
                            index = player.PlaySpell(Hand, land.untappedLands);
                            if (index >= 0)
                            {
                                var spellCard1 = Hand[index];
                                Hand.Remove(spellCard1);
                                Spells.Add(spellCard1);
                                if (spellCard1.CardEffect.Equals(CardEffect.Draw))
                                {
                                    DrawPhase();
                                }
                                if (!spellCard1.Name.Equals(CardName.MM))
                                {
                                    land.untappedLands--;
                                }
                            }
                            else if (index < 0)
                            {
                                land.untappedLands = 0;
                            }
                        }
                    }
                    break;
                //Meat Strat -> All game FIRE POWER
                case 2:
                    while (land.untappedLands > 0)
                    {
                        index = player.PlaySpell(Hand, land.untappedLands);
                        //Prioritize spells and if we run out play creatures
                        if (index >= 0)
                        {
                            var spellCard1 = Hand[index];
                            Hand.Remove(spellCard1);
                            Spells.Add(spellCard1);
                            if (spellCard1.CardEffect.Equals(CardEffect.Draw))
                            {
                                DrawPhase();
                            }
                            if (!spellCard1.Name.Equals(CardName.MM))
                            {
                                land.untappedLands--;
                            }
                        }
                        else if(index < 0)
                        {
                            index = player.PlayCreature(Hand, land.untappedLands);
                            if (index >= 0)
                            {
                                var creatureCard1 = Hand[index];
                                Hand.Remove(creatureCard1);
                                Creatures.Add(creatureCard1);
                                if (creatureCard1.Name.Equals(CardName.SSM) || creatureCard1.Name.Equals(CardName.MS) || creatureCard1.Name.Equals(CardName.BR))
                                {
                                    land.untappedLands--;
                                }
                            }
                            else if(index < 0)
                            {
                                land.untappedLands = 0;
                            }
                        }
                    }
                    break;
                //Both Strat -> Early game play creature, then lay on the spells
                //If its turn 2 with 2 mana and you run out of creatures then play a spell
                //If you cant play a spell or a creature then end the storm
                case 3:
                    if (turn <= 2)
                    {
                        while (land.untappedLands > 0)
                        {
                            index = player.PlayCreature(Hand, land.untappedLands);
                            if (index >= 0)
                            {
                                var creatureCard2 = Hand[index];
                                Hand.Remove(creatureCard2);
                                Creatures.Add(creatureCard2);
                            }
                            else if (index < 0)
                            {
                                index = player.PlaySpell(Hand, land.untappedLands);
                                if (index >= 0)
                                {
                                    var spellCard2 = Hand[index];
                                    Hand.Remove(spellCard2);
                                    Spells.Add(spellCard2);
                                    if (spellCard2.CardEffect.Equals(CardEffect.Draw))
                                    {
                                        DrawPhase();
                                    }
                                    if (!spellCard2.Name.Equals(CardName.MM))
                                    {
                                        land.untappedLands--;
                                    }
                                }
                                else if (index < 0)
                                {
                                    land.untappedLands = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        while (land.untappedLands > 0)
                        {
                            index = player.PlaySpell(Hand, land.untappedLands);
                            if (index >= 0)
                            {
                                var spellCard2 = Hand[index];
                                Hand.Remove(spellCard2);
                                Spells.Add(spellCard2);
                                if (spellCard2.CardEffect.Equals(CardEffect.Draw))
                                {
                                    DrawPhase();
                                }
                                if (!spellCard2.Name.Equals(CardName.MM))
                                {
                                    land.untappedLands--;
                                }
                            }
                            else if (index < 0)
                            {
                                land.untappedLands = 0;
                            }
                        }
                    }   
              break;
            }
        }

        public bool isOpponentAlive()
        {
            while(opponentLifeTotal > 0)
            {
                return true;
            }
            deck.Restart(deck.graveyard);
            return false;
            
        }

        public void CombatPhase()
        {
            int damage = Spells.Count * Creatures.Count;
            foreach (var card in Spells)
            {
                if (card.CardEffect.Equals(CardEffect.Damage) && card.Name.Equals(CardName.LB) || card.Name.Equals(CardName.LS))
                {
                    damage += 3;
                }
                else if (card.CardEffect.Equals(CardEffect.Damage) && card.Name.Equals(CardName.LD))
                {
                    damage++;
                }
                else if (card.CardEffect.Equals(CardEffect.Damage) && card.Name.Equals(CardName.BL))
                {
                    damage += 2;
                }
                deck.graveyard.Add(card);
            }
            foreach (var card in Creatures)
            {
                if (card.Typing.Equals(CardType.Creature) && card.Name.Equals(CardName.MS) || card.Name.Equals(CardName.SSM))
                {
                    damage++;
                }
                else if (card.Typing.Equals(CardType.Creature) && card.Name.Equals(CardName.BR))
                {
                    damage += 3;
                }
            }

            Spells.Clear();
            opponentLifeTotal = opponentLifeTotal - damage;
        }

        public void EndPhase()
        {
            if (opponentLifeTotal > 0)
            {
                turn++;
                land.untappedLands = Lands.Count;
                land.tappedLands = 0;
            }
            
        }

    }
}
