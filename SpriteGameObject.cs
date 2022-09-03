using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class SpriteGameObject : GameObject
{
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
    public Vector2 Origin = new Vector2(0.0f, 0.0f);

    /**
     * Scale of the object applied after the size.
     */
    public float Scale = 1.0f;

    /**
     * Rotation of the object.
     */
    public float Rotation = 0.0f;

    public override void Render(GameTime time, SpriteBatch spriteBatch)
    {
        Vector2 scale = new Vector2(this.Size.X / this.Texture.Width, this.Size.Y / this.Texture.Height) * this.Scale;

        Vector2 origin = new Vector2(this.Origin.X / this.Size.X * this.Texture.Width, this.Origin.Y / this.Size.Y * this.Texture.Height);

        Vector2 position = new Vector2(this.Position.X + this.Origin.X, this.Position.Y + this.Origin.Y);

        spriteBatch.Draw(this.Texture, position, new Rectangle(0, 0, this.Texture.Width, this.Texture.Height), Color.White, this.Rotation, origin, scale, SpriteEffects.None, 0);
    }
}