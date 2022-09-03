using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

enum PowerupType
{
    /**
     * Reduce the time between each bomb.
     */
    BombTime,
    /**
     * Improve the firepower range of the bombs
     */
    FirePower,
    /**
     * Increase the player movement speed.
     */
    Speed
}

/**
 * Powerups enhance the player capabilities.
 */
class Powerup : GameObject
{
    /**
     * Type of the powerup.
     */
    public PowerupType Type = PowerupType.BombTime;

    public Powerup(PowerupType type)
    {
        this.Type = type;
        this.Origin = new Vector2(15.0f, 15.0f);
    }

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        Dictionary<PowerupType, string> texture = new Dictionary<PowerupType, string>();
        texture[PowerupType.BombTime] = "environment_05.png";
        texture[PowerupType.FirePower] = "environment_08.png";
        texture[PowerupType.Speed] = "environment_10.png";

        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/" + texture[this.Type]);
    }

    public override void Update(GameTime time)
    {
        float timer = (float)time.TotalGameTime.TotalSeconds;
        this.Scale = (float)(Math.Cos(timer * 5.0f)) * 0.2f + 0.8f;
    }

}