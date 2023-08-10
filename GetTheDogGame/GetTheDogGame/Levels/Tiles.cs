using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;

namespace GetTheDogGame.Levels
{
    public class Tiles
    {
        protected Texture2D texture;
        private Rectangle rectangle, srcRectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public Rectangle SrcRectangle
        {
            get { return srcRectangle; }
            set { srcRectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, srcRectangle, Color.White);
        }
    }

    public class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("TilesNonSliced");
            switch (i)
            {
                case 1: this.SrcRectangle = new Rectangle(1, 1, 46, 46); break;
                case 2: this.SrcRectangle = new Rectangle(1, 1, 46, 46); break;
                case 3: this.SrcRectangle = new Rectangle(48, 32, 31, 31); break;
            }

            this.Rectangle = newRectangle;
        }
    }

}

