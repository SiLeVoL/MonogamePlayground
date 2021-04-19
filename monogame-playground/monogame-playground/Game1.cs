﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame_playground.Controls;
using monogame_playground.Gameplay;

namespace monogame_playground
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState _state = GameState.MainMenu;
        private Color _backgroundColor = Color.Black;
        private List<Component> _gameComponents;
        private List<Game3DObject> _game3DModels;

        //Player
        private Player _player;
        
        //Camera
        private Camera _camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            //Setup Camera
            _camera = new Camera(new Vector3(0f, 0f, 0f), new Vector3(0f, -30, -20), _graphics);
            // _worldMatrix = Matrix.CreateWorld(new Vector3(0f, 0f, 0f), Vector3.Forward, Vector3.Up);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var playButton = new Button(Content.Load<Texture2D>("Controls/BiggerButton"),
                Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 2),
                Text = "Play",
                FontSize = 2
            };

            playButton.Click += PlayButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("Controls/BiggerButton"),
                Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, _graphics.GraphicsDevice.Viewport.Height / 1.5f),
                Text = "Quit",
                FontSize = 2
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>() {
                playButton,
                quitButton,
            };
            
            // 3D Models
            _player = new Player(Content.Load<Model>("Models/sphere"));
            Enemy obstacle = new Enemy(Content.Load<Model>("Models/Cube"), new Vector3(0f, 40f, 0f));

            _game3DModels = new List<Game3DObject>() {
                _player,
                obstacle
            };
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void PlayButton_Click(object sender, System.EventArgs e)
        {
            _state = GameState.Play;
        }

        protected override void Update(GameTime gameTime)
        {
            switch (_state)
            {
                case GameState.MainMenu:
                    UpdateMainMenu(gameTime);
                    break;
                case GameState.Pause:
                    UpdatePause(gameTime);
                    break;
                case GameState.Play:
                    UpdatePlay(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            switch (_state)
            {
                case GameState.MainMenu:
                    DrawMainMenu(gameTime);
                    break;
                case GameState.Pause:
                    DrawPause(gameTime);
                    break;
                case GameState.Play:
                    DrawPlay(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }

        private void UpdateMainMenu(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _state = GameState.Play;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var component in _gameComponents)
            {
                component.Update(gameTime);
            }
        }

        private void DrawMainMenu(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColor);

            _spriteBatch.Begin();

            foreach (var component in _gameComponents)
            {
                component.Draw(gameTime, _spriteBatch);
            }

            _spriteBatch.End();
        }

        private void UpdatePause(GameTime gameTime)
        {

        }

        private void DrawPause(GameTime gameTime)
        {

        }

        private void UpdatePlay(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }
            
            //update Models
            foreach (var model in _game3DModels) {
                model.Update(gameTime);
            }

            base.Update(gameTime);
        }

        private void DrawPlay(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            //draw Models
            foreach (var model in _game3DModels) {
                model.Draw(gameTime, _camera);
            }
            
            base.Draw(gameTime);
        }
    }

    enum GameState
    {
        MainMenu,
        Pause,
        Play
    }
}
