using System;
using GetTheDogGame.UI.States;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.Buttons
{
	public class StartBtn : Button
	{
		public StartBtn(Game1 game, int x, int y) : base(game, x, y)
		{
            Texture = game.Content.Load<Texture2D>("play");
		}

        internal override void ButtonFunction()
        {
            Game.ChangeState(new PlayState(Game));
        }
    }
}

