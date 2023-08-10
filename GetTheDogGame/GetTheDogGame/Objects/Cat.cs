using System;
using GetTheDogGame.Animations;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Objects
{
	public class Cat : Enemy
	{
        Animation runAnimation, attackAnimation, deathAnimation;

        public Cat(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            base.width = 32;
            base.height = 32;
            base.scale = 4;

            MakeAnimations();

            animationManager = new AnimationManager();
            animationManager.CurrentAnimation = runAnimation;
        }

        internal override void MakeAnimations()
        {
            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 0, 11);

            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 1, 4);

            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 2, 7);
        }
    }
}

