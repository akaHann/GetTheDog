using System;
using GetTheDogGame.Interfaces;
using GetTheDogGame.Others;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GetTheDogGame
{
	public class KeyboardReader : IInputReader
	{
        public Movement Movement { get; } = new Movement();

        public bool Jump { get; private set; }

        private int speed = 1;

        public KeyboardReader()
		{
		}

        public bool ReadAttack()
        {
            KeyboardState state = Keyboard.GetState();

            return state.IsKeyDown(Keys.Space);
        }

        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (state.IsKeyDown(Keys.Left) && this.ReadMovement())
            {
                    direction.X = -speed;
                    Movement.Horizontal = HorizontalDirection.Left;
            }
            else if(state.IsKeyDown(Keys.Right) && ReadMovement())
            {
                direction.X = speed;
                Movement.Horizontal = HorizontalDirection.Right;
            }

            Jump = state.IsKeyDown(Keys.Up);
            Movement.Vertical = Jump ? VerticalDirection.Up : VerticalDirection.None;

            return direction;
        }

        public bool ReadMovement()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Right))
                return false;

            return state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right);
        }
    }
}

