using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class PlayerTest {
        [Test]
        public void AsksThePlayerToRollTheDice() {
            Player player = new Player("Manoj", new MockBoard(), new MockDice());
            MockConsole mockConsole = MockConsole.Empty();

            player.TakeTurn(mockConsole);

            mockConsole.AssertTextWasPrinted("\n\n=> Manoj, press enter to roll the dice.");
        }

        [Test]
        public void ItUsesTheBoardToCalculateItsNewPosition() {
            MockBoard mockBoard = new MockBoard();
            Player player = new Player("Manoj", mockBoard, new MockDice());

            player.TakeTurn(MockConsole.Empty());

            mockBoard.AssertNewPositionCalculatedWithPreviousPosition(1);
        }

        [Test]
        public void StartsOnSquare1() {
            Assert.AreEqual(1, new Player("Manoj", new MockBoard(), new MockDice()).CurrentPosition());
        }

        [Test]
        public void SetsPositionUsingTheBoard() {
            Player player = new Player("Manoj", new MockBoard(5), new MockDice());

            player.TakeTurn(MockConsole.Empty());

            Assert.AreEqual(5, player.CurrentPosition());
        }

        [Test]
        public void PassesDiceRollIntoBoard() {
            MockBoard mockBoard = new MockBoard(5);
            Player player = new Player("Manoj", mockBoard, new MockDice(3));

            player.TakeTurn(MockConsole.Empty());

            mockBoard.AssertNewPositionCalculatedWithDiceRoll(3);
        }

        [Test]
        public void PassesCurrentPositionIntoBoard() {
            MockBoard mockBoard = new MockBoard(5);
            Player player = new Player("Manoj", mockBoard, new MockDice());

            player.TakeTurn(MockConsole.Empty());
            player.TakeTurn(MockConsole.Empty());

            mockBoard.AssertNewPositionCalculatedWithPreviousPosition(5);
        }

        [Test]
        public void PromptsUserToPressEnterWhenTakingTurn() {
            Player player = new Player("Sam", new MockBoard(), new MockDice());
            MockConsole mockConsole = MockConsole.Empty();

            player.TakeTurn(mockConsole);

            mockConsole.AssertRead();
        }

        [Test]
        public void ChecksIfTheyHaveWonAfterTheirTurnUsingTheirFinalPosition() {
            MockBoard mockBoard = new MockBoard(5);
            Player player = new Player("Sam", mockBoard, new MockDice());

            player.TakeTurn(MockConsole.Empty());

            mockBoard.AssertWinCheckedForPosition(5);
        }

        [Test]
        public void ReturnsResultOfWinningCheckWhenTakingTurn() {
            MockBoard mockBoard = new MockBoard(5, true);
            Player player = new Player("Sam", mockBoard, new MockDice());

            Assert.True(player.TakeTurn(MockConsole.Empty()));
        }

        [Test]
        public void ItPrintsOutTheDiceRoll() {
            MockConsole mockConsole = MockConsole.Empty();
            MockDice mockDice = new MockDice(2);
            Player player = new Player("Sam", new MockBoard(), mockDice);
            
            player.TakeTurn(mockConsole);
            
            mockConsole.AssertTextWasPrinted("You rolled a 2!");
        }
    }
}