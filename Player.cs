using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Player : GameObject
{
    private Texture2D Texture;

    private Vector2 Size = new Vector2(30, 30);


    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/bomb.png");

        // this.Texture.Width
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


        //this.Position.X += 0.1f;
    }

    public override void Render(GameTime time, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(this.Texture, this.Position, new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y), Color.White, this.Rotation, this.Origin, this.Scale, SpriteEffects.None, 0);
    }

}