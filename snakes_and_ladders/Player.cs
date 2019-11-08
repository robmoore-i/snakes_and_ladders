namespace snakes_and_ladders {
    public class Player : IPlayer {
        private readonly string name;

        public Player(string name) {
            this.name = name;
        }

        public string Name() {
            return name;
        }

        public void TakeTurn(IConsole console, IBoard board) {
            console.Print(name + ", press enter to roll the dice.");
            board.CalculateNewPosition(1, 1);
        }
    }
}