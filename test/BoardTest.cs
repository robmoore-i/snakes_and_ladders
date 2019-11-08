using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class BoardTest {
        [Test]
        public void AddsCurrentPositionAndDiceRollTogether() {
            Board board = new Board();

            Assert.AreEqual(6, board.CalculateNewPosition(1, 5));
        }

        [Test]
        public void IfItHitsALadderItGoesUpIt() {
            Board board = new Board(new Ladder(6, 12));

            Assert.AreEqual(12, board.CalculateNewPosition(1, 5));
        }
        
        [Test]
        public void IfItHitsASnakeItGoesDownIt() {
            Board board = new Board(new Snake(6, 3));

            Assert.AreEqual(3, board.CalculateNewPosition(2, 4));
        }
    }
}