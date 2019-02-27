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
    // Parent Class
    class GameManager
    {
        // Fields
        
        protected Rectangle gameObjectPosition;
        protected Texture2D gameObjecttexture;

        public Rectangle GameObjectPosition { get { return gameObjectPosition; } set { gameObjectPosition = value; } }

        // Contructor
        public GameManager(Rectangle p_gameObjectPosition, Texture2D p_gameObjecttexture)
        {
            gameObjectPosition = p_gameObjectPosition;
            gameObjecttexture = p_gameObjecttexture;
        }

        // Base Draw() Method
        public virtual void Draw(SpriteBatch sb, Rectangle postion, Texture2D texture, Color color)
        {
            sb.Draw(texture, postion, color);
        }
        // Interits Collides Method from ICollisions interface
        public bool Collides(GameManager gm)
        {
            if (gm.GameObjectPosition.Intersects(this.gameObjectPosition))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
