using Microsoft.Xna.Framework;


/**
 * Camera is used to control the viewport of the game.
 */
internal class Camera
{
    /**
     * Zoom level of the camera.
     */
    public float zoom = 1.0f;

    /**
     * Center of the camera.
     */
    public Vector2 center = new Vector2();

    public Matrix transformationMatrix() {
        Matrix matrix = new Matrix();

        // Apply zoom to the matrix
        matrix.M11 = zoom;
        matrix.M22 = zoom;
        matrix.M33 = zoom;

        // Translation
        matrix.M13 = center.X;
        matrix.M23 = center.Y;

        return matrix;
    }
}
