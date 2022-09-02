using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block : SpriteGameObject
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
        string fname = "./assets/textures/crate_01.png";
        if (this.Destructible)
        {
            fname = "./assets/textures/crate_42.png";
            if (this.Explosive)
            {
                fname = "./assets/textures/crate_43.png";
            }
        }

        this.Texture = ContentUtils.Loadtexture(graphicsDevice, fname);
    }

    public override void Render(GameTime time, SpriteBatch spriteBatch)
    {
    }

    public override void Update(GameTime time)
    {
    }
}