
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;

/**
* Scene is a collections of rendering objects that are drawn into screen.
*/
internal class Scene
{   /**
     * List of the game objects in the scene.
     * 
     * They are updated and rendered by their order.
     */
    public List<GameObject> Objects = new List<GameObject>();

    /**
     * Physics simulation world.
     */
    public World World = null;

    /**
     * Graphics device used by the scene objects.
     */
    public GraphicsDevice GraphicsDevice = null;

    public Scene(GraphicsDevice graphicsDevice)
    {
        this.GraphicsDevice = graphicsDevice;
        this.World = new World();
        this.World.Gravity = new Vector2(0.0f, 0.0f);
    }

    /**
     * Add a new game objec to the scene.
     * 
     * Sets the scene of the object and inializes the object.
     */
    public void Add(GameObject obj)
    {
        if (obj.Scene != null)
        {
            throw new System.Exception("Object cant have a scene defined.");
        }

        obj.Scene = this;
        this.Objects.Add(obj);
        obj.Initialize(this.GraphicsDevice);
    }

    /**
     * Remove a game object from the scene.
     * 
     * The object is destroyed before removal.
     */
    public void Remove(GameObject obj)
    {
        this.Objects.Remove(obj);
        if (obj.Body != null)
        {
            this.World.RemoveAsync(obj.Body);
        }
    }

    /**
     * Update the state of objects in the scene.
     */
    public void Update(GameTime time)
    {
        this.World.Step((float)time.ElapsedGameTime.TotalSeconds);

        GameObject[] objs = this.Objects.ToArray();
        foreach (GameObject obj in objs)
        {
            obj.Update(time);
        }
    }

    /**
     * Render objects to the screen.
     */
    public void Render(GameTime time, SpriteBatch spriteBatch)
    {
        foreach (GameObject obj in this.Objects)
        {
            obj.Render(time, spriteBatch);
        }
    }
}