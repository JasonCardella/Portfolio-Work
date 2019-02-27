using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Midnight_Money
{
    // Inherts from the GameManger and the ICollisions interface here you go sire
    class Player : GameManager, IStealth
    {
        // Fields 
        private Rectangle playerPosition;
        private Vector2 locationPlayer;
        private Texture2D playerTexture;
        private bool collidesWith;
        private bool playerHitsWall;
        private bool detected; 
        private int x;
        private int y;
        private KeyboardState kb;
        private KeyboardState prevKb;
        private LevelEditor myEditor;

        private PlayerState playerCurrentState;
        private PlayerState playerPreviousState;

        // Properties 
        public PlayerState PlayerCurrentState { get { return playerCurrentState; } set { playerCurrentState = value; } }
        public PlayerState PlayerPreviousState { get { return playerPreviousState; } set { playerPreviousState = value; } }
        public Vector2 LocationPlayer { get { return locationPlayer; } set { locationPlayer = value; } }
        public Rectangle PlayerPosition { get { return playerPosition; } set { playerPosition = value; } }
        public bool CollidesWith { get { return collidesWith; } set { collidesWith = value; } }
        public bool Detected { get { return detected; } set { detected = value; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return Y; } set { y = value; } }

        public bool PlayerHitsWall { get { return playerHitsWall; } set { playerHitsWall = value; }}

        // Interited the GameMangers Constructor
        public Player(Rectangle p_playerPosition, Texture2D p_playerTexture) : base(p_playerPosition, p_playerTexture)
        {
            locationPlayer = new Vector2(50, 50);
            playerPosition = p_playerPosition;
            playerTexture = p_playerTexture;
            x = playerPosition.X;
            y = playerPosition.Y;
            myEditor = new LevelEditor();
        }

        // Interits Collides Method from ICollisions interface
        public bool Collides(GameManager gm)
        {
            if (gm.GameObjectPosition.Intersects(this.playerPosition))
            { 
                return true;
            }
            else
            {
                return false;
            }

        }

        //Sight of Enemy
        public bool EnemyDetections(Enemy enemy)
        {
            // Determines if the player is detected by an enemy
            if(playerPosition.Intersects(enemy.EnemyPosition))
            {
                Console.WriteLine("REE");
                return true;
            }          
            return false;
        }

     

        // Overriden Draw() from the GameManager Class
        public override void Draw(SpriteBatch sb, Rectangle postion, Texture2D texture, Color color)
        {
            base.Draw(sb, postion, texture, color);
        }

        //Player Movement
        public void PlayerMovement(LevelEditor gameLevel)
        {
            // Gets Keyboard States
            kb = Keyboard.GetState();
            prevKb = Keyboard.GetState();

            myEditor = gameLevel;
            //Switch statement movement for animation
            //Face Left, Walk Left
            //Face Right, Walk Right
            //Face Up, Walk Up,
            //Face Down, Walk Down
            switch (playerCurrentState)
            {
                case PlayerState.FaceLeft:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Face Left");
                        playerCurrentState = PlayerState.FaceLeft;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.WalkLeft:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Walk Left");
                        playerCurrentState = PlayerState.FaceLeft;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.FaceRight:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Face Right");
                        playerCurrentState = PlayerState.FaceRight;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.WalkRight:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Walk Right");
                        playerCurrentState = PlayerState.FaceRight;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.FaceUp:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Face Up");
                        playerCurrentState = PlayerState.FaceUp;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.WalkUp:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Walk Up");
                        playerCurrentState = PlayerState.FaceUp;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.FaceDown:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Face Down");
                        playerCurrentState = PlayerState.FaceDown;
                    }

                    prevKb = kb;
                    break;

                case PlayerState.WalkDown:
                    CheckingPlayerState();
                    if (kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S))
                    {
                        Console.WriteLine("Walk Down");
                        playerCurrentState = PlayerState.FaceDown;
                    }

                    prevKb = kb;
                    break;

            }
        }
        private bool boxCollision(List<Environment> crates)
        {
            //trying to find out how to code collisions from certain sides of player rectangle.
            //look in checkPlayerState()
            bool collide = false;
            for(int i = 0; i < crates.Count; i++)
            {
                if(crates[i].Collides(PlayerPosition))
                {
                    collide = true;
                    break;
                }
            }
            if(collide == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Method for checking state of player movement
        public void CheckingPlayerState()
        {
            //the origin of the sprite is the middle so we may need to add 22 and 17 to X and Y respectively to the playerPosition to makeup for it

            //NORMAL WALK
            //MOVE UP
            
                if (kb.IsKeyDown(Keys.W) && kb.IsKeyUp(Keys.LeftControl))
                {
                    locationPlayer.Y = locationPlayer.Y - 3;
                    playerPosition.Y = Convert.ToInt32(locationPlayer.Y) - 17;
                    playerCurrentState = PlayerState.WalkUp;
                }
                if (kb.IsKeyDown(Keys.W) && kb.IsKeyUp(Keys.LeftControl) && boxCollision(myEditor.ListCrates) == true)
                {
                    locationPlayer.Y = locationPlayer.Y + 6;
                    playerPosition.Y = Convert.ToInt32(locationPlayer.Y) + 17;
                }
            //MOVE LEFT
                if (kb.IsKeyDown(Keys.A) && kb.IsKeyUp(Keys.LeftControl))
                {
                    locationPlayer.X = locationPlayer.X - 3;
                    playerPosition.X = Convert.ToInt32(locationPlayer.X) - 22;
                    playerCurrentState = PlayerState.WalkLeft;
                }
                if (kb.IsKeyDown(Keys.A) && kb.IsKeyUp(Keys.LeftControl) && boxCollision(myEditor.ListCrates) == true)
                {
                    locationPlayer.X = locationPlayer.X + 6;
                    playerPosition.X = Convert.ToInt32(locationPlayer.X) + 22;
                }
                //MOVE DOWN

                if (kb.IsKeyDown(Keys.S) && kb.IsKeyUp(Keys.LeftControl) && boxCollision(myEditor.ListCrates) != true)
                {
                    locationPlayer.Y = locationPlayer.Y + 3;
                    playerPosition.Y = Convert.ToInt32(locationPlayer.Y) + 17;
                    playerCurrentState = PlayerState.WalkDown;
                }
                if(kb.IsKeyDown(Keys.S) && kb.IsKeyUp(Keys.LeftControl) && boxCollision(myEditor.ListCrates) == true)
                {
                    locationPlayer.Y = locationPlayer.Y - 6;
                    playerPosition.Y = Convert.ToInt32(locationPlayer.Y) - 17;
                }
                if (kb.IsKeyDown(Keys.D) && kb.IsKeyUp(Keys.LeftControl))
                {
                    locationPlayer.X = locationPlayer.X + 3;
                    playerPosition.X = Convert.ToInt32(locationPlayer.X) + 22;
                    playerCurrentState = PlayerState.WalkRight;
                }
                if (kb.IsKeyDown(Keys.D) && kb.IsKeyUp(Keys.LeftControl) && boxCollision(myEditor.ListCrates) == true)
                {
                    locationPlayer.X = locationPlayer.X - 6;
                    playerPosition.X = Convert.ToInt32(locationPlayer.X) - 22;
                }

                //SLOW WALK
                if (kb.IsKeyDown(Keys.W) && kb.IsKeyDown(Keys.LeftControl))
                {
                    locationPlayer.Y = locationPlayer.Y - 1;
                    playerPosition.Y = Convert.ToInt32(locationPlayer.Y) - 17;
                    playerCurrentState = PlayerState.WalkUp;
                }
                if (kb.IsKeyDown(Keys.A) && kb.IsKeyDown(Keys.LeftControl))
                {
                    locationPlayer.X = locationPlayer.X - 1;
                    playerPosition.X = Convert.ToInt32(locationPlayer.X) - 22;
                    playerCurrentState = PlayerState.WalkLeft;
                }
                if (kb.IsKeyDown(Keys.S) && kb.IsKeyDown(Keys.LeftControl))
                {
                    locationPlayer.Y = locationPlayer.Y + 1; 
                    playerPosition.Y = Convert.ToInt32(locationPlayer.Y) - 17;
                    playerCurrentState = PlayerState.WalkDown;
                }
                if (kb.IsKeyDown(Keys.D) && kb.IsKeyDown(Keys.LeftControl))
                {
                    locationPlayer.X = locationPlayer.X + 1;
                    playerPosition.X = Convert.ToInt32(locationPlayer.X) - 22;
                    playerCurrentState = PlayerState.WalkRight;
                }

                // *** CODE FOR EITHER UP OR DOWN OR LEFT OR RIGHT AT ONE INSTANCE
                //if (kb.IsKeyDown(Keys.W) && kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.S) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.LeftControl))
                //{
                //    locationPlayer.Y = locationPlayer.Y - 3;
                //    playerCurrentState = PlayerState.WalkUp;
                //}
                //if (kb.IsKeyDown(Keys.A) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.S) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.LeftControl) )
                //{
                //    locationPlayer.X = locationPlayer.X - 3;
                //    playerCurrentState = PlayerState.WalkLeft;
                //}
                //if (kb.IsKeyDown(Keys.S) && kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.D) && kb.IsKeyUp(Keys.LeftControl))
                //{
                //    locationPlayer.Y = locationPlayer.Y + 3;
                //    playerCurrentState = PlayerState.WalkDown;
                //}
                //if (kb.IsKeyDown(Keys.D) && kb.IsKeyUp(Keys.A) && kb.IsKeyUp(Keys.S) && kb.IsKeyUp(Keys.W) && kb.IsKeyUp(Keys.LeftControl))
                //{
                //    locationPlayer.X = locationPlayer.X + 3;
                //    playerCurrentState = PlayerState.WalkRight;
                //}


            
        }

    }
}
