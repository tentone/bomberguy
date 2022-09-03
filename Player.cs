using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using tainicom.Aether.Physics2D.Dynamics;

class Player : GameObject
{
    /**
     * Player controlls is used to command the player.
     */
    public PlayerControls Controls = new PlayerKeyboardControls();

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
     * Textures used by the player object
     */
    public Texture2D[] Textures = new Texture2D[4];

    /**
     * Time until the next bomb can be planted.
     */
    private float NextBombTime = 0.0f;

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Textures[0] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/Player/player_21.png");
        this.Textures[1] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/Player/player_01.png");
        this.Textures[2] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/Player/player_10.png");
        this.Textures[3] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/Player/player_12.png");

        this.Texture = this.Textures[0];

        this.Scale = 1.1f;

        this.Body = this.Scene.World.CreateRectangle(30.0f, 30.0f, 1.0f, this.Position, 0.0f, BodyType.Dynamic);
    }

    public override void Update(GameTime time)
    {
        float delta = (float)time.ElapsedGameTime.TotalSeconds;

        // Move the player around
        if (this.Controls.left())
        {
            this.Position.X -= this.Speed * delta;
            this.Texture = this.Textures[3];
        }
        if (this.Controls.right())
        {
            this.Position.X += this.Speed * delta;
            this.Texture = this.Textures[2];
        }
        if (this.Controls.up())
        {
            this.Position.Y -= this.Speed * delta;
            this.Texture = this.Textures[1];
        }
        if (this.Controls.down())
        {
            this.Position.Y += this.Speed * delta;
            this.Texture = this.Textures[0];
        }

        // Decrease timer of next bomb placement
        if (this.NextBombTime > 0)
        {
            this.NextBombTime -= delta;
        }

        if (this.NextBombTime <= 0 && this.Controls.bomb())
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