using System.Collections.Generic;
using NUnit.Framework;
using snakes_and_ladders;

namespace test {
    public class GameTest {
        [Test]
        public void ItGetsTheNumberOfPlayers() {
            List<IPlayer> players = new List<IPlayer>(new[] {new Player("Manoj"), new Player("Ryan")});
            Game game = new Game(EmptyMockConsole(), players);
            Assert.AreEqual(2, game.numberOfPlayers);
        }

        [Test]
        public void ItGetsThePlayerNames() {
            List<IPlayer> players = new List<IPlayer>(new[] {new Player("Manoj"), new Player("Ryan")});
            Game game = new Game(EmptyMockConsole(), players);
            CollectionAssert.AreEqual(new List<string>(new[] {"Manoj", "Ryan"}), game.PlayerNames());
        }

        [Test]
        public void TheFirstPlayerTakesTheirTurn() {
            MockPlayer mockPlayer = new MockPlayer();
            List<IPlayer> players = new List<IPlayer>(new IPlayer[] {mockPlayer, new Player("Ryan")});
            Game game = new Game(EmptyMockConsole(), players);
            game.Start();
            mockPlayer.AssertTurnTaken();
        }

        private static MockConsole EmptyMockConsole() {
            return new MockConsole(new List<string>(new string[] { }));
        }
    }
}