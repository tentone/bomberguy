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

        this.Window.AllowUserResizing = true;
        this.Window.AllowAltF4 = true;

        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();


        this.scene = new Scene(this.GraphicsDevice);

        int size = 30;
        float spacing = 30.0f;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                string fname = (x + y) % 2 == 0 ? "ground_a.png" : "ground_b.png";
                SpriteGameObject floor = new SpriteGameObject();
                floor.Texture = ContentUtils.Loadtexture(this.GraphicsDevice, "./assets/textures/" + fname);
                floor.Position.X = x * spacing;
                floor.Position.Y = y * spacing;
                this.scene.Add(floor);

            }
        }

        for (int i = 0; i < size; i++)
        {
            Block t = new Block(false, false);
            t.Position.Y = 0.0f;
            t.Position.X = i * spacing - 1;
            this.scene.Add(t);

            Block b = new Block(false, false);
            b.Position.Y = (size - 1) * spacing;
            b.Position.X = i * spacing;
            this.scene.Add(b);

            Block l = new Block(false, false);
            l.Position.X = 0.0f;
            l.Position.Y = i * spacing;
            this.scene.Add(l);

            Block r = new Block(false, false);
            r.Position.X = (size - 1) * spacing;
            r.Position.Y = i * spacing;
            this.scene.Add(r);
        }


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

        //this.spriteBatch.DrawString(this.font, "BomberGuy", new Vector2(100, 100), Color.White);

        this.spriteBatch.End();

        base.Draw(time);
    }
}



