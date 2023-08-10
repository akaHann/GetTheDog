using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GetTheDogGame.UI.Buttons
{
	public class CloseBtn : Button
	{
		public CloseBtn(Game1 game, int x, int y) : base(game, x, y)
		{
            Texture = game.Content.Load<Texture2D>("quit");
		}

        internal override void ButtonFunction()
        {
            Game.Exit();
        }
    }
}

