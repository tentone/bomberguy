using Microsoft.Xna.Framework;


/**
 * Camera is used to control the viewport of the game.
 */
class Camera
{
    /**
     * Zoom level of the camera.
     */
    public float Zoom = 1.0f;

    /**
     * Position of the camera.
     */
    public Vector2 Position = new Vector2();

    /**
     * Get the transformation matrix of the camera.
     */
    public Matrix transformationMatrix()
    {
        Matrix matrix = new Matrix();

        // Apply zoom to the matrix
        matrix.M11 = Zoom;
        matrix.M22 = Zoom;
        matrix.M33 = Zoom;

        // Translation
        matrix.M13 = Position.X;
        matrix.M23 = Position.Y;

        return matrix;
    }
}
