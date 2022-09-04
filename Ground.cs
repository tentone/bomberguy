using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;


/**
 * Ground is just a visual tile in the playing field.
 */
class Ground: GameObject
{
    /**
     * Textures shared across all object instances.
     */
    public static Texture2D[] Textures = new Texture2D[2];

    public static void LoadTextures(GraphicsDevice graphicsDevice)
    {
        string[] textures = { "ground_a.png", "ground_b.png"};
        for (int i = 0; i < textures.Length; i++)
        {
            Ground.Textures[i] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/" + textures[i]);
        }
    }
}
