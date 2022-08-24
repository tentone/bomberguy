
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
     * Add a new game objec to the scene.
     */
    public void Add(GameObject obj) {
        this.objects.Add(obj);
    }

    /**
     * Remove a game object from the scene.
     * 
     * The object is destroyed before removal.
     */
    public void Remove(GameObject obj) {
        this.objects.Remove(obj);
    }

    /**
     * Initialize objects in the scene.
     */
    public void Initialize(GraphicsDevice graphicsDevice)
    {
        foreach (GameObject obj in this.objects)
        {
            obj.Initialize(graphicsDevice);
        }
    }
       
    /**
     * Update the state of objects in the scene.
     */
    public void Update(GameTime time) {
        foreach (GameObject obj in this.objects)
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