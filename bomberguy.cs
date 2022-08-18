using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpriteFontPlus;
using System.IO;

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

        FileStream fileStream = new FileStream("./assets/textures/bomb.png", FileMode.Open);
        this.bomb = Texture2D.FromStream(this.GraphicsDevice, fileStream);
        fileStream.Dispose();

        this.font = TtfFontBaker.Bake(File.ReadAllBytes("./assets/fonts/PressStart2P.ttf"), 20, 1024, 1024, new[]
            {
                CharacterRange.BasicLatin,
                CharacterRange.Latin1Supplement,
                CharacterRange.LatinExtendedA,
                CharacterRange.Cyrillic
            }
        ).CreateSpriteFont(GraphicsDevice);

        // TODO: use this.Content to load your game content here
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
