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
    class AI_Control
    {
        static int playerZeroOffsetCardNumber1 = 0;
        static int playerZeroOffsetCardNumber2 = 0;
        static int playerZeroOffsetCardNumber3 = 0;
        static int playerZeroOffsetCardNumber4 = 0;
        static int playerZeroOffsetCardNumber5 = 0;
        static int playerZeroOffsetCardNumber6 = 0;
        static int playerZeroOffsetCardNumber7 = 0;
        static int playerZeroOffsetCardNumber8 = 0;
        static int playerZeroOffsetCardNumber9 = 0;
        static int playerZeroOffsetCardNumber10 = 0;
        static int playerZeroOffsetCardNumber11 = 0;
        static int playerZeroOffsetCardNumber12 = 0;
        static int playerZeroOffsetCardNumber13 = 0;
        static int playerZeroOffsetCardNumber14 = 0;
        static int playerZeroOffsetCardNumber15 = 0;
        static int playerZeroOffsetCardNumber16 = 0;
        static int playerZeroOffsetCardNumber17 = 0;
        static int playerZeroOffsetCardNumber18 = 0;
        static int playerZeroOffsetCardNumber19 = 0;
        static int playerZeroOffsetCardNumber20 = 0;
        static int playerZeroOffsetCardNumber21 = 0;
        static int playerZeroOffsetCardNumber22 = 0;
        static int playerZeroOffsetCardNumber23 = 0;
        static int playerZeroOffsetCardNumber24 = 0;
        static int playerZeroOffsetCardNumber25 = 0;
        static int playerZeroOffsetCardNumber26 = 0;
        static int playerZeroOffsetCardNumber27 = 0;
        static int playerZeroOffsetCardNumber28 = 0;
        static int playerZeroOffsetCardNumber29 = 0;
        static int playerZeroOffsetCardNumber30 = 0;
        static int playerZeroOffsetCardNumber31 = 0;
        static int playerZeroOffsetCardNumber32 = 0;
        static int playerZeroOffsetCardNumber33 = 0;
        static int playerTwoOffsetCardNumber1 = 0;
        static int playerTwoOffsetCardNumber2 = 0;
        static int playerTwoOffsetCardNumber3 = 0;
        static int playerTwoOffsetCardNumber4 = 0;
        static int playerTwoOffsetCardNumber5 = 0;
        static int playerTwoOffsetCardNumber6 = 0;
        static int playerTwoOffsetCardNumber7 = 0;
        static int playerTwoOffsetCardNumber8 = 0;
        static int playerTwoOffsetCardNumber9 = 0;
        static int playerTwoOffsetCardNumber10 = 0;
        static int playerTwoOffsetCardNumber11 = 0;
        static int playerTwoOffsetCardNumber12 = 0;
        static int playerTwoOffsetCardNumber13 = 0;
        static int playerTwoOffsetCardNumber14 = 0;
        static int playerTwoOffsetCardNumber15 = 0;
        static int playerTwoOffsetCardNumber16 = 0;
        static int playerTwoOffsetCardNumber17 = 0;
        static int playerTwoOffsetCardNumber18 = 0;
        static int playerTwoOffsetCardNumber19 = 0;
        static int playerTwoOffsetCardNumber20 = 0;
        static int playerTwoOffsetCardNumber21 = 0;
        static int playerTwoOffsetCardNumber22 = 0;
        static int playerTwoOffsetCardNumber23 = 0;
        static int playerTwoOffsetCardNumber24 = 0;
        static int playerTwoOffsetCardNumber25 = 0;
        static int playerTwoOffsetCardNumber26 = 0;
        static int playerTwoOffsetCardNumber27 = 0;
        static int playerTwoOffsetCardNumber28 = 0;
        static int playerTwoOffsetCardNumber29 = 0;
        static int playerTwoOffsetCardNumber30 = 0;
        static int playerTwoOffsetCardNumber31 = 0;
        static int playerTwoOffsetCardNumber32 = 0;
        static int playerTwoOffsetCardNumber33 = 0;
        static int playerThreeOffsetCardNumber1 = 0;
        static int playerThreeOffsetCardNumber2 = 0;
        static int playerThreeOffsetCardNumber3 = 0;
        static int playerThreeOffsetCardNumber4 = 0;
        static int playerThreeOffsetCardNumber5 = 0;
        static int playerThreeOffsetCardNumber6 = 0;
        static int playerThreeOffsetCardNumber7 = 0;
        static int playerThreeOffsetCardNumber8 = 0;
        static int playerThreeOffsetCardNumber9 = 0;
        static int playerThreeOffsetCardNumber10 = 0;
        static int playerThreeOffsetCardNumber11 = 0;
        static int playerThreeOffsetCardNumber12 = 0;
        static int playerThreeOffsetCardNumber13 = 0;
        static int playerThreeOffsetCardNumber14 = 0;
        static int playerThreeOffsetCardNumber15 = 0;
        static int playerThreeOffsetCardNumber16 = 0;
        static int playerThreeOffsetCardNumber17 = 0;
        static int playerThreeOffsetCardNumber18 = 0;
        static int playerThreeOffsetCardNumber19 = 0;
        static int playerThreeOffsetCardNumber20 = 0;
        static int playerThreeOffsetCardNumber21 = 0;
        static int playerThreeOffsetCardNumber22 = 0;
        static int playerThreeOffsetCardNumber23 = 0;
        static int playerThreeOffsetCardNumber24 = 0;
        static int playerThreeOffsetCardNumber25 = 0;
        static int playerThreeOffsetCardNumber26 = 0;
        static int playerThreeOffsetCardNumber27 = 0;
        static int playerThreeOffsetCardNumber28 = 0;
        static int playerThreeOffsetCardNumber29 = 0;
        static int playerThreeOffsetCardNumber30 = 0;
        static int playerThreeOffsetCardNumber31 = 0;
        static int playerThreeOffsetCardNumber32 = 0;
        static int playerThreeOffsetCardNumber33 = 0;
        static int playerFourOffsetCardNumber1 = 0;
        static int playerFourOffsetCardNumber2 = 0;
        static int playerFourOffsetCardNumber3 = 0;
        static int playerFourOffsetCardNumber4 = 0;
        static int playerFourOffsetCardNumber5 = 0;
        static int playerFourOffsetCardNumber6 = 0;
        static int playerFourOffsetCardNumber7 = 0;
        static int playerFourOffsetCardNumber8 = 0;
        static int playerFourOffsetCardNumber9 = 0;
        static int playerFourOffsetCardNumber10 = 0;
        static int playerFourOffsetCardNumber11 = 0;
        static int playerFourOffsetCardNumber12 = 0;
        static int playerFourOffsetCardNumber13 = 0;
        static int playerFourOffsetCardNumber14 = 0;
        static int playerFourOffsetCardNumber15 = 0;
        static int playerFourOffsetCardNumber16 = 0;
        static int playerFourOffsetCardNumber17 = 0;
        static int playerFourOffsetCardNumber18 = 0;
        static int playerFourOffsetCardNumber19 = 0;
        static int playerFourOffsetCardNumber20 = 0;
        static int playerFourOffsetCardNumber21 = 0;
        static int playerFourOffsetCardNumber22 = 0;
        static int playerFourOffsetCardNumber23 = 0;
        static int playerFourOffsetCardNumber24 = 0;
        static int playerFourOffsetCardNumber25 = 0;
        static int playerFourOffsetCardNumber26 = 0;
        static int playerFourOffsetCardNumber27 = 0;
        static int playerFourOffsetCardNumber28 = 0;
        static int playerFourOffsetCardNumber29 = 0;
        static int playerFourOffsetCardNumber30 = 0;
        static int playerFourOffsetCardNumber31 = 0;
        static int playerFourOffsetCardNumber32 = 0;
        static int playerFourOffsetCardNumber33 = 0;
        static int activePlayer = 0;

        public static bool playBestCard(Player AIPlayer)
        {
            int bestCardNumber = -1;
            if (AIPlayer.getServings() > 1)
            {
                for (int index = 0; index < AIPlayer.getNumberOfCardsInHand(); index++)
                {
                    if (AIPlayer.lookAtCardInHand(index).getCanBeChambered() && AIPlayer.lookAtCardInHand(index).getChamperCost() == 1)
                    {
                        if (AIPlayer.lookAtCardInHand(index).getCardNumber() == 15)
                        {
                            if (AIPlayer.playerNumber == 0)
                            {
                                playerZeroOffsetCardNumber15++;
                                playerZeroOffsetCardNumber15++;
                            }

                            if (AIPlayer.playerNumber == 1)
                            {
                                playerTwoOffsetCardNumber15++;
                                playerTwoOffsetCardNumber15++;
                            }

                            if (AIPlayer.playerNumber == 2)
                            {
                                playerThreeOffsetCardNumber15++;
                                playerThreeOffsetCardNumber15++;
                            }

                            if (AIPlayer.playerNumber == 3)
                            {
                                playerFourOffsetCardNumber15++;
                                playerFourOffsetCardNumber15++;
                            }
                        }
                        AIPlayer.chamberMaidCard(index);
                        return true;
                    }
                }
            }
            for (int index = 0; index < AIPlayer.getNumberOfCardsInHand(); index++)
            {
                if ((AIPlayer.lookAtCardInHand(index).getCardNumber() > 2 && AIPlayer.lookAtCardInHand(index).getCardNumber() < 19) || AIPlayer.lookAtCardInHand(index).getCardNumber() == 31 || AIPlayer.lookAtCardInHand(index).getCardNumber() == 32 || AIPlayer.lookAtCardInHand(index).getCardNumber() == 33)
                {
                    if (bestCardNumber != -1 && AIPlayer.getServings() != 0)
                    {
                        if (calculateBestCardToPlay(AIPlayer.lookAtCardInHand(index), AIPlayer.lookAtCardInHand(bestCardNumber)))
                        {
                            bestCardNumber = index;
                        }
                    }
                    else if (AIPlayer.getServings() != 0)
                    {
                        bestCardNumber = index;
                    }
                    else if (AIPlayer.getServings() == 0 && (AIPlayer.lookAtCardInHand(index).getCardNumber() == 31 || AIPlayer.lookAtCardInHand(index).getCardNumber() == 32 || AIPlayer.lookAtCardInHand(index).getCardNumber() == 33))
                    {
                        bestCardNumber = index;
                    }
                }
            }
            if (bestCardNumber == -1)
            {
                for (int index = 0; index < AIPlayer.getNumberOfCardsInHand(); index++)
                {
                    if (AIPlayer.chamberMaidCard(index))
                    {
                        index--;
                    }
                }
                return false;
            }
            else
            {
                AIPlayer.playCard(bestCardNumber);
                return true;
            }
        }

        private static bool calculateBestCardToPlay(Card card, Card card_2)
        {
            if (card.getServings() < card_2.getServings())
            {
                return false;
            }
            if (card.getServings() > card_2.getServings())
            {
                return true;
            }
            if (card.getDraws() < card_2.getDraws())
            {
                return false;
            }
            if (card.getDraws() > card_2.getDraws())
            {
                return true;
            }
            if (card.getLove() < card_2.getLove())
            {
                return false;
            }
            if (card.getLove() > card_2.getLove())
            {
                return true;
            }
            if (card.getEmployments() < card_2.getEmployments())
            {
                return false;
            }
            if (card.getEmployments() > card_2.getEmployments())
            {
                return true;
            }
            return true;
        }

        public static bool buyBestCard(Player AIPlayer, PlayArea playingArea)
        {
            activePlayer = AIPlayer.playerNumber;
            Card bestCardToBuy = null;
            int pileNumber = -1;
            if (AIPlayer.getEmployments() != 0)
            {
                for (int index = 0; index < 19; index++)
                {
                    if (index < 10)
                    {
                        if (playingArea.generalMaids.ElementAt(index).getNumberOfRemainingCards() > 0 && playingArea.generalMaids.ElementAt(index).lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.generalMaids.ElementAt(index).lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.generalMaids.ElementAt(index).lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 10)
                    {
                        if (playingArea.marianne.getNumberOfRemainingCards() > 0 && playingArea.marianne.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.marianne.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.marianne.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 11)
                    {
                        if (playingArea.colette.getNumberOfRemainingCards() > 0 && playingArea.colette.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.colette.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.colette.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 12)
                    {
                        if (playingArea.badHabits.getNumberOfRemainingCards() > 0 && playingArea.badHabits.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.badHabits.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.badHabits.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 13)
                    {
                        if (playingArea.illnesses.getNumberOfRemainingCards() > 0 && playingArea.illnesses.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.illnesses.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.illnesses.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 14)
                    {
                        if (playingArea.privateMaidOne.getNumberOfRemainingCards() > 0 && playingArea.privateMaidOne.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.privateMaidOne.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.privateMaidOne.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 15)
                    {
                        if (playingArea.privateMaidTwo.getNumberOfRemainingCards() > 0 && playingArea.privateMaidTwo.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.privateMaidTwo.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.privateMaidTwo.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 16)
                    {
                        if (playingArea.oneLove.getNumberOfRemainingCards() > 0 && playingArea.oneLove.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.oneLove.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.oneLove.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 17)
                    {
                        if (playingArea.twoLove.getNumberOfRemainingCards() > 0 && playingArea.twoLove.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.twoLove.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.twoLove.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 18)
                    {
                        if (playingArea.threeLove.getNumberOfRemainingCards() > 0 && playingArea.threeLove.lookAtTopCard().getCost() < AIPlayer.getLove())
                        {
                            if (calculateBestCardToBuy(playingArea.threeLove.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.threeLove.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                }
            }
            if (bestCardToBuy == null)
            {
                return false;
            }
            else
            {
                if (AIPlayer.buy(bestCardToBuy))
                {
                    adjustCardValues(playingArea, AIPlayer, bestCardToBuy);
                    if (pileNumber < 10)
                    {
                        playingArea.generalMaids.ElementAt(pileNumber).getTopCard();
                        if (playingArea.generalMaids.ElementAt(pileNumber).getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 10)
                    {
                        playingArea.marianne.getTopCard();
                        if (playingArea.marianne.getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 11)
                    {
                        playingArea.colette.getTopCard();
                        if (playingArea.colette.getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 12)
                    {
                        playingArea.badHabits.getTopCard();
                    }
                    else if (pileNumber == 13)
                    {
                        playingArea.illnesses.getTopCard();
                    }
                    else if (pileNumber == 14)
                    {
                        playingArea.privateMaidOne.getTopCard();
                        playingArea.privateMaidOne.addCard(playingArea.privateMaidPile.getTopCard());
                        if (playingArea.privateMaidPile.getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 15)
                    {
                        playingArea.privateMaidTwo.getTopCard();
                        playingArea.privateMaidTwo.addCard(playingArea.privateMaidPile.getTopCard());
                        if (playingArea.privateMaidPile.getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 16)
                    {
                        playingArea.oneLove.getTopCard();
                    }
                    else if (pileNumber == 17)
                    {
                        playingArea.twoLove.getTopCard();
                    }
                    else if (pileNumber == 18)
                    {
                        playingArea.threeLove.getTopCard();
                    }
                    return true;
                }
                return false;
            }
        }

        private static void adjustCardValues(PlayArea playingArea, Player AIPlayer, Card bestCardToBuy)
        {
            if (bestCardToBuy.getCardNumber() == 1)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber1--;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber12++;
                    playerZeroOffsetCardNumber9++;
                    playerZeroOffsetCardNumber20++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber1--;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber12++;
                    playerTwoOffsetCardNumber9++;
                    playerTwoOffsetCardNumber20++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber1--;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber12++;
                    playerThreeOffsetCardNumber9++;
                    playerThreeOffsetCardNumber20++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber1--;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber12++;
                    playerFourOffsetCardNumber9++;
                    playerFourOffsetCardNumber20++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 2)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber2--;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber12++;
                    playerZeroOffsetCardNumber9++;
                    playerZeroOffsetCardNumber20++;
                    playerZeroOffsetCardNumber13++;
                    playerZeroOffsetCardNumber26++;
                    playerZeroOffsetCardNumber24++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber2--;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber12++;
                    playerTwoOffsetCardNumber9++;
                    playerTwoOffsetCardNumber20++;
                    playerTwoOffsetCardNumber13++;
                    playerTwoOffsetCardNumber26++;
                    playerTwoOffsetCardNumber24++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber2--;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber12++;
                    playerThreeOffsetCardNumber9++;
                    playerThreeOffsetCardNumber20++;
                    playerThreeOffsetCardNumber13++;
                    playerThreeOffsetCardNumber26++;
                    playerThreeOffsetCardNumber24++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber2--;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber12++;
                    playerFourOffsetCardNumber9++;
                    playerFourOffsetCardNumber20++;
                    playerFourOffsetCardNumber13++;
                    playerFourOffsetCardNumber26++;
                    playerFourOffsetCardNumber24++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 3)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber3--;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber28++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber3--;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber28++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber3--;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber28++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber3--;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber28++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 4)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber4--;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber28++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber4--;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber28++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber4--;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber28++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber4--;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber28++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 5)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber5--;
                    playerZeroOffsetCardNumber33++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber5--;
                    playerTwoOffsetCardNumber33++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber5--;
                    playerThreeOffsetCardNumber33++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber5--;
                    playerFourOffsetCardNumber33++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 6)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber6--;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber6--;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber6--;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber6--;
                }
            }
            if (bestCardToBuy.getCardNumber() == 7)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber7--;
                    playerZeroOffsetCardNumber1++;
                    playerZeroOffsetCardNumber2++;
                    playerZeroOffsetCardNumber15++;
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber7--;
                    playerTwoOffsetCardNumber1++;
                    playerTwoOffsetCardNumber2++;
                    playerTwoOffsetCardNumber15++;
                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber7--;
                    playerThreeOffsetCardNumber1++;
                    playerThreeOffsetCardNumber2++;
                    playerThreeOffsetCardNumber15++;
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber7--;
                    playerFourOffsetCardNumber1++;
                    playerFourOffsetCardNumber2++;
                    playerFourOffsetCardNumber15++;
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 8)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber8--;
                    playerFourOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerThreeOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerTwoOffsetCardNumber21++;
                    playerTwoOffsetCardNumber14++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber8--;
                    playerFourOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerThreeOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerZeroOffsetCardNumber21++;
                    playerZeroOffsetCardNumber14++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber8--;
                    playerFourOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerTwoOffsetCardNumber21++;
                    playerTwoOffsetCardNumber14++;
                    playerZeroOffsetCardNumber21++;
                    playerZeroOffsetCardNumber14++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber8--;
                    playerThreeOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerTwoOffsetCardNumber21++;
                    playerTwoOffsetCardNumber14++;
                    playerZeroOffsetCardNumber21++;
                    playerZeroOffsetCardNumber14++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 9)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber9--;
                    playerZeroOffsetCardNumber2++;
                    playerZeroOffsetCardNumber15++;
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18++;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber26++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber9--;
                    playerTwoOffsetCardNumber2++;
                    playerTwoOffsetCardNumber15++;
                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18++;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber26++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber9--;
                    playerThreeOffsetCardNumber2++;
                    playerThreeOffsetCardNumber15++;
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18++;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber26++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber9--;
                    playerFourOffsetCardNumber2++;
                    playerFourOffsetCardNumber15++;
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18++;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber26++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 10)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber10--;
                    playerZeroOffsetCardNumber28++;
                    playerZeroOffsetCardNumber24++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber10--;
                    playerTwoOffsetCardNumber28++;
                    playerTwoOffsetCardNumber24++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber10--;
                    playerThreeOffsetCardNumber28++;
                    playerThreeOffsetCardNumber24++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber10--;
                    playerFourOffsetCardNumber28++;
                    playerFourOffsetCardNumber24++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 11)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber11--;
                    playerZeroOffsetCardNumber28++;
                    playerZeroOffsetCardNumber24++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber11--;
                    playerTwoOffsetCardNumber28++;
                    playerTwoOffsetCardNumber24++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber11--;
                    playerThreeOffsetCardNumber28++;
                    playerThreeOffsetCardNumber24++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber11--;
                    playerFourOffsetCardNumber28++;
                    playerFourOffsetCardNumber24++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 12)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber12--;
                    playerZeroOffsetCardNumber2++;
                    playerZeroOffsetCardNumber1++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber12--;
                    playerTwoOffsetCardNumber2++;
                    playerTwoOffsetCardNumber1++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber12--;
                    playerThreeOffsetCardNumber2++;
                    playerThreeOffsetCardNumber1++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber12--;
                    playerFourOffsetCardNumber2++;
                    playerFourOffsetCardNumber1++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 13)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber13--;
                    playerZeroOffsetCardNumber2++;
                    playerZeroOffsetCardNumber15++;
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber13--;
                    playerTwoOffsetCardNumber2++;
                    playerTwoOffsetCardNumber15++;
                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber13--;
                    playerThreeOffsetCardNumber2++;
                    playerThreeOffsetCardNumber15++;
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber13--;
                    playerFourOffsetCardNumber2++;
                    playerFourOffsetCardNumber15++;
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 14)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber14--;
                    playerFourOffsetCardNumber20--;
                    playerFourOffsetCardNumber29--;
                    playerFourOffsetCardNumber30--;
                    playerThreeOffsetCardNumber20--;
                    playerThreeOffsetCardNumber29--;
                    playerThreeOffsetCardNumber30--;
                    playerTwoOffsetCardNumber20--;
                    playerTwoOffsetCardNumber29--;
                    playerTwoOffsetCardNumber30--;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber14--;
                    playerFourOffsetCardNumber20--;
                    playerFourOffsetCardNumber29--;
                    playerFourOffsetCardNumber30--;
                    playerThreeOffsetCardNumber20--;
                    playerThreeOffsetCardNumber29--;
                    playerThreeOffsetCardNumber30--;
                    playerZeroOffsetCardNumber20--;
                    playerZeroOffsetCardNumber29--;
                    playerZeroOffsetCardNumber30--;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber14--;
                    playerFourOffsetCardNumber20--;
                    playerFourOffsetCardNumber29--;
                    playerFourOffsetCardNumber30--;
                    playerTwoOffsetCardNumber20--;
                    playerTwoOffsetCardNumber29--;
                    playerTwoOffsetCardNumber30--;
                    playerZeroOffsetCardNumber20--;
                    playerZeroOffsetCardNumber29--;
                    playerZeroOffsetCardNumber30--;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber14--;
                    playerThreeOffsetCardNumber20--;
                    playerThreeOffsetCardNumber29--;
                    playerThreeOffsetCardNumber30--;
                    playerTwoOffsetCardNumber20--;
                    playerTwoOffsetCardNumber29--;
                    playerTwoOffsetCardNumber30--;
                    playerZeroOffsetCardNumber20--;
                    playerZeroOffsetCardNumber29--;
                    playerZeroOffsetCardNumber30--;
                }
            }
            if (bestCardToBuy.getCardNumber() == 15)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber15--;
                    playerZeroOffsetCardNumber13++;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber27++;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber9++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber15--;
                    playerTwoOffsetCardNumber13++;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber27++;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber9++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber15--;
                    playerThreeOffsetCardNumber13++;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber27++;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber9++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber15--;
                    playerFourOffsetCardNumber13++;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber27++;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber9++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 16)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber16--;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18++;
                    playerZeroOffsetCardNumber13++;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber27++;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber9++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber16--;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18++;
                    playerTwoOffsetCardNumber13++;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber27++;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber9++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber16--;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18++;
                    playerThreeOffsetCardNumber13++;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber27++;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber9++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber16--;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18++;
                    playerFourOffsetCardNumber13++;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber27++;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber9++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 17)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17--;
                    playerZeroOffsetCardNumber18++;
                    playerZeroOffsetCardNumber13++;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber27++;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber9++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17--;
                    playerTwoOffsetCardNumber18++;
                    playerTwoOffsetCardNumber13++;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber27++;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber9++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17--;
                    playerThreeOffsetCardNumber18++;
                    playerThreeOffsetCardNumber13++;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber27++;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber9++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17--;
                    playerFourOffsetCardNumber18++;
                    playerFourOffsetCardNumber13++;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber27++;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber9++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 18)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18--;
                    playerZeroOffsetCardNumber13++;
                    playerZeroOffsetCardNumber24++;
                    playerZeroOffsetCardNumber27++;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber9++;
                }
                if (activePlayer == 1)
                {

                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18--;
                    playerTwoOffsetCardNumber13++;
                    playerTwoOffsetCardNumber24++;
                    playerTwoOffsetCardNumber27++;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber9++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18--;
                    playerThreeOffsetCardNumber13++;
                    playerThreeOffsetCardNumber24++;
                    playerThreeOffsetCardNumber27++;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber9++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18--;
                    playerFourOffsetCardNumber13++;
                    playerFourOffsetCardNumber24++;
                    playerFourOffsetCardNumber27++;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber9++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 19)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber19--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber19--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber19--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber19--;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 20)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber20--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerFourOffsetCardNumber14++;
                    playerFourOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerThreeOffsetCardNumber21++;
                    playerTwoOffsetCardNumber14++;
                    playerTwoOffsetCardNumber21++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber20--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                    playerFourOffsetCardNumber14++;
                    playerFourOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerThreeOffsetCardNumber21++;
                    playerZeroOffsetCardNumber14++;
                    playerZeroOffsetCardNumber21++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber20--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                    playerFourOffsetCardNumber14++;
                    playerFourOffsetCardNumber21++;
                    playerTwoOffsetCardNumber14++;
                    playerTwoOffsetCardNumber21++;
                    playerZeroOffsetCardNumber14++;
                    playerZeroOffsetCardNumber21++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber20--;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                    playerThreeOffsetCardNumber14++;
                    playerThreeOffsetCardNumber21++;
                    playerTwoOffsetCardNumber14++;
                    playerTwoOffsetCardNumber21++;
                    playerZeroOffsetCardNumber14++;
                    playerZeroOffsetCardNumber21++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 21)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber21--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber21--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber21--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                    playerThreeOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber21--;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                    playerFourOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 22)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber22--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber22--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber22--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber22--;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 23)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber23--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber23--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber23--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber23--;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 24)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber24--;
                    playerZeroOffsetCardNumber2++;
                    playerZeroOffsetCardNumber3++;
                    playerZeroOffsetCardNumber4++;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber9++;
                    playerZeroOffsetCardNumber10++;
                    playerZeroOffsetCardNumber11++;
                    playerZeroOffsetCardNumber15++;
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber24--;
                    playerTwoOffsetCardNumber2++;
                    playerTwoOffsetCardNumber3++;
                    playerTwoOffsetCardNumber4++;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber9++;
                    playerTwoOffsetCardNumber10++;
                    playerTwoOffsetCardNumber11++;
                    playerTwoOffsetCardNumber15++;
                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber24--;
                    playerThreeOffsetCardNumber2++;
                    playerThreeOffsetCardNumber3++;
                    playerThreeOffsetCardNumber4++;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber9++;
                    playerThreeOffsetCardNumber10++;
                    playerThreeOffsetCardNumber11++;
                    playerThreeOffsetCardNumber15++;
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber24--;
                    playerFourOffsetCardNumber2++;
                    playerFourOffsetCardNumber3++;
                    playerFourOffsetCardNumber4++;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber9++;
                    playerFourOffsetCardNumber10++;
                    playerFourOffsetCardNumber11++;
                    playerFourOffsetCardNumber15++;
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 25)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber25--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber25--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber25--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber25--;
                    playerZeroOffsetCardNumber2++;
                    playerZeroOffsetCardNumber15++;
                    playerZeroOffsetCardNumber16++;
                    playerZeroOffsetCardNumber17++;
                    playerZeroOffsetCardNumber18++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 26)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber26--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber26--;
                    playerTwoOffsetCardNumber2++;
                    playerTwoOffsetCardNumber15++;
                    playerTwoOffsetCardNumber16++;
                    playerTwoOffsetCardNumber17++;
                    playerTwoOffsetCardNumber18++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber26--;
                    playerThreeOffsetCardNumber2++;
                    playerThreeOffsetCardNumber15++;
                    playerThreeOffsetCardNumber16++;
                    playerThreeOffsetCardNumber17++;
                    playerThreeOffsetCardNumber18++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber26--;
                    playerFourOffsetCardNumber2++;
                    playerFourOffsetCardNumber15++;
                    playerFourOffsetCardNumber16++;
                    playerFourOffsetCardNumber17++;
                    playerFourOffsetCardNumber18++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 27)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber27--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber27--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber27--;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber27--;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 28)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber28--;
                    playerZeroOffsetCardNumber3++;
                    playerZeroOffsetCardNumber4++;
                    playerZeroOffsetCardNumber7++;
                    playerZeroOffsetCardNumber9++;
                    playerZeroOffsetCardNumber10++;
                    playerZeroOffsetCardNumber11++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber28--;
                    playerTwoOffsetCardNumber3++;
                    playerTwoOffsetCardNumber4++;
                    playerTwoOffsetCardNumber7++;
                    playerTwoOffsetCardNumber9++;
                    playerTwoOffsetCardNumber10++;
                    playerTwoOffsetCardNumber11++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber28--;
                    playerThreeOffsetCardNumber3++;
                    playerThreeOffsetCardNumber4++;
                    playerThreeOffsetCardNumber7++;
                    playerThreeOffsetCardNumber9++;
                    playerThreeOffsetCardNumber10++;
                    playerThreeOffsetCardNumber11++;
                    playerFourOffsetCardNumber30++;
                    playerFourOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber28--;
                    playerFourOffsetCardNumber3++;
                    playerFourOffsetCardNumber4++;
                    playerFourOffsetCardNumber7++;
                    playerFourOffsetCardNumber9++;
                    playerFourOffsetCardNumber10++;
                    playerFourOffsetCardNumber11++;
                    playerThreeOffsetCardNumber30++;
                    playerThreeOffsetCardNumber29++;
                    playerTwoOffsetCardNumber30++;
                    playerTwoOffsetCardNumber29++;
                    playerZeroOffsetCardNumber30++;
                    playerZeroOffsetCardNumber29++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 29)
            {
                if (activePlayer == 0)
                {
                    //playerZeroOffsetCardNumber29--;
                    playerFourOffsetCardNumber21++;
                    playerThreeOffsetCardNumber21++;
                    playerTwoOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerThreeOffsetCardNumber14++;
                    playerTwoOffsetCardNumber14++;
                }
                if (activePlayer == 1)
                {
                    //playerTwoOffsetCardNumber29--;
                    playerFourOffsetCardNumber21++;
                    playerThreeOffsetCardNumber21++;
                    playerZeroOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerThreeOffsetCardNumber14++;
                    playerZeroOffsetCardNumber14++;
                }
                if (activePlayer == 2)
                {
                    //playerThreeOffsetCardNumber29--;
                    playerFourOffsetCardNumber21++;
                    playerTwoOffsetCardNumber21++;
                    playerZeroOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerTwoOffsetCardNumber14++;
                    playerZeroOffsetCardNumber14++;
                }
                if (activePlayer == 3)
                {
                    //playerFourOffsetCardNumber29--;
                    playerThreeOffsetCardNumber21++;
                    playerTwoOffsetCardNumber21++;
                    playerZeroOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerTwoOffsetCardNumber14++;
                    playerZeroOffsetCardNumber14++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 30)
            {
                if (activePlayer == 0)
                {
                    playerZeroOffsetCardNumber30++;
                    playerFourOffsetCardNumber21++;
                    playerThreeOffsetCardNumber21++;
                    playerTwoOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerThreeOffsetCardNumber14++;
                    playerTwoOffsetCardNumber14++;
                }
                if (activePlayer == 1)
                {
                    playerTwoOffsetCardNumber30++;
                    playerFourOffsetCardNumber21++;
                    playerThreeOffsetCardNumber21++;
                    playerZeroOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerThreeOffsetCardNumber14++;
                    playerZeroOffsetCardNumber14++;
                }
                if (activePlayer == 2)
                {
                    playerThreeOffsetCardNumber30++;
                    playerFourOffsetCardNumber21++;
                    playerTwoOffsetCardNumber21++;
                    playerZeroOffsetCardNumber21++;
                    playerFourOffsetCardNumber14++;
                    playerTwoOffsetCardNumber14++;
                    playerZeroOffsetCardNumber14++;
                }
                if (activePlayer == 3)
                {
                    playerFourOffsetCardNumber30++;
                    playerThreeOffsetCardNumber21++;
                    playerTwoOffsetCardNumber21++;
                    playerZeroOffsetCardNumber21++;
                    playerThreeOffsetCardNumber14++;
                    playerTwoOffsetCardNumber14++;
                    playerZeroOffsetCardNumber14++;
                }
            }
            if (bestCardToBuy.getCardNumber() == 31)
            {
                if (activePlayer == 0)
                {
                    //playerZeroOffsetCardNumber31--;
                }
                if (activePlayer == 1)
                {
                    //playerTwoOffsetCardNumber31--;
                }
                if (activePlayer == 2)
                {
                    //playerThreeOffsetCardNumber31--;
                }
                if (activePlayer == 3)
                {
                    //playerFourOffsetCardNumber31--;
                }
            }
            if (bestCardToBuy.getCardNumber() == 32)
            {
                if (activePlayer == 0)
                {
                    //playerZeroOffsetCardNumber32--;
                }
                if (activePlayer == 1)
                {
                    //playerTwoOffsetCardNumber32--;
                }
                if (activePlayer == 2)
                {
                    //playerThreeOffsetCardNumber32--;
                }
                if (activePlayer == 3)
                {
                    //playerFourOffsetCardNumber32--;
                }
            }
            if (bestCardToBuy.getCardNumber() == 33)
            {
                if (activePlayer == 0)
                {
                    //playerZeroOffsetCardNumber33--;
                }
                if (activePlayer == 1)
                {
                    //playerTwoOffsetCardNumber33--;
                }
                if (activePlayer == 2)
                {
                    //playerThreeOffsetCardNumber33--;
                }
                if (activePlayer == 3)
                {
                    //playerFourOffsetCardNumber33--;
                }
            }
        }

        private static bool calculateBestCardToBuy(Card card, Card bestCardToBuy, int love)
        {
            if (bestCardToBuy == null && card.getCost() <= love)
            {
                return true;
            }

            if (bestCardToBuy == null)
            {
                return false;
            }

            addValuesToCard(card);
            addValuesToCard(bestCardToBuy);

            if (card.cardValue > bestCardToBuy.cardValue)
            {
                return true;
            }

            if (card.cardValue < bestCardToBuy.cardValue)
            {
                return false;
            }

            if (card.cardValue == bestCardToBuy.cardValue)
            {
                Random rand = new Random();
                int check = rand.Next(-2, 2);
                if (check == -1)
                {
                    return true;
                }
                if (check == 1)
                {
                    return false;
                }
            }

            if (card.getCost() < love && card.getCost() > bestCardToBuy.getCost())
            {
                return true;
            }
            if (card.getCost() < love && card.getCost() < bestCardToBuy.getCost())
            {
                return false;
            }

            if (card.getCost() < love && card.getVP() > bestCardToBuy.getVP())
            {
                return true;
            }
            if (card.getCost() < love && card.getVP() < bestCardToBuy.getVP())
            {
                return false;
            }

            if (card.getCost() < love && card.getServings() > bestCardToBuy.getServings())
            {
                return true;
            }
            if (card.getCost() < love && card.getServings() < bestCardToBuy.getServings())
            {
                return false;
            }

            if (card.getCost() < love && card.getDraws() > bestCardToBuy.getDraws())
            {
                return true;
            }
            if (card.getCost() < love && card.getDraws() < bestCardToBuy.getDraws())
            {
                return false;
            }

            if (card.getCost() < love && card.getLove() > bestCardToBuy.getLove())
            {
                return true;
            }
            if (card.getCost() < love && card.getLove() < bestCardToBuy.getLove())
            {
                return false;
            }

            if (card.getCost() < love && card.getEmployments() > bestCardToBuy.getEmployments())
            {
                return true;
            }
            if (card.getCost() < love && card.getEmployments() < bestCardToBuy.getEmployments())
            {
                return false;
            }

            return false;
        }

        private static void addValuesToCard(Card card)
        {
            if (card.getCardNumber() == 1)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber1;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber1;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber1;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber1;
                }
            }

            if (card.getCardNumber() == 2)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber2;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber2;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber2;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber2;
                }
            }

            if (card.getCardNumber() == 3)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber3;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber3;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber3;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber3;
                }
            }

            if (card.getCardNumber() == 4)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber4;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber4;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber4;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber4;
                }
            }

            if (card.getCardNumber() == 5)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber5;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber5;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber5;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber5;
                }
            }

            if (card.getCardNumber() == 6)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber6;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber6;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber6;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber6;
                }
            }

            if (card.getCardNumber() == 7)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber7;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber7;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber7;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber7;
                }
            }

            if (card.getCardNumber() == 8)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber8;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber8;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber8;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber8;
                }
            }

            if (card.getCardNumber() == 9)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber9;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber9;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber9;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber9;
                }
            }

            if (card.getCardNumber() == 10)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber10;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber10;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber10;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber10;
                }
            }

            if (card.getCardNumber() == 11)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber11;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber11;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber11;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber11;
                }
            }

            if (card.getCardNumber() == 12)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber12;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber12;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber12;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber12;
                }
            }

            if (card.getCardNumber() == 13)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber13;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber13;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber13;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber13;
                }
            }

            if (card.getCardNumber() == 14)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber14;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber14;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber14;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber14;
                }
            }

            if (card.getCardNumber() == 15)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber15;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber15;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber15;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber15;
                }
            }

            if (card.getCardNumber() == 16)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber16;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber16;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber16;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber16;
                }
            }

            if (card.getCardNumber() == 17)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber17;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber17;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber17;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber17;
                }
            }

            if (card.getCardNumber() == 18)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber18;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber18;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber18;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber18;
                }
            }

            if (card.getCardNumber() == 19)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber19;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber19;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber19;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber19;
                }
            }

            if (card.getCardNumber() == 20)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber20;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber20;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber20;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber20;
                }
            }

            if (card.getCardNumber() == 21)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber21;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber21;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber21;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber21;
                }
            }

            if (card.getCardNumber() == 22)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber22;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber22;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber22;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber22;
                }
            }

            if (card.getCardNumber() == 23)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber23;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber23;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber23;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber23;
                }
            }

            if (card.getCardNumber() == 24)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber24;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber24;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber24;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber24;
                }
            }

            if (card.getCardNumber() == 25)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber25;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber25;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber25;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber25;
                }
            }

            if (card.getCardNumber() == 26)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber26;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber26;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber26;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber26;
                }
            }

            if (card.getCardNumber() == 27)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber27;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber27;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber27;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber27;
                }
            }

            if (card.getCardNumber() == 28)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber28;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber28;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber28;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber28;
                }
            }

            if (card.getCardNumber() == 29)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber29;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber29;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber29;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber29;
                }
            }

            if (card.getCardNumber() == 30)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber30;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber30;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber30;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber30;
                }
            }

            if (card.getCardNumber() == 31)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber31;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber31;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber31;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber31;
                }
            }

            if (card.getCardNumber() == 32)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber32;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber32;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber32;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber32;
                }
            }

            if (card.getCardNumber() == 33)
            {
                if (activePlayer == 0)
                {
                    card.cardValue += playerZeroOffsetCardNumber33;
                }
                if (activePlayer == 1)
                {
                    card.cardValue += playerTwoOffsetCardNumber33;
                }
                if (activePlayer == 2)
                {
                    card.cardValue += playerThreeOffsetCardNumber33;
                }
                if (activePlayer == 3)
                {
                    card.cardValue += playerFourOffsetCardNumber33;
                }
            }
        }

        internal static bool discardCardToMakeOthersDiscard(Player AIPlayer)
        {
            for (int index = 0; index < AIPlayer.getNumberOfCardsInHand(); index++)
            {
                if ((AIPlayer.lookAtCardInHand(index).getCardNumber() > 2 && AIPlayer.lookAtCardInHand(index).getCardNumber() < 19) || AIPlayer.lookAtCardInHand(index).getCardNumber() == 31 || AIPlayer.lookAtCardInHand(index).getCardNumber() == 32 || AIPlayer.lookAtCardInHand(index).getCardNumber() == 33)
                {
                    continue;
                }
                return true;
            }
            return false;
        }

        internal static void discardWorstCard(Player AIPlayer)
        {
            int bestCardNumber = -1;
            for (int index = 0; index < AIPlayer.getNumberOfCardsInHand(); index++)
            {
                if (bestCardNumber == -1)
                {
                    bestCardNumber = index;
                }
                else
                {
                    if(calculateBestCardToDiscard(AIPlayer.lookAtCardInHand(index), AIPlayer.lookAtCardInHand(bestCardNumber)))
                    {
                        bestCardNumber = index;
                    }
                }
            }
            AIPlayer.discardCard(bestCardNumber);
        }

        private static bool calculateBestCardToDiscard(Card card, Card card_2)
        {
            if (card.getCardNumber() == 1)
            {
                return true;
            }
            if (card_2.getCardNumber() == 1)
            {
                return false;
            }

            if (card.getServings() < card_2.getServings())
            {
                return true;
            }
            if (card.getServings() > card_2.getServings())
            {
                return false;
            }

            if (card.getDraws() < card_2.getDraws())
            {
                return true;
            }
            if (card.getDraws() > card_2.getDraws())
            {
                return false;
            }

            if (card.getLove() < card_2.getLove())
            {
                return true;
            }
            if (card.getLove() > card_2.getLove())
            {
                return false;
            }

            if (card.getEmployments() < card_2.getEmployments())
            {
                return true;
            }
            if (card.getEmployments() > card_2.getEmployments())
            {
                return false;
            }
            return false;
        }

        internal static void selectDeckMode(Player[] playerList, int activePlayer)
        {
            int selectedPlayer;
            while (true)
            {
                Random rand = new Random();
                selectedPlayer = rand.Next(playerList.Length);
                if (playerList[selectedPlayer].hasCardsInDeck())
                {
                    break;
                }
            }
            calculatedIfToDiscard(playerList, activePlayer, selectedPlayer);
        }

        private static void calculatedIfToDiscard(Player[] playerList, int activePlayer, int selectedPlayer)
        {
            if (playerList[selectedPlayer].lookAtTopCardOfDeck().getCardNumber() == 1 || playerList[selectedPlayer].lookAtTopCardOfDeck().getCardNumber() == 2)
            {
                if (selectedPlayer == activePlayer)
                {
                    playerList[selectedPlayer].discardTopCardOfDeck();
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (selectedPlayer == activePlayer)
                {
                    return;
                }
                else
                {
                    playerList[selectedPlayer].discardTopCardOfDeck();
                }
            }
        }

        internal static void removeBestEvent(Player player, PlayArea playArea)
        {
            int bestCardNumber = -1;
            bool bestCardIsPrivateMaid = false;
            if (player.hasBadHabit())
            {
                playArea.badHabits.addCard(player.removeBadHabit());
                return;
            }
            if (player.hasChamberMaids()){
                for (int index = 0; index < player.getNumberOfMaidsInPrivateQuarters(); index++)
                {
                    if (bestCardNumber == -1)
                    {
                        bestCardNumber = index;
                    }
                    else if (calculateBestEventToRemove(player.chamberMaidAt(index), player.chamberMaidAt(bestCardNumber)))
                    {
                        bestCardNumber = index;
                    }
                }
            }
            if (player.hasPrivateMaid())
            {
                if (bestCardNumber == -1)
                {
                    bestCardIsPrivateMaid = true;
                }
                else if (calculateBestEventToRemove(player.privateMaid(), player.chamberMaidAt(bestCardNumber)))
                {
                    bestCardIsPrivateMaid = true;
                }
            }
            if (!bestCardIsPrivateMaid  && player.hasChamberMaids() && player.chamberMaidAt(bestCardNumber).hasIllness())
            {
                playArea.illnesses.addCard(player.removeIllnessFromMaid(bestCardNumber));
            }
            else if (player.hasPrivateMaid() && player.privateMaid().hasIllness())
            {
                playArea.illnesses.addCard(player.removeIllnessFromPrivateMaid());
            }
        }

        private static bool calculateBestEventToRemove(PrivateQuartersCard privateQuartersCard, PrivateQuartersCard privateQuartersCard_2)
        {
            if (privateQuartersCard.hasIllness() && !privateQuartersCard_2.hasIllness())
            {
                return true;
            }
            if (privateQuartersCard_2.hasIllness() && !privateQuartersCard.hasIllness())
            {
                return false;
            }
            if (privateQuartersCard.getVP() > privateQuartersCard_2.getVP())
            {
                return true;
            }
            if (privateQuartersCard.getVP() < privateQuartersCard_2.getVP())
            {
                return false;
            }
            return false;
        }

        internal static void selectPlayerInput(Player player, PlayArea playArea, Player[] playerList, int activePlayer, GameTime gameTime)
        {
            int selectedPlayer;
            int counter = 0;
            while (true)
            {
                Random rand = new Random();
                selectedPlayer = rand.Next(playerList.Length);
                if ((playerList[selectedPlayer].hasChamberMaids() || playerList[selectedPlayer].hasPrivateMaid()) && selectedPlayer != activePlayer)
                {
                    break;
                }
                if (counter > 100)
                {
                    playArea.badHabits.addCard(new Card(30));
                    playerList[activePlayer].refundBadHabit();
                    return;
                }
                counter++;
            }
            if (playerList[selectedPlayer].handContains(new Card(14)))
            {
                playArea.badHabits.addCard(new Card(30));
                playArea.showClairMode = true;
                playArea.timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
            }
            else
            {
                playerList[selectedPlayer].addBadHabitToPrivateQuarters(new Card(30));
            }
        }

        internal static void selectChamberMaidMode(GameTime gameTime, Player[] playerList, int activePlayer, PlayArea playArea)
        {
            int selectedPlayer;
            int counter = 0;
            int bestCardNumber = -1;
            bool bestCardIsPrivateMaid = false;
            while (true)
            {
                Random rand = new Random();
                selectedPlayer = rand.Next(playerList.Length);
                if ((playerList[selectedPlayer].hasChamberMaids() || playerList[selectedPlayer].hasPrivateMaid()) && selectedPlayer != activePlayer)
                {
                    break;
                }
                if (counter > 100)
                {
                    playArea.illnesses.addCard(new Card(29));
                    playerList[activePlayer].refundIllness();
                    return;
                }
                counter++;
            }
            if (playerList[selectedPlayer].hasChamberMaids())
            {
                for (int index = 0; index < playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters(); index++)
                {
                    if (bestCardNumber == -1)
                    {
                        bestCardNumber = index;
                    }
                    else if (calculateBestEventToAdd(playerList[selectedPlayer].chamberMaidAt(index), playerList[selectedPlayer].chamberMaidAt(bestCardNumber)))
                    {
                        bestCardNumber = index;
                    }
                }
            }
            if (playerList[selectedPlayer].hasPrivateMaid())
            {
                if (bestCardNumber == -1)
                {
                    bestCardIsPrivateMaid = true;
                }
                else if (calculateBestEventToAdd(playerList[selectedPlayer].privateMaid(), playerList[selectedPlayer].chamberMaidAt(bestCardNumber)))
                {
                    bestCardIsPrivateMaid = true;
                }
            }
            if (playerList[selectedPlayer].handContains(new Card(14)))
            {
                playArea.showClairMode = true;
                playArea.timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                playArea.illnesses.addCard(new Card(29));
            }
            else if (!bestCardIsPrivateMaid)
            {
                playerList[selectedPlayer].giveIllnessToChamberMaid(bestCardNumber);
            }
            else
            {
                playerList[selectedPlayer].giveIllnessToPrivateMaid();
            }
        }

        private static bool calculateBestEventToAdd(PrivateQuartersCard privateQuartersCard, PrivateQuartersCard privateQuartersCard_2)
        {
            if (privateQuartersCard.getVP() > privateQuartersCard_2.getVP())
            {
                return true;
            }
            if (privateQuartersCard.getVP() < privateQuartersCard_2.getVP())
            {
                return false;
            }
            return false;
        }

        internal static void selectExchangeModeInput(Player AIPlayer, PlayArea playingArea)
        {
            activePlayer = AIPlayer.playerNumber;
            Card bestCardToBuy = null;
            int pileNumber = -1;
            if (AIPlayer.getEmployments() != 0)
            {
                for (int index = 0; index < 12; index++)
                {
                    if (index < 10)
                    {
                        if (playingArea.generalMaids.ElementAt(index).getNumberOfRemainingCards() > 0 && playingArea.generalMaids.ElementAt(index).lookAtTopCard().getCost() <= 4)
                        {
                            if (calculateBestCardToBuy(playingArea.generalMaids.ElementAt(index).lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.generalMaids.ElementAt(index).lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 10)
                    {
                        if (playingArea.colette.getNumberOfRemainingCards() > 0)
                        {
                            if (calculateBestCardToBuy(playingArea.colette.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.colette.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                    else if (pileNumber == 11)
                    {
                        if (playingArea.twoLove.getNumberOfRemainingCards() > 0)
                        {
                            if (calculateBestCardToBuy(playingArea.twoLove.lookAtTopCard(), bestCardToBuy, AIPlayer.getLove()))
                            {
                                bestCardToBuy = playingArea.twoLove.lookAtTopCard();
                                pileNumber = index;
                            }
                        }
                    }
                }
            }
            if (bestCardToBuy == null)
            {
                return;
            }
            else
            {
                if (AIPlayer.exchange(bestCardToBuy))
                {
                    adjustCardValues(playingArea, AIPlayer, bestCardToBuy);
                    if (pileNumber < 10)
                    {
                        playingArea.generalMaids.ElementAt(pileNumber).getTopCard();
                        if (playingArea.generalMaids.ElementAt(pileNumber).getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 10)
                    {
                        playingArea.colette.getTopCard();
                        if (playingArea.colette.getNumberOfRemainingCards() == 0)
                        {
                            playingArea.emptiedPiles++;
                        }
                    }
                    else if (pileNumber == 11)
                    {
                        playingArea.twoLove.getTopCard();
                    }
                }
            }
        }

        internal static void decideToDiscardForServingsMode(Player player)
        {
            int numberOfCardsToBeDiscarded = 0;
            for (int index = 0; index < player.getNumberOfCardsInHand(); index++)
            {
                if (player.lookAtCardInHand(index).getCardNumber() == 1)
                {
                    numberOfCardsToBeDiscarded++;
                }
                else if (player.lookAtCardInHand(index).getServings() == 0)
                {
                    numberOfCardsToBeDiscarded++;
                }
                else if (player.lookAtCardInHand(index).getLove() == 0)
                {
                    numberOfCardsToBeDiscarded++;
                }
                else if (player.lookAtCardInHand(index).getDraws() == 0)
                {
                    numberOfCardsToBeDiscarded++;
                }
                else if (player.lookAtCardInHand(index).getEmployments() == 0)
                {
                    numberOfCardsToBeDiscarded++;
                }
                if (numberOfCardsToBeDiscarded == 2)
                {
                    break;
                }
            }
            for (int index = 0; index < numberOfCardsToBeDiscarded; index++)
            {
                discardWorstCard(player);
                player.addServing();
            }
        }

        internal static void loveOrEmployment(Player player)
        {
            int totalLove = 0;
            int totalEmployments = 0;
            for (int index = 0; index < player.getNumberOfCardsInHand(); index++)
            {
                totalLove += player.lookAtCardInHand(index).getLove();
                totalEmployments += player.lookAtCardInHand(index).getEmployments();
            }
            if (totalLove > totalEmployments)
            {
                player.addEmployment();
            }
            else
            {
                player.addLove();
            }
        }

        internal static void discardHandForIllnesss(PlayArea playArea, Player player, GameTime gameTime)
        {
            if (playArea.illnesses.getNumberOfRemainingCards() < 2 || !playArea.otherPlayersHaveMaidsInPrivateQuarters(player))
            {
                return;
            }
            int numberOfCardsToBeDiscarded = 0;
            for (int index = 0; index < player.getNumberOfCardsInHand(); index++)
            {
                if (player.lookAtCardInHand(index).getServings() == 0 && player.lookAtCardInHand(index).getLove() == 0 && player.lookAtCardInHand(index).getDraws() == 0 && player.lookAtCardInHand(index).getEmployments() == 0)
                {
                    numberOfCardsToBeDiscarded++;
                }
            }
            if (numberOfCardsToBeDiscarded >= 3)
            {
                discardWorstCard(player);
                discardWorstCard(player);
                discardWorstCard(player);
                discardWorstCard(player);
            }
            int selectedPlayer;
            int bestCardNumber = -1;
            bool bestCardIsPrivateMaid = false;
            while (true)
            {
                Random rand = new Random();
                selectedPlayer = rand.Next(playArea.playerList.Length);
                if ((playArea.playerList[selectedPlayer].hasChamberMaids() || playArea.playerList[selectedPlayer].hasPrivateMaid()) && selectedPlayer != activePlayer)
                {
                    break;
                }
            }
            if (playArea.playerList[selectedPlayer].hasChamberMaids())
            {
                for (int index = 0; index < playArea.playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters(); index++)
                {
                    if (bestCardNumber == -1)
                    {
                        bestCardNumber = index;
                    }
                    else if (calculateBestEventToAdd(playArea.playerList[selectedPlayer].chamberMaidAt(index), playArea.playerList[selectedPlayer].chamberMaidAt(bestCardNumber)))
                    {
                        bestCardNumber = index;
                    }
                }
            }
            if (playArea.playerList[selectedPlayer].hasPrivateMaid())
            {
                if (bestCardNumber == -1)
                {
                    bestCardIsPrivateMaid = true;
                }
                else if (calculateBestEventToAdd(playArea.playerList[selectedPlayer].privateMaid(), playArea.playerList[selectedPlayer].chamberMaidAt(bestCardNumber)))
                {
                    bestCardIsPrivateMaid = true;
                }
            }
            if (!bestCardIsPrivateMaid)
            {
                if (playArea.playerList[selectedPlayer].handContains(new Card(14)))
                {
                    playArea.showClairMode = true;
                    playArea.timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                }
                else if (playArea.illnesses.getNumberOfRemainingCards() > 1)
                {
                    playArea.playerList[selectedPlayer].giveIllnessToChamberMaid(bestCardNumber);
                    playArea.playerList[selectedPlayer].giveIllnessToChamberMaid(bestCardNumber);
                    playArea.illnesses.getTopCard();
                    playArea.illnesses.getTopCard();
                }
                else
                {
                    playArea.playerList[selectedPlayer].giveIllnessToChamberMaid(bestCardNumber);
                    playArea.illnesses.getTopCard();
                }
            }
            else
            {
                if (playArea.playerList[selectedPlayer].handContains(new Card(14)))
                {
                    playArea.showClairMode = true;
                    playArea.timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                }
                else if (playArea.illnesses.getNumberOfRemainingCards() > 1)
                {
                    playArea.playerList[selectedPlayer].giveIllnessToPrivateMaid();
                    playArea.playerList[selectedPlayer].giveIllnessToPrivateMaid();
                    playArea.illnesses.getTopCard();
                    playArea.illnesses.getTopCard();
                }
                else
                {
                    playArea.playerList[selectedPlayer].giveIllnessToPrivateMaid();
                    playArea.illnesses.getTopCard();
                }
            }
        }

        internal static void lookAtRandomCardInAnotherPlayersHandAndSwap(PlayArea playArea, Player player)
        {
            int selectedPlayer;
            while (true)
            {
                Random rand = new Random();
                selectedPlayer = rand.Next(playArea.playerList.Length);
                if ((playArea.playerList[selectedPlayer].getNumberOfCardsInHand() != 0) && selectedPlayer != activePlayer)
                {
                    break;
                }
            }

            int randomCard1 = new Random().Next(playArea.playerList[selectedPlayer].getNumberOfCardsInHand());
            double totalValue = 0;
            for (int index = 0; index < player.getNumberOfCardsInHand(); index++)
            {
                Card card = player.lookAtCardInHand(index);
                addValuesToCard(card);
                totalValue += card.cardValue;
            }
            totalValue /= player.getNumberOfCardsInHand();
            if (playArea.playerList[selectedPlayer].lookAtCardInHand(randomCard1).cardValue > totalValue)
            {
                int randomCard2 = new Random().Next(player.getNumberOfCardsInHand());
                playArea.playerList[selectedPlayer].exchangeCardsWith(playArea.playerList[activePlayer], randomCard1, randomCard2);
            }
        }

        internal static void moveEventCardToAnotherPlayer(PlayArea playArea, Player player, GameTime gameTime)
        {
            activePlayer = player.playerNumber;
            int selectedPlayer;
            int counter = 0;
            int bestCardNumber = -1;
            bool bestCardWasIllness = false;
            bool bestCardIsPrivateMaid = false;
            if (player.hasChamberMaids())
            {
                for (int index = 0; index < player.getNumberOfMaidsInPrivateQuarters(); index++)
                {
                    if (bestCardNumber == -1 && player.chamberMaidAt(index).hasIllness())
                    {
                        bestCardNumber = index;
                    }
                    else if (calculateBestEventToAdd(player.chamberMaidAt(index), player.chamberMaidAt(bestCardNumber)) && player.chamberMaidAt(index).hasIllness())
                    {
                        bestCardNumber = index;
                    }
                }
            }
            if (player.hasBadHabit())
            {
                if (player.getNumberOfBadHabits() > 4 && bestCardNumber != -1)
                {
                    if (player.chamberMaidAt(bestCardNumber).getVP() > 2)
                    {
                        bestCardWasIllness = true;
                        player.chamberMaidAt(bestCardNumber).removeIllness();
                    }
                }
                else if (player.getNumberOfBadHabits() == 4 && bestCardNumber != -1)
                {
                    if (player.chamberMaidAt(bestCardNumber).getVP() > 5)
                    {
                        bestCardWasIllness = true;
                        player.chamberMaidAt(bestCardNumber).removeIllness();
                    }
                }
                else if (player.getNumberOfBadHabits() < 4 && bestCardNumber != -1)
                {
                    if (player.chamberMaidAt(bestCardNumber).getVP() >= 1)
                    {
                        bestCardWasIllness = true;
                        player.chamberMaidAt(bestCardNumber).removeIllness();
                    }
                }
            }
            if (!bestCardWasIllness)
            {
                player.removeBadHabit();
            }
            while (true)
            {
                Random rand = new Random();
                selectedPlayer = rand.Next(playArea.playerList.Length);
                if ((playArea.playerList[selectedPlayer].hasChamberMaids() || playArea.playerList[selectedPlayer].hasPrivateMaid()) && selectedPlayer != activePlayer)
                {
                    break;
                }
                if (counter > 100)
                {
                    playArea.illnesses.addCard(new Card(29));
                    playArea.playerList[activePlayer].refundIllness();
                    return;
                }
                counter++;
            }
            if (bestCardWasIllness)
            {
                if (playArea.playerList[selectedPlayer].hasChamberMaids())
                {
                    for (int index = 0; index < playArea.playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters(); index++)
                    {
                        if (bestCardNumber == -1)
                        {
                            bestCardNumber = index;
                        }
                        else if (calculateBestEventToAdd(playArea.playerList[selectedPlayer].chamberMaidAt(index), playArea.playerList[selectedPlayer].chamberMaidAt(bestCardNumber)))
                        {
                            bestCardNumber = index;
                        }
                    }
                }
                if (playArea.playerList[selectedPlayer].hasPrivateMaid())
                {
                    if (bestCardNumber == -1)
                    {
                        bestCardIsPrivateMaid = true;
                    }
                    else if (calculateBestEventToAdd(playArea.playerList[selectedPlayer].privateMaid(), playArea.playerList[selectedPlayer].chamberMaidAt(bestCardNumber)))
                    {
                        bestCardIsPrivateMaid = true;
                    }
                }
                if (playArea.playerList[selectedPlayer].handContains(new Card(14)))
                {
                    playArea.showClairMode = true;
                    playArea.timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                    playArea.illnesses.addCard(new Card(29));
                }
                else if (!bestCardIsPrivateMaid)
                {
                    playArea.playerList[selectedPlayer].giveIllnessToChamberMaid(bestCardNumber);
                }
                else
                {
                    playArea.playerList[selectedPlayer].giveIllnessToPrivateMaid();
                }
            }
            else
            {
                if (playArea.playerList[selectedPlayer].handContains(new Card(14)))
                {
                    playArea.badHabits.addCard(new Card(30));
                    playArea.showClairMode = true;
                    playArea.timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                }
                else
                {
                    playArea.playerList[selectedPlayer].addBadHabitToPrivateQuarters(new Card(30));
                }
            }
        }

        internal static void discard3LoveToRemoveIllness(Player player, PlayArea playArea)
        {
            int bestCardNumber = -1;
            bool bestCardIsPrivateMaid = false;
            if (player.hasChamberMaids())
            {
                for (int index = 0; index < player.getNumberOfMaidsInPrivateQuarters(); index++)
                {
                    if (bestCardNumber == -1 && player.chamberMaidAt(index).hasIllness())
                    {
                        bestCardNumber = index;
                    }
                    else if (calculateBestEventToAdd(player.chamberMaidAt(index), player.chamberMaidAt(bestCardNumber)) && player.chamberMaidAt(index).hasIllness())
                    {
                        bestCardNumber = index;
                    }
                }
            }
            if (player.hasPrivateMaid() && player.privateMaidHasIllness())
            {
                if (bestCardNumber == -1)
                {
                    bestCardIsPrivateMaid = true;
                }
                else if (calculateBestEventToAdd(player.privateMaid(), player.chamberMaidAt(bestCardNumber)))
                {
                    bestCardIsPrivateMaid = true;
                }
            }
            if (bestCardIsPrivateMaid)
            {
                playArea.illnesses.addCard(player.removeIllnessFromPrivateMaid());
                player.startTurn();
            }
            else
            {
                playArea.illnesses.addCard(player.removeIllnessFromMaid(bestCardNumber));
                player.recheck();
            }
        }
    }
}
