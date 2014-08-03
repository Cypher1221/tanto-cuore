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
        public int numberOfPlayers;
        Player[] playerList;
        int currentPhase = 0;
        int currentCardNumber = 0;
        int currentRowNumber = 0;
        bool selectPlayerModeBool = false;
        bool showBigCardMode;
        public int currentSelectOption = 0;
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
        public int selectChamberMaidPhase { get; set; }
        public int decideDiscardPhase { get; set; }
        public int numberOfCardsToDiscard { get; set; }
        public int numberOfCardsDiscarded { get; set; }
        public bool loveOrEmploymentChoiceBool { get; set; }
        public bool discardHandToAddIllnessesToOneMaidModeBool { get; set; }
        public bool lookAtRandomCardInAnotherPlayersHandAndSwapModeBool { get; set; }
        public bool moveEventCardToAnotherPlayersPrivateQuartersModeBool { get; set; }
        public int discardHandPhase { get; set; }
        public int lookAtRandomCardPhase { get; set; }
        public int randomCard1 { get; set; }
        public int moveEventCardPhase { get; set; }
        public int randomCard2 { get; set; }
        public int emptiedPiles { get; set; }
        public bool discard3LoveToRemoveIllnessModeBool { get; set; }
        public int discard3LoveToRemoveIllnessPhase { get; set; }
        public bool moveEventCardBadHabitMode { get; set; }
        public bool showClairMode { get; set; }
        public double timeModeStarted { get; set; }
        public VictoryPointPackage[] VP;
        public bool gameOver { get; set; }
        public int winner;
        public bool gameIsTied;

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
            if (!showClairMode && !discard3LoveToRemoveIllnessModeBool && !lookAtRandomCardInAnotherPlayersHandAndSwapModeBool && !moveEventCardToAnotherPlayersPrivateQuartersModeBool && !discardHandToAddIllnessesToOneMaidModeBool && !loveOrEmploymentChoiceBool && !selectPlayerModeBool && !selectEventModeBool && !selectDiscardModeBool && !selectDeckModeBool && !selectChamberMaidModeBool && !decideToDiscardForServingsModeBool && !exchangeModeBool)
            {
                drawNormalMode(spriteBatch, gameTime);
            }
            else if (selectPlayerModeBool)
            {
                drawSelectPlayerMode(spriteBatch, gameTime);
            }
            else if (selectEventModeBool)
            {
                playerList[activePlayer].drawPrivateQuartersRemovingIllnesses(spriteBatch);
            }
            else if (selectDiscardModeBool)
            {
                drawSelectDiscardMode(spriteBatch, gameTime);
            }
            else if (selectDeckModeBool)
            {
                drawSelectDeckMode(spriteBatch, gameTime);
            }
            else if(selectChamberMaidModeBool)
            {
                drawSelectChamberMaidMode(spriteBatch, gameTime);
            }
            else if (exchangeModeBool)
            {
                drawExchangeMode(spriteBatch, gameTime);
            }
            else if (decideToDiscardForServingsModeBool)
            {
                drawDecideToDiscardForServingsModeBool(spriteBatch, gameTime);
            }
            else if (discardHandToAddIllnessesToOneMaidModeBool)
            {
                drawDiscardHandForIllnesses(gameTime, spriteBatch);
            }
            else if (lookAtRandomCardInAnotherPlayersHandAndSwapModeBool)
            {
                drawLookAtRandomCardInAnotherPlayersHandAndSwapMode(gameTime, spriteBatch);
            }
            else if (loveOrEmploymentChoiceBool)
            {
                drawLoveOrEmploymentMode(gameTime, spriteBatch);
            }
            else if (moveEventCardToAnotherPlayersPrivateQuartersModeBool)
            {
                drawMoveEventCardToAnotherPlayerMode(gameTime, spriteBatch);
            }
            else if (discard3LoveToRemoveIllnessModeBool)
            {
                drawDiscard3LoveToRemoveIllnessMode(gameTime, spriteBatch);
            }
            else if (showClairMode)
            {
                drawShowClairMode(gameTime, spriteBatch);
            }
        }

        private void drawShowClairMode(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Game1.cardPicturesFull[13], new Vector2(), Color.White);
            spriteBatch.End();
            if (gameTime.TotalGameTime.TotalSeconds - timeModeStarted > 5)
            {
                showClairMode = false;
            }
        }

        private void drawDiscard3LoveToRemoveIllnessMode(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (discard3LoveToRemoveIllnessPhase == 0)
            {
                spriteBatch.Begin();
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.DrawString(Game1.font, "Discard a 3 love to removed an illness from one of your maids?", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard a 3 love to removed an illness from one of your maids?").X / 2, 125), Color.White);
                if (currentSelectOption == 0)
                {
                    spriteBatch.DrawString(Game1.font, "Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard").X / 2, 140), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard").X / 2, 140), Color.White);
                }
                if (currentSelectOption == 1)
                {
                    spriteBatch.DrawString(Game1.font, "Don't Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't Discard").X / 2, 160), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Don't Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't Discard").X / 2, 160), Color.White);
                }
                spriteBatch.End();
            }
            else if (discard3LoveToRemoveIllnessPhase == 1)
            {
                playerList[activePlayer].drawPrivateQuartersRemovingIllnesses(spriteBatch);
            }
        }

        private void drawMoveEventCardToAnotherPlayerMode(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (moveEventCardPhase == 0)
            {
                playerList[activePlayer].drawPrivateQuartersRemovingIllnesses(spriteBatch);
            }
            else if (moveEventCardPhase == 1)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.font, "Select Player to send event card to", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Player to send event card to").X / 2, 125), Color.White);
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
            else if (moveEventCardPhase == 2)
            {
                playerList[selectedPlayer].drawPrivateQuarters(spriteBatch);
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.font, "Select Maid to give illness", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Maid to give illness").X / 2, 500), Color.White);
                spriteBatch.End();
            }
        }

        private void drawLookAtRandomCardInAnotherPlayersHandAndSwapMode(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (lookAtRandomCardPhase == 0)
            {
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.DrawString(Game1.font, "Select the Player who you would like to see a random card from", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select the Player who you would like to see a random card from").X / 2, 125), Color.White);
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
            }
            else if (lookAtRandomCardPhase == 1)
            {
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.DrawString(Game1.font, "Exchange this card for random card of yours?", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2, 125), Color.White);
                if (currentSelectOption == 0)
                {
                    spriteBatch.DrawString(Game1.font, "Yes", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2, 140), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Yes", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2, 140), Color.White);
                }
                if (currentSelectOption == 1)
                {
                    spriteBatch.DrawString(Game1.font, "No", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2, 160), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "No", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2, 160), Color.White);
                }
                spriteBatch.Draw(Game1.cardPicturesFull[playerList[selectedPlayer].lookAtCardInHand(randomCard1).getCardNumber()-1], new Vector2(), Color.White);
            }
            else if (lookAtRandomCardPhase == 2)
            {
                spriteBatch.DrawString(Game1.font, "Press Enter (on the keyboard) or A (on the controller) to Continue", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - 100, 125), Color.White);
                spriteBatch.DrawString(Game1.font, "The card you lost", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - 100, 145), Color.White);
                spriteBatch.Draw(Game1.cardPicturesFull[playerList[activePlayer].lookAtCardInHand(randomCard2).getCardNumber() - 1], new Vector2(), Color.White);
            }
            spriteBatch.End();
        }

        private void drawDiscardHandForIllnesses(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (discardHandPhase == 0)
            {
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.DrawString(Game1.font, "Discard down to 1 card to add 2 illnesses to a maid", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard down to 1 card to add 2 illnesses to a maid").X / 2, 125), Color.White);
                if (currentSelectOption == 0)
                {
                    spriteBatch.DrawString(Game1.font, "Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard").X / 2, 140), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard").X / 2, 140), Color.White);
                }
                if (currentSelectOption == 1)
                {
                    spriteBatch.DrawString(Game1.font, "Don't Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't Discard").X / 2, 160), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Don't Discard", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Don't Discard").X / 2, 160), Color.White);
                }
                spriteBatch.DrawString(Game1.font, "Black colored players have maids in private quarters", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Black colored players have maids in private quarters").X / 2, 200), Color.White);
                for (int index = 0; index < numberOfPlayers; index++)
                {
                    if (playerList[index].hasPrivateMaid() || playerList[index].hasChamberMaids())
                    {
                        if (index == activePlayer)
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index + " <-- You", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index + " <-- You").X / 2, 200 + (Game1.font.MeasureString("Player " + index + " <-- You").Y + 5) * index), Color.Black);
                        }
                        else
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index).X / 2, 200 + (Game1.font.MeasureString("Player " + index).Y + 5) * index), Color.Black);
                        }
                    }
                    else
                    {
                        if (index == activePlayer)
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index + " <-- You", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index + " <-- You").X / 2, 200 + (Game1.font.MeasureString("Player " + index + " <-- You").Y + 5) * index), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(Game1.font, "Player " + index, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + index).X / 2, 200 + (Game1.font.MeasureString("Player " + index).Y + 5) * index), Color.White);
                        }
                    }
                }

            }
            else if (discardHandPhase == 1)
            {
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.DrawString(Game1.font, "Discard down to 1 card to add 2 illnesses to a maid", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard down to 1 card to add 2 illnesses to a maid").X / 2, 125), Color.White);
            }
            else if (discardHandPhase == 2)
            {
                spriteBatch.DrawString(Game1.font, "Select Player to give illnesses too", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Player to give bad habit too").X / 2, 125), Color.White);
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
            }
            else if (discardHandPhase == 3)
            {
                spriteBatch.End();
                playerList[selectedPlayer].drawPrivateQuarters(spriteBatch);
                spriteBatch.Begin();
            }
            spriteBatch.End();
        }

        private void drawLoveOrEmploymentMode(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            playerList[activePlayer].drawHand(spriteBatch);
            spriteBatch.DrawString(Game1.font, "Select to recive +1 Love or + 1 Employments", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select to recive +1 Love or + 1 Employments").X / 2, 125), Color.White);
            if (currentSelectOption == 0)
            {
                spriteBatch.DrawString(Game1.font, "+1 Love", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("+1 Love").X / 2, 140), Color.Red);
            }
            else
            {
                spriteBatch.DrawString(Game1.font, "+1 Love", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("+1 Love").X / 2, 140), Color.White);
            }
            if (currentSelectOption == 1)
            {
                spriteBatch.DrawString(Game1.font, "+1 Employment", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("+1 Employment").X / 2, 160), Color.Red);
            }
            else
            {
                spriteBatch.DrawString(Game1.font, "+1 Employment", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("+1 Employment").X / 2, 160), Color.White);
            }
            spriteBatch.End();
        }

        private void drawDecideToDiscardForServingsModeBool(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (decideDiscardPhase == 0)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.font, "Discard 0, 1, or 2 cards for 0, 1, or 2 servings", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard 0, 1, or 2 cards for 0, 1, or 2 servings").X / 2, 125), Color.White);
                if (currentSelectOption == 0)
                {
                    spriteBatch.DrawString(Game1.font, "Discard 1 card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard 1 card").X / 2, 140), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Discard 1 card", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard 1 card").X / 2, 140), Color.White);
                }
                if (currentSelectOption == 1)
                {
                    spriteBatch.DrawString(Game1.font, "Discard 2 cards", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard 2 cards").X / 2, 160), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Discard 2 cards", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard 2 cards").X / 2, 160), Color.White);
                }
                if (currentSelectOption == 2)
                {
                    spriteBatch.DrawString(Game1.font, "Discard no cards", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard no cards").X / 2, 180), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Game1.font, "Discard no cards", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Discard no cards").X / 2, 180), Color.White);
                }
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.End();
            }
            else if (decideDiscardPhase == 1)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.font, "Select cards to discard for servings", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select cards to discard for servings").X / 2, 125), Color.White);
                playerList[activePlayer].drawHand(spriteBatch);
                spriteBatch.End();
            }
        }

        private void drawNormalMode(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Game1.font, "Player " + activePlayer, new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Player " + activePlayer).X / 2, 125), Color.White);
            drawTown(gameTime, spriteBatch);
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
                if (playerList[activePlayer].getNumberOfCardsInHand() != 0 && playerList[activePlayer].lookAtCardInHand(currentCardNumber) != null)
                {
                    spriteBatch.Draw(Game1.cardPicturesFull[playerList[activePlayer].lookAtCardInHand(currentCardNumber).getCardNumber() - 1], new Vector2(0, 0), Color.White);
                }
            }
            spriteBatch.End();
        } 

        private void drawSelectPlayerMode(SpriteBatch spriteBatch, GameTime gameTime)
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

        private void drawSelectDiscardMode(SpriteBatch spriteBatch, GameTime gameTime)
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

        private void drawSelectDeckMode(SpriteBatch spriteBatch, GameTime gameTime)
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
                spriteBatch.Draw(Game1.cardPicturesFull[playerList[selectedPlayer].lookAtTopCardOfDeck().getCardNumber() - 1], new Vector2(), Color.White);
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

        private void drawSelectChamberMaidMode(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (selectChamberMaidPhase == 0)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(Game1.font, "Select Player to give an illness to one of their chamber or private maids", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Player to give an illness to one of their chamber or private maids").X / 2, 125), Color.White);
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
            else if (selectChamberMaidPhase == 1)
            {
                playerList[selectedPlayer].drawPrivateQuarters(spriteBatch);
            }
        }

        private void drawExchangeMode(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(Game1.font, "Select Maid that costs 4 or less or a 2 love to exchange for a 1 love in your hand", new Vector2(Game1.graphics.GraphicsDevice.Viewport.Width / 2 - Game1.font.MeasureString("Select Maid that costs 4 or less or a 2 love to exchange for a 1 love in your hand").X / 2, 125), Color.White);
            drawTown(gameTime, spriteBatch);
            if (showBigCardMode)
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
            spriteBatch.End();
        }

        private void drawTown(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int index = 0; index < 10; index++)
            {
                if (index >= 5)
                {
                    if (generalMaids.ElementAt(index).getNumberOfRemainingCards() != 0)
                    {
                        if (currentCardNumber == index - 4 && currentRowNumber == 2 && currentPhase == 1)
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
            if (playerList[playerNumber].hasChamberMaids() || playerList[playerNumber].hasPrivateMaid())
            {
                if (badHabits.getNumberOfRemainingCards() != 0 && (playerList[playerNumber].hasChamberMaids() || playerList[playerNumber].hasPrivateMaid()))
                {
                    playerList[playerNumber].addBadHabitToPrivateQuarters(badHabits.getTopCard());
                }
            }
        }

        public void handleGamePlayScreenInput(KeyboardState keyboard, GamePadState gamepad, KeyboardState keyboardOld, GamePadState gamepadOld, GameTime gameTime)
        {
            if (!discard3LoveToRemoveIllnessModeBool && !lookAtRandomCardInAnotherPlayersHandAndSwapModeBool && !moveEventCardToAnotherPlayersPrivateQuartersModeBool && !discardHandToAddIllnessesToOneMaidModeBool && !loveOrEmploymentChoiceBool && !selectPlayerModeBool && !selectEventModeBool && !selectDiscardModeBool && !selectDeckModeBool && !selectChamberMaidModeBool && !decideToDiscardForServingsModeBool && !exchangeModeBool)
            {
                normalInput(keyboard, keyboardOld, gamepad, gamepadOld);
            }
            else if (selectPlayerModeBool)
            {
                selectPlayerModeInput(keyboardOld, gamepadOld, keyboard, gamepad, gameTime);
            }
            else if (selectEventModeBool)
            {
                selectEventModeInput(keyboard,gamepad,keyboardOld,gamepadOld);
            }
            else if (selectDiscardModeBool)
            {
                selectDiscardModeInput(keyboardOld, keyboard, gamepadOld, gamepad);
            }
            else if (selectDeckModeBool)
            {
                selectDeckModeInput(keyboard,keyboardOld,gamepad,gamepadOld);
            }
            else if (selectChamberMaidModeBool)
            {
                selectChamberMaidModeInput(keyboard, gamepadOld, keyboardOld, gamepad, gameTime);
            }
            else if (exchangeModeBool)
            {
                selectExchangeModeInput(keyboard, keyboardOld, gamepad, gamepadOld);
            }
            else if (decideToDiscardForServingsModeBool)
            {
                decicideDiscardModeInput(keyboard, keyboardOld, gamepad, gamepadOld);
            }
            else if (discardHandToAddIllnessesToOneMaidModeBool)
            {
                discardHandForIllnessesInput(keyboard, keyboardOld, gamepad, gamepadOld, gameTime);
            }
            else if (lookAtRandomCardInAnotherPlayersHandAndSwapModeBool)
            {
                lookAtRandomCardInAnotherPlayersHandAndSwapModeInput(keyboard, keyboardOld, gamepad, gamepadOld);
            }
            else if (loveOrEmploymentChoiceBool)
            {
                loveOrEmploymentChoiceInput(keyboard, keyboardOld, gamepad, gamepadOld);
            }
            else if (moveEventCardToAnotherPlayersPrivateQuartersModeBool)
            {
                moveEventCardToAnotherPlayerModeInput(keyboard, keyboardOld, gamepad, gamepadOld, gameTime);
            }
            else if (discard3LoveToRemoveIllnessModeBool)
            {
                discard3LoveToRemoveIllnessModeInput(keyboard, keyboardOld, gamepad, gamepadOld);
            }
        }

        private void discard3LoveToRemoveIllnessModeInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
        {
            if (discard3LoveToRemoveIllnessPhase == 0)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0 && playerList[activePlayer].handContains(new Card(31)))
                    {
                        discard3LoveToRemoveIllnessPhase++;
                        playerList[activePlayer].discardCard(playerList[activePlayer].find3LoveCard());
                    }
                    if (currentSelectOption == 1)
                    {
                        discard3LoveToRemoveIllnessModeBool = false;
                    }
                }
            }
            else if (discard3LoveToRemoveIllnessPhase == 1)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
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
                        if (item < 0)
                        {
                            item = playerList[activePlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                        }
                    }
                }
                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0 && playerList[activePlayer].hasChamberMaids() && playerList[activePlayer].chamberMaidAt(item).hasIllness())
                    {
                        discard3LoveToRemoveIllnessModeBool = false;
                        illnesses.addCard(playerList[activePlayer].removeIllnessFromMaid(item));
                    }
                    else if (currentSelectOption == 1 && playerList[activePlayer].hasPrivateMaid() && playerList[activePlayer].privateMaid().hasIllness())
                    {
                        illnesses.addCard(playerList[activePlayer].removeIllnessFromPrivateMaid());
                        discard3LoveToRemoveIllnessModeBool = false;
                    }
                }
            }
        }

        private void moveEventCardToAnotherPlayerModeInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld, GameTime gameTime)
        {
            if (moveEventCardPhase == 0)
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
                    if (currentSelectOption > 2)
                    {
                        currentSelectOption = 0;
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
                        if (item < 0)
                        {
                            item = playerList[activePlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                        }
                    }
                }
                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0 && playerList[activePlayer].hasChamberMaids() && playerList[activePlayer].chamberMaidAt(item).hasIllness())
                    {
                        playerList[activePlayer].removeIllnessFromMaid(item);
                        moveEventCardPhase++;
                    }
                    else if (currentSelectOption == 1 && playerList[activePlayer].hasPrivateMaid() && playerList[activePlayer].privateMaid().hasIllness())
                    {
                        playerList[activePlayer].removeIllnessFromPrivateMaid();
                        moveEventCardPhase++;
                    }
                    else if (currentSelectOption == 2 && playerList[activePlayer].hasBadHabit())
                    {
                        playerList[activePlayer].removeBadHabit();
                        moveEventCardPhase++;
                        moveEventCardBadHabitMode = true;
                    }
                }
            }
            else if (moveEventCardPhase == 1)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = numberOfPlayers - 1;
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

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption != activePlayer && (playerList[currentSelectOption].hasChamberMaids()|| playerList[currentSelectOption].hasPrivateMaid()))
                    {
                        selectedPlayer = currentSelectOption;
                        moveEventCardPhase++;
                        if (moveEventCardBadHabitMode)
                        {

                            if (playerList[selectedPlayer].handContains(new Card(14)))
                            {
                                moveEventCardToAnotherPlayersPrivateQuartersModeBool = false;
                                badHabits.addCard(new Card(30));
                                showClairMode = true;
                                timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                            }
                            else
                            {
                                playerList[selectedPlayer].addBadHabitToPrivateQuarters(new Card(30));
                                moveEventCardToAnotherPlayersPrivateQuartersModeBool = false;
                            }
                        }
                    }
                }
            }
            else if (moveEventCardPhase == 2)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
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
                        if (item > playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters())
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
                        if (item < 0)
                        {
                            item = playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                        }
                    }
                }
                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0 && playerList[selectedPlayer].hasChamberMaids())
                    {
                        if (playerList[selectedPlayer].handContains(new Card(14)))
                        {
                            moveEventCardToAnotherPlayersPrivateQuartersModeBool = false;
                            illnesses.addCard(new Card(29));
                            showClairMode = true;
                            timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else
                        {
                            playerList[selectedPlayer].giveIllnessToChamberMaid(item);
                            moveEventCardToAnotherPlayersPrivateQuartersModeBool = false;
                        }
                    }
                    else if (currentSelectOption == 1 && playerList[selectedPlayer].hasPrivateMaid())
                    {
                        if (playerList[selectedPlayer].handContains(new Card(14)))
                        {
                            moveEventCardToAnotherPlayersPrivateQuartersModeBool = false;
                            illnesses.addCard(new Card(29));
                            showClairMode = true;
                            timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else
                        {
                            playerList[selectedPlayer].giveIllnessToPrivateMaid();
                            moveEventCardToAnotherPlayersPrivateQuartersModeBool = false;
                        }
                    }
                }
            }
        }

        private void lookAtRandomCardInAnotherPlayersHandAndSwapModeInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
        {
            if (lookAtRandomCardPhase == 0)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = numberOfPlayers - 1;
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

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption != activePlayer)
                    {
                        selectedPlayer = currentSelectOption;
                        lookAtRandomCardPhase++;
                        randomCard1 = new Random().Next(playerList[selectedPlayer].getNumberOfCardsInHand());
                    }
                }
            }
            else if (lookAtRandomCardPhase == 1)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0)
                    {
                        lookAtRandomCardPhase++;
                        randomCard2 = new Random().Next(playerList[activePlayer].getNumberOfCardsInHand());
                    }
                    if (currentSelectOption == 1)
                    {
                        lookAtRandomCardInAnotherPlayersHandAndSwapModeBool = false;
                    }
                }
            }
            else if (lookAtRandomCardPhase == 2)
            {
                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    playerList[selectedPlayer].exchangeCardsWith(playerList[activePlayer], randomCard1, randomCard2);
                    lookAtRandomCardInAnotherPlayersHandAndSwapModeBool = false;
                }
            }
        }

        private void discardHandForIllnessesInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld, GameTime gameTime)
        {
            if (discardHandPhase == 0)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0)
                    {
                        discardHandPhase++;
                        numberOfCardsToDiscard = playerList[activePlayer].getNumberOfCardsInHand() - 1;
                        numberOfCardsDiscarded = 0;
                    }
                    if (currentSelectOption == 1)
                    {
                        discardHandToAddIllnessesToOneMaidModeBool = false;
                    }
                }
            }else if (discardHandPhase == 1)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentCardNumber--;
                    if (currentCardNumber < 0)
                    {
                        currentCardNumber = playerList[activePlayer].getNumberOfCardsInHand() - 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentCardNumber++;
                    if (currentCardNumber >= playerList[activePlayer].getNumberOfCardsInHand())
                    {
                        currentCardNumber = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    
                    playerList[activePlayer].discardCard(currentCardNumber);
                    numberOfCardsDiscarded++;
                    if (numberOfCardsDiscarded == numberOfCardsToDiscard)
                    {
                        discardHandPhase++;
                    }
                }
            }
            else if (discardHandPhase == 2)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = numberOfPlayers - 1;
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

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (playerList[currentSelectOption].hasChamberMaids() || playerList[currentSelectOption].hasPrivateMaid())
                    {
                        selectedPlayer = currentSelectOption;
                        discardHandPhase++;
                    }
                }
            }
            else if (discardHandPhase == 3)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 1;
                    }
                }
                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
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
                        if (item > playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters())
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
                        if (item < 0)
                        {
                            item = playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                        }
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentSelectOption == 0 && playerList[selectedPlayer].hasChamberMaids() && illnesses.getNumberOfRemainingCards() > 0)
                    {
                        if (playerList[selectedPlayer].handContains(new Card(14)))
                        {
                            discardHandToAddIllnessesToOneMaidModeBool = false;
                            illnesses.addCard(new Card(29));
                            showClairMode = true;
                            timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else if (illnesses.getNumberOfRemainingCards() > 1)
                        {
                            playerList[selectedPlayer].giveIllnessToChamberMaid(item);
                            playerList[selectedPlayer].giveIllnessToChamberMaid(item);
                            illnesses.getTopCard();
                            illnesses.getTopCard();
                            discardHandToAddIllnessesToOneMaidModeBool = false;
                        }
                        else
                        {
                            playerList[selectedPlayer].giveIllnessToChamberMaid(item);
                            illnesses.getTopCard();
                            discardHandToAddIllnessesToOneMaidModeBool = false;
                        }
                    }
                    else if (currentSelectOption == 1 && playerList[selectedPlayer].hasPrivateMaid() && illnesses.getNumberOfRemainingCards() > 0)
                    {
                        if (playerList[selectedPlayer].handContains(new Card(14)))
                        {
                            discardHandToAddIllnessesToOneMaidModeBool = false;
                            illnesses.addCard(new Card(29));
                            showClairMode = true;
                            timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else if (illnesses.getNumberOfRemainingCards() > 1)
                        {
                            playerList[selectedPlayer].giveIllnessToPrivateMaid();
                            playerList[selectedPlayer].giveIllnessToPrivateMaid();
                            illnesses.getTopCard();
                            illnesses.getTopCard();
                            discardHandToAddIllnessesToOneMaidModeBool = false;
                        }
                        else
                        {
                            playerList[selectedPlayer].giveIllnessToPrivateMaid();
                            illnesses.getTopCard();
                            discardHandToAddIllnessesToOneMaidModeBool = false;
                        }
                    }
                }
            }
        }

        private void loveOrEmploymentChoiceInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                currentSelectOption--;
                if (currentSelectOption < 0)
                {
                    currentSelectOption = 1;
                }
            }
            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {
                currentSelectOption++;
                if (currentSelectOption > 1)
                {
                    currentSelectOption = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if (currentSelectOption == 0)
                {
                    playerList[activePlayer].addLove();
                    loveOrEmploymentChoiceBool = false;
                }
                if (currentSelectOption == 1)
                {
                    playerList[activePlayer].addEmployment();
                    loveOrEmploymentChoiceBool = false;
                }
            }
        }

        private void decicideDiscardModeInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                if (decideDiscardPhase == 0)
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = 2;
                    }
                }
                else if (decideDiscardPhase == 2)
                {
                    currentCardNumber--;
                    if (currentCardNumber < 0)
                    {
                        currentCardNumber = playerList[activePlayer].getNumberOfCardsInHand() - 1;
                    }
                }
            }
            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {
                if (decideDiscardPhase == 0)
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
                    }
                }
                else if (decideDiscardPhase == 1)
                {
                    currentCardNumber++;
                    if (currentCardNumber >= playerList[activePlayer].getNumberOfCardsInHand())
                    {
                        currentCardNumber = 0;
                    }
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if (decideDiscardPhase == 0 && currentSelectOption == 0)
                {
                    decideDiscardPhase++;
                    numberOfCardsToDiscard = 1;
                    numberOfCardsDiscarded = 0;
                }
                else if (decideDiscardPhase == 0 && currentSelectOption == 1)
                {
                    decideDiscardPhase++;
                    numberOfCardsToDiscard = 2;
                    numberOfCardsDiscarded = 0;
                }
                else if (decideDiscardPhase == 0 && currentSelectOption == 2)
                {
                    decideToDiscardForServingsModeBool = false;
                }
                else if (decideDiscardPhase == 1)
                {
                    playerList[activePlayer].discardCard(currentCardNumber);
                    numberOfCardsDiscarded++;
                    playerList[activePlayer].addServing();
                    if (numberOfCardsDiscarded == numberOfCardsToDiscard)
                    {
                        decideToDiscardForServingsModeBool = false;
                    }
                }
            }
        }

        private void selectExchangeModeInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
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

            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
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

            if ((keyboard.IsKeyDown(Keys.Right) && !keyboardOld.IsKeyDown(Keys.Right)) ||
                    (ButtonState.Pressed == gamepad.DPad.Right && !(ButtonState.Pressed == gamepadOld.DPad.Right)) ||
                    (keyboard.IsKeyDown(Keys.D) && !keyboardOld.IsKeyDown(Keys.D)) ||
                    (gamepad.ThumbSticks.Left.X > 0 && !(gamepadOld.ThumbSticks.Left.X > 0)))
            {
                currentCardNumber++;
                if (currentCardNumber >= 5 && currentRowNumber == 0 || currentCardNumber >= 7)
                {
                    currentCardNumber = 0;
                }
            }

            if ((keyboard.IsKeyDown(Keys.Left) && !keyboardOld.IsKeyDown(Keys.Left)) ||
                (ButtonState.Pressed == gamepad.DPad.Left && !(ButtonState.Pressed == gamepadOld.DPad.Left)) ||
                (keyboard.IsKeyDown(Keys.A) && !keyboardOld.IsKeyDown(Keys.A)) ||
                (gamepad.ThumbSticks.Left.X < 0 && !(gamepadOld.ThumbSticks.Left.X < 0)))
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

            if (keyboard.IsKeyDown(Keys.RightControl) && !keyboardOld.IsKeyDown(Keys.RightControl) ||
                gamepad.IsButtonDown(Buttons.Y) && !gamepadOld.IsButtonDown(Buttons.Y))
            {
                showBigCardMode = !showBigCardMode;
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if (currentCardNumber == 2 && currentRowNumber == 0)
                {
                    if (colette.getNumberOfRemainingCards() > 0 && playerList[activePlayer].exchange(colette.lookAtTopCard()))
                    {
                        colette.getTopCard();
                        oneLove.addCard(new Card(33));
                        currentPhase = 0;
                        exchangeModeBool = false;
                    }
                }
                if (currentCardNumber == 0 && currentRowNumber == 1)
                {
                    if (twoLove.getNumberOfRemainingCards() > 0 && playerList[activePlayer].exchange(twoLove.lookAtTopCard()))
                    {
                        twoLove.getTopCard();
                        oneLove.addCard(new Card(33));
                        currentPhase = 0;
                        exchangeModeBool = false;
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
                                if (playerList[activePlayer].exchange(generalMaids.ElementAt(index).lookAtTopCard()))
                                {
                                    generalMaids.ElementAt(index).getTopCard();
                                    oneLove.addCard(new Card(33));
                                    currentPhase = 0;
                                    exchangeModeBool = false;
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
                                if (playerList[activePlayer].exchange(generalMaids.ElementAt(index).lookAtTopCard()))
                                {
                                    generalMaids.ElementAt(index).getTopCard();
                                    oneLove.addCard(new Card(33));
                                    currentPhase = 0;
                                    exchangeModeBool = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void selectChamberMaidModeInput(KeyboardState keyboard, GamePadState gamepadOld, KeyboardState keyboardOld, GamePadState gamepad, GameTime gameTime)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                if (selectChamberMaidPhase == 0)
                {
                    currentSelectOption--;
                    if (currentSelectOption < 0)
                    {
                        currentSelectOption = numberOfPlayers - 1;
                    }
                }
                else if (selectChamberMaidPhase == 1)
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
                if (selectChamberMaidPhase == 0)
                {
                    currentSelectOption++;
                    if (currentSelectOption > numberOfPlayers)
                    {
                        currentSelectOption = 0;
                    }
                }
                else if (selectChamberMaidPhase == 1)
                {
                    currentSelectOption++;
                    if (currentSelectOption > 1)
                    {
                        currentSelectOption = 0;
                    }
                }
            }

            if ((keyboard.IsKeyDown(Keys.Right) && !keyboardOld.IsKeyDown(Keys.Right)) ||
                    (ButtonState.Pressed == gamepad.DPad.Right && !(ButtonState.Pressed == gamepadOld.DPad.Right)) ||
                    (keyboard.IsKeyDown(Keys.D) && !keyboardOld.IsKeyDown(Keys.D)) ||
                    (gamepad.ThumbSticks.Left.X > 0 && !(gamepadOld.ThumbSticks.Left.X > 0)))
            {
                if (selectChamberMaidPhase == 1)
                {
                    if (currentSelectOption == 0)
                    {
                        item++;
                        if (item > playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters())
                        {
                            item = 0;
                        }
                    }
                }
            }

            if ((keyboard.IsKeyDown(Keys.Left) && !keyboardOld.IsKeyDown(Keys.Left)) ||
                (ButtonState.Pressed == gamepad.DPad.Left && !(ButtonState.Pressed == gamepadOld.DPad.Left)) ||
                (keyboard.IsKeyDown(Keys.A) && !keyboardOld.IsKeyDown(Keys.A)) ||
                (gamepad.ThumbSticks.Left.X < 0 && !(gamepadOld.ThumbSticks.Left.X < 0)))
            {
                if (selectChamberMaidPhase == 1)
                {
                    if (currentSelectOption == 0)
                    {
                        item--;
                        if (item < 0)
                        {
                            item = playerList[selectedPlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                        }
                    }
                }
            }

            if (keyboard.IsKeyDown(Keys.Back) && !keyboardOld.IsKeyDown(Keys.Back) ||
                gamepad.IsButtonDown(Buttons.B) && !gamepadOld.IsButtonDown(Buttons.B))
            {
                selectChamberMaidModeBool = false;
                illnesses.addCard(new Card(29));
                playerList[activePlayer].refundIllness();
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if ((playerList[currentSelectOption].hasChamberMaids() || playerList[currentSelectOption].hasPrivateMaid()) && selectChamberMaidPhase == 0)
                {
                    selectChamberMaidPhase++;
                    selectedPlayer = currentSelectOption;
                }else if (selectChamberMaidPhase == 1)
                {
                    if (currentSelectOption == 0 && playerList[selectedPlayer].hasChamberMaids())
                    {
                        if (playerList[selectedPlayer].handContains(new Card(14)))
                        {
                            selectChamberMaidModeBool = false;
                            illnesses.addCard(new Card(29));
                            showClairMode = true;
                            timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else
                        {
                            playerList[selectedPlayer].giveIllnessToChamberMaid(item);
                            selectChamberMaidModeBool = false;
                        }
                    }
                    else if (currentSelectOption == 1 && playerList[selectedPlayer].hasPrivateMaid())
                    {
                        if (playerList[selectedPlayer].handContains(new Card(14)))
                        {
                            selectChamberMaidModeBool = false;
                            illnesses.addCard(new Card(29));
                            showClairMode = true;
                            timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                        }
                        else
                        {
                            playerList[selectedPlayer].giveIllnessToPrivateMaid();
                            selectChamberMaidModeBool = false;
                        }
                    }
                }
            }
        }

        private void normalInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
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
                            if (marianne.getNumberOfRemainingCards() == 0)
                            {
                                emptiedPiles++;
                            }
                        }
                    }
                    if (currentCardNumber == 2 && currentRowNumber == 0)
                    {
                        if (colette.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(colette.lookAtTopCard()))
                        {
                            colette.getTopCard();
                            if (colette.getNumberOfRemainingCards() == 0)
                            {
                                emptiedPiles++;
                            }
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
                                        if (generalMaids.ElementAt(index).getNumberOfRemainingCards() == 0)
                                        {
                                            emptiedPiles++;
                                        }
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
                                        if (generalMaids.ElementAt(index).getNumberOfRemainingCards() == 0)
                                        {
                                            emptiedPiles++;
                                        }
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
                            if (privateMaidPile.getNumberOfRemainingCards() == 0)
                            {
                                emptiedPiles++;
                                if (emptiedPiles == 2)
                                {
                                    endGame();
                                }
                            }
                        }
                    }
                    if (currentCardNumber == 6 && currentRowNumber == 2)
                    {
                        if (privateMaidTwo.getNumberOfRemainingCards() > 0 && playerList[activePlayer].buy(privateMaidTwo.lookAtTopCard()))
                        {
                            privateMaidTwo.getTopCard();
                            privateMaidTwo.addCard(privateMaidPile.getTopCard());
                            if (privateMaidPile.getNumberOfRemainingCards() == 0)
                            {
                                emptiedPiles++;
                                if (emptiedPiles == 2)
                                {
                                    endGame();
                                }
                            }
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

        private void selectPlayerModeInput(KeyboardState keyboardOld, GamePadState gamepadOld, KeyboardState keyboard, GamePadState gamepad, GameTime gameTime)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                currentSelectOption--;
                if (currentSelectOption < 0)
                {
                    currentSelectOption = numberOfPlayers - 1;
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
                if (playerList[currentSelectOption].hasChamberMaids() || playerList[currentSelectOption].hasPrivateMaid())
                {
                    if (playerList[selectedPlayer].handContains(new Card(14)))
                    {
                        selectPlayerModeBool = false;
                        badHabits.addCard(new Card(30));
                        showClairMode = true;
                        timeModeStarted = gameTime.TotalGameTime.TotalSeconds;
                    }
                    else
                    {
                        selectPlayerModeBool = false;
                        playerList[currentSelectOption].addBadHabitToPrivateQuarters(new Card(30));
                    }
                }
            }
        }

        private void selectEventModeInput(KeyboardState keyboard, GamePadState gamepad, KeyboardState keyboardOld, GamePadState gamepadOld)
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
                if (currentSelectOption > 2)
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
                if (playerList[activePlayer].hasChamberMaids() && playerList[activePlayer].privateMaidAt(item).hasIllness() && currentSelectOption == 0)
                {
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
                    if (item < 0)
                    {
                        item = playerList[activePlayer].getNumberOfMaidsInPrivateQuarters() - 1;
                    }
                }
            }
        }

        private void selectDiscardModeInput(KeyboardState keyboardOld, KeyboardState keyboard, GamePadState gamepadOld, GamePadState gamepad)
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
                        if (numberOfPlayers > 2 && playerList[2].getNumberOfCardsInHand() <= 4)
                        {
                            discardPhase++;
                            if (discardPhase - 1 == numberOfPlayers)
                            {
                                selectDiscardModeBool = false;
                            }
                            if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                            {
                                if (numberOfPlayers > 3 && playerList[3].getNumberOfCardsInHand() <= 4)
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
                                if (numberOfPlayers > 2 && playerList[2].getNumberOfCardsInHand() <= 4)
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
                        if (numberOfPlayers > 3 && playerList[3].getNumberOfCardsInHand() <= 4)
                        {
                            discardPhase++;
                            if (discardPhase - 1 == numberOfPlayers)
                            {
                                selectDiscardModeBool = false;
                            }
                            if (activePlayer == 0 || activePlayer == 1 || activePlayer == 2)
                            {
                                if (numberOfPlayers > 3 && playerList[3].getNumberOfCardsInHand() <= 4)
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
                                if (numberOfPlayers > 2 && playerList[2].getNumberOfCardsInHand() <= 4)
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

        private void selectDeckModeInput(KeyboardState keyboard, KeyboardState keyboardOld, GamePadState gamepad, GamePadState gamepadOld)
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
                    if (playerList[currentSelectOption].hasCardsInDeck())
                    {
                        selectedPlayer = currentSelectOption;
                        currentSelectOption = 0;
                        deckPhase++;
                    }
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
                if (emptiedPiles >= 2)
                {
                    endGame();
                }
                activePlayer++;
                currentPhase = 0;
                if (activePlayer >= numberOfPlayers)
                {
                    activePlayer = 0;
                }
                playerList[activePlayer].startTurn();
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
            selectChamberMaidPhase = 0;
        }

        internal void decideToDiscardForServingsMode()
        {
            decideToDiscardForServingsModeBool = true;
            decideDiscardPhase = 0;
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
            currentPhase = 1;
        }

        internal void loveOrEmploymentChoice()
        {
            loveOrEmploymentChoiceBool = true;
        }

        internal void otherPlayersDiscardTopCardDuringEndTurn()
        {
            for (int index = 0; index < numberOfPlayers; index++)
            {
                if (index != activePlayer)
                {
                    playerList[index].otherPlayerHasAmber = true;
                }
            }
        }

        internal void discardHandToAddIllnessesToOneMaidMode()
        {
            discardHandToAddIllnessesToOneMaidModeBool = true;
            discardHandPhase = 0;
        }

        internal void lookAtRandomCardInAnotherPlayersHandAndSwapMode()
        {
            lookAtRandomCardInAnotherPlayersHandAndSwapModeBool = true;
            lookAtRandomCardPhase = 0;
            randomCard1 = 0;
        }

        internal void moveEventCardToAnotherPlayersPrivateQuartersMode()
        {
            moveEventCardToAnotherPlayersPrivateQuartersModeBool = true;
            moveEventCardPhase = 0;
        }

        internal bool otherPlayersHaveMaidsInPrivateQuarters(Player player)
        {
            for (int index = 0; index < numberOfPlayers; index++)
            {
                if (index != player.playerNumber && (playerList[index].hasChamberMaids() || playerList[index].hasPrivateMaid()))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool aPlayerHasCardsInDeck()
        {
            for (int index = 0; index < numberOfPlayers; index++)
            {
                if (playerList[index].hasCardsInDeck())
                {
                    return true;
                }
            }
            return false;
        }

        private void endGame()
        {
            int indexOfPlayerWithMostColettes = 0;
            bool tied = false;
            VP = new VictoryPointPackage[numberOfPlayers];
            for (int index = 0; index < numberOfPlayers; index++)
            {
                VP[index] = playerList[index].calulateVP();
                if (VP[index].coletteCounter > VP[indexOfPlayerWithMostColettes].coletteCounter)
                {
                    indexOfPlayerWithMostColettes = index;
                }
                else if (VP[index].coletteCounter == VP[indexOfPlayerWithMostColettes].coletteCounter && index != indexOfPlayerWithMostColettes)
                {
                    tied = true;
                }
            }
            if (!tied)
            {
                VP[indexOfPlayerWithMostColettes].VP += 5;
            }
            gameOver = true;
            for (int index = 0; index < numberOfPlayers; index++)
            {
                if (VP[index].VP > VP[winner].VP)
                {
                    winner = index;
                }
                else if (VP[index].VP == indexOfPlayerWithMostColettes && index != winner)
                {
                    gameIsTied = true;
                }
            }
        }

        internal void discard3LoveToRemoveIllness()
        {
            discard3LoveToRemoveIllnessModeBool = true;
            discard3LoveToRemoveIllnessPhase = 0;
        }

        internal bool playerHasCard(int target, int p)
        {
            return playerList[target].handContains(new Card(p));
        }
    }
}