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
        int activePlayer = 0;
        int numberOfPlayers;
        Player[] playerList;
        int currentPhase = 0;
        int currentCardNumber = 0;
        int currentRowNumber = 0;
        bool selectPlayerModeBool = false;
        bool showBigCardMode;
        public int currentSelectOption = 0;

        public PlayArea(int numberOfPlayers)
        {
            selectPlayerModeBool = false;
            selectEventModeBool = false;
            selectDeckModeBool = false;
            selectDiscardModeBool = false;
            selectEventModeBool = false;
            selectChamberMaidModeBool = false;
            decideToDiscardForServingsModeBool = false;
            exchangeModeBool = false;
            showBigCardMode = false;
            generalMaids = new List<CardPile>();
            oneLove = new CardPile(new Card(33), 36);
            twoLove = new CardPile(new Card(32), 12);
            threeLove = new CardPile(new Card(31), 8);
            marianne = new CardPile(new Card(1), 8);
            colette = new CardPile(new Card(2), 24);
            badHabits = new CardPile(new Card(30), 0);
            illnesses = new CardPile(new Card(29), 0);
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
            playerList = new Player[numberOfPlayers];
            this.numberOfPlayers = numberOfPlayers;
            for (int index = 0; index < numberOfPlayers; index++)
            {
                playerList[index] = new Player(index, numberOfPlayers, this);
            }
        }

        public PlayArea(List<Card> genralMaidList, int numberOfPlayers)
        {
            selectPlayerModeBool = false;
            selectEventModeBool = false;
            selectDeckModeBool = false;
            selectDiscardModeBool = false;
            selectEventModeBool = false;
            selectChamberMaidModeBool = false;
            decideToDiscardForServingsModeBool = false;
            exchangeModeBool = false;
            showBigCardMode = false;
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
            playerList = new Player[numberOfPlayers];
            this.numberOfPlayers = numberOfPlayers;
            for (int index = 0; index < numberOfPlayers; index++)
            {
                playerList[index] = new Player(index, numberOfPlayers, this);
            }
        }

        public void drawPlayArea(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!selectPlayerModeBool && !selectEventModeBool && !selectDiscardModeBool && !selectDeckModeBool && !selectChamberMaidModeBool && !decideToDiscardForServingsModeBool && !exchangeModeBool)
            {
                spriteBatch.Begin();
                for (int index = 0; index < 10; index++)
                {
                    if (index >= 5)
                    {
                        if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                        {
                            if (currentCardNumber == index-4 && currentRowNumber == 2 && currentPhase == 1)
                            {
                                spriteBatch.Draw(Game1.cardPicturesMini[generalMaids.ElementAt(index).lookAtTopCard().getCardNumber() - 1], new Vector2(250 + (index - 5) * 100, 100 + 250), Color.Red);
                            }
                            else
                            {
                                spriteBatch.Draw(Game1.cardPicturesMini[generalMaids.ElementAt(index).lookAtTopCard().getCardNumber() - 1], new Vector2(250 + (index - 5) * 100, 100 + 250), Color.White);
                            }
                        }
                    }
                    else
                    {
                        if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                        {
                            if (currentCardNumber == 1 + index && currentRowNumber == 1 && currentPhase == 1)
                            {
                                spriteBatch.Draw(Game1.cardPicturesMini[generalMaids.ElementAt(index).lookAtTopCard().getCardNumber() - 1], new Vector2(250 + index * 100, 250), Color.Red);
                            }
                            else
                            {
                                spriteBatch.Draw(Game1.cardPicturesMini[generalMaids.ElementAt(index).lookAtTopCard().getCardNumber() - 1], new Vector2(250 + index * 100, 250), Color.White);
                            }
                        }
                    }
                }
                if (threeLove.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 0 && currentRowNumber == 2 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[threeLove.lookAtTopCard().getCardNumber() - 1], new Vector2(150, 350), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[threeLove.lookAtTopCard().getCardNumber() - 1], new Vector2(150, 350), Color.White);
                    }
                }
                if (twoLove.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 0 && currentRowNumber == 1 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[twoLove.lookAtTopCard().getCardNumber() - 1], new Vector2(150, 250), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[twoLove.lookAtTopCard().getCardNumber() - 1], new Vector2(150, 250), Color.White);
                    }
                }
                if (oneLove.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 0 && currentRowNumber == 0 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[oneLove.lookAtTopCard().getCardNumber() - 1], new Vector2(150, 150), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[oneLove.lookAtTopCard().getCardNumber() - 1], new Vector2(150, 150), Color.White);
                    }
                }
                if (marianne.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 1 && currentRowNumber == 0 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[marianne.lookAtTopCard().getCardNumber() - 1], new Vector2(250, 150), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[marianne.lookAtTopCard().getCardNumber() - 1], new Vector2(250, 150), Color.White);
                    }
                }
                if (colette.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 2 && currentRowNumber == 0 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[colette.lookAtTopCard().getCardNumber() - 1], new Vector2(350, 150), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[colette.lookAtTopCard().getCardNumber() - 1], new Vector2(350, 150), Color.White);
                    }
                }
                if (badHabits.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 3 && currentRowNumber == 0 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[badHabits.lookAtTopCard().getCardNumber() - 1], new Vector2(450, 150), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[badHabits.lookAtTopCard().getCardNumber() - 1], new Vector2(450, 150), Color.White);
                    }
                }
                if (illnesses.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 4 && currentRowNumber == 0 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[illnesses.lookAtTopCard().getCardNumber() - 1], new Vector2(550, 150), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[illnesses.lookAtTopCard().getCardNumber() - 1], new Vector2(550, 150), Color.White);
                    }
                }
                if (privateMaidPile.getNumberOfRemainingCards() != 0)
                {
                    spriteBatch.Draw(Game1.cardBack, new Vector2(750, 150), Color.White);
                }
                if (privateMaidOne.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 6 && currentRowNumber == 1 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[privateMaidOne.lookAtTopCard().getCardNumber() - 1], new Vector2(750, 250), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[privateMaidOne.lookAtTopCard().getCardNumber() - 1], new Vector2(750, 250), Color.White);
                    }
                }
                if (privateMaidTwo.getNumberOfRemainingCards() != 0)
                {
                    if (currentCardNumber == 6 && currentRowNumber == 2 && currentPhase == 1)
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[privateMaidTwo.lookAtTopCard().getCardNumber() - 1], new Vector2(750, 350), Color.Red);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.cardPicturesMini[privateMaidTwo.lookAtTopCard().getCardNumber() - 1], new Vector2(750, 350), Color.White);
                    }
                }
                spriteBatch.End();
                playerList[activePlayer].draw(spriteBatch);
                spriteBatch.Begin();
                if (showBigCardMode && currentPhase == 1)
                {
                    if (currentCardNumber == 0 && currentRowNumber == 0)
                    {
                        if (oneLove.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[oneLove.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 1 && currentRowNumber == 0)
                    {
                        if (marianne.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[marianne.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 2 && currentRowNumber == 0)
                    {
                        if (colette.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[colette.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 3 && currentRowNumber == 0)
                    {
                        if (badHabits.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[badHabits.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 4 && currentRowNumber == 0)
                    {
                        if (illnesses.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[illnesses.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 0 && currentRowNumber == 1)
                    {
                        if (twoLove.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[twoLove.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    for (int index = 0; index < 10; index++)
                    {
                        if (index >= 5)
                        {
                            if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                            {
                                if (currentCardNumber == index - 4 && currentRowNumber == 2 && currentPhase == 1)
                                {
                                    spriteBatch.Draw(Game1.cardPicturesFull[generalMaids.ElementAt(index).lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                                }
                            }
                        }
                        else
                        {
                            if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                            {
                                if (currentCardNumber == index + 1 && currentRowNumber == 1 && currentPhase == 1)
                                {
                                    spriteBatch.Draw(Game1.cardPicturesFull[generalMaids.ElementAt(index).lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                                }
                            }
                        }
                    }
                    if (currentCardNumber == 0 && currentRowNumber == 2)
                    {
                        if (threeLove.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[threeLove.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 6 && currentRowNumber == 1)
                    {
                        if (privateMaidOne.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[privateMaidOne.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                    if (currentCardNumber == 6 && currentRowNumber == 2)
                    {
                        if (privateMaidTwo.getNumberOfRemainingCards() > 0)
                        {
                            spriteBatch.Draw(Game1.cardPicturesFull[privateMaidTwo.lookAtTopCard().getCardNumber() - 1], new Vector2(0, 0), Color.White);
                        }
                    }
                }
                else if (showBigCardMode && currentPhase == 0)
                {
                    if (playerList[activePlayer].getNumberOfCardsInHand() != 0)
                    {
                        spriteBatch.Draw(Game1.cardPicturesFull[playerList[activePlayer].lookAtCardInHand(currentCardNumber).getCardNumber() - 1], new Vector2(0, 0), Color.White);
                    }
                }
                spriteBatch.End();
            }
            else if (selectPlayerModeBool)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.font, "Select Player to give bad habit too", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Player to give bad habit too").X / 2, 125), Color.White);
                for (int index = 0; index < numberOfPlayers; index++)
                {
                    if (currentSelectOption == index)
                    {
                        if (index == activePlayer)
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index + " <-- You", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index + " <-- You").X / 2, 145 + (Game1.font.MeasureString("Player " + index + " <-- You").Y + 5) * index), Color.Red);
                        }
                        else
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index).X / 2, 145 + (Game1.font.MeasureString("Player " + index).Y + 5) * index), Color.Red);
                        }
                    }
                    else
                    {
                        if (index == activePlayer)
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index + " <-- You", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index + " <-- You").X / 2, 145 + (Game1.font.MeasureString("Player " + index + " <-- You").Y + 5) * index), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index).X / 2, 145 + (Game1.font.MeasureString("Player " + index).Y + 5) * index), Color.White);
                        }
                    }
                }
                spriteBatch.End();
            }
            else if (selectEventModeBool)
            {
                playerList[activePlayer].drawPrivateQuarters(spriteBatch);
            }
            else if (selectDiscardModeBool)
            {
                spriteBatch.Begin();
                if (discardPhase == 0)
                {
                    if (currentSelectOption == 0)
                    {
                        spriteBatch.DrawString(Game1.font, "Discard a card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard Card").X / 2, 140), Color.Red);
                    }
                    else
                    {
                        spriteBatch.DrawString(Game1.font, "Discard a card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard Card").X / 2, 140), Color.White);
                    }
                    if (currentSelectOption == 1)
                    {
                        spriteBatch.DrawString(Game1.font, "Don't discard a card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't discard a card").X / 2, 160), Color.Red);
                    }
                    else
                    {
                        spriteBatch.DrawString(Game1.font, "Don't discard a card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't discard a card").X / 2, 160), Color.White);
                    }
                    playerList[activePlayer].drawHand(spriteBatch);
                }
                else if (discardPhase == 1)
                {
                    playerList[activePlayer].drawHand(spriteBatch);
                }
                else if (discardPhase == 2)
                {
                    if (activePlayer == 0)
                    {
                        playerList[1].drawHand(spriteBatch);
                    }
                    else
                    {
                        playerList[0].drawHand(spriteBatch);
                    }
                }
                else if (discardPhase == 3)
                {
                    if (activePlayer == 1 || activePlayer == 0)
                    {
                        playerList[2].drawHand(spriteBatch);
                    }
                    else
                    {
                        playerList[1].drawHand(spriteBatch);
                    }
                }
                else if (discardPhase == 4)
                {
                    if (activePlayer == 2 || activePlayer == 0 || activePlayer == 1)
                    {
                        playerList[3].drawHand(spriteBatch);
                    }
                    else
                    {
                        playerList[2].drawHand(spriteBatch);
                    }
                }
                spriteBatch.End();
            }
            else if (selectDeckModeBool)
            {
                if (deckPhase == 0)
                {
                    spriteBatch.Begin();
                    spriteBatch.DrawString(Game1.font, "Select Player to look at the top card of their deck", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Player to look at the top card of their deck").X / 2, 125), Color.White);
                    for (int index = 0; index < numberOfPlayers; index++)
                    {
                        if (currentSelectOption == index)
                        {
                            if (index == activePlayer)
                            {
                                spriteBatch.DrawString(Game1.font, "Player " + index + " <-- You", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index + " <-- You").X / 2, 145 + (Game1.font.MeasureString("Player " + index + " <-- You").Y + 5) * index), Color.Red);
                            }
                            else
                            {
                                spriteBatch.DrawString(Game1.font, "Player " + index, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index).X / 2, 145 + (Game1.font.MeasureString("Player " + index).Y + 5) * index), Color.Red);
                            }
                        }
                        else
                        {
                            if (index == activePlayer)
                            {
                                spriteBatch.DrawString(Game1.font, "Player " + index + " <-- You", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index + " <-- You").X / 2, 145 + (Game1.font.MeasureString("Player " + index + " <-- You").Y + 5) * index), Color.White);
                            }
                            else
                            {
                                spriteBatch.DrawString(Game1.font, "Player " + index, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index).X / 2, 145 + (Game1.font.MeasureString("Player " + index).Y + 5) * index), Color.White);
                            }
                        }
                    }
                    spriteBatch.End();
                }
                else if (deckPhase == 1)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(Game1.cardPicturesFull[playerList[selectedPlayer].lookAtTopCardOfDeck().getCardNumber()-1], new Vector2(), Color.White);
                    if (currentSelectOption == 0)
                    {
                        spriteBatch.DrawString(Game1.font, "Discard Card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard Card").X / 2, 145), Color.Red);
                    }
                    else
                    {
                        spriteBatch.DrawString(Game1.font, "Discard Card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard Card").X / 2, 145), Color.White);
                        
                    }
                    if (currentSelectOption == 1)
                    {
                        spriteBatch.DrawString(Game1.font, "Don't Discard Card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't Discard Card").X / 2, 160), Color.Red);
                    }
                    else
                    {
                        spriteBatch.DrawString(Game1.font, "Don't Discard Card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't Discard Card").X / 2, 160), Color.White);

                    }
                    spriteBatch.End();
                }
            }
            else if(selectChamberMaidModeBool)
            {

            }
            else if (exchangeModeBool)
            {

            }
            else if (decideToDiscardForServingsModeBool)
            {

            }
        }

        public void otherPlayersDrawCard(int playerNumberToNotDraw)
        {
            for (int index = 0; index < numberOfPlayers; index++)
            {
                if (index != playerNumberToNotDraw)
                {
                    playerList[index].drawCard();
                }
            }
        }

        internal void addBadHabitTo(int playerNumber)
        {
            if (playerList[playerNumber].hasMaidsInPrivateQuarters())
            {
                if (badHabits.getNumberOfRemainingCards() != 0 && playerList[playerNumber].hasMaidsInPrivateQuarters()){
                    playerList[playerNumber].addBadHabitToPrivateQuarters(badHabits.getTopCard());
                }
            }
        }

        public void handleGamePlayScreenInput(KeyboardState keyboard, GamePadState gamepad, KeyboardState keyboardOld, GamePadState gamepadOld)
        {
            if (!selectPlayerModeBool && !selectEventModeBool && !selectDiscardModeBool && !selectDeckModeBool && !selectChamberMaidModeBool && !decideToDiscardForServingsModeBool && !exchangeModeBool)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    if (currentPhase == 0)
                    {

                    }
                    else if (currentPhase == 1)
                    {
                        currentRowNumber--;
                        if (currentRowNumber < 0)
                        {
                            currentRowNumber = 2;
                        }
                        if (currentRowNumber == 0)
                        {
                            if (currentCardNumber > 4)
                            {
                                currentCardNumber = 4;
                            }
                        }
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    if (currentPhase == 0)
                    {

                    }
                    else if (currentPhase == 1)
                    {
                        currentRowNumber++;
                        if (currentRowNumber > 2)
                        {
                            currentRowNumber = 0;
                        }
                        if (currentRowNumber == 0)
                        {
                            if (currentCardNumber > 4)
                            {
                                currentCardNumber = 4;
                            }
                        }
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Right) && !keyboardOld.IsKeyDown(Keys.Right)) ||
                        (ButtonState.Pressed == gamepad.DPad.Right && !(ButtonState.Pressed == gamepadOld.DPad.Right)) ||
                        (keyboard.IsKeyDown(Keys.D) && !keyboardOld.IsKeyDown(Keys.D)) ||
                        (gamepad.ThumbSticks.Left.X > 0 && !(gamepadOld.ThumbSticks.Left.X > 0)))
                {
                    if (currentPhase == 0)
                    {
                        currentCardNumber++;
                        if (currentCardNumber >= playerList[activePlayer].getNumberOfCardsInHand())
                        {
                            currentCardNumber = 0;
                        }
                    }
                    else if (currentPhase == 1)
                    {
                        currentCardNumber++;
                        if (currentCardNumber >= 5 && currentRowNumber == 0 || currentCardNumber >= 7)
                        {
                            currentCardNumber = 0;
                        }
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Left) && !keyboardOld.IsKeyDown(Keys.Left)) ||
                    (ButtonState.Pressed == gamepad.DPad.Left && !(ButtonState.Pressed == gamepadOld.DPad.Left)) ||
                    (keyboard.IsKeyDown(Keys.A) && !keyboardOld.IsKeyDown(Keys.A)) ||
                    (gamepad.ThumbSticks.Left.X < 0 && !(gamepadOld.ThumbSticks.Left.X < 0)))
                {
                    if (currentPhase == 0)
                    {
                        currentCardNumber--;
                        if (currentCardNumber < 0)
                        {
                            currentCardNumber = playerList[activePlayer].getNumberOfCardsInHand() - 1;
                        }
                    }
                    else if (currentPhase == 1)
                    {
                        currentCardNumber--;
                        if (currentCardNumber < 0)
                        {
                            if (currentRowNumber == 0)
                            {
                                currentCardNumber = 4;
                            }
                            else
                            {
                                currentCardNumber = 6;
                            }
                        }
                    }
                }

                if (keyboard.IsKeyDown(Keys.RightShift) && !keyboardOld.IsKeyDown(Keys.RightShift) ||
                    gamepad.IsButtonDown(Buttons.X) && !gamepadOld.IsButtonDown(Buttons.X))
                {
                    if (currentPhase == 0 && playerList[activePlayer].getNumberOfCardsInHand() != 0)
                    {
                        playerList[activePlayer].chamberMaidCard(currentCardNumber);
                        if (currentCardNumber >= playerList[activePlayer].getNumberOfCardsInHand() && currentCardNumber != 0)
                        {
                            currentCardNumber--;
                        }
                    }
                }

                if (keyboard.IsKeyDown(Keys.RightControl) && !keyboardOld.IsKeyDown(Keys.RightControl) ||
                    gamepad.IsButtonDown(Buttons.Y) && !gamepadOld.IsButtonDown(Buttons.Y))
                {
                    showBigCardMode = !showBigCardMode;
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentPhase == 0 && playerList[activePlayer].getNumberOfCardsInHand() != 0)
                    {
                        playerList[activePlayer].playCard(currentCardNumber);
                        if (currentCardNumber >= playerList[activePlayer].getNumberOfCardsInHand() && currentCardNumber != 0)
                        {
                            currentCardNumber--;
                        }
                    }
                    else if (currentPhase == 1)
                    {
                        if (currentCardNumber == 0 && currentRowNumber == 0)
                        {
                            if (oneLove.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(oneLove.lookAtTopCard()))
                            {
                                oneLove.getTopCard();
                            }
                        }
                        if (currentCardNumber == 1 && currentRowNumber == 0)
                        {
                            if (marianne.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(marianne.lookAtTopCard()))
                            {
                                marianne.getTopCard();
                            }
                        }
                        if (currentCardNumber == 2 && currentRowNumber == 0)
                        {
                            if (colette.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(colette.lookAtTopCard()))
                            {
                                colette.getTopCard();
                            }
                        }
                        if (currentCardNumber == 3 && currentRowNumber == 0)
                        {
                            if (badHabits.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(badHabits.lookAtTopCard()))
                            {
                                badHabits.getTopCard();
                            }
                        }
                        if (currentCardNumber == 4 && currentRowNumber == 0)
                        {
                            if (illnesses.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(illnesses.lookAtTopCard()))
                            {
                                illnesses.getTopCard();
                            }
                        }
                        if (currentCardNumber == 0 && currentRowNumber == 1)
                        {
                            if (twoLove.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(twoLove.lookAtTopCard()))
                            {
                                twoLove.getTopCard();
                            }
                        }
                        for (int index = 0; index < 10; index++)
                        {
                            if (index >= 5)
                            {
                                if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                                {
                                    if (currentCardNumber == index - 4 && currentRowNumber == 2 && currentPhase == 1)
                                    {
                                        if (playerList[activePlayer].buy(generalMaids.ElementAt(index).lookAtTopCard()))
                                        {
                                            generalMaids.ElementAt(index).getTopCard();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                                {
                                    if (currentCardNumber == index + 1 && currentRowNumber == 1 && currentPhase == 1)
                                    {
                                        if (playerList[activePlayer].buy(generalMaids.ElementAt(index).lookAtTopCard()))
                                        {
                                            generalMaids.ElementAt(index).getTopCard();
                                        }
                                    }
                                }
                            }
                        }
                        if (currentCardNumber == 0 && currentRowNumber == 2)
                        {
                            if (threeLove.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(threeLove.lookAtTopCard()))
                            {
                                threeLove.getTopCard();
                            }
                        }
                        if (currentCardNumber == 6 && currentRowNumber == 1)
                        {
                            if (privateMaidOne.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(privateMaidOne.lookAtTopCard()))
                            {
                                privateMaidOne.getTopCard();
                                privateMaidOne.addCard(privateMaidPile.getTopCard());
                            }
                        }
                        if (currentCardNumber == 6 && currentRowNumber == 2)
                        {
                            if (privateMaidTwo.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(privateMaidTwo.lookAtTopCard()))
                            {
                                privateMaidTwo.getTopCard();
                                privateMaidTwo.addCard(privateMaidPile.getTopCard());
                            }
                        }
                    }
                }

                if (keyboard.IsKeyDown(Keys.Back) && !keyboardOld.IsKeyDown(Keys.Back) ||
                    gamepad.IsButtonDown(Buttons.B) && !gamepadOld.IsButtonDown(Buttons.B))
                {
                    if (currentPhase == 0)
                    {
                        advancePhase();
                    }
                    else if (currentPhase == 1)
                    {
                        advancePhase();
                    }
                }
            }
            else if (selectPlayerModeBool)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = numberOfPlayers-1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > numberOfPlayers)
                    {
                        currentSelectOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Back) && !keyboardOld.IsKeyDown(Keys.Back) ||
                    gamepad.IsButtonDown(Buttons.B) && !gamepadOld.IsButtonDown(Buttons.B))
                {
                    selectPlayerModeBool = false;
                    badHabits.addCard(new Card(30));
                    playerList[activePlayer].refundBadHabit();
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (playerList[currentSelectOption].hasMaidsInPrivateQuarters())
                    {
                        selectPlayerModeBool = false;
                        playerList[currentSelectOption].addBadHabitToPrivateQuarters(new Card(30));
                    }
                }
            }
            else if (selectEventModeBool)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 2;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 3)
                    {
                        currentSelectOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Back) && !keyboardOld.IsKeyDown(Keys.Back) ||
                    gamepad.IsButtonDown(Buttons.B) && !gamepadOld.IsButtonDown(Buttons.B))
                {
                    selectEventModeBool = false;
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (playerList[activePlayer].hasMaidsInPrivateQuarters() && playerList[activePlayer].privateMaidAt(item).hasIllness() && currentSelectOption == 0){
                        selectEventModeBool = false;
                        illnesses.addCard(playerList[activePlayer].removeIllnessFromMaid(item));
                    }
                    else if (playerList[activePlayer].hasPrivateMaid() && playerList[activePlayer].privateMaid().hasIllness() && currentSelectOption == 1)
                    {
                        selectEventModeBool = false;
                        illnesses.addCard(playerList[activePlayer].removeIllnessFromPrivateMaid());
                    }
                    else if (currentSelectOption == 2 && playerList[activePlayer].hasBadHabit())
                    {
                        selectEventModeBool = false;
                        badHabits.addCard(playerList[activePlayer].removeBadHabit());
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Right) && !keyboardOld.IsKeyDown(Keys.Right)) ||
                        (ButtonState.Pressed == gamepad.DPad.Right && !(ButtonState.Pressed == gamepadOld.DPad.Right)) ||
                        (keyboard.IsKeyDown(Keys.D) && !keyboardOld.IsKeyDown(Keys.D)) ||
                        (gamepad.ThumbSticks.Left.X > 0 && !(gamepadOld.ThumbSticks.Left.X > 0)))
                {
                    if (currentSelectOption == 0)
                    {
                    item++;
                    if (item > playerList[activePlayer].getNumberOfMaidsInPrivateQuarters())
                    {
                        item = 0;
                    }
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Left) && !keyboardOld.IsKeyDown(Keys.Left)) ||
                    (ButtonState.Pressed == gamepad.DPad.Left && !(ButtonState.Pressed == gamepadOld.DPad.Left)) ||
                    (keyboard.IsKeyDown(Keys.A) && !keyboardOld.IsKeyDown(Keys.A)) ||
                    (gamepad.ThumbSticks.Left.X < 0 && !(gamepadOld.ThumbSticks.Left.X < 0)))
                {
                    if (currentSelectOption == 0)
                    {
                        item--;
                        if (item < 0){
                            item = playerList[activePlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                        }
                    }
                }
            }
            else if (selectDiscardModeBool)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    if (discardPhase == 0)
                    {
                        currentSelectOption--;
                        if (currentSelectOption < 0)
                        {
                            currentSelectOption = 1;
                        }
                    }
                    else if (discardPhase == 1)
                    {
                        currentCardNumber--;
                        if (currentCardNumber < 0)
                        {
                            currentCardNumber = playerList[activePlayer].getNumberOfCardsInHand() - 1;
                        }
                    }

                    else if (discardPhase == 2)
                    {
                        currentCardNumber--;
                        if (currentCardNumber < 0)
                        {
                            if (activePlayer == 0)
                            {
                                currentCardNumber = playerList[1].getNumberOfCardsInHand() - 1;
                            }
                            else
                            {
                                currentCardNumber = playerList[0].getNumberOfCardsInHand() - 1;
                            }
                        }
                    }

                    else if (discardPhase == 3)
                    {
                        currentCardNumber--;
                        if (currentCardNumber < 0)
                        {
                            if (activePlayer == 0 || activePlayer == 1)
                            {
                                currentCardNumber = playerList[2].getNumberOfCardsInHand() - 1;
                            }
                            else
                            {
                                currentCardNumber = playerList[1].getNumberOfCardsInHand() - 1;
                            }
                        }
                    }



                    else if (discardPhase == 4)
                    {
                        currentCardNumber--;
                        if (currentCardNumber < 0)
                        {
                            if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                            {
                                currentCardNumber = playerList[3].getNumberOfCardsInHand() - 1;
                            }
                            else
                            {
                                currentCardNumber = playerList[2].getNumberOfCardsInHand() - 1;
                            }
                        }
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    if (discardPhase == 0)
                    {
                        currentSelectOption++;
                        if (currentSelectOption > 1)
                        {
                            currentSelectOption = 0;
                        }
                    }
                    else if (discardPhase == 1)
                    {
                        currentCardNumber++;
                        if (currentCardNumber >= playerList[activePlayer].getNumberOfCardsInHand())
                        {
                            currentCardNumber = 0;
                        }
                    }

                    else if (discardPhase == 2)
                    {
                        currentCardNumber++;
                        if (activePlayer == 0)
                        {
                            if (currentCardNumber >= playerList[1].getNumberOfCardsInHand())
                            {
                                currentCardNumber = 0;
                            }
                        }
                        else
                        {
                            if (currentCardNumber >= playerList[0].getNumberOfCardsInHand())
                            {
                                currentCardNumber = 0;
                            }
                        }
                    }

                    else if (discardPhase == 3)
                    {
                        currentCardNumber++;
                        if (activePlayer == 0 || activePlayer == 1)
                        {
                            if (currentCardNumber >= playerList[2].getNumberOfCardsInHand())
                            {
                                currentCardNumber = 0;
                            }
                        }
                        else
                        {
                            if (currentCardNumber >= playerList[1].getNumberOfCardsInHand())
                            {
                                currentCardNumber = 0;
                            }
                        }
                    }

                    else if (discardPhase == 4)
                    {
                        currentCardNumber++;
                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 3)
                        {
                            if (currentCardNumber >= playerList[3].getNumberOfCardsInHand())
                            {
                                currentCardNumber = 0;
                            }
                        }
                        else
                        {
                            if (currentCardNumber >= playerList[2].getNumberOfCardsInHand())
                            {
                                currentCardNumber = 0;
                            }
                        }
                    }
                }

                if (keyboard.IsKeyDown(Keys.Back) && !keyboardOld.IsKeyDown(Keys.Back) ||
                    gamepad.IsButtonDown(Buttons.B) && !gamepadOld.IsButtonDown(Buttons.B))
                {
                    if (discardPhase == 1)
                    {
                        discardPhase = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (discardPhase == 0 && currentSelectOption == 0)
                    {
                        discardPhase++;

                    }
                    else if (discardPhase == 0 && currentSelectOption == 1)
                    {
                        selectDiscardModeBool = false;
                    }
                    else if (discardPhase == 1)
                    {
                        playerList[activePlayer].discardCard(currentCardNumber);
                        discardPhase++;
                        if (activePlayer == 0)
                        {
                            if (playerList[1].getNumberOfCardsInHand() <= 4)
                            {
                                discardPhase++;
                                if (discardPhase - 1 == numberOfPlayers)
                                {
                                    selectDiscardModeBool = false;
                                }
                                if (activePlayer == 0 || activePlayer == 1)
                                {
                                    if (playerList[2].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                                        {
                                            if (playerList[3].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (playerList[2].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (playerList[3].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                                        {
                                            if (playerList[3].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (playerList[2].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (playerList[0].getNumberOfCardsInHand() <= 4)
                            {
                                discardPhase++;
                                if (discardPhase - 1 == numberOfPlayers)
                                {
                                    selectDiscardModeBool = false;
                                }
                                if (activePlayer == 0 || activePlayer == 1)
                                {
                                    if (playerList[2].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                                        {
                                            if (playerList[3].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (playerList[2].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (playerList[3].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                                        {
                                            if (playerList[3].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (playerList[2].getNumberOfCardsInHand() <= 4)
                                            {
                                                discardPhase++;
                                                if (discardPhase - 1 == numberOfPlayers)
                                                {
                                                    selectDiscardModeBool = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (discardPhase == 2)
                    {
                        if (activePlayer == 0)
                        {
                            playerList[1].discardCard(currentCardNumber);
                        }
                        else
                        {
                            playerList[0].discardCard(currentCardNumber);
                        }
                        discardPhase++;
                        if (discardPhase - 1 == numberOfPlayers)
                        {
                            selectDiscardModeBool = false;
                        }
                        if (activePlayer == 0 || activePlayer == 1)
                        {
                            if (playerList[2].getNumberOfCardsInHand() <= 4)
                            {
                                discardPhase++;
                                if (discardPhase - 1 == numberOfPlayers)
                                {
                                    selectDiscardModeBool = false;
                                }
                                if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                                {
                                    if (playerList[3].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (playerList[2].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (playerList[3].getNumberOfCardsInHand() <= 4)
                            {
                                discardPhase++;
                                if (discardPhase - 1 == numberOfPlayers)
                                {
                                    selectDiscardModeBool = false;
                                }
                                if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                                {
                                    if (playerList[3].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (playerList[2].getNumberOfCardsInHand() <= 4)
                                    {
                                        discardPhase++;
                                        if (discardPhase - 1 == numberOfPlayers)
                                        {
                                            selectDiscardModeBool = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    else if (discardPhase == 3)
                    {
                        if (activePlayer == 0 || activePlayer == 1)
                        {
                            playerList[2].discardCard(currentCardNumber);
                        }
                        else
                        {
                            playerList[3].discardCard(currentCardNumber);
                        }
                        discardPhase++;
                        if (discardPhase - 1 == numberOfPlayers)
                        {
                            selectDiscardModeBool = false;
                        }
                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                        {
                            if (playerList[3].getNumberOfCardsInHand() <= 4)
                            {
                                discardPhase++;
                                if (discardPhase - 1 == numberOfPlayers)
                                {
                                    selectDiscardModeBool = false;
                                }
                            }
                        }
                        else
                        {
                            if (playerList[2].getNumberOfCardsInHand() <= 4)
                            {
                                discardPhase++;
                                if (discardPhase - 1 == numberOfPlayers)
                                {
                                    selectDiscardModeBool = false;
                                }
                            }
                        }
                    }

                    else if (discardPhase == 4)
                    {
                        if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                        {
                            playerList[3].discardCard(currentCardNumber);
                        }
                        else
                        {
                            playerList[2].discardCard(currentCardNumber);
                        }
                        discardPhase++;
                        if (discardPhase - 1 == numberOfPlayers)
                        {
                            selectDiscardModeBool = false;
                        }
                    }
                }
            }
            else if (selectDeckModeBool)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    if (deckPhase == 0)
                    {
                        currentSelectOption--;
                        if (currentSelectOption < 0)
                        {
                            currentSelectOption = numberOfPlayers - 1;
                        }
                    }
                    else if (deckPhase == 1)
                    {
                        currentSelectOption--;
                        if (currentSelectOption < 0)
                        {
                            currentSelectOption = 1;
                        }
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    if (deckPhase == 0)
                    {
                        currentSelectOption++;
                        if (currentSelectOption > numberOfPlayers)
                        {
                            currentSelectOption = 0;
                        }
                    }
                    else if (deckPhase == 1)
                    {
                        currentSelectOption++;
                        if (currentSelectOption > 1)
                        {
                            currentSelectOption = 0;
                        }
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (deckPhase == 0)
                    {
                        selectedPlayer = currentSelectOption;
                        currentSelectOption = 0;
                        deckPhase++;
                    }
                    else if (deckPhase == 1)
                    {
                        if (currentSelectOption == 0)
                        {
                            playerList[selectedPlayer].discardTopCardOfDeck();
                        }
                        selectDeckModeBool = false;
                    }
                }
            }
        }
        
        public int getCurrentCardNumber()
        {
            return currentCardNumber;
        }

        public void advancePhase()
        {
            currentPhase++;
            if (currentPhase == 2)
            {
                currentRowNumber = 0;
                currentCardNumber = 0;
                playerList[activePlayer].endTurn();
                activePlayer++;
                currentPhase = 0;
                if (activePlayer >= numberOfPlayers)
                {
                    activePlayer = 0;
                }
            }
        }

        internal int getCurrentPhase()
        {
            return currentPhase;
        }

        internal void selectPlayerMode()
        {
            selectPlayerModeBool = true;
        }

        internal void selectChamberMaidMode()
        {
            selectChamberMaidModeBool = true;
        }

        internal void decideToDiscardForServingsMode()
        {
            decideToDiscardForServingsModeBool = true;
        }

        internal void selectDeckMode()
        {
            selectDeckModeBool = true;
            deckPhase = 0;
        }

        internal void selectEventMode()
        {
            selectEventModeBool = true;
        }

        internal void selectDiscardMode()
        {
            selectDiscardModeBool = true;
            discardPhase = 0;
        }

        internal void exchangeMode()
        {
            exchangeModeBool = true;
        }

        public bool selectChamberMaidModeBool { get; set; }

        public bool decideToDiscardForServingsModeBool { get; set; }

        public bool selectDeckModeBool { get; set; }

        public bool selectEventModeBool { get; set; }

        public bool selectDiscardModeBool { get; set; }

        public bool exchangeModeBool { get; set; }

        public int item { get; set; }

        public int discardPhase { get; set; }

        public int deckPhase { get; set; }

        public int selectedPlayer { get; set; }
    }
}