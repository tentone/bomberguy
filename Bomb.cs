using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Bomb : SpriteGameObject
{
    /**
     * Power (range) of the bombs dropped by the player.
     */
    public int Power = 1;

    /**
     * Time left until the bomb explodes in seconds.
     */
    public float TimeLeft = 3.0f;

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/bomb.png");
    }

    public override void Update(GameTime time)
    {
        float delta = (float)time.ElapsedGameTime.TotalSeconds;
        this.TimeLeft -= delta;
        if (this.TimeLeft < 0) {
            this.Scene.Remove(this);
            // TODO <EXPLODE BOMB>
        }
    }
}