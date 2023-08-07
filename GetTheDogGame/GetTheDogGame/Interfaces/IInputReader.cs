using Microsoft.Xna.Framework;

namespace GetTheDogGame.Interfaces
{
	public interface IInputReader
	{
		Vector2 ReadInput();

		bool ReadMovement();

		bool ReadAttack();
	}
}

