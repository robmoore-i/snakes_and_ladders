using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class GameTest {
        [Test]
        public void ItGetsTheNumberOfPlayers() {
            List<Player> players = new List<Player>(new[] {new Player("Manoj"), new Player("Ryan")});
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { }));
            Game game = new Game(mockPrinter, players);
            Assert.AreEqual(2, game.numberOfPlayers);
        }
        
        [Test]
        public void ItGetsThePlayerNames() {
            List<Player> players = new List<Player>(new[] {new Player("Manoj"), new Player("Ryan")});
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { }));
            Game game = new Game(mockPrinter, players);
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan"}), game.PlayerNames());
        }

        [Test]
        public void ItAsksTheFirstPlayerToRollTheDice() {
            List<Player> players = new List<Player>(new[] {new Player("Manoj"), new Player("Ryan")});
            MockPrinter mockPrinter = new MockPrinter(new List<string>(new string[] { }));
            Game game = new Game(mockPrinter, players);
            game.Start();
            mockPrinter.AssertTextWasPrinted("Manoj, press enter to roll the dice.");
        }
    }
}