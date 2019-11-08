using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class MockBoard : IBoard {
        private readonly int newPosition;
        private int calculateNewPositionCalledWithPosition;

        public MockBoard() : this(1) { }

        public MockBoard(int newPosition) {
            this.newPosition = newPosition;
        }

        public void AssertPositionUpdateCalculated(int expectedPositionArgument) {
            Assert.AreEqual(expectedPositionArgument, calculateNewPositionCalledWithPosition);
        }

        public int CalculateNewPosition(int currentPosition, int diceRoll) {
            calculateNewPositionCalledWithPosition = currentPosition;
            return newPosition;
        }
    }
}