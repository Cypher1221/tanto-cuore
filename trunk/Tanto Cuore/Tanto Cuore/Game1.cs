using System;
using System.Collections.Generic;
using System.Linq;
#if WINDOWS
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;
#endif
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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        static public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int screenNumber = 0; //0 main screen, 1 single player setup, 2 multiplayer setup, 3 settings, 4 gamplay screen, 5 results screen
        int lastScreen = 0; //last screen that was loaded.
        int currentMainMenuOption =0 ; //0 single player setup, 1 multiplayer setup, 2 settings, 3 exit game.
        const int mainMenu = 0;
        const int singlePlayerSetup = 1;
        const int multiPlayerSetup = 2;
        const int settings = 3;
        const int gameplayScreen = 4;
        const int resultsScreen = 5;
        const int generalMaidSelectionScreen = 6;
        const int generalMaidReplacementScreen = 7;
        int numberOfMainMenuOptions = 4;
        static public SpriteFont font;
        String[] mainMenuOptionsStrings;
        int currentSinglePlayerSetupMenuOption = 0; //0 beginner mode, 1 random mode, 2 edit general maids, 3 number of ai, 4 start, 5 return.
        int numberOfSinglePlayerSetupMenuOptions = 6;
        String[] singlePlayerSetupMenuOptionsStrings;
        int currentMultiPlayerSetupMenuOption = 0; //0 beginner mode, 1 random mode, 2 edit general maids, 3 number of players, 4 number of ai, 5 start, 6 return.
        int numberOfMultiPlayerSetupMenuOptions = 7;
        String[] multiPlayerSetupMenuOptionsStrings;
        int currentMultiPlayerModeOption = 0;
        int numberOfMultiPlayerModeOptions = 4;
        String[] multiPlayerModeMenuOptions;
#if WINDOWS
        int currentMultiPlayerSetupMenuOptionServer = 0; //0 beginner mode, 1 random mode, 2 edit general maids, 3 number of players, 4 number of ai, 5 start, 6 return.
        int numberOfMultiPlayerSetupOptionsServer = 7; 
        String[] multiPlayerSetupMenuOptionsServer;
        int currentMultiPlayerSetupMenuOptionClient = 0; //0 beginner mode, 1 random mode, 2 edit general maids, 3 number of players, 4 number of ai, 5 send ready signal, 6 return.
        int numberOfMultiPlayerSetupOptionsClient = 7; 
        String[] multiPlayerSetupMenuOptionsClient;
#endif
        bool beginnerMode = true;
        bool randomMode = false;
        PlayArea playArea;
        int numberOfAIPlayers = 1;
        int numberOfPlayers = 2;
        List<Card> generalMaids;
        List<Card> allGeneralMaids;
        String[] generalMaidNames;
        int selectedMaid = 0;
        int replacementMaid = 0;
#if WINDOWS
        internal static IPHostEntry ipHostInfo;
        internal static IPAddress ipAddress;
        internal static IPEndPoint localEndPoint;
        internal static IPEndPoint remoteEP;
        GamerServicesComponent GSC;
        IAsyncResult KeyboardResult;
        internal static Socket sender;
        internal static Socket listener;
        internal static Socket handler;
        internal static string data = null;
        internal static byte[] dataBuffer;
        bool ready = false;
        bool done = false;
        List<Song> songs;
        Random rand;
        bool gameStart = false;
        int soundOptionSelection = 0;
        const int soundOptionSelectionNumber = 4;
#endif
        double SettingsStartTime = 0;
        static public Texture2D[] cardPicturesFull;
        static public Texture2D[] cardPicturesMini;
        static public Texture2D cardBack;
        static public SoundEffect cardNoise;

        public int stage { get; set; }

        KeyboardState keyboardOld;
        MouseState mouseOld;
        GamePadState gamepadOld;

        public Game1()
        {
            GSC = new GamerServicesComponent(this);

            Components.Add(GSC); 
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1000;
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
#if WINDOWS
            MediaPlayer.Volume = .1f;
            string[] filePaths = Directory.GetFiles(@"Content\Music\", "*.mp3");
            songs = new List<Song>();
            foreach (string filepath in filePaths)
            {
                var ctor = typeof(Song).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance, null,
                    new[] { typeof(string), typeof(string), typeof(int) }, null);
                Song song = (Song)ctor.Invoke(new object[] { filepath, @filepath, 0 });
                songs.Add(song);
            }
            rand = new Random();
#endif
            gamepadOld = new GamePadState();
            mouseOld = new MouseState();
            keyboardOld = new KeyboardState();
            mainMenuOptionsStrings = new String[numberOfMainMenuOptions];
            mainMenuOptionsStrings[singlePlayerSetup - 1] = "Singleplayer Setup";
            mainMenuOptionsStrings[multiPlayerSetup - 1] = "Multiplayer Setup";
            mainMenuOptionsStrings[settings - 1] = "Settings";
            mainMenuOptionsStrings[3] = "End Game";
            singlePlayerSetupMenuOptionsStrings = new String[numberOfSinglePlayerSetupMenuOptions];
            singlePlayerSetupMenuOptionsStrings[0] = "Beginner Mode";
            singlePlayerSetupMenuOptionsStrings[1] = "Random Mode";
            singlePlayerSetupMenuOptionsStrings[2] = "Edit General Maids";
            singlePlayerSetupMenuOptionsStrings[3] = "Number of AI Players: ";
            singlePlayerSetupMenuOptionsStrings[4] = "Start Single Player";
            singlePlayerSetupMenuOptionsStrings[5] = "Return";
            multiPlayerSetupMenuOptionsStrings = new String[numberOfMultiPlayerSetupMenuOptions];
            multiPlayerSetupMenuOptionsStrings[0] = "Beginner Mode";
            multiPlayerSetupMenuOptionsStrings[1] = "Random Mode";
            multiPlayerSetupMenuOptionsStrings[2] = "Edit General Maids";
            multiPlayerSetupMenuOptionsStrings[3] = "Number of Players: ";
            multiPlayerSetupMenuOptionsStrings[4] = "Number of AI Players: ";
            multiPlayerSetupMenuOptionsStrings[5] = "Start Multi Player";
            multiPlayerSetupMenuOptionsStrings[6] = "Return";
#if WINDOWS
            multiPlayerSetupMenuOptionsServer = new String[numberOfMultiPlayerSetupOptionsServer];
            multiPlayerSetupMenuOptionsServer[0] = "Beginner Mode";
            multiPlayerSetupMenuOptionsServer[1] = "Random Mode";
            multiPlayerSetupMenuOptionsServer[2] = "Edit General Maids";
            multiPlayerSetupMenuOptionsServer[3] = "Number of Players: ";
            multiPlayerSetupMenuOptionsServer[4] = "Number of AI Players: ";
            multiPlayerSetupMenuOptionsServer[5] = "Start Multi Player";
            multiPlayerSetupMenuOptionsServer[6] = "Return";
            multiPlayerSetupMenuOptionsClient = new String[numberOfMultiPlayerSetupOptionsClient];
            multiPlayerSetupMenuOptionsClient[0] = "Beginner Mode";
            multiPlayerSetupMenuOptionsClient[1] = "Random Mode";
            multiPlayerSetupMenuOptionsClient[2] = "Edit General Maids";
            multiPlayerSetupMenuOptionsClient[3] = "Number of Players: ";
            multiPlayerSetupMenuOptionsClient[4] = "Number of AI Players: ";
            multiPlayerSetupMenuOptionsClient[5] = "Send Ready Signal";
            multiPlayerSetupMenuOptionsClient[6] = "Leave Game";
            multiPlayerModeMenuOptions = new String[numberOfMultiPlayerModeOptions];
#else
            multiPlayerModeMenuOptions = new String[2];
#endif
            multiPlayerModeMenuOptions[0] = "Local Game";
#if WINDOWS
            multiPlayerModeMenuOptions[1] = "Host Game";
            multiPlayerModeMenuOptions[2] = "Join Game";
            multiPlayerModeMenuOptions[3] = "Return";
#else
            
            multiPlayerModeMenuOptions[1] = "Return";
#endif
            cardPicturesFull = new Texture2D[33];
            cardPicturesMini = new Texture2D[33];
            generalMaids = new List<Card>();
            generalMaids.Add(new Card(16));
            generalMaids.Add(new Card(17));
            generalMaids.Add(new Card(18));
            generalMaids.Add(new Card(15));
            generalMaids.Add(new Card(13));
            generalMaids.Add(new Card(10));
            generalMaids.Add(new Card(11));
            generalMaids.Add(new Card(6));
            generalMaids.Add(new Card(5));
            generalMaids.Add(new Card(3));
            generalMaidNames = new String[16];
            generalMaidNames[0] = "Anise Greenway";
            generalMaidNames[1] = "Ophelia Grail";
            generalMaidNames[2] = "Sainsbury Lockwood";
            generalMaidNames[3] = "Tenalys Trent";
            generalMaidNames[4] = "Natsumi Fujikawa";
            generalMaidNames[5] = "Nena Wilder";
            generalMaidNames[6] = "Esquine Foret";
            generalMaidNames[7] = "Genevieve Daubigny";
            generalMaidNames[8] = "Moine de Lefevre";
            generalMaidNames[9] = "Eliza Rosewater";
            generalMaidNames[10] = "Kagari Ichinomiya";
            generalMaidNames[11] = "Claire Saint-Juste";
            generalMaidNames[12] = "Safran Virginie";
            generalMaidNames[13] = "Azure Crescent";
            generalMaidNames[14] = "Viola Crescent";
            generalMaidNames[15] = "Rouge Crescent";
            allGeneralMaids = new List<Card>();
            for (int index = 0; index < 16; index++)
            {
                allGeneralMaids.Add(new Card(index + 3));
            }
            base.Initialize();
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
            cardBack = this.Content.Load<Texture2D>("cardBack");
            cardNoise = this.Content.Load<SoundEffect>("240777__f4ngy__dealing-card");
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
            input(gameTime);
            if (screenNumber == gameplayScreen && playArea.gameOver)
            {
                screenNumber = resultsScreen;
            }
#if WINDOWS
            if (songs.Count != 0 && MediaPlayer.State == MediaState.Stopped)
            {
                int songNum = rand.Next(songs.Count);
                MediaPlayer.Play(songs.ElementAt(songNum));
            }
#endif
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
                case multiPlayerSetup:
                    drawMultiPlayerSetupMenuOptions(gameTime);
                    break;
                case gameplayScreen:
                    playArea.drawPlayArea(gameTime, spriteBatch);
                    break;
                case settings:
                    drawSettingsScreen(gameTime, spriteBatch);
                    break;
                case resultsScreen:
                    drawResultsScreen(gameTime);
                    break;
                case generalMaidSelectionScreen:
                    drawGeneralMaidSelectionScreen(gameTime);
                    break;
                case generalMaidReplacementScreen:
                    drawGeneralMaidReplacementScreen(gameTime);
                    break;
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void drawSettingsScreen(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Settings Menu", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Settings Menu").X / 2, 125), Color.White);
            if (soundOptionSelection == 0)
            {
                spriteBatch.DrawString(font, "Music is Muted: " + MediaPlayer.IsMuted, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Music is Muted: " + MediaPlayer.IsMuted).X / 2, 145), Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Music is Muted: " + MediaPlayer.IsMuted, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Music is Muted: " + MediaPlayer.IsMuted).X / 2, 145), Color.White);
            }
            if (soundOptionSelection == 1)
            {
                spriteBatch.DrawString(font, "Music Volume: " + (int)(MediaPlayer.Volume * 100), new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Music Volume: " + (int)(MediaPlayer.Volume * 100)).X / 2, 165), Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Music Volume: " + (int)(MediaPlayer.Volume * 100), new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Music Volume: " + (int)(MediaPlayer.Volume * 100)).X / 2, 165), Color.White);
            }
            if (soundOptionSelection == 2)
            {
                spriteBatch.DrawString(font, "Sound FXs Volume: " + (int)(SoundEffect.MasterVolume * 100), new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Sound FXs Volume: " + (int)(SoundEffect.MasterVolume * 100)).X / 2, 185), Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Sound FXs Volume: " + (int)(SoundEffect.MasterVolume * 100), new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Sound FXs Volume: " + (int)(SoundEffect.MasterVolume * 100)).X / 2, 185), Color.White);
            }
            if (soundOptionSelection == 3)
            {
                spriteBatch.DrawString(font, "Return", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Return").X / 2, 205), Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Return", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Return").X / 2, 205), Color.White);
            }
            spriteBatch.End();
        }

        private void drawGeneralMaidReplacementScreen(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int index = 0; index < 10; index++)
            {
                if (index == replacementMaid)
                {
                    spriteBatch.DrawString(font, generalMaidNames[generalMaids.ElementAt(index).getCardNumber() - 3] + " Number: " + generalMaids.ElementAt(index).getCardNumber(), new Vector2(0, 0 + index * 25), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(font, generalMaidNames[generalMaids.ElementAt(index).getCardNumber() - 3] + " Number: " + generalMaids.ElementAt(index).getCardNumber(), new Vector2(0, 0 + index * 25), Color.White);
                }
            }
            spriteBatch.Draw(cardPicturesFull[generalMaids.ElementAt(replacementMaid).getCardNumber() - 1], new Vector2(graphics.GraphicsDevice.Viewport.Width - cardPicturesFull[allGeneralMaids.ElementAt(selectedMaid).getCardNumber() - 1].Bounds.Width, 0), Color.White);
            spriteBatch.End();
        }

        private void drawGeneralMaidSelectionScreen(GameTime gameTime)
        {
            bool genearalMaidsContains = false;
            spriteBatch.Begin();
            for (int index = 0; index < 16; index++)
            {
                genearalMaidsContains = false;
                for (int index2 = 0; index2 < 10; index2++)
                {
                    if (generalMaids.ElementAt(index2).getCardNumber() == allGeneralMaids.ElementAt(index).getCardNumber())
                    {
                        if (index == selectedMaid)
                        {
                            spriteBatch.DrawString(font, generalMaidNames[index] + " Number: " + allGeneralMaids.ElementAt(index).getCardNumber() + " <", new Vector2(0, 0 + index * 25), Color.Red);
                            genearalMaidsContains = true;
                            break;
                        }
                        spriteBatch.DrawString(font, generalMaidNames[index] + " Number: " + allGeneralMaids.ElementAt(index).getCardNumber(), new Vector2(0, 0 + index * 25), Color.Red);
                        genearalMaidsContains = true;
                        break;
                    }
                }
                if (!genearalMaidsContains)
                {
                    if (index == selectedMaid)
                    {
                        spriteBatch.DrawString(font, generalMaidNames[index] + " Number: " + allGeneralMaids.ElementAt(index).getCardNumber() + " <", new Vector2(0, 0 + index * 25), Color.White);
                    }
                    spriteBatch.DrawString(font, generalMaidNames[index] + " Number: " + allGeneralMaids.ElementAt(index).getCardNumber(), new Vector2(0, 0 + index * 25), Color.White);
                }
                
            }
            if (selectedMaid != allGeneralMaids.Count)
            {
                spriteBatch.Draw(cardPicturesFull[allGeneralMaids.ElementAt(selectedMaid).getCardNumber() - 1], new Vector2(graphics.GraphicsDevice.Viewport.Width - cardPicturesFull[allGeneralMaids.ElementAt(selectedMaid).getCardNumber() - 1].Bounds.Width, 0), Color.White);
            }
            if (selectedMaid == allGeneralMaids.Count)
            {
                spriteBatch.DrawString(font, "Return <", new Vector2(0, (allGeneralMaids.Count + 1) * 25), Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, "Return", new Vector2(0, (allGeneralMaids.Count + 1) * 25), Color.White);
            }
            spriteBatch.End();
        }

        private void drawMultiPlayerSetupMenuOptions(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (stage == 0)
            {
                spriteBatch.DrawString(font, "Multi Player Setup Menu", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Multi Player Setup Menu").X / 2, 125), Color.White);
                for (int i = 0; i < numberOfMultiPlayerModeOptions; i++)
                {
                    if (currentMultiPlayerModeOption == i)
                    {
                        spriteBatch.DrawString(font, multiPlayerModeMenuOptions[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerModeMenuOptions[i]).X / 2, 150 + i * 25), Color.Red);
                    }
                    else
                    {
                        spriteBatch.DrawString(font, multiPlayerModeMenuOptions[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerModeMenuOptions[i]).X / 2, 150 + i * 25), Color.White);
                    }
                }
            }
            else if (stage == 1)
            {
                //spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
                //spriteBatch.Draw(mainMenu, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - mainMenu.Width / 2, 100), Color.White);
                spriteBatch.DrawString(font, "Multi Player Setup Menu", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Multi Player Setup Menu").X / 2, 125), Color.White);

                //For each menu selection, if the current menu selection is selected draw it red, else draw it white.
                for (int i = 0; i < numberOfMultiPlayerSetupMenuOptions; i++)
                {
                    if (currentMultiPlayerSetupMenuOption == i)
                    {
                        if (i == 0 && beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.Red);
                        }
                        else if (i == 0 && !beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.Red);
                        }
                        else if (i == 1 && randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.Red);
                        }
                        else if (i == 1 && !randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.Red);
                        }
                        else if (i == 3)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + numberOfPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + numberOfPlayers).X / 2, 150 + i * 25), Color.Red);
                        }
                        else if (i == 4)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers).X / 2, 150 + i * 25), Color.Red);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i]).X / 2, 150 + i * 25), Color.Red);
                        }
                    }
                    else
                    {
                        if (i == 0 && beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.White);
                        }
                        else if (i == 0 && !beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.White);
                        }
                        else if (i == 1 && randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " On").X / 2, 150 + i * 25), Color.White);
                        }
                        else if (i == 1 && !randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + " Off").X / 2, 150 + i * 25), Color.White);
                        }
                        else if (i == 3)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + numberOfPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + numberOfPlayers).X / 2, 150 + i * 25), Color.White);
                        }
                        else if (i == 4)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers).X / 2, 150 + i * 25), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsStrings[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsStrings[i]).X / 2, 150 + i * 25), Color.White);
                        }
                    }
                }
            }
#if WINDOWS
            else if (stage == 2)
            {
                //spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
                //spriteBatch.Draw(mainMenu, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - mainMenu.Width / 2, 100), Color.White);
                spriteBatch.DrawString(font, "Multi Player Setup Menu", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Multi Player Setup Menu").X / 2, 125), Color.White);
                spriteBatch.DrawString(font, "IP Address: " + ipAddress, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("IP Adress: " + ipAddress).X / 2, 150), Color.White);

                //For each menu selection, if the current menu selection is selected draw it red, else draw it white.
                for (int i = 0; i < numberOfMultiPlayerSetupMenuOptions; i++)
                {
                    if (currentMultiPlayerSetupMenuOptionServer == i)
                    {
                        if (i == 0 && beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " On").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 0 && !beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " Off").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 1 && randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " On").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 1 && !randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " Off").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 3)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + numberOfPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + numberOfPlayers).X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 4)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + numberOfAIPlayers).X / 2, 175 + i * 25), Color.Red);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i]).X / 2, 175 + i * 25), Color.Red);
                        }
                    }
                    else
                    {
                        if (i == 0 && beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " On").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 0 && !beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " Off").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 1 && randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " On").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 1 && !randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + " Off").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 3)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + numberOfPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + numberOfPlayers).X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 4)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i] + numberOfAIPlayers).X / 2, 175 + i * 25), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsServer[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsServer[i]).X / 2, 175 + i * 25), Color.White);
                        }
                    }
                }
            }

            else if (stage == 4)
            {
                //spriteBatch.Draw(mainMenu, Vector2.Zero, Color.White);
                //spriteBatch.Draw(mainMenu, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - mainMenu.Width / 2, 100), Color.White);
                spriteBatch.DrawString(font, "Multi Player Setup Menu", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Multi Player Setup Menu").X / 2, 125), Color.White);
                spriteBatch.DrawString(font, "IP Address: " + ipAddress, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("IP Adress: " + ipAddress).X / 2, 150), Color.White);

                //For each menu selection, if the current menu selection is selected draw it red, else draw it white.
                for (int i = 0; i < numberOfMultiPlayerSetupMenuOptions; i++)
                {
                    if (currentMultiPlayerSetupMenuOptionClient == i)
                    {
                        if (i == 0 && beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " On").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 0 && !beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " Off").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 1 && randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " On").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 1 && !randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " Off").X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 3)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + numberOfPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + numberOfPlayers).X / 2, 175 + i * 25), Color.Red);
                        }
                        else if (i == 4)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + numberOfAIPlayers).X / 2, 175 + i * 25), Color.Red);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i]).X / 2, 175 + i * 25), Color.Red);
                        }
                    }
                    else
                    {
                        if (i == 0 && beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " On").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 0 && !beginnerMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " Off").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 1 && randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " On", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " On").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 1 && !randomMode)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + " Off", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + " Off").X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 3)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + numberOfPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + numberOfPlayers).X / 2, 175 + i * 25), Color.White);
                        }
                        else if (i == 4)
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i] + numberOfAIPlayers, new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i] + numberOfAIPlayers).X / 2, 175 + i * 25), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, multiPlayerSetupMenuOptionsClient[i], new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(multiPlayerSetupMenuOptionsClient[i]).X / 2, 175 + i * 25), Color.White);
                        }
                    }
                }
            }
#endif
            spriteBatch.End();
        }

        private void drawResultsScreen(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Results Screen", new Vector2(), Color.White);
            for (int index = 0; index < playArea.numberOfPlayers; index++)
            {
                spriteBatch.DrawString(font, "Player " + index + " Score: " + playArea.VP[index].VP, new Vector2(0, 10 + index * font.MeasureString("Player " + index + " Score: " + playArea.VP[index].VP).Y + font.MeasureString("Results Screen").Y), Color.White);
            }
            if (!playArea.gameIsTied)
            {
                spriteBatch.DrawString(font, "Player " + playArea.winner + " wins", new Vector2(0, font.MeasureString("Player " + playArea.winner + " wins").Y * (playArea.numberOfPlayers + 1) + 10), Color.White);
            }
            spriteBatch.End();
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
                        if (numberOfAIPlayers == 4)
                        {
                            spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers + " AI only game", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers).X / 2, 150 + i * 25), Color.Red);
                        }
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
                        if (numberOfAIPlayers == 4)
                        {
                            spriteBatch.DrawString(font, singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers + " AI only game", new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 - font.MeasureString(singlePlayerSetupMenuOptionsStrings[i] + numberOfAIPlayers).X / 2, 150 + i * 25), Color.White);
                        }
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
                    screenNumber = -1;
                    this.Exit();
                    MediaPlayer.Stop();
                }
                if (screenNumber == 2)
                {
                    stage = 0;
                }
                if (screenNumber == settings)
                {
                    lastScreen = mainMenu;
                }
            }
        }

        void input(GameTime gameTime)
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
            else if (screenNumber == multiPlayerSetup)
            {
                handleMultiPlayerSetupMenuInput(keyboard, gamepad);
            }
            else if (screenNumber == gameplayScreen)
            {
                playArea.handleGamePlayScreenInput(keyboard, gamepad, keyboardOld, gamepadOld, gameTime);
            }
            else if (screenNumber == generalMaidSelectionScreen)
            {
                handleGeneralMaidSelection(keyboard, gamepad);
            }
            else if (screenNumber == generalMaidReplacementScreen)
            {
                handleGeneralMaidReplacement(keyboard, gamepad);
            }
            else if (screenNumber == settings)
            {
                handleSettingsMenu(keyboard, gamepad, gameTime);
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

            if (keyboard.IsKeyDown(Keys.P) && !keyboardOld.IsKeyDown(Keys.P) ||
                        gamepad.IsButtonDown(Buttons.Start) && !gamepadOld.IsButtonDown(Buttons.Start))
            {
                if (screenNumber != generalMaidReplacementScreen)
                {
                    lastScreen = screenNumber;
                    screenNumber = settings;
                    SettingsStartTime = gameTime.TotalGameTime.TotalSeconds;
                }
            }
            gamepadOld = gamepad;
            mouseOld = mouse;
            keyboardOld = keyboard;
        }

        private void handleSettingsMenu(KeyboardState keyboard, GamePadState gamepad, GameTime gameTime)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                    (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                    (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                    (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                soundOptionSelection--;
                if (soundOptionSelection < 0)
                {
                    soundOptionSelection = soundOptionSelectionNumber - 1;
                }
            }
            if ((keyboard.IsKeyDown(Keys.Left) && !keyboardOld.IsKeyDown(Keys.Left)) ||
                (ButtonState.Pressed == gamepad.DPad.Left && !(ButtonState.Pressed == gamepadOld.DPad.Left)) ||
                (keyboard.IsKeyDown(Keys.A) && !keyboardOld.IsKeyDown(Keys.A)) ||
                (gamepad.ThumbSticks.Left.X < 0 && !(gamepadOld.ThumbSticks.Left.X < 0)))
            {
                if (soundOptionSelection == 1)
                {
                    MediaPlayer.Volume -= 0.10000000000000f;
                    if (MediaPlayer.Volume < 0)
                    {
                        MediaPlayer.Volume = 0;
                    }
                }
                if (soundOptionSelection == 2)
                {
                    SoundEffect.MasterVolume -= 0.1f;
                    if (SoundEffect.MasterVolume < 0)
                    {
                        SoundEffect.MasterVolume = 0;
                    }
                }
            }

            if ((keyboard.IsKeyDown(Keys.Right) && !keyboardOld.IsKeyDown(Keys.Right)) ||
                    (ButtonState.Pressed == gamepad.DPad.Right && !(ButtonState.Pressed == gamepadOld.DPad.Right)) ||
                    (keyboard.IsKeyDown(Keys.D) && !keyboardOld.IsKeyDown(Keys.D)) ||
                    (gamepad.ThumbSticks.Left.X > 0 && !(gamepadOld.ThumbSticks.Left.X > 0)))
            {
                if (soundOptionSelection == 1)
                {
                    MediaPlayer.Volume += 0.10000000000000f;
                    if (MediaPlayer.Volume > 1)
                    {
                        MediaPlayer.Volume = 1;
                    }
                }
                if (soundOptionSelection == 2)
                {
                    SoundEffect.MasterVolume += 0.1f;
                    if (SoundEffect.MasterVolume > 1)
                    {
                        SoundEffect.MasterVolume = 1;
                    }
                }
            }
            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {

                soundOptionSelection++;
                if (soundOptionSelection >= soundOptionSelectionNumber)
                {
                    soundOptionSelection = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if (soundOptionSelection == 0)
                {
                    if (MediaPlayer.IsMuted)
                    {
                        MediaPlayer.IsMuted = false;
                    }
                    else
                    {
                        MediaPlayer.IsMuted = true;
                    }
                }

                if (soundOptionSelection == 3)
                {
                    screenNumber = lastScreen;
                }
            }
            if (gameTime.TotalGameTime.TotalSeconds - SettingsStartTime > 60)
            {
                screenNumber = lastScreen;
            }
        }

        private void handleGeneralMaidReplacement(KeyboardState keyboard, GamePadState gamepad)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                replacementMaid--;
                if (replacementMaid < 0)
                {
                    replacementMaid = generalMaids.Count-1;
                }
            }

            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {
                replacementMaid++;
                if (replacementMaid >= generalMaids.Count)
                {
                    replacementMaid = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                generalMaids.RemoveAt(replacementMaid);
                generalMaids.Add(allGeneralMaids.ElementAt(selectedMaid));
                screenNumber = generalMaidSelectionScreen;
            }
        }

        private void handleGeneralMaidSelection(KeyboardState keyboard, GamePadState gamepad)
        {
            if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
            {
                selectedMaid--;
                if (selectedMaid < 0)
                {
                    selectedMaid = allGeneralMaids.Count;
                }
            }

            if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
            {
                selectedMaid++;
                if (selectedMaid >= allGeneralMaids.Count + 1)
                {
                    selectedMaid = 0;
                }
            }

            if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
            {
                if (selectedMaid == allGeneralMaids.Count)
                {
                    screenNumber = lastScreen;
                }
                else
                {
                    for (int index = 0; index < generalMaids.Count; index++)
                    {
                        if (generalMaids.ElementAt(index).getCardNumber() == allGeneralMaids.ElementAt(selectedMaid).getCardNumber())
                        {
                            return;
                        }
                    }
                    screenNumber = generalMaidReplacementScreen;
                }
            }
        }

        private void handleMultiPlayerSetupMenuInput(KeyboardState keyboard, GamePadState gamepad)
        {
            if (stage == 0)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentMultiPlayerModeOption--;
                    if (currentMultiPlayerModeOption < 0)
                    {
                        currentMultiPlayerModeOption = numberOfMultiPlayerModeOptions - 1;
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentMultiPlayerModeOption++;
                    if (currentMultiPlayerModeOption >= numberOfMultiPlayerModeOptions)
                    {
                        currentMultiPlayerModeOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentMultiPlayerModeOption == 0)
                    {
                        stage = 1;
                        numberOfAIPlayers = 0;
                    }
#if WINDOWS
                    else if (currentMultiPlayerModeOption == 1)
                    {
                        stage = 2;
                        numberOfAIPlayers = 0;
                        // Establish the local endpoint for the socket.
                        // Dns.GetHostName returns the name of the 
                        // host running the application.
                        ipHostInfo = Dns.Resolve(Dns.GetHostName());
                        ipAddress = ipHostInfo.AddressList[0];
                        localEndPoint = new IPEndPoint(ipAddress, 11000);
                        listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        listener.Bind(localEndPoint);
                    }
                    else if (currentMultiPlayerModeOption == 2)
                    {
                        stage = 3;
                        // Establish the remote endpoint for the socket.
                        // This example uses port 11000 on the local computer.
                        ipHostInfo = Dns.Resolve(Dns.GetHostName());
                        //ipAddress = ipHostInfo.AddressList[0];
                        //remoteEP = new IPEndPoint(ipAddress,11000);
                    }
                    else if (currentMultiPlayerModeOption == 3)
                    {
                        screenNumber = 0;
                    }
#else
                    else if (currentMultiPlayerModeOption == 1)
                    {
                        screenNumber = 0;
                    }
#endif
                }
            }
            else if (stage == 1)
            {
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentMultiPlayerSetupMenuOption--;
                    if (currentMultiPlayerSetupMenuOption < 0)
                    {
                        currentMultiPlayerSetupMenuOption = numberOfMultiPlayerSetupMenuOptions - 1;
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentMultiPlayerSetupMenuOption++;
                    if (currentMultiPlayerSetupMenuOption >= numberOfMultiPlayerSetupMenuOptions)
                    {
                        currentMultiPlayerSetupMenuOption = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentMultiPlayerSetupMenuOption == 0)
                    {
                        beginnerMode = !beginnerMode;
                        randomMode = false;
                    }
                    else if (currentMultiPlayerSetupMenuOption == 1)
                    {
                        beginnerMode = false;
                        randomMode = !randomMode;
                        CardPile generalMaidsPile = new CardPile(allGeneralMaids);
                        generalMaids = new List<Card>();
                        for (int index = 0; index < 10; index++)
                        {
                            generalMaids.Add(generalMaidsPile.getTopCard());
                        }
                    }
                    else if (currentMultiPlayerSetupMenuOption == 2)
                    {
                        beginnerMode = false;
                        randomMode = false;
                        screenNumber = generalMaidSelectionScreen;
                        lastScreen = 2;
                    }
                    else if (currentMultiPlayerSetupMenuOption == 3)
                    {
                        numberOfPlayers++;
                        if (numberOfPlayers > 4)
                        {
                            numberOfPlayers = 2;
                        }
                    }
                    else if (currentMultiPlayerSetupMenuOption == 4)
                    {
                        numberOfAIPlayers++;
                        if (numberOfPlayers - numberOfAIPlayers < 2)
                        {
                            numberOfPlayers++;
                            if (numberOfPlayers > 4)
                            {
                                numberOfPlayers = 4;
                            }
                        }
                        if (numberOfAIPlayers > 2)
                        {
                            numberOfAIPlayers = 0;
                        }
                    }
                    else if (currentMultiPlayerSetupMenuOption == 5)
                    {
                        if (beginnerMode)
                        {
                            playArea = new PlayArea(numberOfPlayers, numberOfAIPlayers);
                        }
                        else
                        {
                            playArea = new PlayArea(generalMaids, numberOfPlayers, numberOfAIPlayers);
                        }
                        screenNumber = 4;
                    }

                    else if (currentMultiPlayerSetupMenuOption == 6)
                    {
                        screenNumber = 0;
                        numberOfAIPlayers = 1;
                    }
                }
            }
#if WINDOWS
            else if (stage == 2)
            {
                if (handler == null)
                {
                    try
                    {
                        listener.Listen(10);
                        handler = listener.Accept();
                    }
                    catch (Exception e)
                    {
                        stage = 0;
                    }
                }
                byte[] msg;
                string MSG = "0,";
                if (done)
                {
                    done = false;
                    screenNumber = 0;
                    numberOfAIPlayers = 1;
                    MSG = "2,";
                }
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentMultiPlayerSetupMenuOptionServer--;
                    if (currentMultiPlayerSetupMenuOptionServer < 0)
                    {
                        currentMultiPlayerSetupMenuOptionServer = numberOfMultiPlayerSetupOptionsServer - 1;
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentMultiPlayerSetupMenuOptionServer++;
                    if (currentMultiPlayerSetupMenuOptionServer >= numberOfMultiPlayerSetupOptionsServer)
                    {
                        currentMultiPlayerSetupMenuOptionServer = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentMultiPlayerSetupMenuOptionServer == 0)
                    {
                        beginnerMode = !beginnerMode;
                        randomMode = false;
                    }
                    else if (currentMultiPlayerSetupMenuOptionServer == 1)
                    {
                        beginnerMode = false;
                        randomMode = !randomMode;
                        CardPile generalMaidsPile = new CardPile(allGeneralMaids);
                        generalMaids = new List<Card>();
                        for (int index = 0; index < 10; index++)
                        {
                            generalMaids.Add(generalMaidsPile.getTopCard());
                        }
                    }
                    else if (currentMultiPlayerSetupMenuOptionServer == 2)
                    {
                        beginnerMode = false;
                        randomMode = false;
                        screenNumber = generalMaidSelectionScreen;
                        lastScreen = 2;
                    }
                    else if (currentMultiPlayerSetupMenuOptionServer == 3)
                    {
                        //numberOfPlayers++;
                        //if (numberOfPlayers > 4)
                        //{
                        //    numberOfPlayers = 2;
                        //}
                    }
                    else if (currentMultiPlayerSetupMenuOptionServer == 4)
                    {
                        numberOfAIPlayers++;
                        if (numberOfPlayers - numberOfAIPlayers < 2)
                        {
                            numberOfPlayers++;
                            if (numberOfPlayers > 4)
                            {
                                numberOfPlayers = 4;
                            }
                        }
                        if (numberOfAIPlayers > 2)
                        {
                            numberOfAIPlayers = 0;
                            numberOfPlayers = 2;
                        }
                    }
                    else if (currentMultiPlayerSetupMenuOptionServer == 5 && ready)
                    {
                        
                        MSG = "1,";
                        gameStart = true;
                    }

                    else if (currentMultiPlayerSetupMenuOptionServer == 6)
                    {
                        screenNumber = 0;
                        numberOfAIPlayers = 1;
                        MSG = "2,";
                    }
                }
                for (int index = 0; index < generalMaids.Count; index++)
                {
                    MSG += generalMaids.ElementAt(index).getCardNumber() + ",";
                }
                if (beginnerMode)
                {
                    MSG += "0,";
                }
                else if (randomMode)
                {
                    MSG += "1,";
                }
                else
                {
                    MSG += "2,";
                }
                MSG += numberOfPlayers + "," + numberOfAIPlayers + ",";
                msg = Encoding.ASCII.GetBytes(MSG);
                int bytesSent = handler.Send(msg);
                byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.ElementAt(0) == '0')
                {
                    ready = true;
                }
                else if (data.ElementAt(0) == '1')
                {
                    ready = false;
                }
                else if (data.ElementAt(0) == '2')
                {
                    done = true;
                    handler.Shutdown(SocketShutdown.Both);
                }
                data = "";
                if (gameStart)
                {
                    if (beginnerMode)
                    {
                        playArea = new PlayArea(numberOfPlayers, numberOfAIPlayers, 0);
                    }
                    else
                    {
                        playArea = new PlayArea(generalMaids, numberOfPlayers, numberOfAIPlayers, 0);
                    }
                    screenNumber = 4;
                }
            }
            else if (stage == 3)
            {
                string title = "IP Adress";
                string description = "Enter the IP Adress you want to connect to";
                string defaultText = "192.168.0.0";
                string IPAdress = "";
                if (!Guide.IsVisible)
                {
                    KeyboardResult = Guide.BeginShowKeyboardInput(new PlayerIndex(), title, description, defaultText, null, null);
                }
                if (KeyboardResult.IsCompleted)
                {
                    IPAdress = Guide.EndShowKeyboardInput(KeyboardResult);
                    ipAddress = IPAddress.Parse(IPAdress);
                    remoteEP = new IPEndPoint(ipAddress, 11000);
                    localEndPoint = new IPEndPoint(ipHostInfo.AddressList[0], 11000);
                    sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(remoteEP);
                    stage = 4;
                }
            }
            else if (stage == 4)
            {
                done = false;
                dataBuffer = new byte[1024];
                byte[] msg;
                String MSG = "";
                int bytesRec = sender.Receive(dataBuffer);
                data += Encoding.ASCII.GetString(dataBuffer, 0, bytesRec);
                string[] words = data.Split(',');
                if (words[0] == "0")
                {

                }
                if (words[0] == "1")
                {
                    if (beginnerMode)
                    {
                        playArea = new PlayArea(numberOfPlayers, numberOfAIPlayers, 1);
                    }
                    else
                    {
                        playArea = new PlayArea(generalMaids, numberOfPlayers, numberOfAIPlayers, 1);
                    }
                    screenNumber = 4;
                }
                if (words[0] == "2")
                {
                    screenNumber = 0;
                    numberOfAIPlayers = 1;
                }
                generalMaids = new List<Card>();
                for (int index = 0; index < 10; index++)
                {
                    generalMaids.Add(new Card(Convert.ToInt32(words[index + 1])));
                }
                if (words[11] == "0")
                {
                    beginnerMode = true;
                    randomMode = false;
                }
                if (words[11] == "1")
                {
                    beginnerMode = false;
                    randomMode = true;
                }
                if (words[11] == "2")
                {
                    beginnerMode = false;
                    randomMode = false;
                }
                numberOfPlayers = Convert.ToInt32(words[12]);
                numberOfAIPlayers = Convert.ToInt32(words[13]);
                if ((keyboard.IsKeyDown(Keys.Up) && !keyboardOld.IsKeyDown(Keys.Up)) ||
                        (ButtonState.Pressed == gamepad.DPad.Up && !(ButtonState.Pressed == gamepadOld.DPad.Up)) ||
                        (keyboard.IsKeyDown(Keys.W) && !keyboardOld.IsKeyDown(Keys.W)) ||
                        (gamepad.ThumbSticks.Left.Y > 0 && !(gamepadOld.ThumbSticks.Left.Y > 0)))
                {
                    currentMultiPlayerSetupMenuOptionClient--;
                    if (currentMultiPlayerSetupMenuOptionClient < 0)
                    {
                        currentMultiPlayerSetupMenuOptionClient = numberOfMultiPlayerSetupOptionsClient - 1;
                    }
                }

                if ((keyboard.IsKeyDown(Keys.Down) && !keyboardOld.IsKeyDown(Keys.Down)) ||
                    (ButtonState.Pressed == gamepad.DPad.Down && !(ButtonState.Pressed == gamepadOld.DPad.Down)) ||
                    (keyboard.IsKeyDown(Keys.S) && !keyboardOld.IsKeyDown(Keys.S)) ||
                    (gamepad.ThumbSticks.Left.Y < 0 && !(gamepadOld.ThumbSticks.Left.Y < 0)))
                {
                    currentMultiPlayerSetupMenuOptionClient++;
                    if (currentMultiPlayerSetupMenuOptionClient >= numberOfMultiPlayerSetupOptionsClient)
                    {
                        currentMultiPlayerSetupMenuOptionClient = 0;
                    }
                }

                if (keyboard.IsKeyDown(Keys.Enter) && !keyboardOld.IsKeyDown(Keys.Enter) ||
                    gamepad.IsButtonDown(Buttons.A) && !gamepadOld.IsButtonDown(Buttons.A))
                {
                    if (currentMultiPlayerSetupMenuOptionClient == 5)
                    {
                        ready = !ready;
                    }
                    if (currentMultiPlayerSetupMenuOptionClient == 6)
                    {
                        done = true;
                    }
                }
                if (done)
                {
                    MSG += "2";
                }
                else if (ready)
                {
                    MSG += "0";
                }
                else if (!ready)
                {
                    MSG += "1";
                }
                msg = Encoding.ASCII.GetBytes(MSG);
                sender.Send(msg);
                if (words[0] == "2")
                {
                    sender.Shutdown(SocketShutdown.Both);
                }
                data = "";
            }
#endif
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
                    CardPile generalMaidsPile = new CardPile(allGeneralMaids);
                    generalMaids = new List<Card>();
                    for (int index = 0; index < 10; index++)
                    {
                        generalMaids.Add(generalMaidsPile.getTopCard());
                    }
                }
                else if (currentSinglePlayerSetupMenuOption == 2)
                {
                    beginnerMode = false;
                    randomMode = false;
                    screenNumber = generalMaidSelectionScreen;
                    lastScreen = 1;
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
                    if (beginnerMode)
                    {
                        if (numberOfAIPlayers == 4)
                        {
                            playArea = new PlayArea(numberOfAIPlayers, numberOfAIPlayers);
                        }
                        else
                        {
                            playArea = new PlayArea(1 + numberOfAIPlayers, numberOfAIPlayers);
                        }
                    }
                    else
                    {
                        if (numberOfAIPlayers == 4)
                        {
                            playArea = new PlayArea(generalMaids, numberOfAIPlayers, numberOfAIPlayers);
                        }
                        else
                        {
                            playArea = new PlayArea(generalMaids, 1 + numberOfAIPlayers, numberOfAIPlayers);
                        }
                    }
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
