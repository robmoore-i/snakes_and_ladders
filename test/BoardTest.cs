using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class BoardTest {
        [Test]
        public void AddsCurrentPositionAndDiceRollTogether() {
            MockConsole mockConsole = MockConsole.Empty();
            Board board = new Board(mockConsole, 100);

            Assert.AreEqual(6, board.CalculateNewPosition(1, 5));
            mockConsole.AssertTextWasPrinted("You hop along to square 6");
        }

        [Test]
        public void IfItHitsALadderItGoesUpIt() {
            MockConsole mockConsole = MockConsole.Empty();
            Board board = new Board(mockConsole, 100, new Ladder(6, 12));

            Assert.AreEqual(12, board.CalculateNewPosition(1, 5));
            mockConsole.AssertTextWasPrinted("You climb up a ladder and ascend to square 12");
        }
        
        [Test]
        public void IfItHitsASnakeItGoesDownIt() {
            MockConsole mockConsole = MockConsole.Empty();
            Board board = new Board(mockConsole, 100, new Snake(6, 3));

            Assert.AreEqual(3, board.CalculateNewPosition(2, 4));
            mockConsole.AssertTextWasPrinted("You slide down a snake and plummet to square 3");
        }

        [Test]
        public void IfPlayerGetsToTheEndThenTheyWin() {
            Board board = new Board(MockConsole.Empty(), 100);

            Assert.True(board.HasWon(100));
        }
    }
}