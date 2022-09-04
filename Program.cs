using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

new GameLoop().Run();

/**
 * Main game class.
 * 
 * Handles all the main logic cycles.
 */
public class GameLoop : Game
{
    private GraphicsDeviceManager graphics;

    private SpriteBatch spriteBatch;

    private SpriteFont font;

    private Scene scene = null;

    private Camera camera = new Camera();

    public GameLoop()
    {
        this.graphics = new GraphicsDeviceManager(this);
        this.graphics.PreferredBackBufferHeight = 900;
        this.graphics.PreferredBackBufferWidth = 900;
        this.graphics.GraphicsProfile = GraphicsProfile.Reach;

        this.Window.AllowUserResizing = true;
        this.Window.AllowAltF4 = true;

        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Fire.LoadTextures(this.GraphicsDevice);
        Bomb.LoadTextures(this.GraphicsDevice);
        Ground.LoadTextures(this.GraphicsDevice);
        Block.LoadTextures(this.GraphicsDevice);
        Player.LoadTextures(this.GraphicsDevice);
        Powerup.LoadTextures(this.GraphicsDevice);

        base.Initialize();

        this.scene = new Scene(this.GraphicsDevice);

        FieldGenerator.Generate(this.scene);

        Player a = new Player();
        a.Position.X = 60.0f;
        a.Position.Y = 60.0f;
        this.scene.Add(a);

        //Player b = new Player();
        //b.Position.X = 100.0f;
        //this.scene.Add(b);

        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

        this.font = ContentUtils.LoadFont(this.GraphicsDevice, "./assets/fonts/PressStart2P.ttf");

    }

    protected override void Update(GameTime time)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            this.Exit();
        }

        base.Update(time);

        this.scene.Update(time);
    }

    protected override void Draw(GameTime time)
    {
        GraphicsDevice.Clear(Color.Black);

        this.spriteBatch.Begin();

        this.scene.Render(time, this.spriteBatch);

        this.spriteBatch.DrawString(this.font, "BomberGuy", new Vector2(10, 10), Color.White, 0.0f, new Vector2(), 0.6f, SpriteEffects.None, 0);

        this.spriteBatch.End();

        base.Draw(time);
    }
}



