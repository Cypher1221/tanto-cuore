using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tanto_Cuore
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int screenNumber = 0; //0 main screen, 1 single player setup, 2 multiplayer setup, 3 settings, 4 gamplay screen, 5 results screen
        int currentMainMenuOption =0 ; //0 single player setup, 1 multiplayer setup, 2 settings, 3 exit game.
        const int mainMenu = 0;
        const int singlePlayerSetup = 1;
        const int multiplayerSetup = 2;
        const int settings = 3;
        const int gameplayScreen = 4;
        const int resultsScreen = 5;
        int numberOfMainMenuOptions = 4;
        SpriteFont font;
        String[] mainMenuOptionsStrings;
        int currentSinglePlayerSetupMenuOption = 0; //0 beginner mode, 1 random mode, 2 edit general maids, 3 number of ai, 4 start, 5 return.
        int numberOfSinglePlayerSetupMenuOptions = 6;
        String[] singlePlayerSetupMenuOptionsStrings;
        bool beginnerMode = true;
        bool randomMode = false;
        PlayArea playArea;
        int numberOfAIPlayers = 1;

        Texture2D[] cardPicturesFull;
        Texture2D[] cardPicturesMini;

        KeyboardState keyboardOld;
        MouseState mouseOld;
        GamePadState gamepadOld;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            gamepadOld = new GamePadState();
            mouseOld = new MouseState();
            keyboardOld = new KeyboardState();
            mainMenuOptionsStrings = new String[numberOfMainMenuOptions];
            mainMenuOptionsStrings[singlePlayerSetup - 1] = "Singleplayer Setup";
            mainMenuOptionsStrings[multiplayerSetup - 1] = "Multiplayer Setup";
            mainMenuOptionsStrings[settings - 1] = "Settings";
            mainMenuOptionsStrings[3] = "End Game";
            singlePlayerSetupMenuOptionsStrings = new String[numberOfSinglePlayerSetupMenuOptions];
            singlePlayerSetupMenuOptionsStrings[0] = "Beginner Mode";
            singlePlayerSetupMenuOptionsStrings[1] = "Random Mode";
            singlePlayerSetupMenuOptionsStrings[2] = "Edit General Maids";
            singlePlayerSetupMenuOptionsStrings[3] = "Number of AI Players: ";
            singlePlayerSetupMenuOptionsStrings[4] = "Start Single Player";
            singlePlayerSetupMenuOptionsStrings[5] = "Return";
            cardPicturesFull = new Texture2D[33];
            cardPicturesMini = new Texture2D[33];
            PlayArea playArea = new PlayArea();
            base.Initialize();
            //List<Card> generalMaids = new List<Card>();
            //for (int index = 0; index < 15; index++)
            //{
            //    generalMaids.Add(new Card(index + 3));
            //}
            //CardPile generalMaidsPile = new CardPile(generalMaids);
            //generalMaids = new List<Card>();
            //for (int index = 0; index < 10; index++)
            //{
            //    generalMaids.Add(generalMaidsPile.getTopCard());
            //}
            //PlayArea playArea2 = new PlayArea(generalMaids);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = this.Content.Load<SpriteFont>("menuFont");
            for (int index = 0; index < 33; index++)
            {
                cardPicturesFull[index] = this.Content.Load<Texture2D>((index + 1) + "");
                cardPicturesMini[index] = this.Content.Load<Texture2D>((index + 1) + "-mini");
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            input();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch(screenNumber){
                case mainMenu:
                    drawMainMenu(gameTime);
                    break;
                case singlePlayerSetup:
                    drawSinglePlayerSetupMenuOptionsStrings(gameTime);
                    break;
                case multiplayerSetup:
                    break;
                case gameplayScreen:
                    break;
                case settings:
                    break;
                case resultsScreen:
                    break;
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void drawSinglePlayerSetupMenuOptionsStrings(GameTime gameTime)
        {
            spriteBatch.Begin();
            //spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
            //spriteBatch.Draw(mainMenu, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - mainMenu.Width / 2, 100), Color.White);
            spriteBatch.DrawString(font, "Single Player Setup Menu", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Single Player Setup Menu").X / 2, 125), Color.White);

            //For each menu selection, if the current menu selection is selected draw it red, else draw it white.
            for (int i = 0; i < numberOfSinglePlayerSetupMenuOptions; i++)
            {
                if (currentSinglePlayerSetupMenuOption == i)
                {
                    if (i == 0 && beginnerMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.Red);
                    }
                    else if (i == 0 && !beginnerMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.Red);
                    }
                    else if (i == 1 && randomMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.Red);
                    }
                    else if (i == 1 && !randomMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.Red);
                    }
                    else if (i == 3)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers).X / 2, 150 + i * 25), Color.Red);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i]).X / 2, 150 + i * 25), Color.Red);
                    }
                }
                else
                {
                    if (i == 0 && beginnerMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.White);
                    }
                    else if (i == 0 && !beginnerMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.White);
                    }
                    else if (i == 1 && randomMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.White);
                    }
                    else if (i == 1 && !randomMode)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.White);
                    }
                    else if (i == 3)
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers).X / 2, 150 + i * 25), Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i]).X / 2, 150 + i * 25), Color.White);
                    }
                }
            }

            spriteBatch.End();
        }

        private void drawMainMenu(GameTime gameTime)
        {
            spriteBatch.Begin();
            //spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
            //spriteBatch.Draw(mainMenu, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - mainMenu.Width / 2, 100), Color.White);
            spriteBatch.DrawString(font, "Main Menu", new Vector2((graphics.GraphicsDevice.Viewport.Width / 2 + 60 + graphics.GraphicsDevice.Viewport.Width / 4) - font.MeasureString("Main Menu").X / 2, 125), Color.White);

            //For each menu selection, if the current menu selection is selected draw it red, else draw it white.
            for (int i = 0; i < numberOfMainMenuOptions; i++)
            {
                if (currentMainMenuOption == i)
                {
                    spriteBatch.DrawString(font, mainMenuOptionsStrings[i], new Vector2((graphics.GraphicsDevice.Viewport.Width / 2 + 60 + graphics.GraphicsDevice.Viewport.Width / 4) - font.MeasureString(mainMenuOptionsStrings[i]).X / 2, 150 + i * 25), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(font, mainMenuOptionsStrings[i], new Vector2((graphics.GraphicsDevice.Viewport.Width / 2 + 60 + graphics.GraphicsDevice.Viewport.Width / 4) - font.MeasureString(mainMenuOptionsStrings[i]).X / 2, 150 + i * 25), Color.White);
                }
            }

            spriteBatch.End();
        }

        private void handleMainMenuInput(KeyboardState keyboard, GamePadState gamepad)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                    (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                    (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                    (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                currentMainMenuOption--;
                if (currentMainMenuOption < 0)
                {
                    currentMainMenuOption = numberOfMainMenuOptions - 1;
                }
            }

            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {
                currentMainMenuOption++;
                if (currentMainMenuOption >= numberOfMainMenuOptions)
                {
                    currentMainMenuOption = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                screenNumber = currentMainMenuOption + 1;
                if (screenNumber == 4)
                {
                    this.Exit();
                }
            }
        }

        void input()
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();
            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);

            if (screenNumber == mainMenu)
            {
                handleMainMenuInput(keyboard, gamepad);
            }
            else if(screenNumber == singlePlayerSetup)
            {
                handleSinglePlayerSetupMenuInput(keyboard, gamepad);
            }
            else
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                    (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                    (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                    (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {

                }

                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {

                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    screenNumber = 0;
                }
            }
            gamepadOld = gamepad;
            mouseOld = mouse;
            keyboardOld = keyboard;
        }

        private void handleSinglePlayerSetupMenuInput(KeyboardState keyboard, GamePadState gamepad)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                    (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                    (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                    (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                currentSinglePlayerSetupMenuOption--;
                if (currentSinglePlayerSetupMenuOption < 0)
                {
                    currentSinglePlayerSetupMenuOption = numberOfSinglePlayerSetupMenuOptions - 1;
                }
            }

            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {
                currentSinglePlayerSetupMenuOption++;
                if (currentSinglePlayerSetupMenuOption >= numberOfSinglePlayerSetupMenuOptions)
                {
                    currentSinglePlayerSetupMenuOption = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if (currentSinglePlayerSetupMenuOption == 0)
                {
                    beginnerMode = !beginnerMode;
                    randomMode = false;
                }
                else if (currentSinglePlayerSetupMenuOption == 1)
                {
                    beginnerMode = false;
                    randomMode = !randomMode;
                }
                else if (currentSinglePlayerSetupMenuOption == 2)
                {
                    //to do
                }
                else if (currentSinglePlayerSetupMenuOption == 3)
                {
                    numberOfAIPlayers++;
                    if (numberOfAIPlayers > 4){
                        numberOfAIPlayers = 1;
                    }
                }
                else if (currentSinglePlayerSetupMenuOption == 4)
                {
                    screenNumber = 4;
                }

                else if (currentSinglePlayerSetupMenuOption == 5)
                {
                    screenNumber = 0;
                }
            }
        }
    }
}
