using GetTheDogGame.UI.Buttons;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetTheDogGame.UI.States
{
    public class WinnerState : GameState
    {
        private Texture2D _backgroundTexture;
        private Background _background;

        public WinnerState(Game1 game) : base(game)
        {
            Thread.Sleep(200);

            _backgroundTexture = Content.Load<Texture2D>("gamewin");
            _background = new Background(_backgroundTexture);

            Buttons.Add(new MenuBtn(game, 610, 400));
            Buttons.Add(new RestartBtn(game, 610, 400));
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
