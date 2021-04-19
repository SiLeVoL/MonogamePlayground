namespace monogame_playground.Gameplay {
    public class GameState {
        public State State { get; set; }
    }

    public enum State
    {
        MainMenu,
        Loose,
        Play
    }
}