namespace snakes_and_ladders {
    public interface IBoard {
        int CalculateNewPosition(int currentPosition, int diceRoll);

        bool HasWon(int square);
    }
}