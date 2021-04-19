using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace monogame_playground.Gameplay {
    public class Camera {
        public Vector3 CamTarget { get; set; }
        public Vector3 CamPosition { get; set; }
        public Matrix ProjectionMatrix { get; }
        public Matrix ViewMatrix { get; }

        public Camera(Vector3 camTarget, Vector3 camPosition, GraphicsDeviceManager graphics) {
            CamTarget = camTarget;
            CamPosition = camPosition;

            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio,
                1f, 1000f);
                
            ViewMatrix = Matrix.CreateLookAt(camPosition, camTarget,
                                     new Vector3(0f, 1f, 0f));// Y up
        }
    }
}