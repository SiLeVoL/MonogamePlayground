using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace monogame_playground.Gameplay {
    public class Enemy : Game3DObject {
        private float speed = 40f;
        private float speedup = 5f;
        private float startingSpeed = 40f;
        private SoundEffect sound;

        public Enemy(Model model, Vector3 position, SoundEffect s) : base(model, position) {
            sound = s;
        }

        public override void Reset() {
            base.Reset();

            speed = startingSpeed;
            sound.Play();
        }

        public override void Update(GameTime gameTime, List<Game3DObject> entities, GameState gameState) {
            base.Update(gameTime, entities, gameState);
            
            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            _position.Y -= speed * deltaTime;
            _position.X += (entities.Find(x => x.GetType() == typeof(Player)).Position.X - _position.X) * 4f * deltaTime;

            if (_position.Y < -20) {
                speed += speedup;
                
                base.Reset();
                sound.Play();
            }
        }
    }
}