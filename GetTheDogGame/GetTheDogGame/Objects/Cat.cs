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
            base.height = 34;
            base.scale = 3;

            MakeAnimations();

            animationManager = new AnimationManager();
            animationManager.CurrentAnimation = runAnimation;
        }

        internal override void MakeAnimations()
        {
            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 1, 4);
        }
    }
}

