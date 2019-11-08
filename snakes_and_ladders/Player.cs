namespace snakes_and_ladders {
    public class Player : IPlayer {
        private readonly string name;
        private readonly IBoard board;
        private int currentPosition = 1;

        public Player(string name, IBoard board) {
            this.name = name;
            this.board = board;
        }

        public string Name() {
            return name;
        }

        public void TakeTurn(IConsole console) {
            console.Print(name + ", press enter to roll the dice.");
            currentPosition = board.CalculateNewPosition(1, 1);
        }

        public int CurrentPosition() {
            return currentPosition;
        }
    }
}