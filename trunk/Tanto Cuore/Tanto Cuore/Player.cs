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
        internal Hand hand;
        internal Deck deck;
        internal PrivateQuarters privateQuarters;
        internal List<Card> playedCards;
        internal int servings = 1;
        internal int love = 0;
        internal int employments = 1;
        internal int playerNumber;
        int totalNumberOfPlayers;
        PlayArea thePlayArea;
        public bool gainedExtraServing { get; set; }
        public bool gainedExtraCard { get; set; }
        public bool otherPlayerHasAmber { get; set; }
        public bool playerIsAI { get; set; }
        public bool playerIsOnline { get; set; }

        public Player(int playerNumber, int totalNumberOfPlayers, PlayArea thePlayArea, bool isAI, bool isOnline)
        {
            playerIsAI = isAI;
            playerIsOnline = isOnline;
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
            gainedExtraCard = false;
            gainedExtraServing = false;
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
                if (drawsTemp > 0 && hasPrivateMaid() && !privateQuarters.privateMaid().hasIllness())
                {
                    if (privateMaid().getCardNumber() == 28 && !gainedExtraCard)
                    {
                        drawsTemp++;
                        gainedExtraCard = false;
                    }
                    else if (privateMaid().getCardNumber() == 24 && !gainedExtraServing)
                    {
                        servings++;
                        gainedExtraServing = false;
                    }
                }
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
                                target2 = totalNumberOfPlayers-1;
                            }
                            if (target1 != playerNumber && !thePlayArea.playerHasCard(target1, 14))
                            {
                                thePlayArea.addBadHabitTo(target1);
                            }
                            if (target2 != playerNumber && target1 != target2 && !thePlayArea.playerHasCard(target2, 14))
                            {
                                thePlayArea.addBadHabitTo(target1);
                            }
                            break;
                        case 9:
                            thePlayArea.decideToDiscardForServingsMode();
                            break;
                        case 12:
                            if (thePlayArea.aPlayerHasCardsInDeck())
                            {
                                thePlayArea.selectDeckMode();
                            }
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
            if (!(hasChamberMaids() || hasPrivateMaid()))
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
        
        internal bool hasChamberMaids()
        {
            return privateQuarters.hasChamberMaids();
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
            int handsize = 5;
            if (deck.hasCards() && otherPlayerHasAmber)
            {
                if (!(deck.showTopCard().getCardNumber() <= 18))
                {
                    handsize--;
                }
                deck.discardTopCard();
                otherPlayerHasAmber = false;
            }
            for (int index = 0; index < handsize; index++)
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

        internal bool chamberMaidCard(int currentCardNumber)
        {
            Card temp = hand.lookAtCardInHand(currentCardNumber);
            if (temp.getCanBeChambered() && servings >= temp.getChamperCost())
            {
                privateQuarters.addCardToPrivateQuarters(hand.playCard(currentCardNumber));
                servings -= temp.getChamperCost();
                return true;
            }
            return false;
        }

        internal Card lookAtCardInHand(int currentCardNumber)
        {
            if (currentCardNumber < hand.getHand().Count)
            {
                return hand.getHand().ElementAt(currentCardNumber);
            }
            return null;
        }

        internal void drawPrivateQuartersRemovingIllnesses(SpriteBatch spriteBatch)
        {
            privateQuarters.drawRemovingIllnesses(spriteBatch, thePlayArea);
        }

        internal int getNumberOfMaidsInPrivateQuarters()
        {
            return privateQuarters.getNumberOfMaidsInPrivateQuarters();
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

        internal void refundIllness()
        {
            love += 4;
            employments++;
        }

        internal void giveIllnessToChamberMaid(int item)
        {
            privateQuarters.addIllnessToCard(item, new Card(29));
        }

        internal void giveIllnessToPrivateMaid()
        {
            privateQuarters.addIllnessToPrivateMaid();
        }

        internal bool hasCardsInDeck()
        {
            return deck.hasCards();
        }

        internal void drawPrivateQuarters(SpriteBatch spriteBatch)
        {
            privateQuarters.draw(spriteBatch, thePlayArea);
        }

        internal bool exchange(Card card)
        {
            if (card.getCost() <= 4)
            {
                hand.addCardToHand(card);
                hand.removeOneLove();
                return true;
            }
            return false;
        }

        internal void addServing()
        {
            servings++;
        }

        internal void startTurn()
        {
            if (hasPrivateMaid() && !privateQuarters.privateMaid().hasIllness())
            {
                int privateMaidNumber = privateQuarters.getPrivateMaidNumber();
                switch (privateMaidNumber)
                {
                    case 19:
                        thePlayArea.otherPlayersDiscardTopCardDuringEndTurn();
                        break;
                    case 20:
                        if ((privateQuarters.hasChamberMaids() || privateQuarters.hasPrivateMaid()) && thePlayArea.otherPlayersHaveMaidsInPrivateQuarters(this))
                        {
                            thePlayArea.discardHandToAddIllnessesToOneMaidMode();
                        }
                        break;
                    case 21:
                        if (privateQuarters.hasEvents() && thePlayArea.otherPlayersHaveMaidsInPrivateQuarters(this))
                        {
                            thePlayArea.moveEventCardToAnotherPlayersPrivateQuartersMode();
                        }
                        break;
                    case 22:
                        thePlayArea.loveOrEmploymentChoice();
                        break;
                    case 23:
                        hand.addCardToHand(deck.drawCard());
                        break;
                    case 24:
                        gainedExtraServing = false;
                        break;
                    case 25:
                        thePlayArea.lookAtRandomCardInAnotherPlayersHandAndSwapMode();
                        break;
                    case 26:
                        servings++;
                        break;
                    case 27:
                        love++;
                        break;
                    case 28:
                        gainedExtraCard = false;
                        break;
                }
            }
            if (hand.containsCard(31) && privateQuarters.hasIllnesses())
            {
                thePlayArea.discard3LoveToRemoveIllness();
            }
        }
        
        internal void addLove()
        {
            love++;
        }

        internal void addEmployment()
        {
            employments++;
        }

        internal void exchangeCardsWith(Player player, int randomCard1, int randomCard2)
        {
            Card temp1 = player.hand.discardCard(randomCard2);
            Card temp2 = hand.discardCard(randomCard1);
            hand.addCardToHand(temp1);
            player.hand.addCardToHand(temp2);
        }

        internal int find3LoveCard()
        {
            for (int index = 0; index < hand.getHand().Count; index++)
            {
                if (hand.getHand().ElementAt(index).getCardNumber() == 31)
                {
                    return index;
                }
            }
            return 0;
        }

        internal bool handContains(Card card)
        {
            if (hand.getHand().Count > 0)
            {
                return hand.containsCard(card.getCardNumber());
            }
            return false;
        }

        internal PrivateQuartersCard chamberMaidAt(int item)
        {
            return privateQuarters.chamberMaidAt(item);
        }

        internal VictoryPointPackage calulateVP()
        {
            VictoryPointPackage VP = new VictoryPointPackage();
            for (int index = 0; index < hand.getHand().Count; index++)
            {
                VP.VP += hand.getHand().ElementAt(index).getVP();
                if (hand.getHand().ElementAt(index).getVariableVP())
                {
                    int cardNumber = hand.getHand().ElementAt(index).getCardNumber();
                    switch (cardNumber)
                    {
                        case 2:
                            VP.coletteCounter++;
                            break;
                        case 4:
                            VP.opheliaCounter++;
                            break;
                    }
                }
            }
            VP = deck.CalculateVP(VP);
            if (VP.opheliaCounter > 1)
            {
                VP.VP += calulateVPFromOphelia(VP.opheliaCounter);
            }
            VP = privateQuarters.caculateVP(VP);
            return VP;
        }

        private int calulateVPFromOphelia(int p)
        {
            if (p % 2 == 0)
            {
                return p * -2;
            }
            return p * 2;
        }

        internal int getServings()
        {
            return servings;
        }

        internal void recheck()
        {
            if (hand.containsCard(31) && privateQuarters.hasIllnesses())
            {
                thePlayArea.discard3LoveToRemoveIllness();
            }
        }

        internal int getLove()
        {
            return love;
        }

        internal int getEmployments()
        {
            return employments;
        }

        internal int getNumberOfBadHabits()
        {
            return privateQuarters.getNumberOfBadHabits();
        }

        internal bool privateMaidHasIllness()
        {
            return privateQuarters.privateMaidHasIllness();
        }
    }
}
