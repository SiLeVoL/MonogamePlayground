﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_playground.Gameplay {
    public class Enemy : Game3DObject {

        public Enemy(Model model) : base(model) {
        }

        public Enemy(Model model, Vector3 position) : base(model) {
            _position = position;
        }
        
        public override void Update(GameTime gameTime, List<Game3DObject> entities, GameState gameState) {
            base.Update(gameTime, entities, gameState);

            _position.Y -= .5f;
            _position.X += (entities.Find(x => x.GetType() == typeof(Player)).Position.X - _position.X) * 0.05f;

            if (_position.Y < -20) {
                _position = new Vector3(0f, 40, 0f);
            }
        }
    }
}