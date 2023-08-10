using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GetTheDogGame.Interfaces
{
	//Elke game object zal dit interface implementeren 
	public interface IGameObject
	{
		void Update(GameTime gameTime);
		void Draw(SpriteBatch spriteBatch);
	}
}

