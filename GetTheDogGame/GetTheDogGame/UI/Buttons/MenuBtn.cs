using System;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.Buttons
{
	public class MenuBtn : Button
	{
		public MenuBtn(Game1 game, int x, int y) : base(game, x, y)
		{
            Texture = game.Content.Load<Texture2D>("");
		}

        internal override void ButtonFunction()
        {
            //Game.ChangeState(new MainMenu(Game));
        }
    }
}

