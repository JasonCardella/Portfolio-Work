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
    class Environment : GameManager
    {
        // Fields
        private Texture2D environmentTexture;
        private Rectangle environmentPosition;
        public bool collidesWith;
        private int x;
        private int y;

        // Properties
        public Rectangle EnvironmentPosition { get { return environmentPosition; } set { environmentPosition = value; } }
        public bool CollidesWith { get { return collidesWith; } set { collidesWith = value; } }
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return Y; } set { y = value; } }

        public Environment(Rectangle p_environmentPosition, Texture2D p_texture) : base(p_environmentPosition, p_texture)
        {
            environmentPosition = p_environmentPosition;
            environmentTexture = p_texture;
            x = environmentPosition.X;
            y = environmentPosition.Y;
        }

        // Interits Collides Method from ICollisions interface
        public bool Collides(Rectangle rect)
        {
            if (rect.Intersects(this.environmentPosition))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        // Overriden Draw() from the GameManager Class
        public override void Draw(SpriteBatch sb, Rectangle postion, Texture2D texture, Color color)
        {
            base.Draw(sb, postion, texture, color);
        }
    }
}
