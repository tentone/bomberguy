using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class Player : SpriteGameObject
{
    /**
     * Speed at wich the player moves around.
     */
    public float Speed = 100.0f;

    /**
     * Power (range) of the bombs dropped by the player.
     */
    public int Power = 1;

    /**
     * Time between bombs for the player.
     */
    public float BombTime = 3.0f;

    /**
     * Time until the next bomb can be planted.
     */
    private float NextBombTime = 0.0f;

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/Player/player_21.png");
    }

    public override void Update(GameTime time)
    {
        float delta = (float)time.ElapsedGameTime.TotalSeconds;

        // Move the player around
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            this.Position.X -= this.Speed * delta;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            this.Position.X += this.Speed * delta;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            this.Position.Y -= this.Speed * delta;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            this.Position.Y += this.Speed * delta;
        }

        // Decrease timer of next bomb placement
        if (this.NextBombTime > 0)
        {
            this.NextBombTime -= delta;
        }


        if (this.NextBombTime <= 0 && Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            Bomb bomb = new Bomb();
            bomb.Power = this.Power;
            bomb.Position = new Vector2(this.Position.X, this.Position.Y);
            bomb.Position.X = (float)Math.Round(bomb.Position.X / 30.0f) * 30.0f;
            bomb.Position.Y = (float)Math.Round(bomb.Position.Y / 30.0f) * 30.0f;
            this.Scene.Add(bomb);

            this.NextBombTime = this.BombTime;
        }
    }



}