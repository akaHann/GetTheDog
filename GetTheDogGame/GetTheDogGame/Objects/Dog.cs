using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GetTheDogGame.Objects
{
	public class Dog
	{
		Texture2D dogTexture;
		private bool collected;

		private int x { get; set; }
		private int y { get; set; }
		
		private int size { get; set; }

		public Rectangle rectangle;

		public Dog(ContentManager content, int xPosition, int yPosition)
		{
			x = xPosition;
			y = yPosition;

			size = 50;

			dogTexture = content.Load<Texture2D>("dog");
			rectangle = new Rectangle(xPosition, yPosition, size, size);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (!collected)
				spriteBatch.Draw(dogTexture, rectangle, Color.White);
		}

		public void Collected()
		{
			collected = true;
			rectangle.Y = -1000;
			Player.score += 1;
		}
	}
}

