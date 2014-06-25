using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class PrivateQuarters
    {
        List<PrivateQuartersCard> cardList;
        List<PrivateQuartersCard> privateMaids;

        public PrivateQuarters()
        {
            cardList = new List<PrivateQuartersCard>();
            privateMaids = new List<PrivateQuartersCard>();
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
    }
}
