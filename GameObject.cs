using Microsoft.Xna.Framework;

/**
* Game objects are self contained that have all the required game logic.
*
* Game objects are placed into a scene that is used to managem them.
* 
* The game object class should be inherited by other objects that will implement the required control and rendering code.
*/
internal abstract class GameObject
{
    public bool Visible = true;

    public Vector2 position = new Vector2(0.0f, 0.0f);

    public Vector2 scale = new Vector2(1.0f, 1.0f);

    public float rotation = 0.0f;

    public void Destroy() { }
    public void Update() { }
    public void Render() { }
}