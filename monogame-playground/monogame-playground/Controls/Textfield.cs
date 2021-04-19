using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_playground.Controls {
    public class Textfield : Component {
        private SpriteFont _font;
        private Vector2 _position;
        private float _fontSize = 1;
        
        public Color PenColor { get; set; }
        
        public Vector2 Position {
            get => _position;
            set => _position = new Vector2(value.X - Rectangle.Width / 2, value.Y - Rectangle.Height / 2);
        }
        
        public float FontSize {
            get => _fontSize;
            set => _fontSize = value;
        }

        public Rectangle Rectangle {
            get { return new Rectangle((int) Position.X, (int) Position.Y, (int) _font.MeasureString(Text).X + 2, _font.Texture.Height); }
        }

        public string Text { get; set; }

        public Textfield(SpriteFont font) {
            _font = font;
            PenColor = Color.White;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!string.IsNullOrEmpty(Text)) {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2 * FontSize);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2 * FontSize);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor, 0f, Vector2.Zero,
                    Vector2.One * FontSize, SpriteEffects.None, 0f);
            }
        }

        public void Update(GameTime gameTime) {
        }
    }
}