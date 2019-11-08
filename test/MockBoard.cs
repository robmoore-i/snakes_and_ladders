using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockBoard : IBoard {
        private readonly int newPosition;
        private readonly bool won;
        private int calculateNewPositionCalledWithPosition;
        private int calculateNewPositionCalledWithDiceRoll;
        private int winCheckedForPosition;

        public MockBoard() : this(1) { }

        public MockBoard(int newPosition) : this(newPosition, false) {
        }

        public MockBoard(int newPosition, bool won) {
            this.newPosition = newPosition;
            this.won = won;
        }

        public void AssertNewPositionCalculatedWithPreviousPosition(int expectedPreviousPosition) {
            Assert.AreEqual(expectedPreviousPosition, calculateNewPositionCalledWithPosition);
        }
        
        public void AssertNewPositionCalculatedWithDiceRoll(int expectedDiceRoll) {
            Assert.AreEqual(expectedDiceRoll, calculateNewPositionCalledWithDiceRoll);
        }

        public int CalculateNewPosition(int currentPosition, int diceRoll) {
            calculateNewPositionCalledWithPosition = currentPosition;
            calculateNewPositionCalledWithDiceRoll = diceRoll;
            return newPosition;
        }

        public bool HasWon(int square) {
            winCheckedForPosition = square;
            return won;
        }

        public void AssertWinCheckedForPosition(int expectedPosition) {
            Assert.AreEqual(expectedPosition, winCheckedForPosition);
        }
    }
}