using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class Deck
    {
        List<Card> deck;
        List<Card> discardPile;

        public Deck(){
            deck = new List<Card>();
            discardPile = new List<Card>();
            discardPile.Add(new Card(2));
            discardPile.Add(new Card(2));
            discardPile.Add(new Card(2));
            discardPile.Add(new Card(33));
            discardPile.Add(new Card(33));
            discardPile.Add(new Card(33));
            discardPile.Add(new Card(33));
            discardPile.Add(new Card(33));
            discardPile.Add(new Card(33));
            discardPile.Add(new Card(33));
            this.shuffle();
        }

        public Card drawCard(){
            if (deck.Count == 0) {
                this.shuffle();
            }
            Card cur = deck.ElementAt(0);
            deck.RemoveAt(0);
            return cur;
        }

        public void discardCard(Card card)
        {
            discardPile.Add(card);
        }

        void shuffle()
        {
            int totalNumberOfCards = discardPile.Count;
            for (int index = 0; index < totalNumberOfCards; index++)
            {
                Random random = new Random();
                int randomCard = random.Next(0, discardPile.Count);
                deck.Add(discardPile.ElementAt(randomCard));
                discardPile.RemoveAt(randomCard);
            }
        }

        public Card showTopCard()
        {
            if (deck.Count != 0)
            {
                return deck.ElementAt(0);
            }
            return null;
        }

        public void removeTopCard()
        {
            discardPile.Add(deck.ElementAt(0));
            deck.RemoveAt(0);
        }

        public Card topDiscardPileCard()
        {
            if (discardPile.Count != 0)
            {
                return discardPile.ElementAt(discardPile.Count - 1);
            }
            return null;
        }

        internal void discardHand(List<Card> list)
        {
            discardPile.AddRange(list);
        }

        internal void discardTopCard()
        {
            discardPile.Add(deck.ElementAt(0));
            deck.RemoveAt(0);
        }
    }
}
