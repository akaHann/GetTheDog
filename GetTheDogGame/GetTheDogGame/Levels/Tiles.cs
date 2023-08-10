using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;

namespace GetTheDogGame.Levels
{
    public class Tiles
    {
        public Rectangle Rectangle { get; set; }
        public Rectangle SrcRectangle { get; set; }
        protected Texture2D texture;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, SrcRectangle, Color.White);
        }
    }

}

