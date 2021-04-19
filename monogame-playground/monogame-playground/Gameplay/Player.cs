using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;

namespace monogame_playground.Gameplay {
    
    public class Player : ModelObject {
        private ModelObject _player;
        public Player Instance => this;

        public Player(ModelObject playerModel) {
            _player = playerModel;
        }
    }
}