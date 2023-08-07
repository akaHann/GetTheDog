using System.Collections.Generic;
using GetTheDogGame.UI.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.States
{
	public abstract class GameState
	{
		protected Game Game { get; }
		protected GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
		protected ContentManager Content => Game.Content;
		internal List<Button> Buttons { get; } = new List<Button>();

		public GameState(Game1 game)
		{
			Game = game;
		}

		public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
		public abstract void Update(GameTime gameTime);
	}
}

