using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_playground.Gameplay {
    
    public class Player : Game3DObject {
        private float speed = .3f;
        private float distance = 2;

        public Player(Model model) : base(model) {
        }
        
        public override void Update(GameTime gameTime, List<Game3DObject> entities) {
            base.Update(gameTime, entities);

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

            foreach (Enemy enemy in entities.FindAll(x => x.GetType() == typeof(Enemy))) {
                if (enemy.Position.X + distance > _position.X &&
                    enemy.Position.X - distance < _position.X &&
                    enemy.Position.Y + distance > _position.Y &&
                    enemy.Position.Y - distance < _position.Y) {
                    // _state = GameState.Pause;
                }
            }
        }
    }
}