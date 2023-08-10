using System;
using GetTheDogGame.Animations;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Objects
{
    class Zombie : Enemy
    {
        Animation runAnimation, attackAnimation, deathAnimation;

        public Zombie(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            base.speed.X = 2;
            base.width = 64;
            base.height = 64;
            base.scale = 2;

            MakeAnimations();

            animationManager.CurrentAnimation = runAnimation;
        }

        internal override void MakeAnimations()
        {
            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 0, 9);

            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 1, 8);

            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 2, 4);
        }
    }

}

