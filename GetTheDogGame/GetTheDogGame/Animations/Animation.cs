using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GetTheDogGame.Animations
{
	public class Animation
	{
		public AnimationFrame CurrentFrame { get; set; }
		private List<AnimationFrame> frames;
		private int counter;

		private double secondCounter = 0;
		private int fps = 15;

		public Animation()
		{
			frames = new List<AnimationFrame>();
		}

		public void AddSpriteRow(int width, int height, int row, int numberOfSprites)
		{
			for (int i = 0; i < numberOfSprites; i++)
			{
				frames.Add(new AnimationFrame(new Rectangle(width * i, row * height, width, height)));
			}
		}

		public void Update(GameTime gameTime)
		{
            int fps = 15;
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }
            CurrentFrame = frames[counter];
            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
	}
}

