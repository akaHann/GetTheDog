using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI
{
	public class Background
	{
		private readonly Texture2D _backgroundTexture;

		public Background(Texture2D backgroundTexture)
		{
			_backgroundTexture = backgroundTexture;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_backgroundTexture, Vector2.Zero, ConsoleColor.White);
		}
	}
}

