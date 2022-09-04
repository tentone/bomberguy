using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;

class Fire : GameObject
{
    /**
     * Time left until the bomb fire disapears in seconds.
     */
    public float TimeLeft = 1.0f;

    /**
     * Texture shared across all object instances.
     */
    public static Texture2D FireTexture = null;

    public static void LoadTextures(GraphicsDevice graphicsDevice)
    {
        Fire.FireTexture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/explosion.png");
    }

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = Fire.FireTexture;

        this.Body = this.Scene.World.CreateRectangle(this.Size.X, this.Size.Y, this.Rotation, this.Position, 0.0f, BodyType.Static);
        this.Body.Tag = this;
    }


    public override void Update(GameTime time)
    {
        base.Update(time);

        float delta = (float)time.ElapsedGameTime.TotalSeconds;
        this.TimeLeft -= delta;
        if (this.TimeLeft < 0)
        {
            this.Scene.Remove(this);
        }
    }
}