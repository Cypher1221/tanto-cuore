using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanto_Cuore
{
    class PlayArea
    {
        CardPile oneLove;
        CardPile twoLove;
        CardPile threeLove;
        List<CardPile> generalMaids;
        CardPile marianne;
        CardPile colette;
        CardPile badHabits;
        CardPile illnesses;
        CardPile privateMaidOne;
        CardPile privateMaidTwo;
        CardPile privateMaidPile;

        public PlayArea()
        {
            generalMaids = new List<CardPile>();
            oneLove = new CardPile(new Card(33), 36);
            twoLove = new CardPile(new Card(32), 12);
            threeLove = new CardPile(new Card(31), 8);
            marianne = new CardPile(new Card(1), 8);
            colette = new CardPile(new Card(2), 24);
            generalMaids.Add(new CardPile(new Card(16), 10));
            generalMaids.Add(new CardPile(new Card(17), 10));
            generalMaids.Add(new CardPile(new Card(18), 10));
            generalMaids.Add(new CardPile(new Card(15), 10));
            generalMaids.Add(new CardPile(new Card(13), 10));
            generalMaids.Add(new CardPile(new Card(10), 10));
            generalMaids.Add(new CardPile(new Card(11), 10));
            generalMaids.Add(new CardPile(new Card(6), 10));
            generalMaids.Add(new CardPile(new Card(5), 10));
            generalMaids.Add(new CardPile(new Card(3), 8));
            List<Card> privateMaids = new List<Card>();
            for (int index = 0; index < 10; index++)
            {
                privateMaids.Add(new Card(index + 19));
            }
            privateMaidPile = new CardPile(privateMaids);
            privateMaidOne = new CardPile(privateMaidPile.getTopCard(), 1);
            privateMaidTwo = new CardPile(privateMaidPile.getTopCard(), 1);
        }

        public PlayArea(List<Card> genralMaidList)
        {
            generalMaids = new List<CardPile>();
            oneLove = new CardPile(new Card(33), 36);
            twoLove = new CardPile(new Card(32), 12);
            threeLove = new CardPile(new Card(31), 8);
            marianne = new CardPile(new Card(1), 8);
            colette = new CardPile(new Card(2), 24);
            badHabits = new CardPile(new Card(30), 16);
            illnesses = new CardPile(new Card(29), 10);
            List<Card> privateMaids = new List<Card>();
            for (int index = 0; index < 10; index++)
            {
                privateMaids.Add(new Card(index + 19));
                if (genralMaidList.ElementAt(index).getCardNumber() != 3 || genralMaidList.ElementAt(index).getCardNumber() != 4)
                {
                    generalMaids.Add(new CardPile(genralMaidList.ElementAt(index), 10));
                }
                else
                {
                    generalMaids.Add(new CardPile(genralMaidList.ElementAt(index), 8));
                }
            }
            privateMaidPile = new CardPile(privateMaids);
            privateMaidOne = new CardPile(privateMaidPile.getTopCard(), 1);
            privateMaidTwo = new CardPile(privateMaidPile.getTopCard(), 1);
        }
    }
}
