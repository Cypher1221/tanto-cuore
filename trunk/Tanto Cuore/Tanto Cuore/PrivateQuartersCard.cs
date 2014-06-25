using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class PrivateQuartersCard
    {
        Card thisCard;
        List<Card> illnesses;

        public PrivateQuartersCard(Card card)
        {
            thisCard = card;
            illnesses = new List<Card>();
        }

        public Card removeIllness(){
            if (illnesses.Count == 0)
            {
                return null;
            }
            else
            {
                Card card = illnesses.ElementAt(0);
                illnesses.RemoveAt(0);
                return card;
            }
        }

        public bool addIllness(Card illness)
        {
            if (illness.getCardNumber() != 29)
            {
                return false;
            }
            illnesses.Add(illness);
            return true;
        }

        public int getNumberOfIllnesses()
        {
            return illnesses.Count;
        }
    }
}
