using System;
using GetTheDogGame.Animations;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Objects
{
	public class Spikes : Enemy
	{
		Animation staticAnimation;

		public Spikes(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
		{
			width = 32;
			base.height = 32;
			scale = 1;

			MakeAnimations();

			animationManager.CurrentAnimation = staticAnimation;
		}

        internal override void MakeAnimations()
        {
            staticAnimation = new Animation();
            staticAnimation.AddSpriteRow(width, height, 0, 1);
        }

        public override void Move()
        {
			position.X += 0;
        }
    }
}

