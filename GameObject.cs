using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/**
* Game objects are self contained that have all the required game logic.
*
* Game objects are placed into a scene that is used to managem them.
* 
* The game object class should be inherited by other objects that will implement the required control and rendering code.
*/
internal abstract class GameObject
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
     * Position of the object.
     */
    public Vector2 Position = new Vector2(0.0f, 0.0f);

    /**
     * Scale of the object.
     */
    public Vector2 Scale = new Vector2(1.0f, 1.0f);

    /**
     * Center point of the object.
     * 
     * Position and rotation are relative to the center point.
     */
    public Vector2 Center = new Vector2(0.0f, 0.0f);

    /**
     * Rotation of the object.
     */
    public float Rotation = 0.0f;

    /**
     * Scene where this object belongs.
     */
    public Scene Scene = null;


    /**
     * Initialize the game object. Load resources if necessary.
     * 
     * Called when the object is added to the scene.
     */
    abstract public void Initialize(GraphicsDevice graphicsDevice);

    /**
     * Update logic of the game object.
     * 
     * Include user interactions and interactions between objects.
     */
    abstract public void Update(GameTime time);

    /**
     * Draw the object to the screen. The object is rendered in a sprite batch.
     */
    abstract public void Render(GameTime time, SpriteBatch spriteBatch);

    /**
     * Remove the object from scene, and cleanup any resources no longer being used.
     */
    public void Destroy() {
        this.Scene.Remove(this);
    }
}