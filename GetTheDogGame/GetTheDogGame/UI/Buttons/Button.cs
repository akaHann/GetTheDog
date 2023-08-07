using System;
using GetTheDogGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GetTheDogGame.UI.Buttons
{
	public abstract class Button : IGameObject
	{
		protected Game1 Game { get; }
		protected GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
		protected ContentManager Content => Game.Content;
		internal Texture2D Texture { get; private set; }
		public Rectangle Rectangle { get; private set; }
		public bool Clicked { get; private set;}
		public Color Color { get; private set; } = Color.White;

		internal int Width { get; set; } = 175;
		internal int Height { get; set; } = 60;
		internal int X { get; private set; }
		internal int Y { get; private set; }

		public Button(Game1 game, int x, int y)
		{
			Game = game;
			SetPos(x, y);
			Rectangle = new Rectangle(X, Y, Width, Height);
		}

		public void SetSize(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public void SetPos(int x, int y)
		{
			X = x;
			Y = y;
		}

        public void Update(GameTime gameTime)
        {
			var mouseState = Mouse.GetState();
			var mousePosition = new Point(mouseState.X, mouseState.Y);

			if (Rectangle.Contains(mousePosition))
			{
				Color = Color.Gray;
				Clicked = mouseState.LeftButton == ButtonState.Pressed;
			}
			else
			{
				Color = Color.White;
				Clicked = false;
			}
			if (Clicked)
			{
				ButtonFunction();
			}
        }

		internal abstract void ButtonFunction();

        public void Draw(SpriteBatch spriteBatch)
        {
			spriteBatch.Draw(Texture, Rectangle, Color);
        }

	}
}

