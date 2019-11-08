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

        public bool TakeTurn(IConsole console) {
            console.Print(name + ", press enter to roll the dice.");
            console.Read();
            currentPosition = board.CalculateNewPosition(currentPosition, dice.Roll());
            return board.HasWon(currentPosition);
        }

        public int CurrentPosition() {
            return currentPosition;
        }
    }
}