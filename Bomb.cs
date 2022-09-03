using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        this.Origin = new Vector2(15.0f, 15.0f);
    }

    public override void Update(GameTime time)
    {
        float delta = (float)time.ElapsedGameTime.TotalSeconds;
        this.TimeLeft -= delta;
        if (this.TimeLeft < 0)
        {
            this.Scene.Remove(this);
            this.Explode();
        }

        // Animate bomb scale and rotation
        float total = (float)time.TotalGameTime.TotalSeconds;
        this.Rotation = (float)Math.Cos(total) * 0.5f;
        this.Scale = (float)(Math.Cos(total * 3.0f)) * 0.1f + 0.9f;
    }

    /**
     * Explode the bomb and create fire elements.
     * 
     * Fire will kill the player and destroy any walls
     */
    public void Explode()
    {
        var fire = new Fire();
        fire.Position.X = this.Position.X;
        fire.Position.Y = this.Position.Y;
        this.Scene.Add(fire);

        for (int i = 1; i <= Power; i++)
        {
            var l = new Fire();
            l.Position.X = this.Position.X + i * 30;
            l.Position.Y = this.Position.Y;
            this.Scene.Add(l);

            var r = new Fire();
            r.Position.X = this.Position.X - i * 30;
            r.Position.Y = this.Position.Y;
            this.Scene.Add(r);

            var u = new Fire();
            u.Position.Y = this.Position.Y + i * 30;
            u.Position.X = this.Position.X;
            this.Scene.Add(u);

            var d = new Fire();
            d.Position.Y = this.Position.Y - i * 30;
            d.Position.X = this.Position.X;
            this.Scene.Add(d);
        }
    }
}
