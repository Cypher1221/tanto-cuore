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
    class Player
    {
        Hand hand;
        Deck deck;
        PrivateQuarters privateQuarters;
        List<Card> playedCards;
        int servings = 1;
        int love = 0;
        int employments = 1;
        int playerNumber;
        int totalNumberOfPlayers;
        PlayArea thePlayArea;


        public Player(int playerNumber, int totalNumberOfPlayers, PlayArea thePlayArea)
        {
            hand = new Hand();
            deck = new Deck();
            hand.addCardToHand(deck.drawCard());
            hand.addCardToHand(deck.drawCard());
            hand.addCardToHand(deck.drawCard());
            hand.addCardToHand(deck.drawCard());
            hand.addCardToHand(deck.drawCard());
            privateQuarters = new PrivateQuarters();
            playedCards = new List<Card>();
            this.playerNumber = playerNumber;
            this.totalNumberOfPlayers = totalNumberOfPlayers;
            this.thePlayArea = thePlayArea;
        }

        internal void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            List<Card> hand = this.hand.getHand();
            for (int index = 0; index < hand.Count; index++)
            {
                if (thePlayArea.getCurrentCardNumber() == index && thePlayArea.getCurrentPhase() == 0)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[hand.ElementAt(index).getCardNumber() - 1], new Vector2(300 + 100 * index, 600), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[hand.ElementAt(index).getCardNumber() - 1], new Vector2(300 + 100 * index, 600), Color.White);
                }
            }
            if (deck.topDiscardPileCard() != null)
            {
                spriteBatch.Draw(Game1.cardPicturesMini[deck.topDiscardPileCard().getCardNumber() - 1], new Vector2(200, 500), Color.White);
            }
            if (deck.showTopCard() != null)
            {
                //spriteBatch.Draw(Game1.cardPicturesMini[deck.showTopCard().getCardNumber() - 1], new Vector2(150, 600), Color.White);
                spriteBatch.Draw(Game1.cardBack, new Vector2(200, 600), Color.White);
            }
            for (int index = 0; index < playedCards.Count; index++)
            {
                spriteBatch.Draw(Game1.cardPicturesMini[playedCards.ElementAt(index).getCardNumber() - 1], new Vector2(300 + 100 * index, 500), Color.White);
            }
            spriteBatch.DrawString(Game1.font, "Servings: " + servings, new Vector2(0,500), Color.White);
            spriteBatch.DrawString(Game1.font, "Love: " + love, new Vector2(0,550), Color.White);
            spriteBatch.DrawString(Game1.font, "Employments: " + employments, new Vector2(0,600), Color.White);
            spriteBatch.End();
        }

        public void drawCard()
        {
            hand.addCardToHand(deck.drawCard());
        }

        public void playCard(int handIndex)
        {
            Card temp = hand.lookAtCardInHand(handIndex);
            if (temp.getCardNumber() > 2 && temp.getCardNumber() < 19 && servings >= 1)
            {
                servings--;
                int drawsTemp = temp.getDraws();
                int servingsTemp = temp.getServings();
                int employmentsTemp = temp.getEmployments();
                int loveTemp = temp.getLove();
                bool isSpecialCard = temp.getSpecialAbility();
                for (int index = 0; index < drawsTemp; index++)
                {
                    hand.addCardToHand(deck.drawCard());
                }
                servings += servingsTemp;
                employments += employmentsTemp;
                love += loveTemp;
                if (isSpecialCard)
                {
                    int cardNumber = temp.getCardNumber();
                    switch (cardNumber)
                    {
                        case 5:
                            List<Card> cards = hand.getHand();
                            for (int index = 0; index < cards.Count; index++)
                            {
                                if (cards.ElementAt(index).getCardNumber() == 33)
                                {
                                    thePlayArea.exchangeMode();
                                    break;
                                }
                            }
                            break;
                        case 6:
                            thePlayArea.otherPlayersDrawCard(playerNumber);
                            break;
                        case 7:
                            thePlayArea.selectDiscardMode();
                            break;
                        case 8:
                            int target1 = playerNumber + 1;
                            int target2 = playerNumber - 1;
                            if (target1 >= totalNumberOfPlayers)
                            {
                                target1 = 0;
                            }
                            if (target2 < 0)
                            {
                                target2 = totalNumberOfPlayers;
                            }
                            if (target1 != playerNumber)
                            {
                                thePlayArea.addBadHabitTo(target1);
                            }
                            if (target2 != playerNumber && target1 != target2)
                            {
                                thePlayArea.addBadHabitTo(target1);
                            }
                            break;
                        case 9:
                            thePlayArea.decideToDiscardForServingsMode();
                            break;
                        case 12:
                            thePlayArea.selectDeckMode();
                            break;
                        case 14:
                            if (hasEvents())
                            {
                                thePlayArea.selectEventMode();
                            }
                            break;
                    }
                }
                playedCards.Add(hand.playCard(handIndex));
            }
            else if (temp.getCardNumber() >= 31 && temp.getCardNumber() <= 33)
            {
                int loveTemp = temp.getLove();
                love += loveTemp;
                playedCards.Add(hand.playCard(handIndex));
            }
        }

        private bool hasEvents()
        {
            if (!hasMaidsInPrivateQuarters())
            {
                return false;
            }
            else
            {
                return privateQuarters.hasEvents();
            }
        }

        public void discardCard(int handIndex)
        {
            deck.discardCard(hand.discardCard(handIndex));
        }
        
        internal bool hasMaidsInPrivateQuarters()
        {
            return privateQuarters.containsCards();
        }

        internal void addBadHabitToPrivateQuarters(Card card)
        {
            privateQuarters.addBadHabit(card);
        }

        public void endTurn()
        {
            for (int index = 0; index < playedCards.Count; index++)
            {
                deck.discardCard(playedCards.ElementAt(index));
            }
            deck.discardHand(hand.getHand());
            hand.clear();
            playedCards.Clear();
            servings = 1;
            love = 0;
            employments = 1;
            for (int index = 0; index < 5; index++)
            {
                hand.addCardToHand(deck.drawCard());
            }
        }

        internal int getNumberOfCardsInHand()
        {
            return hand.getHand().Count;
        }

        public bool buy(Card card)
        {
            if (card.getCost() <= love && employments > 0)
            {
                employments--;
                love -= card.getCost();
                if (card.getCardNumber() >= 19 && card.getCardNumber() <= 30)
                {
                    if (card.getCardNumber() >= 19 && card.getCardNumber() <= 28)
                    {
                        privateQuarters.addCardToPrivateQuarters(card);
                    }
                    else if (card.getCardNumber() == 29)
                    {
                        thePlayArea.selectChamberMaidMode();
                    }
                    else if (card.getCardNumber() == 30)
                    {
                        thePlayArea.selectPlayerMode();
                    }
                }
                else
                {
                    deck.discardCard(card);
                }
                return true;
            }
            return false;
        }

        internal void chamberMaidCard(int currentCardNumber)
        {
            Card temp = hand.lookAtCardInHand(currentCardNumber);
            if (temp.getCanBeChambered() && servings >= temp.getChamperCost())
            {
                privateQuarters.addCardToPrivateQuarters(hand.playCard(currentCardNumber));
                servings -= temp.getChamperCost();
            }
        }

        internal Card lookAtCardInHand(int currentCardNumber)
        {
            return hand.getHand().ElementAt(currentCardNumber);
        }

        internal void drawPrivateQuarters(SpriteBatch spriteBatch)
        {
            privateQuarters.draw(spriteBatch, thePlayArea);
        }

        internal int getNumberOfMaidsInPrivateQuarters()
        {
            return privateQuarters.getNumberOfMaidsInPrivateQuarters();
        }

        internal PrivateQuartersCard privateMaidAt(int item)
        {
            return privateQuarters.privateMaidAt(item);
        }

        internal Card removeIllnessFromMaid(int item)
        {
            return privateQuarters.removeIllenessFrom(item);
        }

        internal Card removeIllnessFromPrivateMaid()
        {
            return privateQuarters.removeIllenessPrivateMaid();
        }

        internal void refundBadHabit()
        {
            love += 2;
            employments++;
        }

        internal void drawHand(SpriteBatch spriteBatch)
        {
            List<Card> hand = this.hand.getHand();
            for (int index = 0; index < hand.Count; index++)
            {
                if (thePlayArea.getCurrentCardNumber() == index && thePlayArea.getCurrentPhase() == 0)
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[hand.ElementAt(index).getCardNumber() - 1], new Vector2(300 + 100 * index, 600), Color.Red);
                }
                else
                {
                    spriteBatch.Draw(Game1.cardPicturesMini[hand.ElementAt(index).getCardNumber() - 1], new Vector2(300 + 100 * index, 600), Color.White);
                }
            }
        }

        internal bool hasBadHabit()
        {
            return privateQuarters.hasBadHabit();
        }

        internal Card removeBadHabit()
        {
            return privateQuarters.removeBadHabit();
        }

        internal PrivateQuartersCard privateMaid()
        {
            return privateQuarters.privateMaid();
        }

        internal bool hasPrivateMaid()
        {
            return privateQuarters.hasPrivateMaid();
        }

        internal void discardTopCardOfDeck()
        {
            deck.discardTopCard();
        }

        internal Card lookAtTopCardOfDeck()
        {
            return deck.showTopCard();
        }
    }
}
