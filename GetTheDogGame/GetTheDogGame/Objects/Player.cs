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
        bool hasJumped, reachedTop;
        public Rectangle rectangle;
        private Texture2D playerTexture;
        private Vector2 position;
        private Vector2 speed;
        private int scale, width, height;
        private SpriteEffects se = SpriteEffects.None;
        Animation runAnimation, attackAnimation, staticAnimation, jumpAnimation, deathAnimation;
        AnimationManager animationManager;
        public static int score { get; set; }
        public bool jump { get; set; }
        public KeyboardReader inputReader { get; set; }

        public Player(Texture2D texture, IInputReader inputReader)
        {
            playerTexture = texture;
            this.inputReader = (KeyboardReader)inputReader;

            speed = new Vector2(8, 5);
            position = new Vector2(50, 400);
            scale = 1;
            width = 64;
            height = 62;
            hasJumped = true;

            MakeAnimations();

            animationManager = new AnimationManager();
            SetCurrentAnimation(staticAnimation);

        }

        void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }

        public void Update(GameTime gameTime)
        {
            CheckAnimationToSet(inputReader.ReadMovement(), inputReader.ReadAttack());
            animationManager.CurrentAnimation.Update(gameTime);
            Move();
        }

        void CheckAnimationToSet(bool moving, bool attack)
        {
            if (inputReader.movement.Horizontal == HorizontalDirection.Left)
                se = SpriteEffects.FlipHorizontally;
            if (inputReader.movement.Horizontal == HorizontalDirection.Right)
                se = SpriteEffects.None;
            if (moving)
                SetCurrentAnimation(runAnimation);
            else
                SetCurrentAnimation(staticAnimation);
            if (attack)
                SetCurrentAnimation(attackAnimation);
            if (hasJumped)
                SetCurrentAnimation(jumpAnimation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int rotation = 0;
            spriteBatch.Draw(playerTexture, position, animationManager.CurrentAnimation.CurrentFrame.srcRectangle,
                Color.White, rotation, new Vector2(0, 0), scale, se, 0f);
        }

        private void Move()
        {
            var direction = inputReader.ReadInput();
            direction *= speed;
            position += direction;
            MoveX();
            Jump();
        }

        private void MoveX()
        {
            int widthBorder = 1400;
            int rightBorder = widthBorder - width * scale;
            if (position.X > rightBorder)
            {
                position.X = rightBorder;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
        }

        private void Jump()
        {
            jump = inputReader.Jump;
            if (speed.Y < 13)
                speed.Y += 0.4f;
            if (jump && !hasJumped && !reachedTop)
            {
                hasJumped = true;
                position.Y -= 3f;
                speed.Y = -6f;
            }

            if (position.Y + height > 787)
            {
                position.Y = 787 - height;
            }
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

            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width + 20;
            }

            if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + rectangle.Width - 40;
            }

            if (rectangle.TouchBottomOf(newRectangle))
            {
                reachedTop = true;
                speed.Y += 4f;
            }
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

        public void KilledEnemy(bool onTop)
        {
            if (onTop)
            {
                speed.Y = -5;
            }
        }
    }
}

