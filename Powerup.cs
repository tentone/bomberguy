using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

enum PowerupType
{
    BombTime,
    FirePower,
    Speed
}

class Powerup : SpriteGameObject
{
    /**
     * Type of the powerup.
     */
    public PowerupType Type = PowerupType.BombTime;

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        Dictionary<PowerupType, string> texture = new Dictionary<PowerupType, string>();
        texture[PowerupType.BombTime] = "environment_05.png";
        texture[PowerupType.FirePower] = "environment_08.png";
        texture[PowerupType.Speed] = "environment_10.png";

        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/Environment/" + texture[this.Type]);
    }
}