using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Fire : SpriteGameObject
{
    /**
     * Time left until the bomb fire disapears in seconds.
     */
    public float TimeLeft = 1.0f;

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/explosion.png");
    }

    public override void Update(GameTime time)
    {
        float delta = (float)time.ElapsedGameTime.TotalSeconds;
        this.TimeLeft -= delta;
        if (this.TimeLeft < 0)
        {
            this.Scene.Remove(this);
        }
    }
}