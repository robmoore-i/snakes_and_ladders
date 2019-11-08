using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class PlayerTest {
        [Test]
        public void AsksThePlayerToRollTheDice() {
            Player player = new Player("Manoj", new MockBoard());
            MockConsole mockConsole = MockConsole.Empty();

            player.TakeTurn(mockConsole);

            mockConsole.AssertTextWasPrinted("Manoj, press enter to roll the dice.");
        }

        [Test]
        public void ItUsesTheBoardToCalculateItsNewPosition() {
            MockBoard mockBoard = new MockBoard();
            Player player = new Player("Manoj", mockBoard);

            player.TakeTurn(MockConsole.Empty());

            mockBoard.AssertPositionUpdateCalculated(1);
        }

        [Test]
        public void StartsOnSquare1() {
            Assert.AreEqual(1, new Player("Manoj", new MockBoard()).CurrentPosition());
        }

        [Test]
        public void SetsPositionUsingTheBoard() {
            Player player = new Player("Manoj", new MockBoard(5));

            player.TakeTurn(MockConsole.Empty());

            Assert.AreEqual(5, player.CurrentPosition());
        }
    }
}