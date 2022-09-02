using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class SpriteGameObject : GameObject
{
    /**
     * Texture used by the sprite object.
     */
    public Texture2D Texture;

    /**
     * Position of the object.
     */
    public Vector2 Position = new Vector2(0.0f, 0.0f);

    /**
     * Size of the object.
     */
    public Vector2 Size = new Vector2(30.0f, 30.0f);

    /**
     * Center point of the object.
     * 
     * Position and rotation are relative to the center point.
     */
    public Vector2 Origin = new Vector2(0.0f, 0.0f);

    /**
     * Rotation of the object.
     */
    public float Rotation = 0.0f;

    public override void Render(GameTime time, SpriteBatch spriteBatch)
    {
        Vector2 scale = new Vector2(this.Size.X / this.Texture.Width, this.Size.Y / this.Texture.Height);

        spriteBatch.Draw(this.Texture, this.Position, null, Color.White, this.Rotation, this.Origin, scale, SpriteEffects.None, 0);
    }
}