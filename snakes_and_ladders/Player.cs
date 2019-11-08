namespace snakes_and_ladders {
    public class Player : IPlayer {
        private readonly string name;

        public Player(string name) {
            this.name = name;
        }

        public string Name() {
            return name;
        }
    }
}