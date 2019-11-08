namespace snakes_and_ladders {
    public class Player : IPlayer {
        private readonly string name;
        private int currentPosition = 1;

        public Player(string name) {
            this.name = name;
        }

        public string Name() {
            return name;
        }

        public void TakeTurn(IConsole console, IBoard board) {
            console.Print(name + ", press enter to roll the dice.");
            currentPosition = board.CalculateNewPosition(1, 1);
        }

        public int CurrentPosition() {
            return currentPosition;
        }
    }
}