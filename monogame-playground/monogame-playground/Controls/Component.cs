using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_playground.Controls {
    public interface Component {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void Update(GameTime gameTime);
    }
}