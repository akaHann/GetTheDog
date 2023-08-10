using GetTheDogGame.UI.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GetTheDogGame;

public class Game1 : Game
{
    private GameState CurrentGameState;
    private GameState NextGameState;

    public void ChangeState(GameState newState)
    {
        NextGameState = newState;
    }

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 1400,
            PreferredBackBufferHeight = 787
        };

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        CurrentGameState = new MainMenu(this);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (NextGameState != null)
        {
            CurrentGameState = NextGameState;
            NextGameState = null;
        }

        CurrentGameState.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        CurrentGameState.Draw(gameTime, _spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}

