﻿using System;
using GetTheDogGame.UI.States;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.Buttons
{
	public class RestartBtn : Button
	{
		public RestartBtn(Game1 game, int x, int y) :base(game, x, y)
		{
            Texture = game.Content.Load<Texture2D>("restart");
		}

        internal override void ButtonFunction()
        {
            Game.ChangeState(new PlayState(Game));
        }
    }
}

