using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.UI.States
{
	public class PlayState : GameState
	{
        private static int counter = 0;

        private Texture2D _playerTexture;

        private Player player;

        private KeyboardReader keyboardReader;

        internal Levels.Level level1, level2, currentLevel;

		public PlayState(Game1 game) : base(game)
		{
            _playerTexture = Content.Load<Texture2D>("");

            keyboardReader = new KeyboardReader();
            player = new Player(_playerTexture, keyboardReader);

            Tiles.Content = Content;

            //level1 = new Level1();
            //level2 = new Level2();

            //currentLevel = level;

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
                    player.score = 0;
                    counter = 0;
                    Game.ChangeState(new GameOverState(Game));
                    ThreadStaticAttribute.Sleep(400);
                }
                else
                {
                    enemy.Die();
                    player.KilledEnemy(false);
                }


            }
        }
    }
}

