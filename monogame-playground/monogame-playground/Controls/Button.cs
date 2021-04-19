using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_playground.Controls {
    public class Button : Component {
        #region Fields

        private MouseState _currentMouse;
        private MouseState _previousMouse;
        private SpriteFont _font;
        private bool _isHovering;
        private Texture2D _texture;
        private Vector2 _position;
        private int _buttonSize = 1;

        #endregion

        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColor { get; set; }
        public Vector2 Position {
            get => _position;
            set => _position = new Vector2(value.X, value.Y);
        }

        public int ButtonSize {
            get => _buttonSize;
            set =>_buttonSize = value;
        }

        public Rectangle Rectangle {
            get { return new Rectangle((int) Position.X - _texture.Width * ButtonSize / 2, (int) Position.Y -_texture.Height * ButtonSize / 2, _texture.Width * ButtonSize, _texture.Height * ButtonSize); }
        }

        public string Text { get; set; }

        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font) {
            _texture = texture;
            _font = font;
            PenColor = Color.Black;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            var color = Color.White;

            if (_isHovering) {
                color = Color.LightGray;
            }

            spriteBatch.Draw(_texture, Rectangle, color);

            if (!string.IsNullOrEmpty(Text)) {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X * ButtonSize);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y * ButtonSize);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor, 0f, Vector2.Zero, Vector2.One * 2 * ButtonSize, SpriteEffects.None, 0f);
            }
        }

        public void Update(GameTime gameTime) {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            _isHovering = false;
            
            if (Rectangle.Contains(_currentMouse.Position)) {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released &&
                    _previousMouse.LeftButton == ButtonState.Pressed) {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}