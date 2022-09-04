using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Dynamics.Contacts;

class Player : GameObject
{
    /**
     * Player controlls is used to command the player.
     */
    public PlayerControls Controls = new PlayerKeyboardControls();

    /**
     * Speed at wich the player moves around.
     */
    public float Speed = 400.0f;

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

    /**
     * Textures shared across all object instances.
     */
    public static Texture2D[] Textures = new Texture2D[12];

    public static void LoadTextures(GraphicsDevice graphicsDevice)
    {
        string[] textures = {
            // Up
            "player_01.png", "player_02.png", "player_03.png",
            // Left
            "player_11.png", "player_12.png", "player_13.png",
            // Down
            "player_21.png", "player_22.png", "player_23.png",
            // Right
            "player_31.png", "player_32.png", "player_33.png",
        };

        for (int i = 0; i < textures.Length; i++)
        {
            Player.Textures[i] = ContentUtils.Loadtexture(graphicsDevice, "./assets/textures/player/" + textures[i]);
        }
    }

    public override void Initialize(GraphicsDevice graphicsDevice)
    {
        this.Texture = Player.Textures[6];

        this.Scale = 1.0f;

        this.Body = this.Scene.World.CreateCircle(11.0f, 0.0f, this.Position, BodyType.Dynamic);
        this.Body.Tag = this;
        this.Body.FixedRotation = true;
        this.Body.LinearDamping = 4.0f;
        this.Body.OnCollision += this.OnCollision;
    }

    /**
     * Process collisions withs other objects in the scene.
     */
    public bool OnCollision(Fixture self, Fixture other, Contact contact)
    {
        Body body = other.Body;

        if (body.Tag is Powerup)
        {
            Powerup power = (Powerup)body.Tag;
            power.ApplyPowerup(this);
            power.Destroy();
        }

        if (body.Tag is Fire)
        {
            this.Destroy();
        }

        return true;
    }


    public override void Update(GameTime time)
    {
        base.Update(time);

        float delta = (float)time.ElapsedGameTime.TotalSeconds;

        // Move the player around
        if (this.Controls.left())
        {
            this.Body.ApplyLinearImpulse(new Vector2(-this.Speed * delta, 0));
            this.Texture = Player.Textures[3];
        }
        if (this.Controls.right())
        {
            this.Body.ApplyLinearImpulse(new Vector2(this.Speed * delta, 0));
            this.Texture = Player.Textures[9];
        }
        if (this.Controls.up())
        {
            this.Body.ApplyLinearImpulse(new Vector2(0, -this.Speed * delta));
            this.Texture = Player.Textures[0];
        }
        if (this.Controls.down())
        {
            this.Body.ApplyLinearImpulse(new Vector2(0, this.Speed * delta));
            this.Texture = Player.Textures[6];
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