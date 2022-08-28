using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Player : GameObject
{
    public override void Initialize(GraphicsDevice graphicsDevice)
    {
    }

    public override void Render(GameTime time, SpriteBatch spriteBatch)
    {
    }

    public override void Update(GameTime time)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {

        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {

        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {

        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {

        }
    }
}