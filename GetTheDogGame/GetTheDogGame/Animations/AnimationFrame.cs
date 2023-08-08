using System;
using Microsoft.Xna.Framework;

namespace GetTheDogGame.Animations
{
	public class AnimationFrame
	{
		public Rectangle srcRectangle { get; set; }

		public AnimationFrame(Rectangle rectangle)
		{
			srcRectangle = rectangle;
		}
	}
}

