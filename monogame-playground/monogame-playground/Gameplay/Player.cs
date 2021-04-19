using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace monogame_playground.Gameplay {
    
    public class Player : Model {
        private Model _player;
        public Player Instance => this;

        public Player(Model playerModel) {
            _player = playerModel;
        }
    }
}