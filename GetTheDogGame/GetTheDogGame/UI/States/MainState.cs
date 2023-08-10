using System;
using System.Threading;
using GetTheDogGame.UI.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.States
{
	public class MainState : GameState
	{
        private Texture2D _backgroundTexture;
        private Background _background;

		public MainState(Game1 game) : base(game)
		{
            Thread.Sleep(200);

            _backgroundTexture = Content.Load<Texture2D>("mainmenu");
            _background = new Background(_backgroundTexture);

            Buttons.Add(new StartBtn(game, 610, 400));
            Buttons.Add(new CloseBtn(game, 610, 480));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _background.Draw(spriteBatch);

            foreach (var button in Buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in Buttons)
            {
                button.Update(gameTime);
            }
        }
    }
}

