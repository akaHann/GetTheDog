using System;
using System.Threading;
using GetTheDogGame.Levels;
using GetTheDogGame.Objects;
using GetTheDogGame.Others;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.States
{
	public class PlayState : GameState
	{
        Game1 _game;
        private static int counter = 0;

        private Texture2D _playerTexture;

        private Player player;

        private KeyboardReader keyboardReader;

        internal Levels.Level level1, level2, currentLevel;

		public PlayState(Game1 game) : base(game)
		{
            _game = game;
                _playerTexture = Content.Load<Texture2D>("sprite");

            keyboardReader = new KeyboardReader();
            player = new Player(_playerTexture, keyboardReader);

            Tiles.Content = Content;

            level1 = new FirstLevel(game.GraphicsDevice, Content);
            level2 = new SecondLevel(game.GraphicsDevice, Content);

            currentLevel = level1;

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            currentLevel.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            currentLevel.Update(gameTime);
            player.Update(gameTime);

            foreach (CollisionTiles tile in currentLevel.map.CollisionTiles)
            {
                player.Collision(tile.Rectangle, currentLevel.map.Width, currentLevel.map.Height);
            }

            foreach (var enemy in currentLevel.enemies)
            {
                //TODO: spikes kunnen niet dood
                if (player.rectangle.TouchTopOf(enemy.rectangle))
                {
                    enemy.Die();
                    player.KilledEnemy(true);
                }
                else if (!keyboardReader.ReadAttack())
                {
                    Player.Score = 0;
                    counter = 0;
                    //_game.ChangeState(new GameOverState(_game));
                    //ThreadStaticAttribute.Sleep(400);
                }
                else
                {
                    enemy.Die();
                    player.KilledEnemy(false);
                }

                if (Player.Score == currentLevel.MaxScore)
                {
                    counter++;
                    Player.Score = 0;
                    if(counter > 1)
                    {
                        //_game.ChangeState(new WinnerState(_game));
                        counter = 0;
                    }
                    else
                    {
                        _game.ChangeState(new PlayState(_game) { currentLevel = level2 });
                    }

                    Thread.Sleep(400);
                }
            }
            foreach (var dog in currentLevel.dogs)
            {
                if (player.rectangle.Intersects(dog.rectangle))
                {
                    dog.Collected();
                }
            }
        }
    }
}

