/**
 * Scene is a collections of rendering objects that are drawn into screen.
 */
internal class Scene
{
    public GameObject[] objects = new GameObject[0];

    /**
     * Add a new game objec to the scene.
     */
    public void Add(GameObject obj) {
           
    }

    /**
     * Remove a game object from the scene.
     * 
     * The object is destroyed before removal.
     */
    public void Remove(GameObject obj) {
    }
}