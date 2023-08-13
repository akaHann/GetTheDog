using System;
using GetTheDogGame.Objects;
using GetTheDogGame.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GetTheDogGame.Levels
{
    public abstract class Level
    {
        public Map map;
        public List<Dog> dogs;
        public int MaxScore
        {
            get { return enemies.Count + dogs.Count; }
        }

        public Texture2D _backgroundTexture, _spikesTexture, _zombieTexture, _catTexture;
        internal Background background;
        internal List<Enemy> enemies;
        internal ContentManager _content;
        internal GraphicsDevice _graphicsDevice;

        public Level(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _content = content;
            _graphicsDevice = graphicsDevice;

            enemies = new List<Enemy>();
            dogs = new List<Dog>();

            _catTexture = _content.Load <Texture2D>("cat");
            _zombieTexture = _content.Load<Texture2D>("zombie");
            _spikesTexture = _content.Load<Texture2D>("spikes");
            _backgroundTexture = _content.Load<Texture2D>("background");
            GenerateLevel();
        }

        public abstract void GenerateLevel();

        public void Update(GameTime gameTime)
        {
            foreach (var enemy in enemies)
                enemy.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            map.Draw(spriteBatch);
            foreach (var enemy in enemies)
                enemy.Draw(spriteBatch);
            foreach (var dog in dogs)
                dog.Draw(spriteBatch);
        }
    }


}

