using System;
using GetTheDogGame.Animations;
using GetTheDogGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Objects
{
	public abstract class Enemy : IGameObject, IDieable
	{
		public bool isAlive { get; private set; } = true;
		public Rectangle rectangle;
		internal Vector2 position, speed;
		internal SpriteEffects spriteEffects = SpriteEffects.None;

		internal Texture2D texture;

		internal AnimationManager animationManager;

		private int start, end;
		internal int width, height, scale;

		public Enemy(Texture2D texture, int startPos, int endPos, int height)
		{
			this.texture = texture;
			start = startPos;
			end = endPos;

			speed = new Vector2(3, 3);
			position = new Vector2(startPos, 700 - height);

			animationManager = new AnimationManager();
		}

        public void Update(GameTime gameTime)
        {
			if (isAlive)
			{
				Move();
				rectangle = new Rectangle((int)position.X + 50, (int)position.Y+height, 32 - 10, 32);
				animationManager.CurrentAnimation.Update(gameTime);
			}
        }

		internal abstract void MakeAnimations();

		public virtual void Move()
		{
			position.X += speed.X;

			if(position.X >= end)
			{
				speed.X *= -1;
				spriteEffects = SpriteEffects.FlipHorizontally;

			}

			if(position.X <= start)
			{
				speed.X *= -1;
				spriteEffects = SpriteEffects.None;
			}
		}


        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
				spriteBatch.Draw(texture, position, animationManager.CurrentAnimation.CurrentFrame.srcRectangle,
					Color.White, 0f, new Vector2(0, 0), scale, spriteEffects, 0f);

            }
        }

        public void Die()
        {
			isAlive = false;
			rectangle.Y = -500;
			Player.Score += 1;
        }
    }
}

