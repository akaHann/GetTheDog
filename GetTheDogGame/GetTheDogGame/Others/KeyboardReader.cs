using GetTheDogGame.Interfaces;
using GetTheDogGame.Others;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GetTheDogGame.Others
{
    public class KeyboardReader : IInputReader
    {
        public Movement movement { get; private set; } = new Movement();
        public bool Jump { get; private set; }

        private int speed = 1;


        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = new Vector2(0, 2);

            if (state.IsKeyDown(Keys.Left))
            {
                if (this.ReadMovement())
                {
                    direction.X = -speed;
                    movement.Horizontal = HorizontalDirection.Left;
                }
            }
            if (state.IsKeyDown(Keys.Right))
            {
                if (this.ReadMovement())
                {
                    direction.X = speed;
                    movement.Horizontal = HorizontalDirection.Right;
                }
            }
            if (state.IsKeyDown(Keys.Up))
            {
                Jump = true;
                movement.Vertical = VerticalDirection.Up;
            }
            else
            {
                Jump = false;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                movement.Vertical = VerticalDirection.Down;
            }
            return direction;
        }

        public bool ReadMovement()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left) && state.IsKeyDown(Keys.Right)) return false;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Right)) return true;

            return false;
        }

        public bool ReadAttack()
        {
            KeyboardState state = Keyboard.GetState();
            bool attack = false;

            if (state.IsKeyDown(Keys.Space))
            {
                attack = true;
            }

            return attack;
        }
    }
}
