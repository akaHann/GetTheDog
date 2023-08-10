using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Levels
{
    public class CollisionTiles : Tiles
    {
        private static ContentManager content;

        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("TilesNonSliced");
            switch (i)
            {
                case 1: SrcRectangle = new Rectangle(1, 1, 46, 46); break;
                case 2: SrcRectangle = new Rectangle(1, 1, 46, 46); break;
                case 3: SrcRectangle = new Rectangle(48, 32, 31, 31); break;
            }

            Rectangle = newRectangle;
        }
    }
}

