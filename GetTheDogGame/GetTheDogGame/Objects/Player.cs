using System;
using GetTheDogGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Objects
{
	public class Player : IGameObject
	{
        private Texture2D playerTexture;
        private Vector2 position;
        private Vector2 speed;
        private int scale;
        private int width;
        private int height;
        private bool hasJumped, reachedTop;
        private SpriteEffects spriteEffects = SpriteEffects.None;
        private AnimationManager animationManager;
        private KeyboardReader keyboardReader;

        public static int Score { get; set; }
        public bool Jump { get; set; }


        public Player(Texture2D texture, IInputReader inputReader)
		{
            playerTexture = texture;
            this.keyboardReader = (KeyboardReader)inputReader;

            speed = new Vector2(8, 5);
            position = new Vector2(50, 400);
            scale = 1;
            width = 64;
            height = 64;
            hasJumped = true;

            MakeAnimations();
            animationManager = new AnimationManager();
            SetCurrentAnimation(staticAnimation);
		}

        private void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }

        private void CheckAnimationToSet(bool moving, bool attack)
        {
            if (keyboardReader.Movement.Horizontal == Others.HorizontalDirection.Left)
                spriteEffects = SpriteEffects.FlipHorizontally;
            if (keyboardReader.Movement.Horizontal == Others.HorizontalDirection.Right)
                spriteEffects = SpriteEffects.None;
            if (moving)
                SetCurrentAnimation(runAnimation);
            else
                SetCurrentAnimation(staticAnimation);
            if (attack)
                SetCurrentAnimation(attackAnimation);
            if (hasJumped)
                SetCurrentAnimation(jumpAnimation);
        }
        private void Move()
        {
            var direction = keyboardReader.ReadInput();
            direction *= speed;
            position += direction;
            Box();
            Jump();
        }

        private void Box()
        {
            int rightBorder = 1400 - width * scale;
            position.X = MathHelper.Clamp(position.X, 0, rightBorder);
        }

        private void Jump()
        {
            bool shouldJump = keyboardReader.Jump;

            if (shouldJump && !hasJumped && !reachedTop)
            {
                hasJumped = true;
                position.Y -= 3f;
                speed.Y = -6f;
            }

            speed.Y = MathHelper.Min(speed.Y + 0.4f, 13);
            position.Y = MathHelper.Clamp(position.Y, 0, 787 - height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, position, animationManager.CurrentAnimation.CurrentFrame.srcRectangle,
                Color.White, 0, Vector2.Zero, scale, spriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            CheckAnimationToSet(keyboardReader.ReadMovement(), keyboardReader.ReadAttack());
            animationManager.CurrentAnimation.Update(gameTime);
            Move();
        }

        public void KilledEnemy(bool onTop)
        {
            if (onTop)
                speed.Y = -5;
        }
    }
}

