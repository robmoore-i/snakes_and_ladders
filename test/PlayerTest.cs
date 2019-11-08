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

        [Test]
        public void StartsOnSquare1() {
            Assert.AreEqual(1, new Player("Mike").CurrentPosition());
        }

        [Test]
        public void SetsPositionUsingTheBoard() {
            Player player = new Player("Mike");
            
            player.TakeTurn(MockConsole.Empty(), new MockBoard(5));
            
            Assert.AreEqual(5, player.CurrentPosition());
        }
    }
}