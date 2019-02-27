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
    class Enemy : GameManager
    {
        // Fields
        private Texture2D enemyTexture;
        private Texture2D losTexture;
        private Rectangle enemyPosition;
        private Rectangle lineOfSight;
        private bool canSeePlayer; 
        public bool collidesWith;
        private int x;
        private int y;
        

        // Properties
        public Rectangle EnemyPosition { get { return enemyPosition; } set { enemyPosition = value; } }
        public Rectangle LineOfSight { get { return lineOfSight; } set { lineOfSight = value; } }
        public bool CollidesWith { get { return collidesWith; } set { collidesWith = value; } }
        public bool CanSeePlayer { get { return canSeePlayer; } set { canSeePlayer = value; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return Y; } set { y = value; } }

        public Enemy(Rectangle p_enemyPosition, Texture2D p_enemyTexture, Rectangle p_lineOfSight) : base(p_enemyPosition, p_enemyTexture)
        {
            enemyPosition = p_enemyPosition;
            enemyTexture = p_enemyTexture;
            x = enemyPosition.X;
            y = enemyPosition.Y;
            lineOfSight = p_lineOfSight;
            //lineOfSight = new Rectangle(enemyPosition.X, enemyPosition.Y, 163, enemyPosition.Height);   //comment this out to disable enemy line of sight box (GOD MODE!!!)
            canSeePlayer = false;
        }



        // Interits Collides Method from ICollisions interface
        public bool Collides(GameManager gm)
        {
            if (gm.GameObjectPosition.Intersects(this.enemyPosition))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        //Sight of Enemy
        public bool PlayerIsSeen(Player p1)
        {
            if (p1.PlayerPosition.Intersects(lineOfSight) && canSeePlayer == false)
            {
                canSeePlayer = true;
                return canSeePlayer;
            }
            else
            {
                //Console.WriteLine("Enemy can't see the player");
                canSeePlayer = false; 
                return canSeePlayer; 
            }
        }

        // Overriden Draw() from the GameManager Class
        public override void Draw(SpriteBatch sb, Rectangle position, Texture2D texture, Color color)
        {
            base.Draw(sb, position, texture, color);
        }


    }
}
