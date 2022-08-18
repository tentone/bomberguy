using Microsoft.Xna.Framework;


/**
 * Camera is used to control the viewport of the game.
 */
internal class Camera
{
    /**
     * Zoom level of the camera.
     */
    public float zoom;

    /**
     * Center of the camera.
     */
    public Vector2 center;

    public Matrix transformationMatrix() {
        // TODO <ADD CODE HERE>

        return new Matrix();
    }
}
