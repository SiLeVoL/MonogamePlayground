using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace monogame_playground.Gameplay {
    public class Enemy : Game3DObject {
        SoundEffect sound;

        public Enemy(Model model) : base(model) {
        }

        public Enemy(Model model, Vector3 position,SoundEffect s ) : base(model) {
            _position = position;
            sound = s;
        }
        
        public override void Update(GameTime gameTime, List<Game3DObject> entities, GameState gameState) {
            base.Update(gameTime, entities, gameState);
            
            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            _position.Y -= 40f * deltaTime;
            _position.X += (entities.Find(x => x.GetType() == typeof(Player)).Position.X - _position.X) * 4f * deltaTime;


           

                if (_position.Y < -20) {
                _position = new Vector3(0f, 60, 0f);
                sound.Play();

            }


        }
    }
}