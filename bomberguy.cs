using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/**
 * Main game class.
 * 
 * Handles all the main logic cycles.
 */
public class Bomberguy : Game
{
    private GraphicsDeviceManager graphics;

    private SpriteBatch spriteBatch;

    private Texture2D bomb;

    private SpriteFont font;



    public Bomberguy()
    {
        this.graphics = new GraphicsDeviceManager(this);
        this.Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

        this.bomb = ContentUtils.Loadtexture(this.GraphicsDevice, "./assets/textures/bomb.png");

        this.font = ContentUtils.LoadFont(this.GraphicsDevice, "./assets/fonts/PressStart2P.ttf");
    }

    protected override void Update(GameTime time)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
            this.Exit();
        }
        

        // TODO: Add your update logic here

        base.Update(time);
    }

    protected override void Draw(GameTime time)
    {
        GraphicsDevice.Clear(Color.Black);

        spriteBatch.Begin();
        spriteBatch.Draw(bomb, new Rectangle(0, 0, 30, 30), Color.White);
        spriteBatch.DrawString(this.font, "BomberGuy", new Vector2(100, 100), Color.White);

        spriteBatch.End();

        base.Draw(time);
    }
}
