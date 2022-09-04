using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;


/**
* Game objects are self contained that have all the required game logic.
*
* Game objects are placed into a scene that is used to managem them.
* 
* The game object class should be inherited by other objects that will implement the required control and rendering code.
*/
class GameObject
{
    public static int ID = 0;

    /**
     * Identifier of the game object.
     * 
     * Each game object has its own unique ID.s
     */
    public int Id = ID++;

    /**
     * Visibility of the object. If false the object is not rendered.
     */
    public bool Visible = true;

    /**
     * Scene where this object belongs.
     */
    public Scene Scene = null;

    /**
     * Texture used by the sprite object.
     */
    public Texture2D Texture;

    /**
     * Position of the object in the screen.
     */
    public Vector2 Position = new Vector2(0.0f, 0.0f);

    /**
     * Size of the object in the screen.
     */
    public Vector2 Size = new Vector2(30.0f, 30.0f);

    /**
     * Center point of the object.
     * 
     * Position and rotation are relative to the center point.
     */
    public Vector2 Origin = new Vector2(15.0f, 15.0f);

    /**
     * Scale of the object applied after the size.
     */
    public float Scale = 1.0f;

    /**
     * Rotation of the object.
     */
    public float Rotation = 0.0f;

    /**
     * Physics simulation body.
     */
    public Body Body = null;

    /**
     * Check if this object is colliding with another object.
     */
    public bool Colliding(GameObject obj)
    {
        Rectangle a = new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);
        Rectangle b = new Rectangle((int)obj.Position.X, (int)obj.Position.Y, (int)obj.Size.X, (int)obj.Size.Y);

        return a.Intersects(b);
    }


    /**
     * Draw the object to the screen. The object is rendered in a sprite batch.
     */
    public virtual void Render(GameTime time, SpriteBatch spriteBatch)
    {
        Vector2 scale = new Vector2(this.Size.X / this.Texture.Width, this.Size.Y / this.Texture.Height) * this.Scale;

        Vector2 origin = new Vector2(this.Origin.X / this.Size.X * this.Texture.Width, this.Origin.Y / this.Size.Y * this.Texture.Height);

        Vector2 position = new Vector2(this.Position.X + this.Origin.X, this.Position.Y + this.Origin.Y);

        spriteBatch.Draw(this.Texture, position, new Rectangle(0, 0, this.Texture.Width, this.Texture.Height), Color.White, this.Rotation, origin, scale, SpriteEffects.None, 0);
    }

    /**
     * Initialize the game object. Load resources if necessary.
     * 
     * Called when the object is added to the scene.
     */
    public virtual void Initialize(GraphicsDevice graphicsDevice) { }

    /**
     * Update logic of the game object.
     * 
     * Include user interactions and interactions between objects.
     */
    public virtual void Update(GameTime time)
    {
        if (this.Body != null)
        {
            this.Position = this.Body.Position;
            this.Rotation = this.Body.Rotation;
        }
    }

    /**
     * Remove the object from scene, and cleanup any resources no longer being used.
     */
    public virtual void Destroy()
    {
        this.Scene.Remove(this);
    }
}