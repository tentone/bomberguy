
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

/**
* Scene is a collections of rendering objects that are drawn into screen.
*/
internal class Scene
{   /**
     * List of the game objects in the scene.
     * 
     * They are updated and rendered by their order.
     */
    public List<GameObject> objects = new List<GameObject>();

    /**
     * Graphics device used by the scene objects.
     */
    public GraphicsDevice GraphicsDevice = null;

    public Scene(GraphicsDevice graphicsDevice)
    {
        this.GraphicsDevice = graphicsDevice;
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
            throw new System.Exception("Object cant have a scene set.");
        }
        obj.Scene = this;
        this.objects.Add(obj);
        obj.Initialize(this.GraphicsDevice);
    }

    /**
     * Remove a game object from the scene.
     * 
     * The object is destroyed before removal.
     */
    public void Remove(GameObject obj)
    {
        this.objects.Remove(obj);
    }

    /**
     * Update the state of objects in the scene.
     */
    public void Update(GameTime time)
    {
        GameObject[] objs = this.objects.ToArray();
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
        foreach (GameObject obj in this.objects)
        {
            obj.Render(time, spriteBatch);
        }
    }
}