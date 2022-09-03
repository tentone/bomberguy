using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/**
 * Animated sprite is used to render a texture atlas with animation as drawing board.
 * 
 * The animation is played from the top left corner to the bottom right corner.
 */
class AnimatedSprite : GameObject
{
    /**
     * Rows of the atlas (evenly spaced).
     */
    public int Rows;

    /**
     * Columns of the atlas (evenly spaced).
     */
    public int Columns;

    /**
     * Number of frames of the animation.
     *
     * Can be less that the grid size of the atlas.
     */
    private int frames;

    /**
     * Current animation frame
     */
    private int currentFrame;

    public AnimatedSprite(Texture2D texture, int rows, int columns, int frames = 0)
    {
        this.Texture = texture;
        this.Rows = rows;
        this.Columns = columns;
        this.currentFrame = 0;
        this.frames = frames == 0 ? Rows * Columns : frames;
    }

    public override void Update(GameTime time)
    {
        this.currentFrame++;
        if (this.currentFrame == this.frames)
        {
            this.currentFrame = 0;
        }
    }

    public override void Render(GameTime time, SpriteBatch spriteBatch)
    {
        int width = this.Texture.Width / this.Columns;
        int height = this.Texture.Height / this.Rows;
        int row = this.currentFrame / this.Columns;
        int column = this.currentFrame % this.Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Vector2 scale = new Vector2(this.Size.X / sourceRectangle.Width, this.Size.Y / sourceRectangle.Height);

        spriteBatch.Draw(this.Texture, this.Position, sourceRectangle, Color.White, this.Rotation, this.Origin, scale, SpriteEffects.None, 0);
    }
}
