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
    class Collectible : GameManager
    {

        // Fields
        private Texture2D collectibleTexture;
        private Rectangle collectiblePosition;
        public bool collidesWith;
        private int x;
        private int y;
        private bool collected;

        // Properties
        public Rectangle CollectiblePosition { get { return collectiblePosition; } set { collectiblePosition = value; } }
        public bool CollidesWith { get { return collidesWith; } set { collidesWith = value; } }
        public bool Collected { get { return collected; } set { collected = value; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return Y; } set { y = value; } }

        public Collectible(Rectangle p_collectiblePosition, Texture2D p_collectibleTexture) : base(p_collectiblePosition, p_collectibleTexture)
        {
            collectiblePosition = p_collectiblePosition;
            collectibleTexture = p_collectibleTexture;
            x = collectiblePosition.X;
            y = collectiblePosition.Y;
            collected = false;
        }

        // Interits Collides Method from ICollisions interface
        public bool Collides(GameManager gm)
        {
            if (gm.GameObjectPosition.Intersects(this.collectiblePosition))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Player collects collectible
        public bool PlayerGetItem(Player p1)
        {
            if (p1.PlayerPosition.Intersects(collectiblePosition) && collected == false)
            {
                //Console.WriteLine("Collects Item");
                collected = true;
                return collected;
            }
            else
            {
                //Console.WriteLine("Does not collect");
                collected = false;
                return collected;
            }
        }

        // Overriden Draw() from the GameManager Class
        public override void Draw(SpriteBatch sb, Rectangle postion, Texture2D texture, Color color)
        {
            base.Draw(sb, collectiblePosition, texture, color);
        }
    }
}
