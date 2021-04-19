using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_playground.Gameplay {
    
    public class Player : Game3DObject {
        private float speed = .3f;

        public Player(Model model) : base(model) {
        }
        
        public override void Update(GameTime gameTime) {
            base.Update(gameTime);

            // Movement
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                _position.X += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) {
                _position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) {
                _position.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
                _position.Y -= speed;
            }
        }
    }
}