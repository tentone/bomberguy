using System;

internal class FieldGenerator
{
    public static void Generate(Scene scene)
    {
        int size = 30;
        float spacing = 30.0f;

        // Ground
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                string fname = (x + y) % 2 == 0 ? "ground_a.png" : "ground_b.png";
                SpriteGameObject floor = new SpriteGameObject();
                floor.Texture = ContentUtils.Loadtexture(scene.GraphicsDevice, "./assets/textures/" + fname);
                floor.Position.X = x * spacing;
                floor.Position.Y = y * spacing;
                scene.Add(floor);

            }
        }

        // Outter walls
        for (int i = 0; i < size; i++)
        {
            Block t = new Block(false, false);
            t.Position.Y = 0.0f;
            t.Position.X = i * spacing - 1;
            scene.Add(t);

            Block b = new Block(false, false);
            b.Position.Y = (size - 1) * spacing;
            b.Position.X = i * spacing;
            scene.Add(b);

            Block l = new Block(false, false);
            l.Position.X = 0.0f;
            l.Position.Y = i * spacing;
            scene.Add(l);

            Block r = new Block(false, false);
            r.Position.X = (size - 1) * spacing;
            r.Position.Y = i * spacing;
            scene.Add(r);
        }

        Random random = new Random();

        // Powerups
        int powerups = 15;
        for (int i = 0; i < powerups; i++) {
            Powerup powerup = new Powerup(PowerupType.FirePower);
            powerup.Position.X = random.Next(size) * spacing;
            powerup.Position.Y = random.Next(size) * spacing;
            scene.Add(powerup);
        }
    }
}