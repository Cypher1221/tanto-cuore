using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class CardPile
    {
        List<Card> pile;
        bool faceDown;

        public CardPile(List<Card> newPile)
        {
            pile = new List<Card>(newPile);
            faceDown = true;
            shuffle();
        }

        public CardPile(Card pileType, int numberOfCards)
        {
            faceDown = false;
            pile = new List<Card>();
            for (int card = 0; card < numberOfCards; card++)
            {
                pile.Add(pileType);
            }
        }

        private void shuffle()
        {
            if (faceDown)
            {
                Random random = new Random();
                List<Card> tempList = new List<Card>(pile);
                pile.Clear();
                int totalNumberOfCards = tempList.Count;
                for (int index = 0; index < totalNumberOfCards; index++)
                {
                    int randomCard = random.Next(0, tempList.Count);
                    pile.Add(tempList.ElementAt(randomCard));
                    tempList.RemoveAt(randomCard);
                }
            }
        }

        public Card getTopCard()
        {
            Card card = pile.ElementAt(0);
            pile.RemoveAt(0);
            return card;
        }
        
        public Card lookAtTopCard()
        {
            return pile.ElementAt(0);
        }

        public int getNumberOfRemainingCards(){
            return pile.Count;
        }

        public void addCard(Card card)
        {
            pile.Add(card);
        }
    }
}
