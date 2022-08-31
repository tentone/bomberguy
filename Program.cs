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

    private Texture2D bomb;

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

        this.scene.Add(new Player());

        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

        this.bomb = ContentUtils.Loadtexture(this.GraphicsDevice, "./assets/textures/bomb.png");

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

        //this.spriteBatch.Draw(bomb, new Rectangle(0, 0, 30, 30), Color.White);
        //this.spriteBatch.DrawString(this.font, "BomberGuy", new Vector2(100, 100), Color.White);

        this.spriteBatch.End();

        base.Draw(time);
    }
}



