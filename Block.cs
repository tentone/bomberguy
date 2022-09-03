using Microsoft.Xna.Framework.Graphics;

class Block : GameObject
{
    /**
     * If true the is destructible when it collides with fire.
     */
    public bool Destructible = false;

    /**
     * If the crate is exploside it will explode when a bomb destroys it.
     */
    public bool Explosive = false;

    public Block(bool destructible, bool explosive)
    {
        this.Destructible = destructible;
        this.Explosive = explosive;
    }

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        string fname = "crate_01.png";
        if (this.Destructible)
        {
            fname = "crate_42.png";
            if (this.Explosive)
            {
                fname = "crate_43.png";
            }
        }

        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/" + fname);
    }

    public override void Destroy() {
        base.Destroy();

        if (this.Explosive)
        {
            this.Explode();
        }
    }

    /**
     * Explode the block and create fire elements.
     */
    public void Explode()
    {
        var fire = new Fire();
        fire.Position.X = this.Position.X;
        fire.Position.Y = this.Position.Y;
        this.Scene.Add(fire);

        var l = new Fire();
        l.Position.X = this.Position.X + 30;
        l.Position.Y = this.Position.Y;
        this.Scene.Add(l);

        var r = new Fire();
        r.Position.X = this.Position.X - 30;
        r.Position.Y = this.Position.Y;
        this.Scene.Add(r);

        var u = new Fire();
        u.Position.Y = this.Position.Y + 30;
        u.Position.X = this.Position.X;
        this.Scene.Add(u);

        var d = new Fire();
        d.Position.Y = this.Position.Y - 30;
        d.Position.X = this.Position.X;
        this.Scene.Add(d);
    }
}