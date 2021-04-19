using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using monogame_playground.Gameplay;


namespace monogame_playground {
    public class Game3DObject {
        protected Model _model;
        protected Vector3 _position = new Vector3(0f, 0f, 0f);
        public Vector3 Position => _position;

        public Game3DObject(Model model) {
            _model = model;
        }

        public virtual void Update(GameTime gameTime, List<Game3DObject> entities, GameState gameState) {
            
        }
        
        public virtual void Draw(GameTime gameTime, Camera camera) {
            DrawModel(_model, Matrix.CreateTranslation(_position), camera.ViewMatrix, camera.ProjectionMatrix);
        }
        
        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}