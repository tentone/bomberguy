using Microsoft.Xna.Framework.Input;

/**
* Interface to define a player controller.
* 
* Can be used to implement keyboard controlls or AI based controlls.
*/
interface PlayerControls
{
    /**
     * Move the player UP
     */
    public bool up();

    /**
     * Move the player Down
     */
    public bool down();

    /**
      * Move the player Left
      */
    public bool left();

    /**
     * Move the player Right
     */
    public bool right();

    /**
     * Place a bomb.
     */
    public bool bomb();
}



class PlayerKeyboardControls : PlayerControls
{
    public static Keys[] KeysP1 = { Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.M };

    public static Keys[] KeysP2 = { Keys.W, Keys.S, Keys.A, Keys.D, Keys.Q };

    /**
     * List of keys to use in this player controller
     */
    public Keys[] keys = PlayerKeyboardControls.KeysP1;

    public PlayerKeyboardControls(Keys[] keys)
    {
        this.keys = keys;
    }

    public bool up() { return Keyboard.GetState().IsKeyDown(this.keys[0]); }
    public bool down() { return Keyboard.GetState().IsKeyDown(this.keys[1]); }
    public bool left() { return Keyboard.GetState().IsKeyDown(this.keys[2]); }
    public bool right() { return Keyboard.GetState().IsKeyDown(this.keys[3]); }
    public bool bomb() { return Keyboard.GetState().IsKeyDown(this.keys[4]); }
}