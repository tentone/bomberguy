using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

/**
 * Type of the power up.
 */
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

    /**
     * Textures shared across all object instances.
     */
    public static Dictionary<PowerupType, Texture2D> Textures = new Dictionary<PowerupType, Texture2D>();

    public static void LoadTextures(GraphicsDevice graphicsDevice)
    {
        Dictionary<PowerupType, string> texture = new Dictionary<PowerupType, string>();
        texture[PowerupType.BombTime] = "environment_05.png";
        texture[PowerupType.FirePower] = "environment_08.png";
        texture[PowerupType.Speed] = "environment_10.png";


        foreach (KeyValuePair<PowerupType, string> entry in texture)
        {
            Powerup.Textures[entry.Key] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/" + entry.Value);
        }
    }

    public Powerup(PowerupType type)
    {
        this.Type = type;
    }

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = Powerup.Textures[this.Type];
    }

    public override void Update(GameTime time)
    {
        base.Update(time);

        float timer = (float)time.TotalGameTime.TotalSeconds;
        this.Scale = (float)(Math.Cos(timer * 5.0f)) * 0.2f + 0.8f;
    }

    /**
     * Apply powerup effect to the player.
     */
    public void ApplyPowerup(Player player)
    {
        if (this.Type == PowerupType.BombTime)
        {
            player.BombTime -= 1.0f;
        }
        else if (this.Type == PowerupType.FirePower)
        {
            player.Power += 1;
        }
        else if (this.Type == PowerupType.Speed)
        {
            player.Speed += 30.0f;
        }
    }
}