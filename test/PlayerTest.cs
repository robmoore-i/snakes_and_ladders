using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class PlayerTest {
        [Test]
        public void AsksThePlayerToRollTheDice() {
            Player player = new Player("Manoj");
            MockConsole mockConsole = MockConsole.Empty();
            player.TakeTurn(mockConsole, new MockBoard());
            mockConsole.AssertTextWasPrinted("Manoj, press enter to roll the dice.");
        }

        [Test]
        public void ItUsesTheBoardToCalculateItsNewPosition() {
            MockBoard mockBoard = new MockBoard();
            Player player = new Player("Paul");
            MockConsole mockConsole = MockConsole.Empty();
            player.TakeTurn(mockConsole, mockBoard);
            mockBoard.AssertPositionUpdateCalculated(1);
        }
    }

    public class MockBoard : IBoard {
        private int calculateNewPositionCalledWithPosition;

        public void AssertPositionUpdateCalculated(int expectedPositionArgument) {
            Assert.AreEqual(expectedPositionArgument, calculateNewPositionCalledWithPosition);
        }

        public int CalculateNewPosition(int currentPosition, int diceRoll) {
            calculateNewPositionCalledWithPosition = currentPosition;
            return 1;
        }
    }
}