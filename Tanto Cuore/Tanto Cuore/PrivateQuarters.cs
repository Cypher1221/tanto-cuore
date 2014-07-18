using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tanto_Cuore
{
    class PrivateQuarters
    {
        List<PrivateQuartersCard> cardList;
        List<PrivateQuartersCard> privateMaids;
        List<Card> badHabits;

        public PrivateQuarters()
        {
            cardList = new List<PrivateQuartersCard>();
            privateMaids = new List<PrivateQuartersCard>();
            badHabits = new List<Card>();
        }

        public bool addIllnessToCard(int card, Card illness)
        {
            if (card > cardList.Count)
            {
                return false;
            }
            return cardList.ElementAt(card).addIllness(illness);
        }

        public bool addCardToPrivateQuarters(Card card)
        {
            if (card.getCardNumber() != 2 || (card.getCardNumber() >= 15 && card.getCardNumber() <= 18) )
            {
                cardList.Add(new PrivateQuartersCard(card));
                return true;
            }
            if (card.getCardNumber() >= 19 && card.getCardNumber() <= 28)
            {
                privateMaids.Add(new PrivateQuartersCard(card));
                return true;
            }
            return false;
        }

        internal bool containsCards()
        {
            return privateMaids.Count != 0 || cardList.Count != 0;
        }

        internal void addBadHabit(Card card)
        {
            if (privateMaids.Count != 0 || cardList.Count != 0)
            {
                badHabits.Add(card);
            }
        }

        internal void draw(SpriteBatch spriteBatch, PlayArea playArea)
        {
            spriteBatch.Begin();
            for (int index = 0; index < cardList.Count; index++)
            {
                if (cardList.ElementAt(index).getNumberOfIllnesses() != 0){
                    if (playArea.currentSelectOption == 0 && playArea.item == index)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[cardList.ElementAt(index).getCardNumber()], new Vector2(100 * index, 0), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[cardList.ElementAt(index).getCardNumber()], new Vector2(100 * index, 0), Color.White);
                    }
                }
            }
            if (privateMaids.Count != 0 && privateMaids.ElementAt(privateMaids.Count-1).getNumberOfIllnesses() != 0)
            {
                if (playArea.currentSelectOption == 1)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[privateMaids.ElementAt(privateMaids.Count - 1).getCardNumber()], new Vector2(0, 100), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[privateMaids.ElementAt(privateMaids.Count - 1).getCardNumber()], new Vector2(0, 100), Color.White);
                }
            }
            if (badHabits.Count != 0){
                if (playArea.currentSelectOption == 2)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[29], new Vector2(0, 100), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[29], new Vector2(0, 100), Color.White);
                }
            }
            spriteBatch.End();
        }

        internal int getNumberOfMaidsInPrivateQuarters()
        {
            return cardList.Count;
        }

        internal PrivateQuartersCard privateMaidAt(int item)
        {
            return cardList.ElementAt(item);
        }

        internal Card removeIllenessFrom(int item)
        {
            return cardList.ElementAt(item).removeIllness();
        }

        internal Card removeIllenessPrivateMaid()
        {
            return privateMaids.ElementAt(privateMaids.Count - 1).removeIllness();
        }

        internal bool hasEvents()
        {
            bool cardListHasEvent = false;
            for (int index = 0; index < cardList.Count; index++)
            {
                if (cardList.ElementAt(index).hasIllness())
                {
                    cardListHasEvent = true;
                    break;
                }
            }
            return badHabits.Count != 0 || (privateMaids.Count != 0 && privateMaids.ElementAt(privateMaids.Count - 1).hasIllness()) || cardListHasEvent;
        }

        internal bool hasBadHabit()
        {
            return badHabits.Count != 0;
        }

        internal Card removeBadHabit()
        {
            Card temp = badHabits.ElementAt(0);
            badHabits.RemoveAt(0);
            return temp;
        }

        internal PrivateQuartersCard privateMaid()
        {
            return privateMaids.ElementAt(privateMaids.Count-1);
        }

        internal bool hasPrivateMaid()
        {
            return privateMaids.Count != 0;
        }
    }
}
