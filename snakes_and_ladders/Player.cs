namespace snakes_and_ladders {
    public class Player : IPlayer {
        private readonly string name;
        private readonly IBoard board;
        private readonly IDice dice;
        private int currentPosition = 1;

        public Player(string name, IBoard board, IDice dice) {
            this.name = name;
            this.board = board;
            this.dice = dice;
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