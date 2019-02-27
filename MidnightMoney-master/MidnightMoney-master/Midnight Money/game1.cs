using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Midnight_Money
{
    /// <summary>
    /// No this is Patrick
    /// </summary>

    // enums for the different States that this game can be in 
    enum GameState
    {
        MainMenu,
        Game,
        Pause,
        Controls,
        GameOver
    }

    // Enums for direction of walking/facing for player
    enum PlayerState
    {
        FaceLeft,
        WalkLeft,
        FaceRight,
        WalkRight,
        FaceUp,
        WalkUp,
        FaceDown,
        WalkDown
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Create Objects
        Player player1;
        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;
        Enemy enemy4;
        Enemy enemy5;
        Enemy enemy6;
        Enemy enemy7;
        Collectible money;
        Environment crate;

        LevelEditor myEditor;
        // Texture2D fields for sprites

        private Texture2D texturePlayer;
        private Texture2D textureEnemy;
        private Texture2D textureCrate;
        private Texture2D textureMoney;
        private Texture2D mainMenuBackGround;
        private Texture2D mainMenuBox;
        private Texture2D title;
        private Texture2D quit;
        private Texture2D start;
        private Texture2D mainMenuButton;
        private Texture2D youWin;
        private Texture2D gameOver; 
        private Texture2D gameBackground;
        private Texture2D gamePaused;
        private Texture2D resume;
        private Texture2D back;
        private Texture2D textureEnemyLOS;
        private Texture2D controlsList;
        private Texture2D controls;


        // Rectangle fields for sprites
        private Rectangle positionPlayer;
        private Rectangle positionEnemy1;
        private Rectangle positionEnemy2;
        private Rectangle positionEnemy3;
        private Rectangle positionEnemy4;
        private Rectangle positionEnemy5;
        private Rectangle positionEnemy6;
        private Rectangle positionEnemy7;
        private Rectangle positionCrate;
        private Rectangle positionMoney;

        private Rectangle mainMenuBackGroundPosition;
        private Rectangle mainMenuBoxPosition;
        private Rectangle mainMenuTitlePosition;
        private Rectangle mainMenuQuitPosition;
        private Rectangle mainMenuStartPosition;
        private Rectangle mainMenuButtonPosition;

        private Rectangle youWinPosition;
        private Rectangle gameOverPosition;
        private Rectangle gamePausedPosition;
        private Rectangle controlsPosition;
        private Rectangle resumePosition;
        private Rectangle backPosition;
        private Rectangle controlsListPosition;

        private Vector2 playerLoc;
        private Vector2 spriteOrigin;


        // SpriteFont string
        private string controlString;

        // Field to hold the current state of the game
        private GameState currentState;
        private GameState prevState;

        // Field to gold the current and previous MouseState
        private MouseState ms;
        private MouseState prevMS;
        private KeyboardState kbState;

        //Lists
        private List<Environment> listCrates;
        
        private List<Enemy> listEnemy;
        private List<Collectible> listMoney;
        private List<Rectangle> listPositionsMoney;
        private List<Rectangle> enemyPositions;
        private List<Rectangle> listPositionsCrates;

        // ANIMATION FIELDS 
        // Texture and drawing
        private Texture2D playerSpriteSheet;  // The single image with all of the animation frames

        // Animation
        int frame;              // The current animation frame
        double timeCounter;     // The amount of time that has passed
        double fps;             // The speed of the animation
        double timePerFrame;    // The amount of time (in fractional seconds) per frame
        private int rotation;   // Rotation of spritesheet for vertical 

        // Constants for "source" rectangle (inside the image)
        const int WalkFrameCount = 19;         // The number of frames in the animation
        const int PlayerRectOffsetY = 142;    // How far down in the image are the frames?
        const int PlayerRectHeight = 35;     // The height of a single frame
        const int PlayerRectWidth = 45;      // The width of a single frame

        string[,] LevelMap;


        public int Rotation { get { return rotation; } set { rotation = value; } }

        public Game1()
        {
            
            //HELLO GIT WORK PLEASE
            
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

            this.IsMouseVisible = true;
            // TODO: Add your initialization logic here


            //Initalizes lists
            listCrates = new List<Environment>();
            listEnemy = new List<Enemy>();  
            listMoney = new List<Collectible>();
            listPositionsMoney = new List<Rectangle>();
            listPositionsCrates = new List<Rectangle>();
            enemyPositions = new List<Rectangle>();

            enemy6 = new Enemy(positionEnemy6, textureEnemy, new Rectangle((777 - 163), 360, 163, 35));
            listEnemy.Add(enemy1);
            listEnemy.Add(enemy2);
            listEnemy.Add(enemy3);
            listEnemy.Add(enemy4);
            listEnemy.Add(enemy5);
            listEnemy.Add(enemy6);
            listEnemy.Add(enemy7);

            // Makes the first GameState the MainMenu 
            currentState = GameState.MainMenu;

            //Rectangle of player **SUBJECT TO CHANGE**
            positionPlayer.X = 100;
            positionPlayer.Y = 100;
            positionPlayer.Width = 2;
            positionPlayer.Height = 2;         
            playerLoc = new Vector2(100, 200);
            
            //Rectangle of enemy1 **SUBJECT TO CHANGE**
            positionEnemy1.X = 185;
            positionEnemy1.Y = 23;
            positionEnemy1.Width = 35;
            positionEnemy1.Height = 35;
            positionEnemy2.X = 195;
            positionEnemy2.Y = 150;
            positionEnemy2.Width = 35;
            positionEnemy2.Height = 35;

            positionEnemy3.X = 537;
            positionEnemy3.Y = 85;
            positionEnemy3.Width = 35;
            positionEnemy3.Height = 35;

            positionEnemy4.X = 280;
            positionEnemy4.Y = 300;
            positionEnemy4.Width = 35;
            positionEnemy4.Height = 35;

            positionEnemy5.X = 500;
            positionEnemy5.Y = 225;
            positionEnemy5.Width = 35;
            positionEnemy5.Height = 35;

            positionEnemy6.X = 777;
            positionEnemy6.Y = 365;
            positionEnemy6.Width = -35;
            positionEnemy6.Height = -35;

            positionEnemy7.X = 45;
            positionEnemy7.Y = 382;
            positionEnemy7.Width = 35;
            positionEnemy7.Height = 35;

            enemyPositions.Add(positionEnemy1);
            enemyPositions.Add(positionEnemy2);
            enemyPositions.Add(positionEnemy3);
            enemyPositions.Add(positionEnemy4);
            enemyPositions.Add(positionEnemy5);
            enemyPositions.Add(positionEnemy6);
            enemyPositions.Add(positionEnemy7);

            //Rectangle of collecitble **SUBJECT TO CHANGE**
            positionMoney.X = 300;
            positionMoney.Y = 300;
            positionMoney.Width = 25;
            positionMoney.Height = 25;
            

            //Rectangle of Crate **SUBJECT TO CHANGE**
            positionCrate.Width = 10;
            positionCrate.Height = 10;

            player1 = new Player(positionPlayer, texturePlayer);    //Creates Player named player1
            for (int i = 0; i < listEnemy.Count; i++)
            {
                listEnemy[i] = new Enemy(enemyPositions[i], textureEnemy, new Rectangle(enemyPositions[i].X, enemyPositions[i].Y, 163, 35));
            }
            listEnemy[5].LineOfSight = new Rectangle((777 - 163), 340, 163, 35);        // Moves the line of sight rectangle of enemy 6
            money = new Collectible(positionMoney, textureMoney);   //Creates Collectible named money
            crate = new Environment(positionCrate, textureCrate);   //Creates Envrionment named crate

            // Created all the Rectangles for the mainMenu asects
            mainMenuBackGroundPosition = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            mainMenuBoxPosition = new Rectangle(50, 50, (GraphicsDevice.Viewport.Width - 100), (GraphicsDevice.Viewport.Height - 100));
            mainMenuTitlePosition = new Rectangle(225, 65, 350 ,75);
            mainMenuStartPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 75, 150, 150, 50);
            mainMenuQuitPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 75, 300, 150, 50);

            // Rectangles for the GameOver State
            mainMenuButtonPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 125, 150, 300, 50);
            youWinPosition = new Rectangle(225, 55, 350, 75);
            gameOverPosition = new Rectangle(225, 55, 350, 75);

            // Rectangles for the Pause State
            gamePausedPosition = new Rectangle(275, 55, 275, 65);
            controlsPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 80, 210, 175, 60);
            resumePosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 80, 125, 175, 65);
            backPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 75, 300, 150, 50);
            controlsListPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 200, 140, 450, 150);

            // Gets the mouse state at the begining of the game
            ms = Mouse.GetState();
            prevMS = Mouse.GetState(); 

            // Gets the mouse state and keyboard state at the beginning of the game
            kbState = Keyboard.GetState();

            // Sets the controlString equal to the text 
            controlString = String.Format("\"W,A,S,D\" for movement\n\"Escape\" key to pause the game.");

            fps = 25.0;
            timePerFrame = 1.0 / fps;
            rotation = 0;
            spriteOrigin = new Vector2(22.5f, 17.5f);

            myEditor = new LevelEditor();
            myEditor.Reader();
            LevelMap = myEditor.GetArray;
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
            
            // Loads textures of objects
            texturePlayer = Content.Load<Texture2D>("GameStateAssets/Player/Walk/survivor-move_knife_0");  // Player character 
            textureEnemy = Content.Load<Texture2D>("GameStateAssets/OtherAssets/enemySpriteRight");             // Enemy character  
            textureCrate = Content.Load<Texture2D>("GameStateAssets/OtherAssets/CrateNoir1");              // Crate that will make up the walls of the game
            textureMoney = Content.Load<Texture2D>("GameStateAssets/OtherAssets/moneybag");                //Money bag collectible 
            textureEnemyLOS = Content.Load<Texture2D>("GameStateAssets/Enemy/Line of Sight box");           //Box outline for Line of Sight

            // Loaded all the textures into the fields for the main menu
            mainMenuBackGround = Content.Load<Texture2D>("MenuStateAssets/MenuBckGround");
            mainMenuBox = Content.Load<Texture2D>("MenuStateAssets/MenuBox");
            title = Content.Load<Texture2D>("MenuStateAssets/MidnightMoneyNoirTxt");
            quit = Content.Load<Texture2D>("MenuStateAssets/QuitColorTxt");
            start = Content.Load<Texture2D>("MenuStateAssets/StartColorTxt");

            // Loaded all the texture into the fields for the game over screen
            mainMenuButton = Content.Load<Texture2D>("OtherStateAssets/MainMenu");
            youWin = Content.Load<Texture2D>("OtherStateAssets/YouWin");
            gameOver = Content.Load<Texture2D>("OtherStateAssets/GameOver");

            // Loaded all the textures into the fields for the game paused screen
            gamePaused = Content.Load<Texture2D>("OtherStateAssets/GamePaused");

            controls = Content.Load<Texture2D>("OtherStateAssets/Controls");
            resume = Content.Load<Texture2D>("OtherStateAssets/Resume");
            back = Content.Load<Texture2D>("OtherStateAssets/Back");

            //Loaded the spritefont into the field
            controlsList = Content.Load<Texture2D>("OtherStateAssets/ControlsList");


            textureMoney = Content.Load<Texture2D>("GameStateAssets/OtherAssets/moneybag");                //Money bag collectible 
            gameBackground = Content.Load<Texture2D>("GameStateAssets/OtherAssets/LevelBackground");       //GameBackground

            playerSpriteSheet = Content.Load<Texture2D>("GameStateAssets/Player/testSpriteSheet"); 

            listCrates = myEditor.PopulateCrateList(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, textureCrate);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Delete))
                Exit();

            // TODO: Add your update logic here
            // At the begining of every frame we get a new mouse state
            ms = Mouse.GetState();
            kbState = Keyboard.GetState();

            // FSM for Gameplay 
            switch (currentState)
            {
                // Menus switch case

                case GameState.MainMenu:
                    // Moves from menu to the game and the menu to quit
                    ms = Mouse.GetState();
                    kbState = Keyboard.GetState();
                    if (mainMenuQuitPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
                    {
                        this.Exit();
                    }
                    if (mainMenuStartPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed || kbState.IsKeyDown(Keys.Enter))
                    {
                        player1.LocationPlayer = new Vector2(100, 100);
                        player1.PlayerPosition = new Rectangle(Convert.ToInt32(player1.LocationPlayer.X),
                            Convert.ToInt32(player1.LocationPlayer.Y),
                            positionPlayer.Width,
                            positionPlayer.Height);  //**USES VECTOR2 LocationPlayer - Creates new player rectangle so game doesn't break.


                        currentState = GameState.Game;
                        prevState = GameState.MainMenu;

                        for (int i = 0; i < listEnemy.Count; i++)   //CanSeePlayer bool is set to false when game starts for each enemy in the list
                        {
                            listEnemy[i].CanSeePlayer = false; 
                        }

                        for (int i = 0; i < listMoney.Count; i++)    //Collected  bool is set to false when game starts for each money collectible in the list
                        {
                            listMoney[i].Collected = false;
                        } 
                    }
                    if (controlsPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
                    {
                        prevState = GameState.MainMenu;
                        currentState = GameState.Controls;
                    }
                    break;



                    //GAME STATE
                case GameState.Game:    //Calls Movement method for player input
                    UpdateAnimation(gameTime); 
                    
                    
                    player1.PlayerMovement(myEditor);

                    

                    //Checks if enemy1 sees player1
                    for (int i = 0; i < listEnemy.Count; i++)
                    {
                        if (listEnemy[i].PlayerIsSeen(player1))    //checks if each enemy in the list is intersecting the player
                        {
                            listEnemy[i].CanSeePlayer = false;        //Resets bool before changing states
                            prevState = GameState.Game;
                            currentState = GameState.GameOver;
                        }
                    }
                    

                    //Checks to see if user wants to pause the game by hitting escape
                    if (kbState.IsKeyDown(Keys.Escape))
                    {
                        prevState = GameState.Game;
                        currentState = GameState.Pause; 
                    }

                    //Checks if player1 intersects money
                    for (int i = 0; i < listMoney.Count; i++)
                    {
                        if (listMoney[i].PlayerGetItem(player1))    //checks if each money collectible in the list is intersecting the player
                        {
                            listMoney[i].Collected = true;  //sets collected to true
                            prevState = GameState.Game;
                            currentState = GameState.GameOver;
                        }
                    }                   
                    break;



					//PAUSE STATE
				case GameState.Pause:
					if (mainMenuButtonPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
					{
						prevState = GameState.Pause;
						currentState = GameState.MainMenu;
					}
					if (controlsPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
					{
						prevState = GameState.Pause;
						currentState = GameState.Controls;
					}
					if (resumePosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
					{
						prevState = GameState.Pause;
						currentState = GameState.Game;
					}
					break;

                    //CONTROLS STATE
                case GameState.Controls:
                    if (prevState == GameState.MainMenu)
                    {
                        if (new Rectangle((GraphicsDevice.Viewport.Width / 2) - 125, 300, 300, 55).Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
                        {
                            prevState = GameState.Controls;
                            currentState = GameState.MainMenu;
                        }
                    }
                    else if (prevState == GameState.Pause)
                    {
                        if (backPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
                        {
                            prevState = GameState.Controls;
                            currentState = GameState.Pause;
                        }
                    }               
                    break;

                    //GAMEOVER STATE
                case GameState.GameOver:
                    // This Changes what is drawn based on rather the collectible was collected or not
                    for (int i = 0; i < listMoney.Count; i++)
                    {
                        if (listMoney[i].Collected == true)
                        {
                            // Ends the game
                            if (mainMenuQuitPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                            {
                                this.Exit();
                            }
                            // If the player clicks the main menu button, it goes to the main menu
                            if (mainMenuButtonPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
                            {
                                prevState = GameState.Game;
                                currentState = GameState.MainMenu;
                            }

                        }
                        else
                        {
                            // Ends the game
                            if (mainMenuQuitPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                            {
                                this.Exit();
                            }
                            // If the player clicks the main menu button, it goes to the main menu
                            if (mainMenuButtonPosition.Contains(ms.Position) && ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
                            {
                                prevState = GameState.Game;
                                currentState = GameState.MainMenu;
                            }
                        }
                    }
                    break; 
            }

            // Sets the previous mouse state to the current mouse state
            prevMS = ms; 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            // FSM for Drawing
            switch (currentState)
            {

                //DRAW MENU
                case GameState.MainMenu:
                    // Draws the mainMenu 
                    spriteBatch.Draw(mainMenuBackGround, mainMenuBackGroundPosition, Color.White);
                    spriteBatch.Draw(mainMenuBox, mainMenuBoxPosition, Color.White);
                    spriteBatch.Draw(title, mainMenuTitlePosition, Color.White);
                    spriteBatch.Draw(quit, mainMenuQuitPosition, Color.White);
                    spriteBatch.Draw(start, mainMenuStartPosition, Color.White);
                    spriteBatch.Draw(controls, controlsPosition, Color.White);
                    break;


                    //DRAW FOR GAME
                case GameState.Game:
                    spriteBatch.Draw(gameBackground, new Rectangle(0, 0,GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height),Color.White);
                    

                    for(int i = 0; i < myEditor.GetArrayWidth; i++)
                    {
                        for(int j = 0; j < myEditor.GetArrayHeight; j++)
                        {
                            if (LevelMap[i,j] == "-")   //draws nothing
                            {
                                //draw nothing
                            }
                            else if (LevelMap[i, j] == "o")     //Draws money bags
                            {
                                
                                money.CollectiblePosition = new Rectangle(i * (GraphicsDevice.Viewport.Width / myEditor.GetArrayWidth), j * (GraphicsDevice.Viewport.Height / myEditor.GetArrayHeight), positionMoney.Width, positionMoney.Height);
                                listPositionsMoney.Add(money.CollectiblePosition);      //adds collectible position to list
                                listMoney.Add(money);                           //adds Collectible to list 

                                for (int e = 0; e < listMoney.Count; e++)   //creating new collectible by looping through
                                {
                                    listMoney[e] = new Collectible(listPositionsMoney[e], textureMoney);
                                }

                                for (int e = 0; e < listMoney.Count; e++)   //drawing listMoney collectible through loop
                                {
                                    listMoney[e].Draw(spriteBatch, listPositionsMoney[e], textureMoney, Color.White);
                                }
                                //ONLY COLLIDES WITH ONE MONEY COLLECTIBLE
                            }
                            else    //Draws Crates
                            {
                                crate.EnvironmentPosition = new Rectangle(i * (GraphicsDevice.Viewport.Width / myEditor.GetArrayWidth), +
                                    j * (GraphicsDevice.Viewport.Height / myEditor.GetArrayHeight), positionCrate.Width, positionCrate.Height);


                               

                            }
                        }
                    }

                   

                    //Draws Enemies
                    for (int i = 0; i < listEnemy.Count; i++)   //drawing listEnemy enemy through loop
                    {
                        listEnemy[i].Draw(spriteBatch, enemyPositions[i], textureEnemy, Color.White);
                    }
                    for(int i = 0; i < listCrates.Count; i++)
                    {
                        listCrates[i].Draw(spriteBatch, listCrates[i].EnvironmentPosition, textureCrate, Color.White);
                    }

                    // Draws animation
                    switch (player1.PlayerCurrentState)
                    {
                        // LEFT
                        case PlayerState.FaceLeft:
                            player1.PlayerPreviousState = PlayerState.FaceLeft;
                            rotation = 0;
                            DrawPlayerStanding(SpriteEffects.FlipHorizontally);
                            break;
                        case PlayerState.WalkLeft:
                            
                            player1.PlayerPreviousState = PlayerState.WalkLeft;
                            rotation = 0;
                            DrawPlayerWalking(SpriteEffects.FlipHorizontally);
                            break;

                        // RIGHT
                        case PlayerState.FaceRight:

                            player1.PlayerPreviousState = PlayerState.FaceRight;
                            rotation = 0;
                            DrawPlayerStanding(SpriteEffects.None);
                            break;
                        case PlayerState.WalkRight:
                            player1.PlayerPreviousState = PlayerState.WalkRight;
                            rotation = 0;
                            DrawPlayerWalking(SpriteEffects.None);
                            break;

                        //UP
                        case PlayerState.FaceUp:
                            rotation = -90;
                            DrawPlayerStanding(SpriteEffects.None);
                            break;
                        case PlayerState.WalkUp:
                            rotation = -90;
                            DrawPlayerWalking(SpriteEffects.None);
                            break;

                        // DOWN
                        case PlayerState.FaceDown:
                            rotation = 90;
                            DrawPlayerStanding(SpriteEffects.None);
                            break;
                        case PlayerState.WalkDown:
                            rotation = 90;
                            DrawPlayerWalking(SpriteEffects.None);
                            break;
                    }

                    break;

                    //DRAW PAUSE
                case GameState.Pause:
                    spriteBatch.Draw(mainMenuBackGround, mainMenuBackGroundPosition, Color.White);
                    spriteBatch.Draw(mainMenuBox, mainMenuBoxPosition, Color.White);
                    spriteBatch.Draw(gamePaused, gamePausedPosition, Color.White);
                    mainMenuButtonPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 125, 300, 300, 50);
                    spriteBatch.Draw(resume, resumePosition, Color.White);
                    spriteBatch.Draw(mainMenuButton, mainMenuButtonPosition, Color.White);
                    spriteBatch.Draw(controls, controlsPosition, Color.White);
                    break;

                case GameState.Controls:
                    // Draws Controls State based on the previous state
                    spriteBatch.Draw(mainMenuBackGround, mainMenuBackGroundPosition, Color.White);
                    spriteBatch.Draw(mainMenuBox, mainMenuBoxPosition, Color.White);
                    spriteBatch.Draw(controls, new Rectangle((GraphicsDevice.Viewport.Width / 2) - 80, 50, 175, 75), Color.White);
                    spriteBatch.Draw(controlsList, controlsListPosition, Color.White);

                    if (prevState == GameState.MainMenu)
                    {
                        spriteBatch.Draw(mainMenuButton, new Rectangle((GraphicsDevice.Viewport.Width / 2) - 125, 300, 300, 55), Color.White);
                    }
                    else if (prevState == GameState.Pause)
                    {
                        spriteBatch.Draw(back, backPosition, Color.White);
                    }
                    break;



                    //DRAW GAME OVER
                case GameState.GameOver:
                    // In the Game Over State it draws the same sprites as the main menu with a few changes
                    mainMenuButtonPosition = new Rectangle((GraphicsDevice.Viewport.Width / 2) - 125, 140, 300, 55);

                    for (int i = 0; i < listMoney.Count; i++)   //loops through collectibles in Money
                    {
                        if (listMoney[i].Collected == true)     //checks if any have Collected == true
                        {
                            // Draws the GameOver state when the player collects the money
                            spriteBatch.Draw(mainMenuBackGround, mainMenuBackGroundPosition, Color.White);
                            spriteBatch.Draw(mainMenuBox, mainMenuBoxPosition, Color.White);
                            spriteBatch.Draw(mainMenuButton, mainMenuButtonPosition, Color.White);
                            spriteBatch.Draw(youWin, youWinPosition, Color.White);
                            spriteBatch.Draw(quit, mainMenuQuitPosition, Color.White);
                            break;
                        }
                        else
                        {
                            // Draws the GameOver state when the enemy sees a player
                            spriteBatch.Draw(mainMenuBackGround, mainMenuBackGroundPosition, Color.White);
                            spriteBatch.Draw(mainMenuBox, mainMenuBoxPosition, Color.White);
                            spriteBatch.Draw(gameOver, gameOverPosition, Color.White);
                            spriteBatch.Draw(mainMenuButton, mainMenuButtonPosition, Color.White);
                            spriteBatch.Draw(quit, mainMenuQuitPosition, Color.White);
                        }
                    }                    
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
        
        //Update's players animation as needed
        private void UpdateAnimation(GameTime gameTime)
        {
            // Handle animation timing
            // - Add to the time counter
            // - Check if we have enough "time" to advance the frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;                     // Adjust the frame

                if (frame > WalkFrameCount)     // Check the bounds
                    frame = 1;                  // Back to 1 (since 0 is the "standing" frame)

                timeCounter -= timePerFrame;    // Remove the time we "used"
            }
        }

        private void DrawPlayerStanding(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                playerSpriteSheet,                    // - The texture to draw
                player1.LocationPlayer,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    0,                          //   - This rectangle specifies
                    PlayerRectOffsetY,        //	   where "inside" the texture
                    PlayerRectWidth,           //     to get pixels (We don't want to
                    PlayerRectHeight),         //     draw the whole thing)
                Color.White,                    // - The color
                rotation,                              // - Rotation (none currently)
                spriteOrigin,                   // - Origin inside the image (top left)
                0.75f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }

        private void DrawPlayerWalking(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                playerSpriteSheet,                    // - The texture to draw
                player1.LocationPlayer,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    frame * PlayerRectWidth,   //   - This rectangle specifies
                    PlayerRectOffsetY,        //	   where "inside" the texture
                    PlayerRectWidth,           //     to get pixels (We don't want to
                    PlayerRectHeight),         //     draw the whole thing)
                Color.White,                    // - The color
                rotation,                              // - Rotation (none currently)
                spriteOrigin,                   // - Origin inside the image (top left)
                0.75f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }
    }       
}

