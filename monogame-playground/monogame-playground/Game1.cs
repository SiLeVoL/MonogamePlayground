using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using monogame_playground.Controls;

namespace monogame_playground
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameState _state = GameState.MainMenu;
        private Color _backgroundColor = Color.Black;
        private List<Component> _gameComponents;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var playButton = new Button(Content.Load<Texture2D>("Controls/BiggerButton"),
                Content.Load<SpriteFont>("Fonts/Font")) {
                Position = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, 700),
                Text = "Play",
                FontSize = 2
            };

            playButton.Click += PlayButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("Controls/BiggerButton"),
                Content.Load<SpriteFont>("Fonts/Font")) {
                Position = new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2, 800),
                Text = "Quit",
                FontSize = 2
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>() {
                playButton,
                quitButton,
            };
        }

        private void QuitButton_Click(object sender, System.EventArgs e) {
            Exit();
        }

        private void PlayButton_Click(object sender, System.EventArgs e) {
            _state = GameState.Play;
        }

        protected override void Update(GameTime gameTime)
        {
            switch (_state) {
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
            switch (_state) {
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

        private void UpdateMainMenu(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Enter)) {
                _state = GameState.Play;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }
            
            foreach (var component in _gameComponents) {
                component.Update(gameTime);
            }
        }

        private void DrawMainMenu(GameTime gameTime) {
            GraphicsDevice.Clear(_backgroundColor);

            _spriteBatch.Begin();
            
            foreach (var component in _gameComponents) {
                component.Draw(gameTime, _spriteBatch);
            }
            
            _spriteBatch.End();
        }
        
        private void UpdatePause(GameTime gameTime) {
            
        }

        private void DrawPause(GameTime gameTime) {
            
        }
        
        private void UpdatePlay(GameTime gameTime) {
            
        }

        private void DrawPlay(GameTime gameTime) {
            GraphicsDevice.Clear(_backgroundColor);
        }
    }

    enum GameState {
        MainMenu,
        Pause,
        Play
    }
}
