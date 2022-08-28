using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Player : SpriteGameObject
{
    /**
     * Speed at wich the player moves around.
     */
    public float Speed = 1.0f;

    /**
     * Power (range) of the bombs dropped by the player.
     */
    public int Power = 1;

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/bomb.png");
    }


    public override void Update(GameTime time)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            this.Position.X -= this.Speed;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            this.Position.X += this.Speed;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            this.Position.Y -= this.Speed;
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            this.Position.Y += this.Speed;
        }


        //this.Position.X += 0.1f;
    }



}