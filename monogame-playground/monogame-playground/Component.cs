using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_playground {
    public interface Component {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public void Update(GameTime gameTime);
    }
}