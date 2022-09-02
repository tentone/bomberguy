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
        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();


        this.scene = new Scene(this.GraphicsDevice);



        for (int x = 0; x < 30; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                string fname = (x + y) % 2 == 0 ? "ground_a.png" : "ground_b.png";
                SpriteGameObject floor = new SpriteGameObject();
                floor.Texture = ContentUtils.Loadtexture(this.GraphicsDevice, "./assets/textures/" + fname);
                floor.Position.X = x * 30.0f;
                floor.Position.Y = y * 30.0f;
                this.scene.Add(floor);

            }
        }

        Player a = new Player();
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



