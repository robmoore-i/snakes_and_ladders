using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockBoard : IBoard {
        private readonly int newPosition;
        private int calculateNewPositionCalledWithPosition;
        private int calculateNewPositionCalledWithDiceRoll;

        public MockBoard() : this(1) { }

        public MockBoard(int newPosition) {
            this.newPosition = newPosition;
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
    }
}