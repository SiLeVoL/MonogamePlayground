﻿using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Audio;



namespace monogame_playground.Gameplay {

    public class Player : Game3DObject {
        private float speed = 20f;
        private float distance = 2;
        private SoundEffect sound;

        public Player(Model model, Vector3 position, SoundEffect s) : base(model, position) {
            sound = s;
        }
        
        public override void Update(GameTime gameTime, List<Game3DObject> entities, GameState gameState) {
            base.Update(gameTime, entities, gameState);
            
            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Movement

            float maxX = 20;
            float maxY = 15;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && maxX >= _position.X) {
                _position.X += speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && -maxX <= _position.X) {
                _position.X -= speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && maxY >= _position.Y) {
                _position.Y += speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && -maxY <= _position.Y ) {
                _position.Y -= speed * deltaTime;
            }

            foreach (Enemy enemy in entities.FindAll(x => x.GetType() == typeof(Enemy))) {
                if (enemy.Position.X + distance > _position.X &&
                    enemy.Position.X - distance < _position.X &&
                    enemy.Position.Y + distance > _position.Y &&
                    enemy.Position.Y - distance < _position.Y) {

                    sound.Play();
                    gameState.State = State.Loose;
                }
            }
        }
    }
}