using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

enum PowerupType {
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
        texture[PowerupType.BombTime] = ;
        texture[PowerupType.FirePower] = ;
        texture[PowerupType.Speed] = ;


        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/" + texture[this.Type]);
    }

    public override void Update(GameTime time){}
}