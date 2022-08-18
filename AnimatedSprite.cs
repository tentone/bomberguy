using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Animated sprite is used to render a texture atlas with animation as drawing board.
 * 
 * The animation is played from the top left corner to the bottom right corner.
 */
internal class AnimatedSprite
{
    /**
     * Texture that has the animation atlas.
     */
    public Texture2D Texture;
       
    /**
     * Rows of the atlas (evenly spaced).
     */
    public int Rows;

    /**
     * Columns of the atlas (evenly spaced).
     */
    public int Columns;

    private int currentFrame;

    /**
     * Number of frames of the animation.
     *
     * Can be less that the grid size of the atlas.
     */
    private int frames;

    public AnimatedSprite(Texture2D texture, int rows, int columns, int frames = 0)
    {
        this.Texture = texture;
        this.Rows = rows;
        this.Columns = columns;
        this.currentFrame = 0;
        this.frames = frames == 0 ? Rows * Columns : frames;
    }

    public void Update()
    {
        this.currentFrame++;
        if (this.currentFrame == this.frames)
        {
            this.currentFrame = 0;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        int width = this.Texture.Width / this.Columns;
        int height = this.Texture.Height / this.Rows;
        int row = this.currentFrame / this.Columns;
        int column = this.currentFrame % this.Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }
}
