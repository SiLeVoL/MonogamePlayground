using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_playground.Controls {
    public class Textfield : Component {
        private SpriteFont _font;
        private Vector2 _position;
        private int _fontSize = 1;
        
        public Color PenColor { get; set; }
        
        public Vector2 Position {
            get => _position;
            set => _position = value;
        }
        
        public int FontSize {
            get => _fontSize;
            set => _fontSize = value;
        }

        public string Text { get; set; }

        public Textfield(SpriteFont font) {
            _font = font;
            PenColor = Color.White;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!string.IsNullOrEmpty(Text)) {
                var x = Position.X - (_font.MeasureString(Text).X / 2 * FontSize);
                var y = Position.Y - (_font.MeasureString(Text).Y / 2 * FontSize);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor, 0f, Vector2.Zero,
                    Vector2.One * FontSize, SpriteEffects.None, 0f);
            }
        }

        public void Update(GameTime gameTime) {
        }
    }
}