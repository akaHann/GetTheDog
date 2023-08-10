using System;
using System.Drawing;
using GetTheDogGame.Animations;
using GetTheDogGame.Interfaces;
using GetTheDogGame.Others;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace GetTheDogGame.Objects
{
	public class Player : IGameObject
	{
        public Microsoft.Xna.Framework.Rectangle rectangle;
        private Texture2D playerTexture;
        private Vector2 position;
        private Vector2 speed;
        private int scale;
        private int width;
        private int height;
        private bool hasJumped, reachedTop;
        private SpriteEffects spriteEffects = SpriteEffects.None;
        private AnimationManager animationManager;
        Animation runAnimation, staticAnimation, attackAnimation, jumpAnimation, deathAnimation;
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

        private void MakeAnimations()
        {
            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 0, 11);
            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 1, 6);
            staticAnimation = new Animation();
            staticAnimation.AddSpriteRow(width, height, 2, 6);
            jumpAnimation = new Animation();
            jumpAnimation.AddSpriteRow(width, height, 3, 3);
            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 4, 3);
        }
        private void Move()
        {
            var direction = keyboardReader.ReadInput();
            direction *= speed;
            position += direction;
            Box();
            Jumping();
        }

        private void Box()
        {
            int rightBorder = 1400 - width * scale;
            position.X = MathHelper.Clamp(position.X, 0, rightBorder);
        }

        private void Jumping()
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

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            if (rectangle.TouchTopOf(newRectangle))
            {
                reachedTop = false;
                hasJumped = false;
                position.Y = newRectangle.Y - height;
                speed.Y = 0f;
            }
            else if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.Left - rectangle.Width + 20;
            }
            else if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.Right - 20;
            }
            else if (rectangle.TouchBottomOf(newRectangle))
            {
                reachedTop = true;
                speed.Y += 4f;
            }
        }
    }
}

