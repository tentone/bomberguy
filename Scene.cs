
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

    public void Update(GameTime time) {
        foreach (GameObject obj in this.objects)
        {
            obj.Update(time);
        }
    }

    public void Render(GameTime time, SpriteBatch spriteBatch)
    {
        foreach (GameObject obj in this.objects)
        {
            obj.Render(time, spriteBatch);
        }
    }
}