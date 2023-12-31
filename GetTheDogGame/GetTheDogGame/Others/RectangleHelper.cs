﻿using System;
using Microsoft.Xna.Framework;

namespace GetTheDogGame.Others
{
	public static class RectangleHelper
	{
        //Ik heb dit stukje code van het internet gehaald.
        //Bron: Oyyou. (2013, 30 januari). XNA Tutorial 40 - Crating a Tile Map (2/3). YouTube. https://www.youtube.com/watch?v=l0WS5SvKdY4
        public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 1 &&
                r1.Bottom <= r2.Top + (r2.Height / 2) &&
                r1.Right >= r2.Left + (r2.Width / 1.9) &&
                r1.Left <= r2.Right - (r2.Width / 1.9));
        }

        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top <= r2.Bottom + 1 &&
                r1.Top >= r2.Bottom - 1 &&
                r1.Right >= r2.Left + (r2.Width / 1.9) &&
                r1.Left <= r2.Right - (r2.Width / 1.9));
        }

        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right &&
                r1.Right >= r2.Left + 20 &&
                r1.Top <= r2.Bottom - (r2.Width / 2) &&
                r1.Bottom >= r2.Top + (r2.Width / 2));
        }

        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left &&
                r1.Left <= r2.Right - 20 &&
                r1.Top <= r2.Bottom - (r2.Width / 2) &&
                r1.Bottom >= r2.Top + (r2.Width / 2));
        }
    }
}

