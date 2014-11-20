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
            if (card.getCardNumber() == 2 || (card.getCardNumber() >= 15 && card.getCardNumber() <= 18) )
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

        internal bool hasChamberMaids()
        {
            return cardList.Count != 0;
        }

        internal void addBadHabit(Card card)
        {
            if (privateMaids.Count != 0 || cardList.Count != 0)
            {
                badHabits.Add(card);
            }
        }

        internal void drawRemovingIllnesses(SpriteBatch spriteBatch, PlayArea playArea)
        {
            spriteBatch.Begin();
            for (int index = 0; index < cardList.Count; index++)
            {
                if (cardList.ElementAt(index).getNumberOfIllnesses() != 0){
                    if (playArea.currentSelectOption == 0 && playArea.item == index)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[cardList.ElementAt(index).getCardNumber()-1], new Vector2(100 * index, 0), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[cardList.ElementAt(index).getCardNumber()-1], new Vector2(100 * index, 0), Color.White);
                    }
                }
            }
            if (privateMaids.Count != 0 && privateMaids.ElementAt(privateMaids.Count-1).getNumberOfIllnesses() != 0)
            {
                if (playArea.currentSelectOption == 1)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[privateMaids.ElementAt(privateMaids.Count - 1).getCardNumber()-1], new Vector2(0, 100), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[privateMaids.ElementAt(privateMaids.Count - 1).getCardNumber()-1], new Vector2(0, 100), Color.White);
                }
            }
            if (badHabits.Count != 0){
                if (playArea.currentSelectOption == 2)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[29], new Vector2(0, 200), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[29], new Vector2(0, 200), Color.White);
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
            return privateMaids.ElementAt(item);
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

        internal void addIllnessToPrivateMaid()
        {
            privateMaids.ElementAt(privateMaids.Count - 1).addIllness(new Card(29));
        }

        internal void draw(SpriteBatch spriteBatch, PlayArea thePlayArea)
        {
            spriteBatch.Begin();
            for (int index = 0; index < cardList.Count; index++)
            {
                if (thePlayArea.currentSelectOption == 0 && thePlayArea.item == index)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[cardList.ElementAt(index).getCardNumber()-1], new Vector2(100 * index, 0), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[cardList.ElementAt(index).getCardNumber()-1], new Vector2(100 * index, 0), Color.White);
                }
            }
            if (hasPrivateMaid())
            {
                if (thePlayArea.currentSelectOption == 1)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[privateMaids.ElementAt(privateMaids.Count - 1).getCardNumber()-1], new Vector2(0, 100), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[privateMaids.ElementAt(privateMaids.Count - 1).getCardNumber()-1], new Vector2(0, 100), Color.White);
                }
            }
            spriteBatch.End();
        }

        internal int getPrivateMaidNumber()
        {
            return privateMaid().getCardNumber();
        }

        internal bool hasIllnesses()
        {
            for (int index = 0; index < cardList.Count; index++)
            {
                if (cardList.ElementAt(index).hasIllness())
                {
                    return true;
                }
            }
            return false || (privateMaids.Count > 0 && privateMaid().hasIllness());
        }

        internal PrivateQuartersCard chamberMaidAt(int item)
        {
            return cardList.ElementAt(item);
        }

        internal VictoryPointPackage caculateVP(VictoryPointPackage VP)
        {
            int VictoryPoints = 0;
            int stafanCounter = 0;
            int azureCounter = 0;
            int violaConter = 0;
            int rougeCounter = 0;
            if (badHabits.Count > 4)
            {
                VictoryPoints -= badHabits.Count * 2;
            }
            else
            {
                VictoryPoints -= badHabits.Count;
            }

            for (int index = 0; index < privateMaids.Count; index++)
            {
                if (!privateMaids.ElementAt(index).hasIllness())
                {
                    VictoryPoints += privateMaids.ElementAt(index).getVP();
                }
            }

            for (int index = 0; index < cardList.Count; index++)
            {
                if (!cardList.ElementAt(index).hasIllness())
                {
                    VictoryPoints += cardList.ElementAt(index).getVP();
                    int cardNumber = cardList.ElementAt(index).getCardNumber();
                    switch (cardNumber)
                    {
                        case 2:
                            VP.coletteCounter++;
                            break;
                        case 15:
                            stafanCounter++;
                            break;
                        case 16:
                            azureCounter++;
                            break;
                        case 17:
                            violaConter++;
                            break;
                        case 18:
                            rougeCounter++;
                            break;
                    }
                }
            }

            while(stafanCounter > 1){
                if (stafanCounter >= 4)
                {
                    VictoryPoints += 12;
                    stafanCounter -= 4;
                }
                else if (stafanCounter >= 3)
                {
                    VictoryPoints += 8;
                    stafanCounter -= 3;
                }
                else if (stafanCounter >= 2)
                {
                    VictoryPoints += 4;
                    stafanCounter -= 2;
                }
            }
            while (azureCounter > 1 || violaConter > 1 || rougeCounter > 1)
            {
                if (azureCounter >= 1 && violaConter >= 1 && rougeCounter >= 1)
                {
                    VictoryPoints += 7;
                    azureCounter--;
                    violaConter--;
                    rougeCounter--;
                }
                else if (violaConter >= 1 && rougeCounter >= 1)
                {
                    VictoryPoints += 3;
                    violaConter--;
                    rougeCounter--;
                }
                else if (azureCounter >= 1 && violaConter >= 1)
                {
                    VictoryPoints += 3;
                    azureCounter--;
                    violaConter--;
                }
                else if (azureCounter >= 1 && rougeCounter >= 1)
                {
                    VictoryPoints += 3;
                    azureCounter--;
                    rougeCounter--;
                }
                else
                {
                    break;
                }
            }

            VP.VP += VictoryPoints;
            return VP;
        }

        internal int getNumberOfBadHabits()
        {
            return badHabits.Count;
        }

        internal bool privateMaidHasIllness()
        {
            return privateMaid().hasIllness();
        }

        internal int getNumberOfPrivateMaids()
        {
            return privateMaids.Count;
        }

        internal void setNumberOfBadHabits(int p)
        {
            if (badHabits.Count < p)
            {
                for (int index = 0; index < p - badHabits.Count; index++)
                {
                    badHabits.Add(new Card(30));
                }
            }
            else if (badHabits.Count > p)
            {
                for (int index = 0; index < badHabits.Count - p; index++)
                {
                    badHabits.RemoveAt(0);
                }
            }
        }

        internal void RemoveAll()
        {
            privateMaids = new List<PrivateQuartersCard>();
            cardList = new List<PrivateQuartersCard>();
        }

        internal void addIllnessToPrivateMaidAt(int privateMaidIndex, Card card)
        {
            privateMaids.ElementAt(privateMaidIndex).addIllness(card);
        }
    }
}
