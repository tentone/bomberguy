using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

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

    /**
     * Textures shared across all object instances.
     */
    public static Texture2D[] Textures = new Texture2D[3];

    public Block(bool destructible, bool explosive)
    {
        this.Destructible = destructible;
        this.Explosive = explosive;
    }


    public static void LoadTextures(GraphicsDevice graphicsDevice)
    {
        string[] textures = { "crate_01.png", "crate_42.png", "crate_43.png" };
        for (int i = 0; i < textures.Length; i++)
        {
            Block.Textures[i] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/" + textures[i]);
        }
    }

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = this.Destructible ? this.Explosive ? Block.Textures[2] : Block.Textures[1] : Block.Textures[0];


        this.Body = this.Scene.World.CreateRectangle(this.Size.X - 0.1f, this.Size.Y - 0.1f, this.Rotation, this.Position, 0.0f, this.Destructible && this.Destructible ? BodyType.Dynamic : BodyType.Static);
        this.Body.FixedRotation = false;
        this.Body.Tag = this;
        if (this.Destructible)
        {
            this.Body.Mass = this.Explosive ? 10.0f : 100000.0f;
            this.Body.OnCollision += this.OnCollision;
        }
    }

    /**
     * Process collisions withs other objects in the scene.
     */
    public bool OnCollision(Fixture self, Fixture other, Contact contact)
    {
        if (this.Destructible)
        {
            Body body = other.Body;
            if (body.Tag is Fire)
            {
                this.Destroy();
            }
        }

        return true;
    }

    public override void Destroy()
    {
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