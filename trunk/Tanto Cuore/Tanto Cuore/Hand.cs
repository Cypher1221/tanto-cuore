﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class Hand
    {
        List<Card> hand;

        public Hand()
        {
            hand = new List<Card>();
        }

        public List<Card> getHand()
        {
            return hand;
        }

        public void addCardToHand(Card drawnCard)
        {
            hand.Add(drawnCard);
        }

        public Card playCard(int index)
        {
            Card playedCard = hand.ElementAt(index);
            hand.RemoveAt(index);
            return playedCard;
        }

        public Card lookAtCardInHand(int index)
        {
            return hand.ElementAt(index);
        }

        internal Card discardCard(int handIndex)
        {
            Card discardCard = hand.ElementAt(handIndex);
            hand.RemoveAt(handIndex);
            return discardCard;
        }

        internal void clear()
        {
            hand.Clear() ;
        }
    }
}
